using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using Microsoft.VisualBasic;


namespace RestaurantApp
{
    public partial class Form1 : Form
    {
        // ─────────────────────────────────────────────────────────────────────────
        //  Class‐level variables
        // ─────────────────────────────────────────────────────────────────────────
        private DataTable orderTable;         // holds current order’s items
        private decimal runningTotal = 0m;    // sum of all LineTotal values

        public Form1()
        {
            InitializeComponent();
        }

        // ─────────────────────────────────────────────────────────────────────────
        //  Step 4F: Form1_Load
        //  Called when the form first appears
        // ─────────────────────────────────────────────────────────────────────────
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeOrderTable();    // 4C: set up an empty DataTable for gridOrderItems
            LoadMenuItems();           // 4D: fetch all menu_items into cmbMenuItems
            UpdateTotalLabel();        // 4E: show “0.00” in lblTotal
        }

        // ─────────────────────────────────────────────────────────────────────────
        //  4C) InitializeOrderTable()
        //  Creates a DataTable schema & binds it to gridOrderItems
        // ─────────────────────────────────────────────────────────────────────────
        private void InitializeOrderTable()
        {
            // 1) Create a new DataTable with columns: MenuItemID, ItemName, Quantity, UnitPrice, LineTotal
            orderTable = new DataTable();
            orderTable.Columns.Add("MenuItemID", typeof(int));
            orderTable.Columns.Add("ItemName", typeof(string));
            orderTable.Columns.Add("Quantity", typeof(int));
            orderTable.Columns.Add("UnitPrice", typeof(decimal));
            orderTable.Columns.Add("LineTotal", typeof(decimal));

            // 2) Bind this DataTable to the DataGridView
            gridOrderItems.DataSource = orderTable;

            // 3) Hide the MenuItemID column (users don’t need to see the numeric ID)
            gridOrderItems.Columns["MenuItemID"].Visible = false;

            // 4) Make other columns read‐only so users can’t accidentally edit them
            gridOrderItems.Columns["ItemName"].ReadOnly = true;
            gridOrderItems.Columns["UnitPrice"].ReadOnly = true;
            gridOrderItems.Columns["LineTotal"].ReadOnly = true;
            gridOrderItems.Columns["Quantity"].ReadOnly = true;
        }

        // ─────────────────────────────────────────────────────────────────────────
        //  4D) LoadMenuItems()
        //  Fetches (id, name, price) from menu_items and binds to cmbMenuItems
        // ─────────────────────────────────────────────────────────────────────────
        private void LoadMenuItems()
        {
            // 1) Read connection string named "RestaurantDb" from App.config
            string connStr = ConfigurationManager
                                .ConnectionStrings["RestaurantDb"]
                                .ConnectionString;

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // 2) Select id, name, price from the menu_items table
                string query = "SELECT id, name, price FROM menu_items";
                var cmd = new MySqlCommand(query, conn);
                var adapter = new MySqlDataAdapter(cmd);
                var menuTable = new DataTable();
                adapter.Fill(menuTable);

                // 3) Bind to ComboBox: DisplayMember = “name”, ValueMember = “id”
                cmbMenuItems.DataSource = menuTable;
                cmbMenuItems.DisplayMember = "name";
                cmbMenuItems.ValueMember = "id";
            }
        }

        // ─────────────────────────────────────────────────────────────────────────
        //  4E) UpdateTotalLabel()
        //  Formats and shows the runningTotal in lblTotal
        // ─────────────────────────────────────────────────────────────────────────
        private void UpdateTotalLabel()
        {
            lblTotal.Text = runningTotal.ToString("0.00");
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // 1) Ensure the user selected a menu item
            if (cmbMenuItems.SelectedItem == null)
            {
                MessageBox.Show("Please select a menu item first.", "Info");
                return;
            }

            // 2) Get the selected item's data
            var drv = (DataRowView)cmbMenuItems.SelectedItem;
            int menuItemId = Convert.ToInt32(drv["id"]);
            string itemName = drv["name"].ToString();
            decimal unitPrice = Convert.ToDecimal(drv["price"]);

            // 3) Read the desired quantity
            int qty = (int)numQuantity.Value;

            // 4) Compute line total (price * quantity)
            decimal lineTotal = unitPrice * qty;

            // 5) Add a new row into the DataTable (orderTable)
            orderTable.Rows.Add(menuItemId, itemName, qty, unitPrice, lineTotal);

            // 6) Update the running total and label
            runningTotal += lineTotal;
            UpdateTotalLabel();
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            // 1) Ensure there’s at least one item in the order
            if (orderTable.Rows.Count == 0)
            {
                MessageBox.Show("Add at least one item before submitting.", "Info");
                return;
            }

            // 2) Prompt for Table Number using a simple InputBox
            int tableNumber;
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                               "Enter table number:",
                               "Table Number",
                               "1");
            if (!int.TryParse(input, out tableNumber) || tableNumber <= 0)
            {
                MessageBox.Show("Invalid table number.", "Error");
                return;
            }

            // 3) Read connection string from App.config
            string connStr = ConfigurationManager
                                .ConnectionStrings["RestaurantDb"]
                                .ConnectionString;

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // 4) Insert into orders (table_number, total_amount)
                string insertOrderSql =
                    "INSERT INTO orders (table_number, total_amount) " +
                    "VALUES (@table, @total)";
                using (var cmdOrder = new MySqlCommand(insertOrderSql, conn))
                {
                    cmdOrder.Parameters.AddWithValue("@table", tableNumber);
                    cmdOrder.Parameters.AddWithValue("@total", runningTotal);
                    cmdOrder.ExecuteNonQuery();

                    // 5) Retrieve the newly inserted order ID
                    long orderId = cmdOrder.LastInsertedId;

                    // 6) Insert each row from orderTable into order_items
                    foreach (DataRow row in orderTable.Rows)
                    {
                        int menuItemId = Convert.ToInt32(row["MenuItemID"]);
                        int quantity = Convert.ToInt32(row["Quantity"]);
                        decimal lineTotal = Convert.ToDecimal(row["LineTotal"]);

                        string insertItemSql =
                            "INSERT INTO order_items " +
                            "(order_id, menu_item_id, quantity, line_total) " +
                            "VALUES (@oid, @mid, @qty, @lt)";
                        using (var cmdItem = new MySqlCommand(insertItemSql, conn))
                        {
                            cmdItem.Parameters.AddWithValue("@oid", orderId);
                            cmdItem.Parameters.AddWithValue("@mid", menuItemId);
                            cmdItem.Parameters.AddWithValue("@qty", quantity);
                            cmdItem.Parameters.AddWithValue("@lt", lineTotal);
                            cmdItem.ExecuteNonQuery();
                        }
                    }
                }
            }

            // 7) Notify user and clear the current order
            MessageBox.Show("Order submitted successfully!", "Success");
            orderTable.Rows.Clear();
            runningTotal = 0m;
            UpdateTotalLabel();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            // 1) Ask for confirmation
            var result = MessageBox.Show(
                "Are you sure you want to clear the current order?",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2) Clear all rows from orderTable
                orderTable.Rows.Clear();

                // 3) Reset the running total
                runningTotal = 0m;

                // 4) Update the Total label
                UpdateTotalLabel();
            }
        }

    }
}


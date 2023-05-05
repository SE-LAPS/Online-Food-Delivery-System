using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;

namespace order_management_system
{
    public partial class Form1 : MaterialForm
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.fdloginDBConnectionString);
        SqlDataAdapter da;
        //SqlDataReader dr;
        SqlCommand cmd;
        Queue queue = new Queue();

        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepOrange800, Primary.DeepOrange900, Primary.DeepOrange500, Accent.DeepOrange200, TextShade.WHITE);
        }

        /// <summary>
        /// Clicking the ;Add order' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu_Click(object sender, EventArgs e)
        {
            tabcontMenu.SelectedTab = tabMenu;
        }

        /// <summary>
        /// Clicking the 'View order list' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueue_Click(object sender, EventArgs e)
        {
            tabcontMenu.SelectedTab = tabQueue;
        }

        /// <summary>
        /// Clicking the 'View orders history button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            tabcontMenu.SelectedTab = tabHistory;
        }

        /// <summary>
        /// Clicking the theme toggle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbThemeToggle_Click(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            if (ptbThemeToggle.Image == Properties.Resources.darktoggle)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                ptbThemeToggle.Image = Properties.Resources.lighttoggle;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                ptbThemeToggle.Image = Properties.Resources.darktoggle;
            }
        }

        // this was supposed to be the theme toggle button.
        //private void btnThemeToggle_Click(object sender, EventArgs e)
        //{
        //    var materialSkinManager = MaterialSkinManager.Instance;
        //    if (btnThemeToggle.Text == "LIGHT MODE")
        //    {
        //        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        //        btnThemeToggle.BackColor = Color.OrangeRed;
        //        btnThemeToggle.Text = "DARK MODE";
        //    }
        //    else
        //    {
        //        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        //        btnThemeToggle.Text = "LIGHT MODE";
        //    }
        //}

        /// <summary>
        /// Clicking the add button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      /*  private void btnAdd_Click(object sender, EventArgs e)
        {
            if (chkbBurger.Checked)
            {
                lstbOrders.Items.Add("Big Burger                     P50.00");
            }
            if (chkbChicken.Checked)
            {
                lstbOrders.Items.Add("Cool Chicken                P80.00");
            }
            if (chkbPizza.Checked)
            {
                lstbOrders.Items.Add("Pretty Pizza                  P100.00");
            }
            if (chkbFries.Checked)
            {
                lstbOrders.Items.Add("Fancy Fries                   P90.00");
            }
            if (chkbCoffee.Checked)
            {
                lstbOrders.Items.Add("Calming Coffee           P60.00");
            }
            if (chkbCoke.Checked)
            {
                lstbOrders.Items.Add("Cold Coke                      P30.00");
            }

            lblCustomersName.Text = $"Customer's Name: {tbCustomersName.Text}";
            lblTotalItem.Text = $"Total Item: {lstbOrders.Items.Count}";

            // below still doesn't funtion. needs to debug.
            int price = 0;
            switch (lstbOrders.Items.ToString())
            {
                case "Big Burger                     P50.00":
                    price = 50;
                    break;
                case "Cool Chicken                P80.00":
                    price = 80;
                    break;
                case "Pretty Pizza                  P100.00":
                    price = 100;
                    break;
                case "Fancy Fries                   P90.00":
                    price = 90;
                    break;
                case "Calming Coffee           P60.00":
                    price = 60;
                    break;
                case "Cold Coke                      P30.00":
                    price = 30;
                    break;
            }
         
            int totalPrice = 0;
            totalPrice += price;
            lblTotalPrice.Text = $"Total Price: {totalPrice}";
            
        } */

        private int totalPrice = 0;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (chkbBurger.Checked)
            {
                lstbOrders.Items.Add("Pizza                      Rs.2500.00");
                totalPrice += 2500;
            }
            if (chkbChicken.Checked)
            {
                lstbOrders.Items.Add("Burger                   Rs.1800.00");
                totalPrice += 1800;
            }
            if (chkbPizza.Checked)
            {
                lstbOrders.Items.Add("Sushi                      Rs.2200.00");
                totalPrice += 2200;
            }
            if (chkbFries.Checked)
            {
                lstbOrders.Items.Add("Pasta                     Rs.1500.00");
                totalPrice += 1500;
            }
            if (chkbCoffee.Checked)
            {
                lstbOrders.Items.Add("Salads                   Rs.1200.00");
                totalPrice += 1200;
            }
            if (chkbCoke.Checked)
            {
                lstbOrders.Items.Add("Tocos                     Rs.2000.00");
                totalPrice += 2000;
            }

            lblCustomersName.Text = $"Customer's Name: {tbCustomersName.Text}";
            lblTotalItem.Text = $"Total Item: {lstbOrders.Items.Count}";
            lblTotalPrice.Text = $"Total Price: {totalPrice}";
        }


        /// <summary>
        /// Clicking the remove button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            lstbOrders.Items.Remove(lstbOrders.SelectedItem);
        }

        /// <summary>
        /// Clicking the Clear button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbCustomersName.ResetText();
            lstbOrders.Items.Clear();
            lblCustomersName.Text = "Customer's Name: ";
            lblTotalItem.Text = "Total Item: ";
            lblTotalPrice.Text = "Total Price: ";
            chkbBurger.Checked = false;
            chkbChicken.Checked = false;
            chkbPizza.Checked = false;
            chkbFries.Checked = false;
            chkbCoffee.Checked = false;
            chkbCoke.Checked = false;
            totalPrice = 0; // reset totalPrice
        }

        /// <summary>
        /// Clicking the 'Send order' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            var order = DateTime.Now + "\t\t" + tbCustomersName.Text + "\t\t\t\t\t" + lstbOrders.Items.Count + "\t\t" + totalPrice;
            lstbQueue.Items.Add(order);
            queue.Enqueue(order);
        }

        /// <summary>
        /// Clicking the 'Remove top order' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveTopOrder_Click(object sender, EventArgs e)
        {
            try
            {
                lstbHistory.Items.Add(queue.Dequeue());
                lstbQueue.Items.RemoveAt(0);
            }
            catch
            {
                MessageBox.Show("Queue empty");
            }
        }

        /// <summary>
        /// Clicking the 'Show first order' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowFirstOrder_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"First order: {queue.Peek()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Clicking the 'Count all orders' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCountAllOrders_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Queue count: {queue.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Clicking the 'Clear all orders' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearAllOrders_Click(object sender, EventArgs e)
        {
            foreach (var item in lstbQueue.Items)
            {
                lstbHistory.Items.Add(item);
            }
            lstbQueue.Items.Clear();
            queue.Clear();
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            lstbHistory.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveSelectedOrder_Click(object sender, EventArgs e)
        {
            // lstbQueue.Items.Remove(lstbQueue.SelectedItem);

            if (lstbQueue.SelectedItem != null)
            {
                lstbHistory.Items.Add(lstbQueue.SelectedItem);
                lstbQueue.Items.Remove(lstbQueue.SelectedItem);
            }

        }

        private void lstbHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT * FROM tbllog WHERE Username=@Username AND Password=@Password", con);
            cmd.Parameters.AddWithValue("@Username", txtname.Text);
            cmd.Parameters.AddWithValue("@Password", txtpwd.Text);

            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i == 1)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr[2].ToString() == "2023")
                {
                    ulog.type = "A";
                }
                else if (dr[2].ToString() == "2022")
                {
                    ulog.type = "C";
                }

                tabcontMenu.SelectedTab = tabHome;
            }

            else
            {
                MessageBox.Show("Please Check Your User-Name Or Password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        /*private void buttonClr_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtpwd.Clear();
        }*/

        private void materialButton1_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtpwd.Clear();
        }

        private void tabHome_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ulog.type))
            {
                if (ulog.type == "A")
                {
                    tabHome.Visible = true;
                    tabMenu.Visible = true;
                    tabQueue.Visible = true;
                    tabHistory.Visible = true;
                    tabContact.Visible = true;
                    tabLogout.Visible = true;
                }
                else if (ulog.type == "C")
                {
                    tabHome.Visible = true;
                    tabMenu.Visible = true;
                    tabQueue.Visible = false;
                    tabHistory.Visible = false;
                    tabContact.Visible = true;
                    tabLogout.Visible = true;
                }
            }
        }

        private void tabLogin_Click(object sender, EventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"H:\\Online Food Ordering System\\New folder (4)\\food-order-management-system\\fdcontactDB.mdf\";Integrated Security=True"; 
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            command.CommandText = "INSERT INTO tblcon (Name, E_mail, Address, Con_num, Msg) VALUES (@Name, @E_mail, @Address, @Con_num, @Msg)";

            // using (SqlCommand command = new SqlCommand(sql, connection))
            // {
            command.Parameters.AddWithValue("@Name", txtname.Text);
            command.Parameters.AddWithValue("@E_mail", txt_Mail.Text);
            command.Parameters.AddWithValue("@Address", txt_Add.Text);
            command.Parameters.AddWithValue("@Con_num", txt_Con.Text);
            command.Parameters.AddWithValue("@Msg", txt_Msg.Text);
            

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();


            txtname.Clear();
            txt_Mail.Clear();
            txt_Add.Clear();
            txt_Con.Clear();
            txt_Msg.Clear();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"H:\\Online Food Ordering System\\New folder (4)\\food-order-management-system\\fdfeedbackDB.mdf\";Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            command.CommandText = "INSERT INTO tblfdbk (Nme, E_mil, Fd_bk) VALUES (@Nme, @E_mil, @Fd_bk)";

            // using (SqlCommand command = new SqlCommand(sql, connection))
            // {
            command.Parameters.AddWithValue("@Nme", txt_nme.Text);
            command.Parameters.AddWithValue("@E_mil", txt_mil.Text);
            command.Parameters.AddWithValue("@Fd_bk", txt_fdbk.Text);
           


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();


            txt_nme.Clear();
            txt_mil.Clear();
            txt_Add.Clear();
            txt_fdbk.Clear();
            
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
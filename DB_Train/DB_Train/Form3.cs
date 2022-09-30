using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Train
{
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection;
        int time_way = 0;
        int price = 0;
        int ID_place;

        DateTime ot = DateTime.Now;
        public Form3()
        {
            InitializeComponent();
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Учеба\Курсач БСБД\DB_Train\DB_Train\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand Stantions = new SqlCommand("SELECT * FROM [Stantions]", sqlConnection);
            SqlCommand Traines = new SqlCommand("SELECT * FROM [Traines]", sqlConnection);

            types.Items.Clear();
            types.Items.Add("Coupe");
            types.Items.Add("Platskart");

            try
            {

                from.Items.Clear();
                to.Items.Clear();
                WorE.Items.Clear();

                WorE.Items.Add("Запад");
                WorE.Items.Add("Восток");

                sqlReader = await Stantions.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    from.Items.Add(sqlReader["Stantion"]);
                    to.Items.Add(sqlReader["Stantion"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            try
            {

                trains.Items.Clear();
                int index = -1;
                sqlReader = await Traines.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    index = trains.FindString(Convert.ToString(sqlReader["N_train"]));
                    if (index == -1)
                        trains.Items.Add(sqlReader["N_train"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            SqlCommand Tickets = new SqlCommand("SELECT * FROM [Tickets]", sqlConnection);

            DateTime dt1 = DateTime.Now;
            DateTime now = DateTime.Now;
            int id_ticket = 0;
            int id_place = 0;
            int ticket_remove = 0;
            try
            {
                sqlReader = await Tickets.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    dt1 = (DateTime)sqlReader["Date"];
                    dt1 = dt1.AddHours((int)sqlReader["time_way"]);
                    id_place = (int)sqlReader["id_place"];
                    if (dt1 <= now)
                    {
                        id_ticket = (int)sqlReader["Id"];
                        ticket_remove = 1;
                        SqlCommand c2 = new SqlCommand("UPDATE [Places] SET [Занято_или_свободно] =@n WHERE [Id]=@Id", sqlConnection);

                        c2.Parameters.AddWithValue("Id", id_place);
                        c2.Parameters.AddWithValue("n", false);
                        await c2.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();

                if (ticket_remove == 1)
                {
                    SqlCommand c = new SqlCommand("DELETE FROM [Tickets] WHERE [Id]=@Id", sqlConnection);
                    c.Parameters.AddWithValue("Id", id_ticket);

                    await c.ExecuteNonQueryAsync();
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label13.Visible)
                label13.Visible = false;
            if (label12.Visible)
                label12.Visible = false;
            SqlDataReader sqlReader = null;

            SqlCommand Traines = new SqlCommand("SELECT * FROM [Traines]", sqlConnection);

            int id_train = 0;
            string str1, str2;
            string str1_1, str2_2;
            try
            {

                sqlReader = await Traines.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    str1 = Convert.ToString(sqlReader["N_train"]);
                    str2 = Convert.ToString(sqlReader["Date"]);
                    str1_1 = trains.Text;
                    str2_2 = dates.Text+":00";
                    if (str1_1 == str1 &&
                        str2_2 == str2)
                        id_train = (int)sqlReader["Id"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            int flag2 = 0;
            int id_place = 0;
            SqlCommand Places = new SqlCommand("SELECT * FROM [Places]", sqlConnection);
            try
            {
                sqlReader = await Places.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (trains.Text == Convert.ToString(sqlReader["N_train"]) &&
                        wagons.Text == Convert.ToString(sqlReader["N_vagon"]) &&
                        types.Text == Convert.ToString(sqlReader["Type"]) &&
                        places.Text == Convert.ToString(sqlReader["N_place"]))
                    {
                        flag2 = 1;
                        id_place = (int)sqlReader["Id"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                    if (flag2 == 1)
                    {
                        SqlCommand c = new SqlCommand("UPDATE [Places] SET [Занято_или_свободно] =@n WHERE [Id]=@Id", sqlConnection);

                        c.Parameters.AddWithValue("Id", id_place);
                        c.Parameters.AddWithValue("n", true);
                        await c.ExecuteNonQueryAsync();
                    }
                }
            }

            SqlCommand Passwords = new SqlCommand("SELECT * FROM [Passwords]", sqlConnection);
            int flag = 0;
            int id_user = 0;
            try
            {
                sqlReader = await Passwords.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if(textBox1.Text == Convert.ToString(sqlReader["Pass"]))
                    {
                        if(price <= (int)sqlReader["Money"])
                        {
                            label13.Visible = true;
                            flag = 1;
                            id_user = (int)sqlReader["Id"];
                        }
                        else
                        {
                            label12.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                    if(flag == 1)
                    {
                        SqlCommand comm = new SqlCommand("INSERT INTO [Tickets] (Name, N_train, N_wagon, N_place, Date, ot, prib, Wagon_type, Price, time_way, id_place, id_train)" +
                       " VALUES(@Name, @N_train, @N_wagon, @N_place, @Date, @ot, @prib, @Wagon_type, @Price, @time_way, @id_place, @id_train)", sqlConnection);

                        comm.Parameters.AddWithValue("Name", FIO.Text);
                        comm.Parameters.AddWithValue("N_train", trains.Text);
                        comm.Parameters.AddWithValue("N_wagon", wagons.Text);
                        comm.Parameters.AddWithValue("N_place", places.Text);
                        comm.Parameters.AddWithValue("Date", ot);
                        comm.Parameters.AddWithValue("ot", from.Text);
                        comm.Parameters.AddWithValue("prib", to.Text);
                        comm.Parameters.AddWithValue("Wagon_type", types.Text);
                        comm.Parameters.AddWithValue("Price", price);
                        comm.Parameters.AddWithValue("time_way", time_way);
                        comm.Parameters.AddWithValue("id_place", id_place);
                        comm.Parameters.AddWithValue("id_train", id_train);
                        await comm.ExecuteNonQueryAsync();

                        SqlCommand c = new SqlCommand("UPDATE [Passwords] SET [Money]=[Money]-" + Convert.ToString(price) +
                       " WHERE [Id]=@Id", sqlConnection);

                        c.Parameters.AddWithValue("Id", id_user);
                        await c.ExecuteNonQueryAsync();
                    }
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;

            SqlCommand Places = new SqlCommand("SELECT * FROM [Places]", sqlConnection);

            try
            {
                wagons.Items.Clear();
                sqlReader = await Places.ExecuteReaderAsync();
                int index = 0;
                while (await sqlReader.ReadAsync())
                {
                    if (index == -1 && trains.Text == Convert.ToString(sqlReader["N_train"])
                        && types.Text == Convert.ToString(sqlReader["Type"]))
                        wagons.Items.Add(sqlReader["N_vagon"]);
                    index = wagons.FindString(Convert.ToString(sqlReader["N_vagon"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if(label14.Visible)
                label14.Visible = false;
            if (label15.Visible)
                label15.Visible = false;
            if (label16.Visible)
                label16.Visible = false;
            
            string time_from = "";
            string time_to = "";

            SqlDataReader sqlReader = null;

            SqlCommand Traines = new SqlCommand("SELECT * FROM [Traines]", sqlConnection);


            var n1 = DateTime.Now;
            time_way = 0;
            price = 0;

            string str1, str2;

            try
            {
                sqlReader = await Traines.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    str1 = Convert.ToString(sqlReader["Date"]);
                    str2 = dates.Text + ":00";
                    if (Convert.ToString(sqlReader["N_train"]) == trains.Text &&
                        str1 == str2)
                    {
                        n1 = (DateTime)sqlReader["Date"];
                        time_from = Convert.ToString(n1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            try
            {
                SqlCommand Stantions = new SqlCommand("SELECT * FROM [Stantions]", sqlConnection);

                int flag = -1;

                int flag2 = -1;
                int j = 0;
                if (WorE.Text == "Запад")
                {
                    sqlReader = await Stantions.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        if (Convert.ToString(sqlReader["Stantion"]) == from.Text)
                        {
                            n1 = n1.AddHours(j);
                            time_from = Convert.ToString(n1);
                            ot = n1;
                            flag = 1;
                            flag2 = 0;
                        }
                        if (Convert.ToString(sqlReader["Stantion"]) == to.Text)
                        {
                            n1 = n1.AddHours(time_way);
                            time_to = Convert.ToString(n1);
                            flag = 0;
                        }
                        if (flag == 1)
                        {
                            price = price + (int)sqlReader["Price"];
                            time_way = time_way + (int)sqlReader["Time"];
                        }
                        if (flag2 == -1)
                        {
                            if ((int)sqlReader["Time"] != 0)
                                j = j + (int)sqlReader["Time"];
                        }
                        //n1 = n1.AddHours((int)sqlReader["Time"]);
                    }

                    label14.Text = time_from;
                    label14.Visible = true;

                    label15.Text = time_to;
                    label15.Visible = true;

                    label16.Text = Convert.ToString(price) + " руб";
                    label16.Visible = true;
                }

                if (WorE.Text == "Восток")
                {
                    sqlReader = await Stantions.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        if (Convert.ToString(sqlReader["Stantion"]) == to.Text)
                        {
                            flag = 1;
                        }
                        if (Convert.ToString(sqlReader["Stantion"]) == from.Text)
                        {
                            flag = 0;
                            flag2 = 1;
                        }
                        if (flag == 1)
                        {
                            price = price + (int)sqlReader["Price"];
                            time_way = time_way + (int)sqlReader["Time"];
                        }
                        if (flag2 == 1)
                        {
                            if ((int)sqlReader["Time"] != 0)
                                j = j + (int)sqlReader["Time"];
                        }
                    }

                    n1 = n1.AddHours(j);
                    time_from = Convert.ToString(n1);
                    ot = n1;
                    n1 = n1.AddHours(time_way);
                    time_to = Convert.ToString(n1);


                    label14.Text = time_from;
                    label14.Visible = true;

                    label15.Text = time_to;
                    label15.Visible = true;

                    label16.Text = Convert.ToString(price) + " руб";
                    label16.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;

            SqlCommand Places = new SqlCommand("SELECT * FROM [Places]", sqlConnection);

            try
            {
                places.Items.Clear();
                sqlReader = await Places.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToString(sqlReader["Занято_или_свободно"]) == "False" &&
                        wagons.Text == Convert.ToString(sqlReader["N_vagon"]) && trains.Text == Convert.ToString(sqlReader["N_train"]))
                    {
                        places.Items.Add(sqlReader["N_place"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            SqlCommand Traines = new SqlCommand("SELECT * FROM [Traines]", sqlConnection);

            try
            {
                dates.Items.Clear();
                sqlReader = await Traines.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (trains.Text == Convert.ToString(sqlReader["N_train"]))
                    {
                        dates.Items.Add(sqlReader["Date"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
    }
}

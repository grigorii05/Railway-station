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
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Учеба\Курсач БСБД\DB_Train\DB_Train\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Tickets]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while(await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add("Номер билета: " + Convert.ToString(sqlReader["Id"]) + " " + Convert.ToString(sqlReader["Name"]) +
                        ", № поезда: " + Convert.ToString(sqlReader["N_train"]) + ", вагон: " + 
                        Convert.ToString(sqlReader["N_wagon"]) + ", место: " + Convert.ToString(sqlReader["N_place"])
                        + ", дата отправления: " + Convert.ToString(sqlReader["Date"]) + ", от: " + Convert.ToString(sqlReader["ot"]) +
                        ", куда: " + Convert.ToString(sqlReader["prib"]) + 
                        " время в пути(в часасх): " + Convert.ToString(sqlReader["time_way"]));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        //-------------------ПОКУПКА БИЛЕТА------------------//
        private async void button1_Click(object sender, EventArgs e)
        {
            
        }

        //------------------ОБНОВЛЕНИЕ ИНФОРМАЦИИ-----------//
        private void button2_Click(object sender, EventArgs e)
        {

        }


        //--------ПРОВЕРКА ВХОДА ПОЛЬЗОВАТЕЛЯ В СИСТЕМУ-----//
        private async void button7_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;

            if (label31.Visible)
                label31.Visible = false;

            SqlCommand Users = new SqlCommand("SELECT * FROM [Users]", sqlConnection);
            Users.Parameters.AddWithValue("login", textBox2.Text);

            int flag = 0;
            int id_pass = 0;
            try
            {
                sqlReader = await Users.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToString(sqlReader["login"]) == textBox2.Text)
                    {
                        flag = 1;
                        id_pass = (int)sqlReader["Id_pass_money"];
                        break;
                    }
                }
                if (flag == 0)
                {
                    label31.Text = "Неверный логин ! Попробуйте снова !";
                    label31.Visible = true;
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

            if (flag != 0)
            {
                int is_acsess = 0;
                SqlCommand pass = new SqlCommand("SELECT * FROM [Passwords]", sqlConnection);
                pass.Parameters.AddWithValue("Pass", textBox1.Text);
                try
                {
                    sqlReader = await pass.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        if ((int)sqlReader["Id"] == id_pass && Convert.ToString(sqlReader["Pass"]) == textBox1.Text)
                        {
                            is_acsess = 1;
                            label31.Text = "Acsess !";
                            label31.Visible = true;
                            Form Form3 = new Form3();
                            Form3.Show();
                            break;
                        }
                    }

                    if (is_acsess == 0)
                    {
                        label31.Text = "Неверный пароль !";
                        label31.Visible = true;
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

        private async void button9_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;

            if (label38.Visible)
                label38.Visible = false;

            SqlCommand Users = new SqlCommand("SELECT * FROM [Users]", sqlConnection);
          
            Users.Parameters.AddWithValue("login", textBox11.Text);

            int flag = 0;
            int id_pass = 0;
            int id_role = 0;
            try
            {
                sqlReader = await Users.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToString(sqlReader["login"]) == textBox11.Text)
                    {
                        flag = 1;
                        id_pass = (int)sqlReader["Id_pass_money"];
                        id_role = (int)sqlReader["Id_role"];
                        break;
                    }
                }
                if (flag == 0)
                {
                    label38.Text = "Неверный логин ! Попробуйте снова !";
                    label38.Visible = true;
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

            if (flag != 0)
            {
                int is_admin = 0;
                SqlCommand roles = new SqlCommand("SELECT * FROM [roles]", sqlConnection);
                try
                {
                    sqlReader = await roles.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        if ((int)sqlReader["Id"] == id_role && Convert.ToString(sqlReader["role"]) == "Admin")
                        {
                            is_admin = 1;
                            break;
                        }
                    }
                     
                    if(is_admin == 0)
                    {
                        label38.Text = "Нет прав администратора !";
                        label38.Visible = true;
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

                if(is_admin == 1)
                {
                    int is_acsess = 0;
                    SqlCommand pass = new SqlCommand("SELECT * FROM [Passwords]", sqlConnection);
                    pass.Parameters.AddWithValue("Pass", textBox12.Text);
                    try
                    {
                        sqlReader = await pass.ExecuteReaderAsync();
                        while (await sqlReader.ReadAsync())
                        {
                            if ((int)sqlReader["Id"] == id_pass && Convert.ToString(sqlReader["Pass"]) == textBox12.Text)
                            {
                                is_acsess = 1;
                                label38.Text = "Acsess !";
                                label38.Visible = true;
                                Form Form2 = new Form2();
                                Form2.Show();
                                break;
                            }
                        }

                        if(is_acsess == 0)
                        {
                            label38.Text = "Неверный пароль !";
                            label38.Visible = true;
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

        private async void button3_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;

            if (label30.Visible)
                label30.Visible = false;

            int ticket_price = -1;
            int Id_of_user = 0;
            int id_place = 0;
            SqlCommand Tickets = new SqlCommand("SELECT * FROM [Tickets]", sqlConnection);
            Tickets.Parameters.AddWithValue("Id", textBox7.Text);

            try
            {
                sqlReader = await Tickets.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToString(sqlReader["Id"]) == textBox7.Text)
                    {
                        ticket_price = (int)sqlReader["Price"];
                        id_place = (int)sqlReader["id_place"];
                        break;
                    }
                }
                if (ticket_price == -1)
                {
                    label30.Text = "Билета с таким номером не существует !";
                    label30.Visible = true;
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

            if (ticket_price != -1)
            {
                SqlCommand Passwords = new SqlCommand("SELECT * FROM [Passwords]", sqlConnection);
                Passwords.Parameters.AddWithValue("Pass", textBox3.Text);
                int flag = 0;
                try
                {
                    sqlReader = await Passwords.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        if (Convert.ToString(sqlReader["Pass"]) == textBox3.Text)
                        {
                            flag = 1;
                            Id_of_user = (int)sqlReader["Id"];
                        }
                    }
                    if (flag == 0)
                    {
                        label30.Text = "Неверный пароль ! Попробуйте снова !";
                        label30.Visible = true;
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
                    if (flag == 1)
                    {
                        SqlCommand c = new SqlCommand("UPDATE [Passwords] SET [Money]=[Money]+" + Convert.ToString(ticket_price)+
                        " WHERE [Id]=@Id", sqlConnection);

                        c.Parameters.AddWithValue("Id", Id_of_user);
                        await c.ExecuteNonQueryAsync();

                        SqlCommand c2 = new SqlCommand("UPDATE [Places] SET [Занято_или_свободно] =@n WHERE [Id]=@Id", sqlConnection);

                        c2.Parameters.AddWithValue("Id", id_place);
                        c2.Parameters.AddWithValue("n", false);
                        await c2.ExecuteNonQueryAsync();

                        SqlCommand command = new SqlCommand("DELETE FROM [Tickets] WHERE [Id]=@Id", sqlConnection);
                        command.Parameters.AddWithValue("Id", textBox7.Text);

                        await command.ExecuteNonQueryAsync();
                        label30.Text = "Билет возвращен !";
                        label30.Visible = true;
                    }
                }
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;

            if (label34.Visible)
                label34.Visible = false;

            if (label3.Visible)
                label3.Visible = false;

            SqlCommand Users = new SqlCommand("SELECT * FROM [Users]", sqlConnection);
            Users.Parameters.AddWithValue("login", textBox9.Text);

            int flag = 0;
            int id_pass = 0;
            try
            {
                sqlReader = await Users.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToString(sqlReader["login"]) == textBox9.Text)
                    {
                        flag = 1;
                        id_pass = (int)sqlReader["Id_pass_money"];
                        break;
                    }
                }
                if (flag == 0)
                {
                    label34.Text = "Неверный логин ! Попробуйте снова !";
                    label34.Visible = true;
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

            if (flag != 0)
            {
                int is_acsess = 0;
                SqlCommand pass = new SqlCommand("SELECT * FROM [Passwords]", sqlConnection);
                pass.Parameters.AddWithValue("Pass", textBox10.Text);
                try
                {
                    sqlReader = await pass.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        if ((int)sqlReader["Id"] == id_pass && Convert.ToString(sqlReader["Pass"]) == textBox10.Text)
                        {
                            is_acsess = 1;
                            label34.Text = "Acsess !";
                            label34.Visible = true;
                            break;
                        }
                    }

                    if (is_acsess == 0)
                    {
                        label34.Text = "Неверный пароль !";
                        label34.Visible = true;
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

                    if (is_acsess == 1)
                    {
                        SqlCommand c = new SqlCommand("UPDATE [Passwords] SET [Money]=[Money]+" + textBox8.Text +
                            " WHERE [Id]=@Id", sqlConnection);

                        c.Parameters.AddWithValue("Id", id_pass);
                        await c.ExecuteNonQueryAsync();
                    }

                    SqlCommand Pass = new SqlCommand("SELECT * FROM [Passwords]", sqlConnection);
                    Pass.Parameters.AddWithValue("Pass", textBox10.Text);

                    try
                    {
                        sqlReader = await Pass.ExecuteReaderAsync();
                        while (await sqlReader.ReadAsync())
                        {
                            if (Convert.ToString(sqlReader["Pass"]) == textBox10.Text && is_acsess == 1)
                            {
                                label34.Text = "Итоговый балланс: " + Convert.ToString(sqlReader["Money"]) + " руб";
                                label34.Visible = true;
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

        private async void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Tickets]", sqlConnection);

            DateTime dt1 = DateTime.Now;
            DateTime now = DateTime.Now;
            int id_ticket = 0;
            int id_place = 0;
            int ticket_remove = 0;
            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add("Номер билета: " + Convert.ToString(sqlReader["Id"]) + " " + Convert.ToString(sqlReader["Name"]) +
                        ", № поезда: " + Convert.ToString(sqlReader["N_train"]) + ", вагон: " +
                        Convert.ToString(sqlReader["N_wagon"]) + ", место: " + Convert.ToString(sqlReader["N_place"])
                        + ", дата отправления: " + Convert.ToString(sqlReader["Date"]) + ", от: " + Convert.ToString(sqlReader["ot"]) +
                        ", куда: " + Convert.ToString(sqlReader["prib"]) +
                        " время в пути(в часасх): " + Convert.ToString(sqlReader["time_way"]));

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

                if(ticket_remove == 1)
                {
                    SqlCommand c = new SqlCommand("DELETE FROM [Tickets] WHERE [Id]=@Id", sqlConnection);
                    c.Parameters.AddWithValue("Id", id_ticket);

                    await c.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
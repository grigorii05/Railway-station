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
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection;
        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Учеба\Курсач БСБД\DB_Train\DB_Train\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;
            SqlCommand Traines = new SqlCommand("SELECT * FROM [Traines]", sqlConnection);

            types.Items.Clear();
            types.Items.Add("Coupe");
            types.Items.Add("Platskart");

            try
            {
                N_traines.Items.Clear();

                sqlReader = await Traines.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    N_traines.Items.Add(sqlReader["N_train"]);
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

            SqlCommand role = new SqlCommand("SELECT * FROM [roles]", sqlConnection);


            try
            {
                roles.Items.Clear();

                sqlReader = await role.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    roles.Items.Add(sqlReader["role"]);
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

        //-----------Добавление поезда----------------------//
        private async void button4_Click(object sender, EventArgs e)
        {
            if (label22.Visible)
                label22.Visible = false;

            SqlDataReader sqlReader = null;
            SqlCommand Traines = new SqlCommand("SELECT * FROM [Traines]", sqlConnection);

            int flag = 0;
            try
            {
                sqlReader = await Traines.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if(Convert.ToString(sqlReader["N_train"]) == textBox3.Text &&
                        Convert.ToString(sqlReader["Date"]) == textBox9.Text)
                        flag = 1;
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
                if(flag != 1)
                {
                    if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                   !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO [Traines] (N_train, Date, ot, Train_info)" +
                            " VALUES(@N_train, @Date, @ot, @Train_info)", sqlConnection);

                        command.Parameters.AddWithValue("N_train", textBox3.Text);
                        command.Parameters.AddWithValue("ot", textBox8.Text);
                        command.Parameters.AddWithValue("Date", textBox9.Text);
                        command.Parameters.AddWithValue("Train_info", textBox7.Text);
                        await command.ExecuteNonQueryAsync();
                    }
                    else
                    {
                        label22.Text = "Все поля должны быть заполнены!";
                        label22.Visible = true;
                    }
                }
                else
                {
                    label22.Text = "Такой поезд уже есть !";
                    label22.Visible = true;
                }
            }
        }

        //-----------Добавление вагона----------------------//
        private async void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (label5.Visible)
                label5.Visible = false;
            if (types.Text == "Platskart")
                n = 54;
            if (types.Text == "Coupe")
                n = 36;

            SqlDataReader sqlReader = null;
            SqlCommand Places = new SqlCommand("SELECT * FROM [Places]", sqlConnection);

            int flag = 0;
            try
            {
                sqlReader = await Places.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToString(sqlReader["N_train"]) == N_traines.Text &&
                        Convert.ToString(sqlReader["N_vagon"]) == textBox2.Text)
                        flag = 1;
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

            if(flag == 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO [Places] (N_train, N_vagon, Type, N_place, Занято_или_свободно)" +
                            " VALUES(@N_train, @N_vagon, @Type, @N_place, @Занято_или_свободно)", sqlConnection);

                        command.Parameters.AddWithValue("N_train", N_traines.Text);
                        command.Parameters.AddWithValue("N_vagon", textBox2.Text);
                        command.Parameters.AddWithValue("Type", types.Text);
                        command.Parameters.AddWithValue("N_place", i);
                        command.Parameters.AddWithValue("Занято_или_свободно", false);
                        await command.ExecuteNonQueryAsync();
                    }
                    else
                    {
                        label5.Text = "Все поля должны быть заполнены!";
                        label5.Visible = true;
                    }
                }
            }
            else
            {
                label5.Visible = true;
            }
        }

        //------------ДОБАВЛЕНИЕ ПОЛЬЗОВАТЕОЛЯ--------------//
        private async void button6_Click(object sender, EventArgs e)
        {
            if (label26.Visible)
                label26.Visible = false;

            SqlDataReader sqlReader = null;
            SqlCommand Traines = new SqlCommand("SELECT * FROM [Users]", sqlConnection);

            int flag = 0;
            try
            {
                sqlReader = await Traines.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToString(sqlReader["login"]) == textBox4.Text)
                        flag = 1;
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

            if(flag != 1)
            {
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                  !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                  !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                  !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    SqlCommand c1 = new SqlCommand("INSERT INTO [Passwords] (Pass, Money)" +
                            " VALUES(@Pass, @Money)", sqlConnection);

                    c1.Parameters.AddWithValue("Pass", textBox1.Text);
                    c1.Parameters.AddWithValue("Money", textBox6.Text);
                    await c1.ExecuteNonQueryAsync();
        
                    int max_id = 0;
                    SqlCommand comm = new SqlCommand("SELECT [ID] FROM [Passwords] WHERE [ID]=(SELECT MAX([Id]) FROM [Passwords])", sqlConnection);
                    sqlReader = await comm.ExecuteReaderAsync();
                    if(await sqlReader.ReadAsync())
                    {
                        max_id = (int)sqlReader["ID"];
                    }

                    if (sqlReader != null)
                        sqlReader.Close();

                    SqlCommand c2 = new SqlCommand("INSERT INTO [Users] (login, FIO, Id_pass_money, Id_role)" +
                            " VALUES(@login, @FIO, @Id_pass_money, @Id_role)", sqlConnection);

                    c2.Parameters.AddWithValue("login", textBox4.Text);
                    c2.Parameters.AddWithValue("FIO", textBox5.Text);
                    c2.Parameters.AddWithValue("Id_pass_money", max_id);

                    if(roles.Text == "Client")
                        c2.Parameters.AddWithValue("Id_role", 2);
                    if (roles.Text == "Admin")
                        c2.Parameters.AddWithValue("Id_role", 1);
                    await c2.ExecuteNonQueryAsync();
                }
                else
                {
                    label26.Text = "Все поля должны быть заполнены!";
                    label26.Visible = true;
                }
            }
            else
            {
                label26.Text = "Такой пользователь уже есть в системе !";
                label26.Visible = true;
            }
        }
    }
}

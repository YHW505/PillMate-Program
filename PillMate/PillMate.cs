using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PillMate
{
    public partial class PillMate : Form
    {
        public PillMate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=coding32;Uid=root;Pwd=Hyeongwoo0!"))
            {
                var idx = textBox1.Text;
                var header = textBox2.Text;
                var body = textBox3.Text;
                string insertQuery = $"INSERT INTO cotable(idx,header,body) VALUES('{idx}', '{header}', '{body}')";
                //string insertQuery = $"INSERT INTO cotable(idx,header,body) VALUES('2', '2header', '2body')";
                try//예외 처리
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);

                    // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("insert success");
                    }
                    else
                    {
                        MessageBox.Show("insert failed");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("failed");
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=coding32;Uid=root;Pwd=Hyeongwoo0!"))
            {
                try//예외 처리
                {
                    connection.Open();
                    string sql = "SELECT * FROM cotable";

                    //ExecuteReader를 이용하여
                    //연결 모드로 데이타 가져오기
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataReader table = cmd.ExecuteReader();
                    while (table.Read())
                    {
                        var index = table["idx"].ToString();
                        var header = table["header"].ToString();
                        var body = table["body"].ToString();
                        ListViewItem listitem = new ListViewItem(new string[] { index, header, body });
                        this.listView1.Items.Add(listitem);

                        //Console.WriteLine("{0} {1}", table["idx"], table["header"], table["body"]);
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

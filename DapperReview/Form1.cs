using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Data.SqlClient;
using DapperReview.Models;

namespace DapperReview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private int xxx()                // anonim method arka trafta bu sekilde calisiyor
        //{
        //    txtAge=txtAge.Text
        //}
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (IDbConnection connection = new SqlConnection(Connection.ConStr("DapperReview")))    // otomatik kapanmasi icin using yazdik
            {
                //var result=connection.Query<DapperTest>("Select * from DapperTest").ToList();   // eger update yapacaksak Query yerine execute yazariz
                //foreach (var item in result)
                //{
                //    lstData.Items.Add(item);
                //}
                string sql = "select * from DapperTest";
                var list = connection.Query<DapperTest>
                    (sql, new {Age=txtAge.Text}).ToList();                 
                                                                         // dat is genoemd als anonymous method,  method zonder naaam
                lstData.DataSource = list;
                      
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // SQL Injection 

            //string sql = $"Insert into DapperTest(firstName, lastName,  age, gender) values('{txtFirstName.Text}', '{txtLastName.Text}', {int.Parse(txtInputAge.Text)}, '{txtGender.Text}') ";

            //using (IDbConnection connection = new SqlConnection(Connection.ConStr("DapperReview")))
            //{
            //    connection.Execute(sql);
            //}

            // Andere Manier   Dat is veiliger

            DapperTest dapperTest = new DapperTest();
            dapperTest.FirstName=txtFirstName.Text;
            dapperTest.LastName=txtLastName.Text;
            dapperTest.Age=int.Parse(txtInputAge.Text);
            dapperTest.Gender=txtGender.Text;

            string sql = "insert into DapperTest (FirstName, LastName,  Age, Gender)" +
                         "Values(@FirstName, @LastName, @Age, @Gender)";

            using (IDbConnection connection = new SqlConnection(Connection.ConStr("DapperReview")))
            {
                connection.Query(sql, dapperTest);
            }

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            using (IDbConnection connection = new SqlConnection(Connection.ConStr("DapperReview")))   
            {            
                string sql = "select * from DapperTest";
                var list = connection.Query<DapperTest>
                    (sql).ToList();
               
                lstData.DataSource = list;

            }
        }
    }
}

using MySql.Data.MySqlClient;
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

namespace DatabasProjekt1
{
    public partial class Form1 : Form
    {
        CarInfo form;

       
        public Form1()
        {
            InitializeComponent();
            form = new CarInfo(this);
        }
        //metod för att displaya
        public void Display()
        {
            CarDB.DisplayAndSearch("SELECT CarID, Brand, Model, Mileage, Cost, Phonenumber FROM car", dataGridView1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void Form1_shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            CarDB.DisplayAndSearch("SELECT CarID, Brand, Model, Mileage, Cost, Phonenumber FROM car WHERE Brand LIKE'%"+ txtBox.Text +"%'", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //Édit
                form.Clear();
                form.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.brand = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.model = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.mileage = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.cost = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.phoneumber = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.UpdateCar();
                form.ShowDialog();
                return;
            }
            if(e.ColumnIndex == 1)
            {
                if(MessageBox.Show("Do you want to delete Car", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //Delete
                    CarDB.DeleteCar(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }
    }
}

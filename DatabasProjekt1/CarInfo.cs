using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabasProjekt1
{
    public partial class CarInfo : Form
    {
        private readonly Form1 _parent;
        public string id, brand, model, mileage, cost, phoneumber;

        public CarInfo(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateCar()
        {
            lblAdd.Text = "Update Car";
            btnSave.Text = "Update";
            txtBrand.Text = brand;
            txtModel.Text = model;
            txtMileage.Text = mileage;
            txtCost.Text = cost;
            txtPhonenumber.Text = phoneumber;
        }

        public void SaveInfo()
        {
            lblAdd.Text = "Add Car";
            btnSave.Text = "Save";
        }

       

        public void Clear()
        {
            
            
            txtBrand.Text = string.Empty;
            txtModel.Text = string.Empty;   
            txtMileage.Text = string.Empty;
            txtCost.Text = string.Empty;    
            txtPhonenumber.Text = string.Empty;
            


        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtBrand.Text.Trim().Length < 1)
            {
                MessageBox.Show("Car Brand is empty( < 1). ");
                return;
            }
            if (txtModel.Text.Trim().Length < 1)
            {
                MessageBox.Show("Car Model is empty( < 1). ");
                return;
            }
            if (txtMileage.Text.Trim().Length == 0)
            {
                MessageBox.Show("Car Mileage is empty( < 1). ");
                return;
            }
            if (txtCost.Text.Trim().Length == 0)
            {
                MessageBox.Show("Car Cost is empty( > 1). ");
                return;
            }
            if (txtPhonenumber.Text.Trim().Length == 0)
            {
                MessageBox.Show("Phonenumber is empty( > 1). ");
                return;
            }
            


            if (btnSave.Text == "Save")
            {
               

                Car cr = new Car(txtBrand.Text.Trim(), txtModel.Text.Trim(), txtMileage.Text.Trim(), txtCost.Text.Trim(), txtPhonenumber.Text.Trim()) ;
                CarDB.AddCar(cr);
                Clear();
                
               
            }
            if(btnSave.Text == "Update")
            {
                Car cr = new Car(txtBrand.Text.Trim(), txtModel.Text.Trim(), txtMileage.Text.Trim(), txtCost.Text.Trim(), txtPhonenumber.Text.Trim());
                CarDB.UpdateCar(cr, id);
            }
            _parent.Display();

            
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    } 
}

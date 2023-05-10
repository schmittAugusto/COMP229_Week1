using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CoffeeShop;

namespace CustomerForm
{
    public partial class CustomerForm : Form
    {
        public Customer _customer;

        public CustomerForm()
        {
            _customer = new Customer();
            InitializeComponent();
        }
        /* 301261086 Yi-Chen, Hsu */
        public CustomerForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            try
            {
                this.Text = customer.Name.ToString();
                fnameTxtBox.Text = customer.Name.Split(' ')[0];
                lnameTxtBox.Text = customer.Name.Split(' ')[1];
                telephoneNumberTxtBox.Text = Convert.ToString(customer.Phone);
                streetTxtBox.Text = Convert.ToString(customer.Address.Street);
                cityTxtBox.Text = Convert.ToString(customer.Address.City);
                provinceComboBox.SelectedItem = customer.Address.Province;
                postalCodeTxtBox.Text = Convert.ToString(customer.Address.PostalCode);
                okBttn.Text = "Save";
            }
            catch(IndexOutOfRangeException)
            {
                fnameTxtBox.Text = customer.Name;
            }
            fnameTxtBox.Enabled = false;
            lnameTxtBox.Enabled = false;

        }
        //Markhill Rodulf Robles
        private void okBttn_Click(object sender, EventArgs e)
        {

            Address address = new Address();
            _customer.Name = $"{fnameTxtBox.Text} {lnameTxtBox.Text}";
            ulong phoneNumber = ulong.Parse(telephoneNumberTxtBox.Text);
            _customer.Phone = phoneNumber;
            address.Street = streetTxtBox.Text;
            address.City = cityTxtBox.Text;
            address.Province = provinceComboBox.SelectedItem.ToString();
            address.PostalCode = postalCodeTxtBox.Text;
            _customer.Address = address;


            this.DialogResult = DialogResult.OK;
            Close();
        }
        //Markhill Rodulf Robles
        private void cancelBttn_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Markhill Rodulf Robles
        private void fnameTxtBox_Enter(object sender, EventArgs e)
        {
            if (fnameTxtBox.Text == "*Required*")
            {
                fnameTxtBox.Text = "";
            }
        }
        //Markhill Rodulf Robles
        private void fnameTxtBox_Leave(object sender, EventArgs e)
        {
            if (fnameTxtBox.Text.Length == 0 || fnameTxtBox.Text == null)
            {
                fnameTxtBox.Text = "*Required*";
            }
        }
        //Markhill Rodulf Robles
        private void lnameTxtBox_Enter(object sender, EventArgs e)
        {
            if (lnameTxtBox.Text == "*Required*")
            {
                lnameTxtBox.Text = "";
            }
        }
        //Markhill Rodulf Robles
        private void lnameTxtBox_Leave(object sender, EventArgs e)
        {
            if (lnameTxtBox.Text.Length == 0 || lnameTxtBox.Text == null)
            {
                lnameTxtBox.Text = "*Required*";
            }
        }
        //Markhill Rodulf Robles
        private void telephoneNumberTxtBox_Enter(object sender, EventArgs e)
        {
            if (telephoneNumberTxtBox.Text == "*Required*")
            {
                telephoneNumberTxtBox.Text = "";
            }
        }
        //Markhill Rodulf Robles
        private void telephoneNumberTxtBox_Leave(object sender, EventArgs e)
        {
            if (telephoneNumberTxtBox.Text.Length == 0 || telephoneNumberTxtBox.Text == null)
            {
                telephoneNumberTxtBox.Text = "*Required*";
            }
        }
        //Markhill Rodulf Robles
        private void postalCodeTxtBox_Enter(object sender, EventArgs e)
        {
            if (postalCodeTxtBox.Text == "*No Spaces*")
            {
                postalCodeTxtBox.Text = "";
            }
        }
        //Markhill Rodulf Robles
        private void postalCodeTxtBox_Leave(object sender, EventArgs e)
        {
            if (postalCodeTxtBox.Text.Length == 0 || postalCodeTxtBox.Text == null)
            {
                postalCodeTxtBox.Text = "*No Spaces*";
            }
        }
    }
}

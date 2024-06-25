// Programmer: Christian Castillo
// Description: Form for taking a carpet order.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Lab_2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void calculateButton_Click(object sender, EventArgs e)
        {
            // Use try-catch to handle any data entry exceptions
            try
            {
                //Declare local constants
                const decimal TAX_RATE = 0.07m;
                const decimal LABOR_RATE = 0.50M;

                // Declare local variables
                double length;          // Length of carpet
                double width;           // Width of carpet
                double area;            // Area of carpet
                decimal price;          // Price of carpet (per sq. ft.)
                decimal carpetCharge;   // Total price of carpet
                decimal tax;            // Tax on total price of carpet
                decimal laborCharge;    // Labor charge for installing carpet
                decimal orderTotal;     // Total charge for order (carpet and labor)

                // Get values from text boxes and assign to variables
                length = double.Parse(lengthTextBox.Text);
                width = double.Parse(widthTextBox.Text);
                price = decimal.Parse(priceTextBox.Text);

                //Calculate and display area of carpet
                area = length * width;
                areaLabel.Text = area.ToString("n2");

                // Calculate and display carpet charge
                carpetCharge = (decimal)area * price; //Cast operator required
                carpetChargeLabel.Text = carpetCharge.ToString("c");

                // Calculate and display tax on carpet charge
                tax = carpetCharge * TAX_RATE;
                taxLabel.Text = tax.ToString("c");

                // Calculate and display labor charge
                laborCharge = (decimal)area * LABOR_RATE;
                laborChargeLabel.Text = laborCharge.ToString("c");

                // Calculate and display order total
                orderTotal = carpetCharge + tax + laborCharge;
                orderTotalLabel.Text = orderTotal.ToString("c");
            }
            catch (Exception ex) 
                 {
                    // Display the default error message
                    MessageBox.Show(ex.Message);
                 }
            }
        // Clear all input and output controls
        private void clearButton_Click(object sender, EventArgs e)
        {
            lengthTextBox.Text = " ";
            widthTextBox.Text = " ";
            priceTextBox.Text = " ";
            areaLabel.Text = " ";
            carpetChargeLabel.Text = " ";
            taxLabel.Text = " ";
            laborChargeLabel.Text = " ";
            orderTotalLabel.Text = " ";

            // Set focus to first input control on form
            lengthTextBox.Focus();
        }
       
        // Close the form (ending the program
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

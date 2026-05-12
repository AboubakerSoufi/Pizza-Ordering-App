using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza____Project
{
   
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        void UpdateWhereToEat()
        {
            UpdateTotalPrice();

            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In.";
                return;
            }

            if (rbTakeOut.Checked)
            {
                lblWhereToEat.Text = "Take Out.";
                return;
            }

        }
        void ResetForm()
        {
            gbCrustType.Enabled = true;
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;

            rbMediem.Checked = true;

            chkExtraChees.Checked = false;
            chkGreenPeppers.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkOnion.Checked = false;
            chkTomatoes.Checked = false;

            rbEatIn.Checked = true;
     
            rbThinCrust.Checked = true;

            btnOrderPizza.Enabled = true;
        }
        void UpdateToppings()
        {
            UpdateTotalPrice();
            string sToppings = "";
            if (chkExtraChees.Checked)
                sToppings = "Extra cheese";

            if (chkOnion.Checked)
                sToppings += ", Onion";

            if (chkOlives.Checked)
                sToppings += ", Olives";

            if (chkTomatoes.Checked)
                sToppings += ", Tomatoes";

            if (chkGreenPeppers.Checked)
                sToppings += ", GreenPeppers";

            if (chkMushrooms.Checked)
                sToppings += ", Mushrooms";

            if (sToppings.StartsWith(","))
                sToppings = sToppings.Substring(1, sToppings.Length - 1).Trim();

            if (sToppings == "")
                sToppings = "No Toppings";

            lblTopping.Text = sToppings;

        }
        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rbThinCrust.Checked)
            {
                lblCrustType.Text = "Thin Crust";
                return;
            }

            if (rbThinkCrust.Checked)
            {
                lblCrustType.Text = "Think Crust";
                return;
            }
        }
        float GetSelectedSizePrice()
        {
            if (rbSmall.Checked)

                return Convert.ToSingle(rbSmall.Tag);

            else if (rbMediem.Checked)

                return Convert.ToSingle(rbMediem.Tag);

            else

                return Convert.ToSingle(rbLarge.Tag);
        }
        float CalculateToppingsPrice()
        {
            float ToppingsTotalPrice = 0;

            if (chkExtraChees.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkExtraChees.Tag);

            if (chkGreenPeppers.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkGreenPeppers.Tag);

            if (chkMushrooms.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkMushrooms.Tag);

            if (chkOlives.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkOlives.Tag);

            if (chkOnion.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkOnion.Tag);

            if (chkTomatoes.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkTomatoes.Tag);

            return ToppingsTotalPrice;

        }
        float GetSelectedCrustPrice()
        {
            if (rbThinCrust.Checked)
                return Convert.ToSingle(rbThinCrust.Tag);
            else
                return Convert.ToSingle(rbThinkCrust.Tag);
        }
        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + CalculateToppingsPrice() + GetSelectedCrustPrice();
        }
        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }
        void UpdateSize()
        {
            UpdateTotalPrice();
            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }
            if (rbMediem.Checked)
            {
                lblSize.Text = "Mediem";
                return;
            }
            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("confirm Order","Confirm",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed successfuly" , "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOrderPizza.Enabled = false;
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbCrustType.Enabled= false;
                gbWhereToEat.Enabled = false;
            }
        }

        private void rbMediem_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();

        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();

        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
    }
}

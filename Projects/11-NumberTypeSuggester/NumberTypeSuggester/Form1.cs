using System.Numerics;
using System.Windows.Forms.VisualStyles;

namespace NumberTypeSuggester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void IntegralCheck_CheckedChanged(object sender, EventArgs e)
        {
            preciseCheck.Visible = !integralCheck.Checked;

            RecalculateSuggestedType();
        }

        private void RecalculateSuggestedType()
        {
            if(IsInputComplete())
            {
                var minValue = BigInteger.Parse(minValTextbox.Text);
                var maxValue = BigInteger.Parse(maxValTextbox.Text);

                if(maxValue >= minValue)
                {
                    resultTypeLabel.Text = NumericTypeSuggester.GetName(minValue, maxValue, integralCheck.Checked, preciseCheck.Checked);
                    return;
                }
            }
            resultTypeLabel.Text = "not enough data"; 
        }

        private void PreciseCheck_CheckedChanged(object sender, EventArgs e)
        {
            RecalculateSuggestedType();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            RecalculateSuggestedType();
            SetColorOfMaxCalueTextField();
        }

        private void SetColorOfMaxCalueTextField()
        {
            bool isValid = true;

            if (IsInputComplete())
            {
                var minValue = BigInteger.Parse(minValTextbox.Text);
                var maxValue = BigInteger.Parse(maxValTextbox.Text);

                if(maxValue < minValue)
                {
                    isValid = false;
                }
            }

            maxValTextbox.BackColor = isValid ? Color.White : Color.IndianRed;
        }

        private bool IsInputComplete()
        {
            return minValTextbox.Text.Length > 0 &&
                !minValTextbox.Text.Equals('-') &&
                maxValTextbox.Text.Length > 0 &&
                !maxValTextbox.Text.Equals('-');
        }

        private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!IsValidInput(e.KeyChar, (TextBox) sender))
            {
                e.Handled = true;
            }
        }

        private static bool IsValidInput(char keyChar, TextBox textBox)
        {
            return
                char.IsDigit(keyChar) ||
                char.IsControl(keyChar) ||
                (keyChar.Equals('-') && textBox.SelectionStart.Equals(0) && !textBox.Text.Contains('-'));
        }
    }
}

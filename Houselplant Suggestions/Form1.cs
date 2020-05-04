using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Houselplant_Suggestions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.trkTemp.Scroll += new System.EventHandler(this.HouseConditionsChanged);
        }

        private void trkTemp_Scroll(object sender, EventArgs e)
        {
            // Use format string, the # symbol is replaced by the number in tryTemp.Value
            // Pressing Alt + 0176 on your number pad types a ° symbol
            lblTemp.Text = trkTemp.Value.ToString("# °F");
        }

        private void HouseConditionsChanged(object sender, EventArgs e)
        {
            int homeTemp = trkTemp.Value;
            bool southFacingWindowAvailable = chkSouthFacing.Checked;

            // Call our method,  use return value
            string suggestedPlant = GenerateSuggestion(homeTemp, southFacingWindowAvailable);

            lblSuggestion.Text = suggestedPlant;
        }

        private string GenerateSuggestion(int temp, bool southFacing)
        {
            if (southFacing)
            {
                if (temp > 65)
                {
                    return "Peace Lily"; // Warm with light
                }
                else
                {
                    return "Spider Plant"; // Cool with light
                }
            }
            else
            {
                if (temp > 65)
                {
                    return "Dragon Tree";  // Warm with low light
                }
                else
                {
                    return "Ivy";  // Cool with low light
                }
            }
        }

        private void btnSuggest_ControlRemoved(object sender, ControlEventArgs e)
        {

        }
    }
}

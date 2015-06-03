using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleNotifier.View
{
    public partial class SettingsPanel : UserControl
    {
        public SettingsPanel()
        {
            InitializeComponent();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Accept to reset all settings to default configuration.\nAll your settings and designers list will be deleted.\nThe program will be restarted to complete this operation.",
                                     "Reset to default settings",
                                     MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
            }
        }
    }
}

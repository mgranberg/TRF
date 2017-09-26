using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRF
{
    public partial class AdminControl : Form
    {
        public AdminControl()
        {
            InitializeComponent();
        }

        private void BtnAdminLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login =new Login();
            login.ShowDialog();
        }
    }
}

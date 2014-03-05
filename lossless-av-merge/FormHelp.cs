using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lossless_av_merge
{
    public partial class FormHelp : Form
    {

        private string helpPath = Environment.CurrentDirectory + "\\help\\help.html";

        public FormHelp()
        {
            InitializeComponent();
        }

        private void FormHelp_Load(object sender, EventArgs e)
        {
            if (File.Exists(helpPath))
            {
                browserHelp.Navigate(helpPath);
            }
        }
    }
}

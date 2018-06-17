using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            cbAutoSelectFilm.Checked = Options.AutoSelectFilm;
            cbAutoSelectDate.Checked = Options.AutoSelectDate;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Options.AutoSelectFilm = cbAutoSelectFilm.Checked;
            Options.AutoSelectDate = cbAutoSelectDate.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }


        public Options Options;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoSForms.Forms
{
    public partial class ClientEditForm : Form
    {
        public ClientEditForm()
        {
            InitializeComponent();
            Load load = new Load(this);
            Load += load.GetHandler("clientEdit");
        }
    }
}

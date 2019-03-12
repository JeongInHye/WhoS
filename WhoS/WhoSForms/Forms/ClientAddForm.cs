using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoSForms.Views;

namespace WhoSForms.Forms
{
    public partial class ClientAddForm : Form
    {
        public ClientAddForm(Form parentForm,ClientView clientView)
        {
            InitializeComponent();
            Load load = new Load(this,clientView);
            Load += load.GetHandler("clientAdd");
        }

        public ClientAddForm(Form parentForm)
        {
            InitializeComponent();
            Load load = new Load(this);
            Load += load.GetHandler("clientAdd");
        }
    }
}

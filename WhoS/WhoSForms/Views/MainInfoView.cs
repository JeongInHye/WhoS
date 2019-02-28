using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoSForms.Modules;

namespace WhoSForms.Views
{
    class MainInfoView
    {
        private Form parentForm;
        private Draw draw;

        public MainInfoView(Form parentForm)
        {
            this.parentForm = parentForm;
            draw = new Draw();
            getView();
        }

        private void getView()
        {

        }
    }
}

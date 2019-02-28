using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoSForms.Modules;

namespace WhoSForms.Views
{
    class IncomeView
    {
        private Form parentForm;
        private Draw draw;

        public IncomeView(Form parentForm)
        {
            this.parentForm = parentForm;
            draw = new Draw();
            getView();
        }

        void getView()
        {

        }
    }
}

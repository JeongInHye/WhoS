using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoSForms.View;
using WhoSForms.Views;

namespace WhoSForms
{
    class Load
    {
        private Form parentForm;

        public Load(Form parentForm)
        {
            this.parentForm = parentForm;
        }

        public EventHandler GetHandler(string viewName)
        {
            switch (viewName)
            {
                case "main":
                    return GetLoad;
                case "mainInfo":
                    return GetMainInfoLoad;
                case "enter":
                    return GetEnterLoad;
                case "out":
                    return GetOutLoad;
                case "location":
                    return GetLocationLoad;
                case "client":
                    return GetClientLoad;
                case "income":
                    return GetIncomeLoad;
                default:
                    return null;
            }
        }

        private void GetLoad(object o, EventArgs a)
        {
            parentForm.Size = new Size(1400, 800);
            parentForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.MaximizeBox = false;
            parentForm.MinimizeBox = false;
            parentForm.Text = "WhoS";
            new MainView(parentForm);
        }

        private void GetMainInfoLoad(object o, EventArgs a)
        {
            parentForm.Size = new Size(1400, 800);
            parentForm.FormBorderStyle = FormBorderStyle.None;
            new MainInfoView(parentForm);
        }

        private void GetEnterLoad(object o, EventArgs a)
        {
            parentForm.Size = new Size(500, 500);
            parentForm.FormBorderStyle = FormBorderStyle.None;
            new EnterView(parentForm);
        }

        private void GetOutLoad(object o, EventArgs a)
        {
            parentForm.Size = new Size(500, 500);
            parentForm.FormBorderStyle = FormBorderStyle.None;
            new OutView(parentForm);
        }

        private void GetLocationLoad(object o, EventArgs a)
        {
            parentForm.Size = new Size(500, 500);
            parentForm.FormBorderStyle = FormBorderStyle.None;
            new LocationView(parentForm);
        }

        private void GetClientLoad(object o, EventArgs a)
        {
            parentForm.Size = new Size(500, 500);
            parentForm.FormBorderStyle = FormBorderStyle.None;
            new ClientView(parentForm);
        }

        private void GetIncomeLoad(object o, EventArgs a)
        {
            parentForm.Size = new Size(500, 500);
            parentForm.FormBorderStyle = FormBorderStyle.None;
            new IncomeView(parentForm);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoSForms.Modules;

namespace WhoSForms.Views
{
    class LocationView
    {
        private Form parentForm;
        private Draw draw;
        private Hashtable hashtable;
        private Button btnLocation;

        public LocationView(Form parentForm)
        {
            this.parentForm = parentForm;
            draw = new Draw();
            getView();
        }

        void getView()
        {
            int count = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    count++;
                    hashtable = new Hashtable();
                    hashtable.Add("size", new Size(80, 80));
                    if (i >= 2 && i <= 3 )
                    {
                        hashtable.Add("point", new Point(100 + (90 * j), 110 + (90 * i)));
                    }
                    else if (i >= 4 && i <= 5)
                    {
                        hashtable.Add("point", new Point(100 + (90 * j), 140 + (90 * i)));
                    }
                    else
                    hashtable.Add("point", new Point(100 + (90 * j), 80 + (90 * i)));
                    hashtable.Add("color", Color.FromArgb(175, 171, 171));
                    hashtable.Add(string.Format("name", "{0}"), count);
                    hashtable.Add(string.Format("text", "{0}"), count);
                    hashtable.Add("font", new Font("맑은 고딕", 13));
                    hashtable.Add("click", (EventHandler)Location_Click);
                    btnLocation = draw.getButton(hashtable, parentForm);
                }
            }
        }

        private void Location_Click(object sender, EventArgs e)
        {
            MessageBox.Show(btnLocation.Text.ToString());
        }
    }
}

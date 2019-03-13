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
    class LocationAddView
    {
        private WebAPI webAPI;
        private Form parentForm;
        private Draw draw;
        private Hashtable hashtable;
        private Label lbl;
        private TextBox tboxloNum;
        private Button btnLocation;
        private string pNum;

        public LocationAddView(Form parentForm, string pNum)
        {
            this.pNum = pNum;
            this.parentForm = parentForm;
            draw = new Draw();
            getView();
        }

        void getView()
        {
            hashtable = new Hashtable();
            hashtable.Add("text", "적재할 위치 ( 1 ~ 36 )");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(40, 40));
            hashtable.Add("font", new Font("맑은 고딕", 15, FontStyle.Bold));
            hashtable.Add("name", "lblClientList");
            lbl = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(45, 80));
            hashtable.Add("width", 200);
            hashtable.Add("name", "tboxloNum");
            hashtable.Add("font", new Font("맑은 고딕", 11));
            tboxloNum = draw.getTextBox(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(80, 70));
            hashtable.Add("point", new Point(270, 40));
            hashtable.Add("color", Color.FromArgb(47, 85, 151));
            hashtable.Add("name", "btnLocation");
            hashtable.Add("text", "적재");
            hashtable.Add("font", new Font("맑은 고딕", 13, FontStyle.Bold));
            hashtable.Add("click", (EventHandler)Location_Click);
            btnLocation = draw.getButton(hashtable, parentForm);
        }

        private void Location_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(tboxloNum.Text);
            if (num < 1 || num > 36)
            {
                MessageBox.Show("1 ~ 36 사이의 수를 입력해주세요");
                tboxloNum.Text = "";
            }
            else
            {
                webAPI = new WebAPI();
                hashtable = new Hashtable();

                hashtable.Add("pNum",pNum);
                hashtable.Add("lNo",tboxloNum.Text);

                if (webAPI.Post(Program.serverUrl + "Enter/LocationAdd", hashtable))
                {
                    MessageBox.Show("적재 완료");
                    parentForm.Close();
                }
            }
        }
    }
}

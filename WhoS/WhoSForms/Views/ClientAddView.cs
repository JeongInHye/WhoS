using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoSForms.Modules;

namespace WhoSForms.Views
{
    class ClientAddView
    {
        private Form parentForm;
        private Draw draw;
        private Hashtable hashtable;
        private Label lblName, lblPName, lblCall, lblAddress, lblID, lblPassword;
        private TextBox tboxName, tboxPName, tboxCall, tboxAddress, tboxID, tboxPassword;
        private Button btnAdd, btnCancel;

        public ClientAddView(Form parentForm)
        {
            this.parentForm = parentForm;
            draw = new Draw();
            getView();
        }
        void getView()
        {
            hashtable = new Hashtable();
            hashtable.Add("text", "거래처 이름 : ");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(50, 50));
            hashtable.Add("font", new Font("맑은 고딕", 15, FontStyle.Bold));
            hashtable.Add("name", "lblName");
            lblName = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("text", "대표자 : ");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(50, 120));
            hashtable.Add("font", new Font("맑은 고딕", 15, FontStyle.Bold));
            hashtable.Add("name", "lblPName");
            lblPName = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("text", "전화번호 : ");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(50, 190));
            hashtable.Add("font", new Font("맑은 고딕", 15, FontStyle.Bold));
            hashtable.Add("name", "lblCall");
            lblCall = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("text", "주소 : ");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(50, 260));
            hashtable.Add("font", new Font("맑은 고딕", 15, FontStyle.Bold));
            hashtable.Add("name", "lblAddress");
            lblAddress = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("text", "아이디 : ");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(50, 330));
            hashtable.Add("font", new Font("맑은 고딕", 15, FontStyle.Bold));
            hashtable.Add("name", "lblID");
            lblID = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("text", "패스워드 : ");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(50, 400));
            hashtable.Add("font", new Font("맑은 고딕", 15, FontStyle.Bold));
            hashtable.Add("name", "lblPassword");
            lblPassword = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(200, 52));
            hashtable.Add("width", 250);
            hashtable.Add("name", "tboxName");
            hashtable.Add("font", new Font("맑은 고딕", 11));
            tboxName = draw.getTextBox(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(200, 122));
            hashtable.Add("width", 250);
            hashtable.Add("name", "tboxPName");
            hashtable.Add("font", new Font("맑은 고딕", 11));
            tboxPName = draw.getTextBox(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(200, 192));
            hashtable.Add("width", 250);
            hashtable.Add("name", "tboxCall");
            hashtable.Add("font", new Font("맑은 고딕", 11));
            tboxCall = draw.getTextBox(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(200, 262));
            hashtable.Add("width", 250);
            hashtable.Add("name", "tboxAddress");
            hashtable.Add("font", new Font("맑은 고딕", 11));
            tboxAddress = draw.getTextBox(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(200, 332));
            hashtable.Add("width", 250);
            hashtable.Add("name", "tboxID");
            hashtable.Add("font", new Font("맑은 고딕", 11));
            tboxID = draw.getTextBox(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(200, 402));
            hashtable.Add("width", 250);
            hashtable.Add("name", "tboxPassword");
            hashtable.Add("font", new Font("맑은 고딕", 11));
            tboxPassword = draw.getTextBox(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(95, 50));
            hashtable.Add("point", new Point(140, 480));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btnAdd");
            hashtable.Add("text", "추가");
            hashtable.Add("font", new Font("맑은 고딕", 13, FontStyle.Bold));
            hashtable.Add("click", (EventHandler)Add_Click);
            btnAdd = draw.getButton(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(95, 50));
            hashtable.Add("point", new Point(280, 480));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btnCancel");
            hashtable.Add("text", "취소");
            hashtable.Add("font", new Font("맑은 고딕", 13, FontStyle.Bold));
            hashtable.Add("click", (EventHandler)Cancel_Click);
            btnCancel = draw.getButton(hashtable, parentForm);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            parentForm.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (tboxName.Text == "" || tboxPName.Text == "" || tboxCall.Text == "" || tboxID.Text == "" || tboxPassword.Text == "")
            {
                MessageBox.Show("모두 입력해주세요");
            }
            else
            {
                WebClient wc = new WebClient();
                NameValueCollection nameValue = new NameValueCollection();

                nameValue.Add("Name", tboxName.Text);
                nameValue.Add("pName", tboxName.Text);
                nameValue.Add("Call", tboxName.Text);
                nameValue.Add("Address", tboxName.Text);
                nameValue.Add("ID", tboxName.Text);
                nameValue.Add("Password", tboxName.Text);

                byte[] result = wc.UploadValues(Program.serverUrl + "Client/Add", "POST", nameValue);
                string resultStr = Encoding.UTF8.GetString(result);

                if (resultStr == "1")
                {
                    MessageBox.Show("거래처 추가 완료");
                    parentForm.Close();
                }
                else
                {
                    MessageBox.Show("다시 입력해 주세요.");
                }
            }
        }
    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    class ClientEditView
    {
        private WebAPI webAPI;
        private Form parentForm;
        private Draw draw;
        private Hashtable hashtable;
        private Label lblName, lblPName, lblCall, lblAddress, lblID, lblPassword;
        private TextBox tboxName, tboxPName, tboxCall, tboxAddress, tboxID, tboxPassword;
        private Button btnEdit, btnCancel;
        private string clientNum;

        public ClientEditView(Form parentForm, string clientNum)
        {
            this.parentForm = parentForm;
            this.clientNum = clientNum;
            draw = new Draw();
            getView();
        }

        public ClientEditView(Form parentForm)
        {
            this.parentForm = parentForm;
            draw = new Draw();
            getView();
        }

        void getView()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("cNo", clientNum);
            if (!SelectPrint(Program.serverUrl + "Client/ClientEdeitSelect", hashtable))
            {
                MessageBox.Show("실패");
            }

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
            hashtable.Add("size", new Size(95, 50));
            hashtable.Add("point", new Point(140, 480));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btnEdit");
            hashtable.Add("text", "수정");
            hashtable.Add("font", new Font("맑은 고딕", 13, FontStyle.Bold));
            hashtable.Add("click", (EventHandler)Edit_Click);
            btnEdit = draw.getButton(hashtable, parentForm);

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

        private bool SelectPrint(string url, Hashtable ht1)
        {
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection nameValue = new NameValueCollection();

                foreach (DictionaryEntry data in ht1)
                {
                    nameValue.Add(data.Key.ToString(), data.Value.ToString());
                }
                byte[] result = wc.UploadValues(url, "POST", nameValue);
                string resultStr = Encoding.UTF8.GetString(result);

                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(resultStr);

                draw = new Draw();
                for (int i = 0; i < list.Count; i++)
                {
                    JArray jArray = (JArray)list[i];

                    hashtable = new Hashtable();
                    hashtable.Add("point", new Point(200, 52));
                    hashtable.Add("text", jArray[0].ToString());
                    hashtable.Add("width", 250);
                    hashtable.Add("name", "tboxName");
                    hashtable.Add("font", new Font("맑은 고딕", 11));
                    tboxName = draw.getTextBox_text(hashtable, parentForm);

                    hashtable = new Hashtable();
                    hashtable.Add("point", new Point(200, 122));
                    hashtable.Add("text", jArray[1].ToString());
                    hashtable.Add("width", 250);
                    hashtable.Add("name", "tboxPName");
                    hashtable.Add("font", new Font("맑은 고딕", 11));
                    tboxPName = draw.getTextBox_text(hashtable, parentForm);

                    hashtable = new Hashtable();
                    hashtable.Add("point", new Point(200, 192));
                    hashtable.Add("text", jArray[2].ToString());
                    hashtable.Add("width", 250);
                    hashtable.Add("name", "tboxCall");
                    hashtable.Add("font", new Font("맑은 고딕", 11));
                    tboxCall = draw.getTextBox_text(hashtable, parentForm);
                    tboxCall.KeyPress += TboxCall_KeyPress;

                    hashtable = new Hashtable();
                    hashtable.Add("point", new Point(200, 262));
                    hashtable.Add("text", jArray[3].ToString());
                    hashtable.Add("width", 250);
                    hashtable.Add("name", "tboxAddress");
                    hashtable.Add("font", new Font("맑은 고딕", 11));
                    tboxAddress = draw.getTextBox_text(hashtable, parentForm);

                    hashtable = new Hashtable();
                    hashtable.Add("point", new Point(200, 332));
                    hashtable.Add("text", jArray[4].ToString());
                    hashtable.Add("width", 250);
                    hashtable.Add("name", "tboxID");
                    hashtable.Add("font", new Font("맑은 고딕", 11));
                    tboxID = draw.getTextBox_text(hashtable, parentForm);

                    hashtable = new Hashtable();
                    hashtable.Add("point", new Point(200, 402));
                    hashtable.Add("text", jArray[5].ToString());
                    hashtable.Add("width", 250);
                    hashtable.Add("name", "tboxPassword");
                    hashtable.Add("font", new Font("맑은 고딕", 11));
                    tboxPassword = draw.getTextBox_text(hashtable, parentForm);
                    tboxPassword.PasswordChar = '●';
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void TboxCall_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.ForeColor = Color.Black;
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            parentForm.Close();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (tboxName.Text == "" || tboxPName.Text == "" || tboxCall.Text == "" || tboxAddress.Text == "" || tboxID.Text == "" || tboxPassword.Text == "")
            {
                MessageBox.Show("모두 입력해 주세요");
            }
            else
            {
                hashtable = new Hashtable();
                webAPI = new WebAPI();

                hashtable.Add("cNo", clientNum);
                hashtable.Add("cName", tboxName.Text);
                hashtable.Add("cPName", tboxPName.Text);
                hashtable.Add("cCall", tboxCall.Text);
                hashtable.Add("cAddress", tboxAddress.Text);
                hashtable.Add("cID", tboxID.Text);
                hashtable.Add("cPassword", tboxPassword.Text);

                if(webAPI.Post(Program.serverUrl + "Client/Edit", hashtable))
                {
                    MessageBox.Show("수정 완료");
                    parentForm.Close();
                }
            }
        }
    }
}

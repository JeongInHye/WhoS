using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoSForms.Forms;
using WhoSForms.Modules;

namespace WhoSForms.Views
{
    public class ClientView
    {
        private Form parentForm;
        private Draw draw;
        private Hashtable hashtable;
        private Label lblClientList;
        private ListView listClient;
        private Button btnClientAdd, btnClientEdit, btnClientDelete;
        private WebAPI webAPI;
        private string clientNum = "";

        public ClientView(Form parentForm)
        {
            this.parentForm = parentForm;
            draw = new Draw();
            getView();
        }

        void getView()
        {
            hashtable = new Hashtable();
            hashtable.Add("text", "거래처 목록");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(50, 50));
            hashtable.Add("font", new Font("맑은 고딕", 15, FontStyle.Bold));
            hashtable.Add("name", "주문번호");
            lblClientList = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(900, 500));
            hashtable.Add("point", new Point(50, 90));
            hashtable.Add("click", (MouseEventHandler)listClient_click);
            listClient = draw.getListView_FullSelect(hashtable, parentForm);
            listClient.Columns.Add("번호", 0, HorizontalAlignment.Center);
            listClient.Columns.Add("거래처 명", 200, HorizontalAlignment.Center);
            listClient.Columns.Add("대표자", 150, HorizontalAlignment.Center);
            listClient.Columns.Add("전화번호", 240, HorizontalAlignment.Center);
            listClient.Columns.Add("주소", 300, HorizontalAlignment.Center);
            webAPI = new WebAPI();
            webAPI.ListView(Program.serverUrl + "Client/Select", listClient);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(250, 60));
            hashtable.Add("point", new Point(1050, 150));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btnClientAdd");
            hashtable.Add("text", "거래처 추가");
            hashtable.Add("font", new Font("맑은 고딕", 14, FontStyle.Bold));
            hashtable.Add("click", (EventHandler)ClientAdd_Click);
            btnClientAdd = draw.getButton(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(250, 60));
            hashtable.Add("point", new Point(1050, 250));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btnClientEdit");
            hashtable.Add("text", "거래처 수정");
            hashtable.Add("font", new Font("맑은 고딕", 14, FontStyle.Bold));
            hashtable.Add("click", (EventHandler)ClientEdit_Click);
            btnClientEdit = draw.getButton(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(250, 60));
            hashtable.Add("point", new Point(1050, 350));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btnClientDelete");
            hashtable.Add("text", "거래처 삭제");
            hashtable.Add("font", new Font("맑은 고딕", 14, FontStyle.Bold));
            hashtable.Add("click", (EventHandler)ClientDelete_Click);
            btnClientDelete = draw.getButton(hashtable, parentForm);
        }

        private void listClient_click(object sender, EventArgs e)
        {
            listClient = (ListView)sender;
            ListView.SelectedListViewItemCollection itemGroup = listClient.SelectedItems;
            ListViewItem cNoitem = itemGroup[0];

            clientNum = cNoitem.SubItems[0].Text;
            
            ClientEditForm clientEditForm = new ClientEditForm(clientNum);
        }

        private void ClientAdd_Click(object sender, EventArgs e)
        {
            ClientAddForm clientAddForm = new ClientAddForm(parentForm);

            clientAddForm.StartPosition = FormStartPosition.Manual;
            clientAddForm.Location = new Point(parentForm.Location.X + 500, parentForm.Location.Y + 150/*(parentForm.Height / 2) - (clientAddForm.Height / 2)*/);
            clientAddForm.ShowDialog();
        }

        private void ClientEdit_Click(object sender, EventArgs e)
        {
            if (clientNum == "")
            {
                MessageBox.Show("수정할 거래처를 선택해 주세요");
            }
            else
            {
                ClientEditForm clientEditForm = new ClientEditForm(clientNum);

                clientEditForm.StartPosition = FormStartPosition.Manual;
                clientEditForm.Location = new Point(parentForm.Location.X + 500, parentForm.Location.Y + 150/*(parentForm.Height / 2) - (clientAddForm.Height / 2)*/);
                clientEditForm.ShowDialog();
            }
        }

        private void ClientDelete_Click(object sender, EventArgs e)
        {
            webAPI = new WebAPI();
            string cNo = "";
            bool one = true;

            foreach (ListViewItem listitem in listClient.Items)
            {
                if (listClient.Items.Count > 0)
                {
                    for (int i = listClient.Items.Count - 1; i >= 0; i--)
                    {
                        if (listClient.Items[i].Selected == true)
                        {
                            cNo = clientNum;
                            hashtable = new Hashtable();
                            hashtable.Add("cNo", cNo);
                            webAPI.Post(Program.serverUrl + "Client/Delete", hashtable);
                            if (one)
                            {
                                MessageBox.Show("거래처 삭제");
                                one = false;
                            }
                            listClient.Items[i].Remove();
                        }
                    }
                }
            }
        }

        public void list()
        {
            webAPI.ListView(Program.serverUrl + "Client/Select", listClient);
        }
    }
}

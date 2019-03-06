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
    class ClientView
    {
        private Form parentForm;
        private Draw draw;
        private Hashtable hashtable;
        private Label lblClientList;
        private ListView listClient;
        private Button btnClientAdd, btnClientEdit, btnClientDelete;

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
            listClient = draw.getListView_FullSelect(hashtable, parentForm);
            listClient.Columns.Add("", 0, HorizontalAlignment.Center);
            listClient.Columns.Add("번호", 50, HorizontalAlignment.Center);
            listClient.Columns.Add("거래처 명", 240, HorizontalAlignment.Center);

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

        private void ClientAdd_Click(object sender, EventArgs e)
        {
            ClientAddForm clientAddForm = new ClientAddForm();

            clientAddForm.StartPosition = FormStartPosition.Manual;
            clientAddForm.Location = new Point(parentForm.Location.X+ 500, parentForm.Location.Y + 150/*(parentForm.Height / 2) - (clientAddForm.Height / 2)*/);
            clientAddForm.ShowDialog();
        }

        private void ClientEdit_Click(object sender, EventArgs e)
        {
            ClientEditForm clientEditForm = new ClientEditForm();

            clientEditForm.StartPosition = FormStartPosition.Manual;
            clientEditForm.Location = new Point(parentForm.Location.X + 500, parentForm.Location.Y + 150/*(parentForm.Height / 2) - (clientAddForm.Height / 2)*/);
            clientEditForm.ShowDialog();
        }

        private void ClientDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("거래처 삭제");
        }
    }
}

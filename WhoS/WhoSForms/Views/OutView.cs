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
    class OutView
    {
        private WebAPI webAPI;
        private Form parentForm;
        private Draw draw;
        private Hashtable hashtable;
        private Label lblClientList, lblresList, lblNum;
        private TextBox txtNum;
        private ListView listOne, listTwo;
        private Button btnSelect, btnAllList, btnOutCom;
        private string pNum;

        public OutView(Form parentForm)
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
            hashtable.Add("text", "출고 정보 목록");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(450, 50));
            hashtable.Add("font", new Font("맑은 고딕", 15, FontStyle.Bold));
            hashtable.Add("name", "주문번호");
            lblresList = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("text", "발행번호 : ");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(970, 55));
            hashtable.Add("font", new Font("맑은 고딕", 11));
            hashtable.Add("name", "lblNum");
            lblNum = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(1060, 53));
            hashtable.Add("width", 170);
            hashtable.Add("name", "txtNum");
            hashtable.Add("font", new Font("맑은 고딕", 11));
            txtNum = draw.getTextBox(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(80, 35));
            hashtable.Add("point", new Point(1240, 50));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btnEnter");
            hashtable.Add("text", "조회");
            hashtable.Add("font", new Font("맑은 고딕", 13));
            hashtable.Add("click", (EventHandler)Select_Click);
            btnSelect = draw.getButton(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(300, 500));
            hashtable.Add("point", new Point(50, 90));
            hashtable.Add("click", (MouseEventHandler)ListOne_Click);
            listOne = draw.getListView_FullSelect(hashtable, parentForm);
            listOne.Columns.Add("", 0, HorizontalAlignment.Center);
            listOne.Columns.Add("거래처 명", 290, HorizontalAlignment.Center);
            webAPI = new WebAPI();
            webAPI.ListView(Program.serverUrl + "Enter/ClientName", listOne);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(870, 500));
            hashtable.Add("point", new Point(450, 90));
            hashtable.Add("click", (MouseEventHandler)ListTwo_Click);
            listTwo = draw.getListView_FullSelect(hashtable, parentForm);
            listTwo.Columns.Add("", 0, HorizontalAlignment.Center);
            listTwo.Columns.Add("거래처", 180, HorizontalAlignment.Center);
            listTwo.Columns.Add("물품명", 180, HorizontalAlignment.Center);
            listTwo.Columns.Add("중량", 100, HorizontalAlignment.Center);
            listTwo.Columns.Add("출고예정일", 180, HorizontalAlignment.Center);
            listTwo.Columns.Add("발행번호", 125, HorizontalAlignment.Center);
            listTwo.Columns.Add("비고", 100, HorizontalAlignment.Center);
            webAPI = new WebAPI();
            webAPI.ListView(Program.serverUrl + "Out/AllSelect", listTwo);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(190, 50));
            hashtable.Add("point", new Point(450, 600));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btnAllList");
            hashtable.Add("text", "전체 출고정보 보기");
            hashtable.Add("font", new Font("맑은 고딕", 13, FontStyle.Bold));
            hashtable.Add("click", (EventHandler)AllList_Click);
            btnAllList = draw.getButton(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 50));
            hashtable.Add("point", new Point(1220, 600));
            hashtable.Add("color", Color.FromArgb(47, 85, 151));
            hashtable.Add("name", "btnEnter");
            hashtable.Add("text", "출고완료");
            hashtable.Add("font", new Font("맑은 고딕", 13, FontStyle.Bold));
            hashtable.Add("click", (EventHandler)OutCom_Click);
            btnOutCom = draw.getButton(hashtable, parentForm);
        }

        private void ListTwo_Click(object sender, MouseEventArgs e)
        {
            listTwo = (ListView)sender;
            ListView.SelectedListViewItemCollection itemGroup = listTwo.SelectedItems;
            ListViewItem cNoitem = itemGroup[0];

            pNum = cNoitem.SubItems[5].Text;
        }

        private void OutCom_Click(object sender, EventArgs e)
        {
            webAPI = new WebAPI();
            hashtable = new Hashtable();

            hashtable.Add("pNum", pNum);

            if (webAPI.Post(Program.serverUrl + "Out/OutCom",hashtable))
            {
                MessageBox.Show("출고 완료");
                AllList_Click();
            }
        }

        private void AllList_Click()
        {
            webAPI = new WebAPI();
            webAPI.ListView(Program.serverUrl + "Out/AllSelect", listTwo);
        }

        private void ListOne_Click(object sender, EventArgs e)
        {
            webAPI = new WebAPI();

            listOne = (ListView)sender;
            ListView.SelectedListViewItemCollection itemGroup = listOne.SelectedItems;
            ListViewItem cNoitem = itemGroup[0];

            string cName = cNoitem.SubItems[1].Text;

            hashtable = new Hashtable();
            hashtable.Add("cName", cName);
            webAPI.PostListview(Program.serverUrl + "Out/ClientNameSelect", hashtable, listTwo);
        }

        private void Select_Click(object sender, EventArgs e)
        {
            hashtable = new Hashtable();
            webAPI = new WebAPI();

            hashtable.Add("pNum", txtNum.Text);

            webAPI.PostListview(Program.serverUrl + "Out/OutSelectNum", hashtable, listTwo);

            txtNum.Text = "";
        }

        private void AllList_Click(object sender, EventArgs e)
        {
            webAPI = new WebAPI();
            webAPI.ListView(Program.serverUrl + "Out/AllSelect", listTwo);
        }
    }
}

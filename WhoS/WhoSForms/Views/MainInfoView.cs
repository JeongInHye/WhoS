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
    class MainInfoView
    {
        private Form parentForm;
        private Draw draw;
        private Hashtable hashtable;
        private MonthCalendar monthCalendar;
        private Label lbl,lblInfo,lblDate;
        private TextBox txtNum;
        private Button btnSelect;
        private ListView listData;
        private WebAPI webAPI;

        public MainInfoView(Form parentForm)
        {
            this.parentForm = parentForm;
            draw = new Draw();
            getView();
        }

        private void getView()
        {
            monthCalendar = new MonthCalendar();
            monthCalendar.Location = new Point(100, 90);
            monthCalendar.SuspendLayout();
            parentForm.Controls.Add(monthCalendar);
            monthCalendar.DateSelected += MonthCalendar_DateSelected;
            monthCalendar.DateChanged += MonthCalendar_DateChanged;

            hashtable = new Hashtable();
            hashtable.Add("text", "발행번호 or 거래처 : ");
            hashtable.Add("width", 80);
            hashtable.Add("point", new Point(825, 53));
            hashtable.Add("font", new Font("맑은 고딕", 13, FontStyle.Bold));
            hashtable.Add("name", "lbl");
            lbl = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("text", "* 비고는 선택 날짜 기준임");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(95, 270));
            hashtable.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            hashtable.Add("name", "lbl");
            lblInfo = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("text", "");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(110, 295));
            hashtable.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            hashtable.Add("name", "lbl");
            lblDate = draw.getLabel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(1010, 51));
            hashtable.Add("width", 200);
            hashtable.Add("name", "txtNum");
            hashtable.Add("font", new Font("맑은 고딕", 14));
            txtNum = draw.getTextBox(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(80, 35));
            hashtable.Add("point", new Point(1220, 50));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btnEnter");
            hashtable.Add("text", "조회");
            hashtable.Add("font", new Font("맑은 고딕", 14, FontStyle.Regular));
            hashtable.Add("click", (EventHandler)Enter_Click);
            btnSelect = draw.getButton(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(900, 550));
            hashtable.Add("point", new Point(400, 90));
            listData = draw.getListView(hashtable, parentForm);
            listData.Columns.Add("", 0, HorizontalAlignment.Center);
            listData.Columns.Add("거래처", 180, HorizontalAlignment.Center);
            listData.Columns.Add("물품명",230, HorizontalAlignment.Center);
            listData.Columns.Add("중량", 120, HorizontalAlignment.Center);
            listData.Columns.Add("발행번호", 240, HorizontalAlignment.Center);
            listData.Columns.Add("비고", 120, HorizontalAlignment.Center);
        }

        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblDate.Text = "( " + monthCalendar.SelectionStart.ToShortDateString() + " )";
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            string date = e.Start.ToShortDateString();

            hashtable = new Hashtable();
            webAPI = new WebAPI();

            hashtable.Add("date", date);

            webAPI.PostListview(Program.serverUrl + "Main/Select", hashtable, listData);
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            hashtable = new Hashtable();
            webAPI = new WebAPI();

            hashtable.Add("pNum", txtNum.Text);
            hashtable.Add("cName", txtNum.Text);

            webAPI.PostListview(Program.serverUrl + "Main/MainSelectNum", hashtable, listData);

            txtNum.Text = "";
        }
    }
}

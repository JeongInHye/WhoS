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
        private Label lbl;
        private TextBox txtNum;
        private Button btnSelect;
        private ListView listData;

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

            hashtable = new Hashtable();
            hashtable.Add("text", "발행번호 : ");
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(900, 50));
            hashtable.Add("font", new Font("맑은 고딕", 13, FontStyle.Bold));
            hashtable.Add("name", "lbl");
            lbl = draw.getLabel(hashtable, parentForm);

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
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("asdf");
        }
    }
}

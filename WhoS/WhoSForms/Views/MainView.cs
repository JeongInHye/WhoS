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

namespace WhoSForms.View
{
    class MainView
    {
        private Hashtable hashtable;
        private Draw draw;
        private Form parentForm, tagetForm;
        private Button btn_main, btn_enter, btn_out, btn_location, btn_client, btn_income;
        private Panel pnl_head, pnl_contents;

        public MainView(Form parentForm)
        {
            this.parentForm = parentForm;
            draw = new Draw();
            getView();
        }

        private void getView()
        {
            //위 패널----------------------------------------------------
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1385, 85));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "pnl_head");
            pnl_head = draw.getPanel(hashtable, parentForm);

            //아래 패널----------------------------------------------------
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1385, 676));
            hashtable.Add("point", new Point(0, 85));
            //hashtable.Add("color", Color.LightCoral);
            hashtable.Add("color", Color.FromArgb(240, 240, 240));
            hashtable.Add("name", "pnl_contents");
            pnl_contents = draw.getPanel(hashtable, parentForm);

            //버튼들--------------------------------------------------------
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(160, 85));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.FromArgb(240, 240, 240));
            hashtable.Add("name", "btn_main");
            hashtable.Add("text", "메인화면");
            hashtable.Add("font", new Font("맑은 고딕", 14, FontStyle.Regular));
            hashtable.Add("click", (EventHandler)Main_Click);
            btn_main = draw.getButton(hashtable, pnl_head);
            btn_main.ForeColor = Color.FromArgb(71, 70, 68);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(160, 85));
            hashtable.Add("point", new Point(160, 0));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btn_enter");
            hashtable.Add("text", "입고");
            hashtable.Add("font", new Font("맑은 고딕", 14, FontStyle.Regular));
            hashtable.Add("click", (EventHandler)Enter_Click);
            btn_enter = draw.getButton(hashtable, pnl_head);


            hashtable = new Hashtable();
            hashtable.Add("size", new Size(160, 85));
            hashtable.Add("point", new Point(320, 0));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btn_out");
            hashtable.Add("text", "출고");
            hashtable.Add("font", new Font("맑은 고딕", 14, FontStyle.Regular));
            hashtable.Add("click", (EventHandler)Out_Click);
            btn_out = draw.getButton(hashtable, pnl_head);
            btn_out.ForeColor = Color.FromArgb(240, 240, 240);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(160, 85));
            hashtable.Add("point", new Point(480, 0));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btn_location");
            hashtable.Add("text", "적재정보");
            hashtable.Add("font", new Font("맑은 고딕", 14, FontStyle.Regular));
            hashtable.Add("click", (EventHandler)Location_Click);
            btn_location = draw.getButton(hashtable, pnl_head);
            btn_location.ForeColor = Color.FromArgb(240, 240, 240);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(160, 85));
            hashtable.Add("point", new Point(640, 0));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btn_client");
            hashtable.Add("text", "거래처");
            hashtable.Add("font", new Font("맑은 고딕", 14, FontStyle.Regular));
            hashtable.Add("click", (EventHandler)Client_Click);
            btn_client = draw.getButton(hashtable, pnl_head);
            btn_client.ForeColor = Color.FromArgb(240, 240, 240);

            //hashtable = new Hashtable();
            //hashtable.Add("size", new Size(160, 85));
            //hashtable.Add("point", new Point(800, 0));
            //hashtable.Add("color", Color.FromArgb(71, 70, 68));
            //hashtable.Add("name", "btn_income");
            //hashtable.Add("text", "매출");
            //hashtable.Add("font", new Font("맑은 고딕", 14, FontStyle.Regular));
            //hashtable.Add("click", (EventHandler)Income_Click);
            //btn_income = draw.getButton(hashtable, pnl_head);
            //btn_income.ForeColor = Color.FromArgb(240, 240, 240);

            if (tagetForm != null) tagetForm.Dispose();
            tagetForm = draw.getMdiForm(parentForm, new MainInfoForm(), pnl_contents);
            tagetForm.Show();
        }

        private void Main_Click(object sender, EventArgs e)
        {
            btn_main.BackColor = Color.FromArgb(240, 240, 240);
            btn_main.ForeColor = Color.FromArgb(71, 70, 68);

            btn_enter.BackColor = Color.FromArgb(71, 70, 68);
            btn_enter.ForeColor = Color.FromArgb(240, 240, 240);
            btn_out.BackColor = Color.FromArgb(71, 70, 68);
            btn_out.ForeColor = Color.FromArgb(240, 240, 240);
            btn_location.BackColor = Color.FromArgb(71, 70, 68);
            btn_location.ForeColor = Color.FromArgb(240, 240, 240);
            btn_client.BackColor = Color.FromArgb(71, 70, 68);
            btn_client.ForeColor = Color.FromArgb(240, 240, 240);
            //btn_income.BackColor = Color.FromArgb(71, 70, 68);
            //btn_income.ForeColor = Color.FromArgb(240, 240, 240);

            if (tagetForm != null) tagetForm.Dispose();

            tagetForm = draw.getMdiForm(parentForm, new MainInfoForm(), pnl_contents);
            tagetForm.Show();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            btn_enter.BackColor = Color.FromArgb(240, 240, 240);
            btn_enter.ForeColor = Color.FromArgb(71, 70, 68);

            btn_main.BackColor = Color.FromArgb(71, 70, 68);
            btn_main.ForeColor = Color.FromArgb(240, 240, 240);
            btn_out.BackColor = Color.FromArgb(71, 70, 68);
            btn_out.ForeColor = Color.FromArgb(240, 240, 240);
            btn_location.BackColor = Color.FromArgb(71, 70, 68);
            btn_location.ForeColor = Color.FromArgb(240, 240, 240);
            btn_client.BackColor = Color.FromArgb(71, 70, 68);
            btn_client.ForeColor = Color.FromArgb(240, 240, 240);
            //btn_income.BackColor = Color.FromArgb(71, 70, 68);
            //btn_income.ForeColor = Color.FromArgb(240, 240, 240);

            if (tagetForm != null) tagetForm.Dispose();

            tagetForm = draw.getMdiForm(parentForm, new EnterForm(), pnl_contents);
            tagetForm.Show();
        }

        private void Out_Click(object sender, EventArgs e)
        {
            btn_out.BackColor = Color.FromArgb(240, 240, 240);
            btn_out.ForeColor = Color.FromArgb(71, 70, 68);

            btn_main.BackColor = Color.FromArgb(71, 70, 68);
            btn_main.ForeColor = Color.FromArgb(240, 240, 240);
            btn_enter.BackColor = Color.FromArgb(71, 70, 68);
            btn_enter.ForeColor = Color.FromArgb(240, 240, 240);
            btn_location.BackColor = Color.FromArgb(71, 70, 68);
            btn_location.ForeColor = Color.FromArgb(240, 240, 240);
            btn_client.BackColor = Color.FromArgb(71, 70, 68);
            btn_client.ForeColor = Color.FromArgb(240, 240, 240);
            //btn_income.BackColor = Color.FromArgb(71, 70, 68);
            //btn_income.ForeColor = Color.FromArgb(240, 240, 240);

            if (tagetForm != null) tagetForm.Dispose();

            tagetForm = draw.getMdiForm(parentForm, new OutForm(), pnl_contents);
            tagetForm.Show();
        }

        private void Location_Click(object sender, EventArgs e)
        {
            btn_location.BackColor = Color.FromArgb(240, 240, 240);
            btn_location.ForeColor = Color.FromArgb(71, 70, 68);

            btn_main.BackColor = Color.FromArgb(71, 70, 68);
            btn_main.ForeColor = Color.FromArgb(240, 240, 240);
            btn_enter.BackColor = Color.FromArgb(71, 70, 68);
            btn_enter.ForeColor = Color.FromArgb(240, 240, 240);
            btn_out.BackColor = Color.FromArgb(71, 70, 68);
            btn_out.ForeColor = Color.FromArgb(240, 240, 240);
            btn_client.BackColor = Color.FromArgb(71, 70, 68);
            btn_client.ForeColor = Color.FromArgb(240, 240, 240);
            //btn_income.BackColor = Color.FromArgb(71, 70, 68);
            //btn_income.ForeColor = Color.FromArgb(240, 240, 240);

            if (tagetForm != null) tagetForm.Dispose();

            tagetForm = draw.getMdiForm(parentForm, new LocationForm(), pnl_contents);
            tagetForm.Show();
        }

        private void Client_Click(object sender, EventArgs e)
        {
            btn_client.BackColor = Color.FromArgb(240, 240, 240);
            btn_client.ForeColor = Color.FromArgb(71, 70, 68);

            btn_main.BackColor = Color.FromArgb(71, 70, 68);
            btn_main.ForeColor = Color.FromArgb(240, 240, 240);
            btn_enter.BackColor = Color.FromArgb(71, 70, 68);
            btn_enter.ForeColor = Color.FromArgb(240, 240, 240);
            btn_out.BackColor = Color.FromArgb(71, 70, 68);
            btn_out.ForeColor = Color.FromArgb(240, 240, 240);
            btn_location.BackColor = Color.FromArgb(71, 70, 68);
            btn_location.ForeColor = Color.FromArgb(240, 240, 240);
            //btn_income.BackColor = Color.FromArgb(71, 70, 68);
            //btn_income.ForeColor = Color.FromArgb(240, 240, 240);

            if (tagetForm != null) tagetForm.Dispose();

            tagetForm = draw.getMdiForm(parentForm, new ClientForm(), pnl_contents);
            tagetForm.Show();
        }

        //private void Income_Click(object sender, EventArgs e)
        //{
        //    btn_income.BackColor = Color.FromArgb(240, 240, 240);
        //    btn_income.ForeColor = Color.FromArgb(71, 70, 68);

        //    btn_main.BackColor = Color.FromArgb(71, 70, 68);
        //    btn_main.ForeColor = Color.FromArgb(240, 240, 240);
        //    btn_enter.BackColor = Color.FromArgb(71, 70, 68);
        //    btn_enter.ForeColor = Color.FromArgb(240, 240, 240);
        //    btn_out.BackColor = Color.FromArgb(71, 70, 68);
        //    btn_out.ForeColor = Color.FromArgb(240, 240, 240);
        //    btn_location.BackColor = Color.FromArgb(71, 70, 68);
        //    btn_location.ForeColor = Color.FromArgb(240, 240, 240);
        //    btn_client.BackColor = Color.FromArgb(71, 70, 68);
        //    btn_client.ForeColor = Color.FromArgb(240, 240, 240);

        //    if (tagetForm != null) tagetForm.Dispose();

        //    tagetForm = draw.getMdiForm(parentForm, new IncomeForm(), pnl_contents);
        //    tagetForm.Show();
        //}
    }
}
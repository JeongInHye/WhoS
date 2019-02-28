using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WhoSForms.Modules
{
    class Draw
    {
        public Form getMdiForm(Form parentForm, Form tagetForm, Control parentDomain)
        {
            parentForm.IsMdiContainer = true;
            tagetForm.MdiParent = parentForm;
            tagetForm.WindowState = FormWindowState.Maximized;
            tagetForm.FormBorderStyle = FormBorderStyle.None;
            tagetForm.Dock = DockStyle.Fill;                                                           
            parentDomain.Controls.Add(tagetForm);
            return tagetForm;
        }

        public Panel getPanel(Hashtable hashtable, Control parentDomain)
        {
            Panel panel = new Panel();
            panel.Size = (Size)hashtable["size"];
            panel.Location = (Point)hashtable["point"];
            panel.BackColor = (Color)hashtable["color"];
            panel.Name = hashtable["name"].ToString();
            parentDomain.Controls.Add(panel);
            return panel;
        }

        public Label getLabel(Hashtable hashtable, Control parentDomain)
        {
            Label label = new Label();
            label.AutoSize = true;
            //label.Width = (int)hashtable["width"];
            //label.TextAlign = ContentAlignment.MiddleRight;
            label.Location = (Point)hashtable["point"];
            label.Name = hashtable["name"].ToString();
            label.Text = hashtable["text"].ToString();
            label.Font = (Font)hashtable["font"];
            parentDomain.Controls.Add(label);
            return label;
        }

        public Button getButton(Hashtable hashtable, Control parentDomain)
        {
            Button button = new Button();
            button.TabStop = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Size = (Size)hashtable["size"];
            button.Location = (Point)hashtable["point"];
            button.BackColor = (Color)hashtable["color"];
            button.Name = hashtable["name"].ToString();
            button.Text = hashtable["text"].ToString();
            button.Font = (Font)hashtable["font"];
            button.Click += (EventHandler)hashtable["click"];
            button.Cursor = Cursors.Hand;
            parentDomain.Controls.Add(button);
            return button;
        }

        public Button getButton_menu(Hashtable hashtable, Control parentDomain)
        {
            Button button = new Button();
            button.TabStop = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Size = (Size)hashtable["size"];
            button.Location = (Point)hashtable["point"];
            button.BackColor = (Color)hashtable["color"];
            button.Name = hashtable["name"].ToString();
            button.Text = hashtable["text"].ToString();
            button.Font = (Font)hashtable["font"];
            button.Click += (EventHandler)hashtable["click"];
            button.Cursor = Cursors.Hand;
            button.ForeColor = Color.FromArgb(240, 240, 240);
            button.TabStop = false;
            button.FlatAppearance.BorderSize = 1;
            parentDomain.Controls.Add(button);
            return button;
        }

        public TextBox getTextBox(Hashtable hashtable, Control parentDomain)
        {
            TextBox textBox = new TextBox();
            textBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            textBox.Location = (Point)hashtable["point"];
            textBox.Name = hashtable["name"].ToString();
            //textBox.BackColor = (Color)hashtable["color"];
            //textBox.Enabled = (bool)hashtable["enabled"];
            parentDomain.Controls.Add(textBox);
            return textBox;
        }

        public ListView getListView_Check(Hashtable hashtable, Control parentDomain)
        {
            ListView listView = new ListView();
            listView.View = System.Windows.Forms.View.Details;
            listView.GridLines = true;
            listView.Location = (Point)hashtable["point"];
            listView.Size = (Size)hashtable["size"];
            listView.BackColor = (Color)hashtable["color"];
            listView.Name = hashtable["name"].ToString();
            listView.CheckBoxes = true;
            listView.MouseClick += (MouseEventHandler)hashtable["click"];
            listView.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
            parentDomain.Controls.Add(listView);
            return listView;
        }

        public ListView getListView_FullSelect(Hashtable hashtable, Control parentDomain)
        {
            ListView listView = new ListView();
            listView.View = System.Windows.Forms.View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.Location = (Point)hashtable["point"];
            listView.Size = (Size)hashtable["size"];
            listView.BackColor = (Color)hashtable["color"];
            listView.Name = hashtable["name"].ToString();
            listView.MouseClick += (MouseEventHandler)hashtable["click"];
            listView.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
            parentDomain.Controls.Add(listView);
            return listView;
        }

        public DateTimePicker getDateTimePicker(Hashtable hashtable, Control parentDomain)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Font = new Font("맑은 고딕", 11);
            dateTimePicker.Location = (Point)hashtable["point"];
            dateTimePicker.Name = hashtable["name"].ToString();
            dateTimePicker.Size = (Size)hashtable["size"];
            dateTimePicker.TabIndex = 0;
            parentDomain.Controls.Add(dateTimePicker);
            return dateTimePicker;
        }

        public Chart getChart(Hashtable hashtable, Control parentDomain)
        {
            ChartArea chartArea = new ChartArea();
            Chart chart = new Chart();
            Series series = new Series();
            //=================chart area===========================
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.Name = "ChartArea";
            chartArea.AxisX.IsLabelAutoFit = true;
            chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap;
            //chartArea.BackColor = Color.AliceBlue;
            //===================chart==============================
            chart.ChartAreas.Add(chartArea);
            chart.Location = (Point)hashtable["point"];
            chart.Name = hashtable["name"].ToString();

            series.ChartArea = "ChartArea";
            series.Name = "Series";
            //series.BorderColor = Color.Black;
            //series.BorderWidth = 1;
            //series.LabelAngle = 90;
            chart.Series.Add(series);
            chart.Size = (Size)hashtable["size"];
            parentDomain.Controls.Add(chart);
            return chart;
        }
    }
}

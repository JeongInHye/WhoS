using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoSForms.Modules;

namespace WhoSForms.Views
{
    class LocationView
    {
        private WebAPI webAPI;
        private Form parentForm;
        private Draw draw;
        private Hashtable hashtable;
        private Button btnLocation, btnAllLocation;
        private ListView listLocation;

        public LocationView(Form parentForm)
        {
            this.parentForm = parentForm;
            draw = new Draw();
            getView();
        }

        void getView()
        {
            LocationButton();

            //Num(Program.serverUrl + "Location/test");


            hashtable = new Hashtable();
            hashtable.Add("size", new Size(600, 500));
            hashtable.Add("point", new Point(710, 90));
            listLocation = draw.getListView(hashtable, parentForm);
            listLocation.Columns.Add("", 0, HorizontalAlignment.Center);
            listLocation.Columns.Add("거래처 명", 120, HorizontalAlignment.Center);
            listLocation.Columns.Add("물품명", 100, HorizontalAlignment.Center);
            listLocation.Columns.Add("입고일", 130, HorizontalAlignment.Center);
            listLocation.Columns.Add("출고 예정일", 165, HorizontalAlignment.Center);
            listLocation.Columns.Add("위치", 80, HorizontalAlignment.Center);
            webAPI = new WebAPI();
            webAPI.ListView(Program.serverUrl + "Location/AllSelect", listLocation);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(190, 50));
            hashtable.Add("point", new Point(1120, 600));
            hashtable.Add("color", Color.FromArgb(71, 70, 68));
            hashtable.Add("name", "btnAllLocation");
            hashtable.Add("text", "전체 적재정보 보기");
            hashtable.Add("font", new Font("맑은 고딕", 13, FontStyle.Bold));
            hashtable.Add("click", (EventHandler)AllLocation_Click);
            btnAllLocation = draw.getButton(hashtable, parentForm);
        }

        private void AllLocation_Click(object sender, EventArgs e)
        {
            webAPI = new WebAPI();
            webAPI.ListView(Program.serverUrl + "Location/AllSelect", listLocation);
        }

        void LocationButton()
        {
            int count = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    count++;
                    hashtable = new Hashtable();
                    hashtable.Add("size", new Size(80, 80));
                    if (i >= 2 && i <= 3)
                    {
                        hashtable.Add("point", new Point(100 + (90 * j), 80 + (90 * i)));
                    }
                    else if (i >= 4 && i <= 5)
                    {
                        hashtable.Add("point", new Point(100 + (90 * j), 110 + (90 * i)));
                    }
                    else
                        hashtable.Add("point", new Point(100 + (90 * j), 60 + (90 * i)));
                    hashtable.Add(string.Format("name", "{0}"), count);
                    hashtable.Add(string.Format("text", "{0}"), count);
                    hashtable.Add("font", new Font("맑은 고딕", 13));
                    hashtable.Add("click", (EventHandler)Location_Click);

                    WebClient wc = new WebClient();
                    Stream stream = wc.OpenRead(Program.serverUrl + "Location/test");
                    StreamReader sr = new StreamReader(stream);
                    string result = sr.ReadToEnd();
                    ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);

                    for (int k = 0; k < list.Count; k++)
                    {
                        JArray jArray = (JArray)list[k];
                        string[] arr = new string[list.Count];
                        for (int m = 0; m < jArray.Count; m++)
                        {
                            arr[m] = jArray[m].ToString();
                            if (hashtable["name"].ToString() == arr[m].ToString())
                            {
                                hashtable.Add("color", Color.FromArgb(71, 70, 68));
                            }
                        }
                    }
                    if (hashtable["color"] == null)
                    {
                        hashtable.Add("color", Color.FromArgb(175, 171, 171));
                    }
                    btnLocation = draw.getButton(hashtable, parentForm);
                }
            }
        }



        private void Location_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string lNo = button.Name;

            webAPI = new WebAPI();
            hashtable = new Hashtable();

            hashtable.Add("lNo", lNo);

            if (webAPI.PostListview(Program.serverUrl + "Location/LocationBtn", hashtable, listLocation))
            {
                lNo = "";
            }
        }

        //public bool Num(string url)
        //{
        //    MessageBox.Show(btnLocation.Name);
        //    try
        //    {
        //        WebClient wc = new WebClient();
        //        Stream stream = wc.OpenRead(Program.serverUrl + "Location/test");
        //        StreamReader sr = new StreamReader(stream);
        //        string result = sr.ReadToEnd();
        //        ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);

        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            JArray jArray = (JArray)list[i];
        //            string[] arr = new string[list.Count];
        //            for (int j = 0; j < jArray.Count; j++)
        //            {
        //                arr[j] = jArray[j].ToString();
        //                //MessageBox.Show(arr[j].ToString());
        //            }
        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
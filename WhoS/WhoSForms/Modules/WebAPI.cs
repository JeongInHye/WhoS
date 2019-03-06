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
using static System.Windows.Forms.ListView;

namespace WhoSForms.Modules
{
    class WebAPI
    {
        public bool ListView(string url, ListView listView)
        {
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);
                StreamReader sr = new StreamReader(stream);
                string result = sr.ReadToEnd();
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);
                listView.Items.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    JArray jArray = (JArray)list[i];
                    string[] arr = new string[jArray.Count];
                    for (int j = 0; j < jArray.Count; j++)
                    {
                        arr[j] = jArray[j].ToString();
                    }
                    listView.Items.Add(new ListViewItem(arr));
                    listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                    listView.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
                }

                ListViewItemCollection col = listView.Items;    // listview subitems 글꼴 바꾸기
                for (int j = 0; j < col.Count; j++)
                {
                    for (int k = 0; k < col[j].SubItems.Count; k++)
                    {
                        col[j].SubItems[k].Font = new Font("맑은 고딕", 12, FontStyle.Regular);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

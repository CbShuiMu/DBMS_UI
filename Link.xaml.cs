using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DBMS_UI
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            //发送MySql信息
            IList<MySql> MySql = new List<MySql>
            {
                new MySql
                {
                    LinkName=LinkName.Text,
                    Username=Username.Text,
                    Password=Password.Text

                }
            };
            string json = MySql.ToJson();
            PipeClient.MainSend(json);
            MessageBox.Show("连接成功");
            this.Close();
            //PipeClient.MainSend("LinkName = " + LinkName.Text);
            //PipeClient.MainSend("Username = " + Username.Text);
            //PipeClient.MainSend("Password = " + Password.Text);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            //关闭当前窗口
           this.Close();
        }
        public class MySql
        {
            public string LinkName;
            public string Username;
            public string Password;
        }

    }
    static class JsonHelper
    {
        public static string ToJson(this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("传入obj为空，无法继续处理请求返回！");
            }
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObj<T>(this string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("传入Json为空，无法继续处理请求返回！");
            }
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

}

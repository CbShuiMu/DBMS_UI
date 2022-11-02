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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DBMS_UI
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        private void Confirm(object sender, RoutedEventArgs e)
        {
            //发送MySql信息
            IList<DataBase> DataBase = new List<DataBase>
            {
                new DataBase
                {
                    DataBaseName=DataBaseName.Text,

                }
            };
            string json = DataBase.ToJson();
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
        public class DataBase
        {
            public string DataBaseName;
        }
    }

}

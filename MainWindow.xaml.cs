using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBMS_UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.grid.MouseLeftButtonDown += (o, e) => { DragMove(); };
        }

        private void UnFold(object sender, RoutedEventArgs e)
        {
            if(Shuimu.IsExpanded == false)
            {
                Shuimu.IsExpanded = true;
            }
            else
            {
                Shuimu.IsExpanded = false;
            }
        }

        private void test(object sender, RoutedEventArgs e)
        {
            string s  = PipeClient.MainSend("ShuiMu");
            Button b1 = new Button();
            WrapPanel wrapPanel1 = new WrapPanel();
            //MessageBox.Show(s);
            Expander e1 = new Expander();
            Style Expanderstyle = this.FindResource("ExpanderStyle1")as Style;
            HeaderedContentControl headeredContentControl2 = new HeaderedContentControl();
            Image image = this.FindResource("Mysql") as Image;
            TextBlock textBlock=new TextBlock();
            textBlock.Text = s;
            wrapPanel1.Children.Add(image);
            wrapPanel1.Children.Add(textBlock);
            b1.Style = this.FindResource("ButtonThree") as Style;
            b1.Content = wrapPanel1;
            b1.ContextMenu = this.FindResource("MySqlMenu") as ContextMenu;
            headeredContentControl2.Content=b1;
            e1.Name = s;
            e1.Style = Expanderstyle;
            e1.Header = headeredContentControl2;
            MySqlMenu.Children.Add(e1);
            //MySqlMenu.Children.Add(b1);
            //MessageBox.Show("Hello");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void LinkMenu_Initialized(object sender, EventArgs e)

        {

            //设置右键菜单为null

            this.Link.ContextMenu = null;

        }
        private void LinkMenu_Click(object sender, RoutedEventArgs e)

        {

            //目标

            this.LinkMenu.PlacementTarget = this.Link;

            //位置

            this.LinkMenu.Placement = PlacementMode.Bottom;

            //显示菜单

            this.LinkMenu.IsOpen = true;

        }
        private void LinkWindow_Click(object sender, RoutedEventArgs e)
        {
            Window1 LinkWindows = new Window1();
            LinkWindows.Show();
        }
    }
}

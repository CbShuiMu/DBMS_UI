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
using NPOI.SS.UserModel;    //提供ISheet、IRow、ICell等接口
using NPOI.XSSF.UserModel;  //提供相关类操作扩展名为xlsx的2007之后版本Excel文件
using NPOI.HSSF.UserModel;  //提供相关类操作扩展名为xls的2007之前版本Excel文件
using System.IO;
using System.Data;
using NPOI.SS.Formula.Functions;

namespace DBMS_UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt = new DataTable();
        private int newColumnIndex = 1;
        public MainWindow()
        {
            InitializeComponent();
            this.grid.MouseLeftButtonDown += (o, e) => { DragMove(); };
        }

        private void test1(object sender, RoutedEventArgs e)//添加MySql
        {
            //接收后端来的测试信息
            string s  = PipeClient.MainSend("MySql");
            //设置Expander.Header的样式
            HeaderedContentControl headeredContentControl2 = new HeaderedContentControl();
            //设置图片
            Image image = this.FindResource("MySql") as Image;
            //设置文本框(用于显示数据库名)
            TextBlock textBlock = new TextBlock();
            textBlock.Text = s;
            //设置环绕面板
            WrapPanel wrapPanel1 = new WrapPanel();
            wrapPanel1.Height = 20;
            wrapPanel1.Width = 220;
            wrapPanel1.Children.Add(image);
            wrapPanel1.Children.Add(textBlock);
            //设置按钮
            ToggleButton b1 = new ToggleButton();
            b1.Name = s + "MySqlButton";
            b1.Style = this.FindResource("ToggleButtonOne") as Style;
            b1.Content = wrapPanel1;
            b1.ContextMenu = this.FindResource("MySqlMenu") as ContextMenu;
            headeredContentControl2.Content=b1;
            //设置数据绑定（将按钮与expander连接）
            Binding binding = new Binding()
            {
                Path = new PropertyPath("IsChecked"),
                ElementName = s + "MySqlButton",
            };
            //设置折叠菜单
            Expander e1 = new Expander();
            Style Expanderstyle = this.FindResource("ExpanderStyle1") as Style;
            e1.Name = "MySql"+s;
            e1.Style = Expanderstyle;
            e1.Header = headeredContentControl2;
            e1.SetBinding(Expander.IsExpandedProperty, binding);
            //添加菜单
            MySqlMenu.Children.Add(e1);
        }

        private void test2(object sender, RoutedEventArgs e)//添加数据库
        {
            //接收后端来的测试信息
            string s = PipeClient.MainSend("DataBase");
            //设置Expander.Header的样式
            HeaderedContentControl headeredContentControl2 = new HeaderedContentControl();
            //设置图片
            Image image = this.FindResource("DataBase") as Image;
            //设置文本框(用于显示数据库名)
            TextBlock textBlock = new TextBlock();
            textBlock.Text = s;
            //设置环绕面板
            WrapPanel wrapPanel1 = new WrapPanel();
            wrapPanel1.Height = 20;
            wrapPanel1.Width = 220;
            wrapPanel1.Children.Add(image);
            wrapPanel1.Children.Add(textBlock);
            //设置按钮
            ToggleButton b1 = new ToggleButton();
            b1.Name = s + "DataBaseButton";
            b1.Style = this.FindResource("ToggleButtonOne") as Style;
            b1.Content = wrapPanel1;
            b1.ContextMenu = this.FindResource("DataBaseMenu") as ContextMenu;
            headeredContentControl2.Content = b1;
            //设置数据绑定（将按钮与expander连接）
            Binding binding = new Binding()
            {
                Path = new PropertyPath("IsChecked"),
                ElementName = s + "DataBaseButton",
            };
            //设置折叠菜单
            Expander e1 = new Expander();
            Style Expanderstyle = this.FindResource("ExpanderStyle1") as Style;
            e1.Name = "DataBase" + s;
            e1.Style = Expanderstyle;
            e1.Header = headeredContentControl2;
            e1.SetBinding(Expander.IsExpandedProperty, binding);
            //添加菜单
            MySqlMenu.Children.Add(e1);
        }
        private void DataBase_Add(object sender, RoutedEventArgs e)//添加数据库
        {
            //接收后端来的测试信息
            string s = PipeClient.MainSend("MySql");
            //设置Expander.Header的样式
            HeaderedContentControl headeredContentControl2 = new HeaderedContentControl();
            //设置图片
            Image image = this.FindResource("DataBase") as Image;
            //设置文本框(用于显示数据库名)
            TextBlock textBlock = new TextBlock();
            textBlock.Text = s;
            //设置环绕面板
            WrapPanel wrapPanel1 = new WrapPanel();
            wrapPanel1.Height = 20;
            wrapPanel1.Width = 220;
            wrapPanel1.Children.Add(image);
            wrapPanel1.Children.Add(textBlock);
            //设置按钮
            ToggleButton b1 = new ToggleButton();
            b1.Name = s + "DataBaseButton";
            b1.Style = this.FindResource("ToggleButtonOne") as Style;
            b1.Content = wrapPanel1;
            b1.ContextMenu = this.FindResource("DataBaseMenu") as ContextMenu;
            headeredContentControl2.Content = b1;
            //设置数据绑定（将按钮与expander连接）
            Binding binding = new Binding()
            {
                Path = new PropertyPath("IsChecked"),
                ElementName = s + "DataBaseButton",
            };
            //设置折叠菜单
            Expander e1 = new Expander();
            Style Expanderstyle = this.FindResource("ExpanderStyle1") as Style;
            e1.Name = "DataBase"+s;
            e1.Style = Expanderstyle;
            e1.Header = headeredContentControl2;
            e1.SetBinding(Expander.IsExpandedProperty, binding);
            //添加菜单
            MySqlMenu.Children.Add(e1);
        }

        private void MySql_Add(object sender, RoutedEventArgs e)//添加MySql
        {
            //接收后端来的测试信息
            string s = PipeClient.MainSend("ShuiMu");
            //设置Expander.Header的样式
            HeaderedContentControl headeredContentControl2 = new HeaderedContentControl();
            //设置图片
            Image image = this.FindResource("Mysql") as Image;
            //设置文本框(用于显示数据库名)
            TextBlock textBlock = new TextBlock();
            textBlock.Text = s;
            //设置环绕面板
            WrapPanel wrapPanel1 = new WrapPanel();
            wrapPanel1.Height = 20;
            wrapPanel1.Width = 220;
            wrapPanel1.Children.Add(image);
            wrapPanel1.Children.Add(textBlock);
            //设置按钮
            ToggleButton b1 = new ToggleButton();
            b1.Name = s + "MySqlButton";
            b1.Style = this.FindResource("ToggleButtonOne") as Style;
            b1.Content = wrapPanel1;
            b1.ContextMenu = this.FindResource("MySqlMenu") as ContextMenu;
            headeredContentControl2.Content = b1;
            //设置数据绑定（将按钮与expander连接）
            Binding binding = new Binding()
            {
                Path = new PropertyPath("IsChecked"),
                ElementName = s + "MySqlButton",
            };
            //设置折叠菜单
            Expander e1 = new Expander();
            Style Expanderstyle = this.FindResource("ExpanderStyle1") as Style;
            e1.Name = "MySql"+s;
            e1.Style = Expanderstyle;
            e1.Header = headeredContentControl2;
            e1.SetBinding(Expander.IsExpandedProperty, binding);
            //添加菜单
            MySqlMenu.Children.Add(e1);
        }

        private void MySql_Del(object sender, RoutedEventArgs e)//删除MySql
        {
            //Content btn = sender as ToggleButton;
            Expander e1 = this.FindName("db1") as Expander;
            MySqlMenu.Children.Remove(e1);
            MessageBox.Show("删除成功");
        }
        private void New_Query(object sender, RoutedEventArgs e)//新建查询
        {
            C_RichTextBox.Visibility = Visibility.Visible;
            SendCode_Button.Visibility=Visibility.Visible;
            DataGrid1.Visibility = Visibility.Collapsed;
            DataGrid_ButtonPanel.Visibility = Visibility.Collapsed;
        }

        private void New_Form(object sender, RoutedEventArgs e)//新建表
        {
            C_RichTextBox.Visibility = Visibility.Collapsed;
            SendCode_Button.Visibility = Visibility.Collapsed;
            DataGrid1.Visibility = Visibility.Visible;
            DataGrid_ButtonPanel.Visibility = Visibility.Visible;
        }

        private void Send_Code(object sender, RoutedEventArgs e)//删除行
        {

            TextSelection selection = C_RichTextBox.Selection;
            string selected_string = selection.Text;
            PipeClient.MainSend(selected_string);

            //PipeClient.MainSend("Hello Pipe");
            //MessageBox.Show(result);
        }

        private void Row_Add(object sender, RoutedEventArgs e)//添加行
        {

            DataRow row = dt.NewRow();
            dt.Rows.Add(row);
            if (dt.Rows.Count > 0)
            {
                BrushConverter conv1 = new BrushConverter();
                Brush bru1 = conv1.ConvertFromInvariantString("#F0F0F0") as Brush;
                RowDel_Button.Background = bru1;
                RowDel_Button.IsEnabled = true;
            }
        }

        private void Row_Del(object sender, RoutedEventArgs e)//删除行
        {
            if (dt.Rows.Count > 0)
            {
                if (DataGrid1.SelectedIndex != -1 && DataGrid1.SelectedIndex != 0 && DataGrid1.SelectedIndex != dt.Rows.Count)
                {
                    dt.Rows.RemoveAt(DataGrid1.SelectedIndex);
                }
                else
                {
                    dt.Rows.RemoveAt(dt.Rows.Count - 1);
                    if (dt.Rows.Count <= 0)
                    {
                        BrushConverter conv2 = new BrushConverter();　　// 方法1，按钮置灰
                        Brush bru2 = conv2.ConvertFromInvariantString("#FF255687") as Brush;
                        RowDel_Button.Background = bru2;

                        //SolidColorBrush myBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0x25, 0x56, 0x87));  // 方法2 按钮置灰
                        //deleteRowBtn.Background = (System.Windows.Media.Brush)myBrush;

                        //deleteRowBtn.Background = System.Windows.Media.Brushes.ForestGreen; //方法3

                        RowDel_Button.IsEnabled = false;
                    }
                }
            }
        }

        private void Row_Save(object sender, RoutedEventArgs e)//保存并发送表格数据给后端
        {

        }

        private void Show_Form(object sender, RoutedEventArgs e)
        {
            C_RichTextBox.Visibility = Visibility.Collapsed;
            SendCode_Button.Visibility = Visibility.Collapsed;
            DataGrid1.Visibility = Visibility.Visible;
            DataGrid_ButtonPanel.Visibility = Visibility.Visible;

            dt.Columns.Add("ID", typeof(int));

            dt.Columns.Add("Name", typeof(string));

            DataRow row = dt.NewRow();

            row["ID"] = 1;

            row["Name"] = "张三";

            dt.Rows.Add(row);

            row = dt.NewRow();

            row["ID"] = 2;

            row["Name"] = "李四";

            dt.Rows.Add(row);

            DataGrid1.DataContext = dt;

            DataGrid1.ItemsSource = dt.DefaultView;

            //设置网格线

            //DataGrid1.GridLinesVisibility = DataGridGridLinesVisibility.All;
        }

        private void DataGrid01_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            TextBlock textBlock = e.Column.GetCellContent(e.Row) as TextBlock;
            if (textBlock == null)
            {
                return;
            }
            string value = textBlock.Text;
            MessageBox.Show(value);
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
        private void LinkWindow_Open(object sender, RoutedEventArgs e)
        {
            Window1 LinkWindows = new Window1();
            LinkWindows.Show();
        }

        private void DataBaseWindow_Open(object sender, RoutedEventArgs e)
        {
            Window2 DataBaseWindows = new Window2();
            DataBaseWindows.Show();
        }
    }
}

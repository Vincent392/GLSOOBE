using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace GLSOOBE
{
    /// <summary>
    /// Interaction logic for aacnamepage.xaml
    /// </summary>
    public partial class aacnamepage : Page
    {
        public aacnamepage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void createaccount_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo usercreate = new ProcessStartInfo();
            usercreate.FileName = "cmd.exe";
            usercreate.Arguments = "/c net user " + usernameinput.Text + "/add";
            usercreate.UseShellExecute = false;
            usercreate.CreateNoWindow = true;
            Process.Start(usercreate);
            ProcessStartInfo addadmin = new ProcessStartInfo();
            addadmin.FileName = "cmd.exe";
            addadmin.Arguments = "/c net localgroup Administrators " + usernameinput.Text + "/add";
            addadmin.UseShellExecute = false;
            addadmin.CreateNoWindow = true;
            Process.Start(addadmin);
        }

        private void newnext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FinishPage());
        }
    }
}

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

        char[] illegalcharacters = 
            { ' ', '{', '|', '}', '~', '[', '\\', ']', '^', '\'',
            ':', ';', '<', '=', '>', '?', '@', '!', '"', '#',
            '$', '%', '`', '(', ')', '+', '/', '.', ',', '*', '&', 
            '"', '/', '\\', '[', ']', ':', '|', '<', '>', '+', 
            '=', ';', ',', '?', '*', '%' };

        private int usernamecount = 0;

        private void createaccount_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(usernametext.Text.ToString()))
            {
                statustext.Text = "Failed to add the Account name";
                statustext.Visibility = Visibility.Visible;
                return;
            }
            if(usernametext.Text.IndexOfAny(illegalcharacters) >= 0)
            {
                statustext.Text = "Failed to add the Account name";
                statustext.Visibility = Visibility.Visible;
                return;
            }
            if(usernamecount == 8)
            {
                statustext.Text = "You can only add 8 Account names";
                statustext.Visibility = Visibility.Visible;
                return;
            }
            ProcessStartInfo usercreate = new ProcessStartInfo();
            usercreate.FileName = "cmd.exe";
            usercreate.Arguments = "/c net user " + usernametext.Text + " /add";
            usercreate.UseShellExecute = false;
            usercreate.CreateNoWindow = true;
            Process.Start(usercreate);
            ProcessStartInfo addadmin = new ProcessStartInfo();
            addadmin.FileName = "cmd.exe";
            addadmin.Arguments = "/c net localgroup Administrators " + usernametext.Text + " /add";
            addadmin.UseShellExecute = false;
            addadmin.CreateNoWindow = true;
            Process.Start(addadmin);
            statustext.Visibility = Visibility.Hidden;
            //accountscreated.Text = accountscreated.Text + "\n" + usernametext.Text; //Programming warcrimes 101
            accountscreated.Text += Environment.NewLine + usernametext.Text;
            usernamecount++;
        }

        private void newnext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FinishPage());
        }
    }
}

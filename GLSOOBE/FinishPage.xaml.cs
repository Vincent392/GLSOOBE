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
using Microsoft.Win32;

namespace GLSOOBE
{
    /// <summary>
    /// Interaction logic for FinishPage.xaml
    /// </summary>
    public partial class FinishPage : Page
    {
        public FinishPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Regedit logic
            using (RegistryKey setupKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\Setup", true))
            {
                if(setupKey != null)
                {
                    setupKey.SetValue("SetupType", 0, RegistryValueKind.DWord);
                    setupKey.SetValue("SystemSetupInProgress", 0, RegistryValueKind.DWord);
                    setupKey.SetValue("OOBEInProgress", 0, RegistryValueKind.DWord);
                    setupKey.SetValue("SetupPhase", 0, RegistryValueKind.DWord);
                } else
                {
                    MessageBox.Show("What the fuck, HKLM\\SYSTEM\\Setup can't be found.", "GLSOOBE.EXE: god help us.");
                }
            }
            //Yell at sand
            Environment.Exit(0);
        }
    }
}

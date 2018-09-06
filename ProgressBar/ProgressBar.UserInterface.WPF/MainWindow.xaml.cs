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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressBar.UserInterface.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        // Constructor
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region UserInterface Click Events
        /// <summary>
        /// Updates progress bar based on user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateProgressBar();

        }

        private void MenuItem_Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetProgressBar();
        }

        #endregion

        #region Application Logic Code

        private void UpdateProgressBar()
        {
            int userInput = int.Parse(TextBox_Entry.Text);
            ProgressBar_Main.Value = userInput;

            if (ProgressBar_Main.Value < ProgressBar_Main.Minimum || ProgressBar_Main.Value > ProgressBar_Main.Maximum)
            {
                MessageBox.Show("Please enter a valid number between 0 and 100", "Invalid Input", MessageBoxButton.OK);
            }
        }

        private void ResetProgressBar()
        {
            ProgressBar_Main.Value = 0;
            TextBox_Entry.Text = string.Empty;
        }

        #endregion
    }
}

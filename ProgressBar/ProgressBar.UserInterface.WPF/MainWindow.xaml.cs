using System;
using System.Text.RegularExpressions;
using System.Windows;

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

        private void MenuItem_Acknowledgements_Click(object sender, RoutedEventArgs e)
        {
            DisplayAcknowledgementsDialog();
        }

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            DisplayAboutDialog();
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        #region Application Logic Code

        private void UpdateProgressBar()
        {
            /** Regex Information
             *
             *  ^ means the start of the string
             *  [] means the character set
             *  +  means one time or more
             *  $  means end of the string
             *  ^  and $ are needed to validate all of the string string, 
             *  not just part of the string 
             **/

            Regex reg = new Regex("^[a-zA-Z]+$");

            // Check to see if TextBox_Entry.Text contains letters
            if(reg.IsMatch(TextBox_Entry.Text) == false)
            {
                try
                {
                    // Parse string input into an int
                    var userInput = int.Parse(TextBox_Entry.Text);

                    // Validate input
                    if(userInput < ProgressBar_Main.Minimum || userInput > ProgressBar_Main.Maximum)
                    {
                        DisplayInvalidInputMessage();
                    }
                    else
                    {
                        ProgressBar_Main.Value = userInput;
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                DisplayInvalidInputMessage();
            }


        }

        private static void DisplayInvalidInputMessage()
        {
            MessageBox.Show("Please enter a valid number between 0 and 100", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ResetProgressBar()
        {
            ProgressBar_Main.Value = 0;
            TextBox_Entry.Text = string.Empty;
        }

        private static void DisplayAcknowledgementsDialog()
        {
            MessageBox.Show("Progress Bar - Beta 1\n\nApplication logo used as per the CC0 Creative Commons license.", "Acknowledgements", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private static void DisplayAboutDialog()
        {
            MessageBox.Show("Progress Bar - Beta 1\n\nApplication designed and developed by Ryan Alexander.\n\n2018", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion


    }
}

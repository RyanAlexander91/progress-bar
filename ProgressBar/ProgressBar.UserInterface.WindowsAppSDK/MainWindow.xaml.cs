using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;


namespace ProgressBar.UserInterface.WindowsAppSDK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        #region Constructor

        // Constructor
        public MainWindow()
        {
            this.InitializeComponent();

            // Set AppTitleBar UIElement as Titlebar
            Window window = this;
            window.ExtendsContentIntoTitleBar = true; // Enables custom titlebar
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

        private void ResetApplication_Click(object sender, RoutedEventArgs e)
        {
            ResetProgressBar();
        }

        private void MenuFlyoutItem_Acknowledgements_Click(object sender, RoutedEventArgs e)
        {
            DisplayAcknowledgementsDialog();
        }

        private void MenuFlyoutItem_About_Click(object sender, RoutedEventArgs e)
        {
            DisplayAboutDialog();
        }

        private void MenuFlyoutItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        #region Application Logic Code

        private async void UpdateProgressBar()
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
            if (reg.IsMatch(TextBox_Entry.Text) == false)
            {
                try
                {
                    // Parse string input into an int
                    var userInput = int.Parse(TextBox_Entry.Text);

                    // Validate input
                    if (userInput < ProgressBar_Main.Minimum || userInput > ProgressBar_Main.Maximum)
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
                    ContentDialog noWifiDialog = new ContentDialog
                    {
                        Title = "Error",
                        Content = e.Message,
                        CloseButtonText = "Ok"
                    };

                    ContentDialogResult result = await noWifiDialog.ShowAsync();
                }
            }
            else
            {
                DisplayInvalidInputMessage();
            }


        }

        private async void DisplayInvalidInputMessage()
        {
            await ContentDialog_InvalidContent.ShowAsync();

        }

        private void ResetProgressBar()
        {
            ProgressBar_Main.Value = 0;
            TextBox_Entry.Text = string.Empty;
        }

        private async void DisplayAcknowledgementsDialog()
        {
            await ContentDialog_Acknowledgements.ShowAsync();
        }

        private async void DisplayAboutDialog()
        {
            await ContentDialog_About.ShowAsync();
        }

        #endregion

    }
}

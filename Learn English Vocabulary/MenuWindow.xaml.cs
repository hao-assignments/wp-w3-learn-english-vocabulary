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
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Learn_English_Vocabulary
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            this.InitializeComponent();
        }

        private void LearnButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new MainWindow();
            screen.Activate();
        }

        private void ExamButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ExamWindow();
            screen.Activate();
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            var screen = new LoginWindow();
            screen.Activate();
            this.Close();
        }
    }
}

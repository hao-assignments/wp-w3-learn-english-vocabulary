using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Learn_English_Vocabulary
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.InitializeComponent();
        }

        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (username == "admin" && password == "admin")
            {
                if (rememberCheckBox.IsChecked == true)
                {
                    var passwordInBytes = Encoding.UTF8.GetBytes(password);
                    var entropyInBytes = new byte[20];
                    using (var rng = RandomNumberGenerator.Create())
                    {
                        rng.GetBytes(entropyInBytes);
                    }
                    var encryptedPassword = ProtectedData.Protect(
                            passwordInBytes,
                            entropyInBytes,
                            DataProtectionScope.CurrentUser);
                    var encryptedPasswordInBase64 = Convert.ToBase64String(encryptedPassword);
                    var entropyInBase64 = Convert.ToBase64String(entropyInBytes);

                    var localSettings = ApplicationData.Current.LocalSettings;
                    localSettings.Values["username"] = username;
                    localSettings.Values["password"] = encryptedPasswordInBase64;
                    localSettings.Values["entropy"] = entropyInBase64;
                }

                var screen = new MenuWindow();
                screen.Activate();
                this.Close();
            }
            else
            {
                await new ContentDialog()
                {
                    XamlRoot = this.Content.XamlRoot,
                    Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                    Title = "Error",
                    Content = "Invalid username or password.",
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey("username"))
            {
                UsernameTextBox.Text = localSettings.Values["username"].ToString();

                var encryptedPasswordInBase64 = localSettings.Values["password"].ToString();
                var entropyInBase64 = localSettings.Values["entropy"].ToString();

                var encryptedPasswordInBytes = Convert.FromBase64String(encryptedPasswordInBase64);
                var entropyInBytes = Convert.FromBase64String(entropyInBase64);

                var passwordInBytes = ProtectedData.Unprotect(
                    encryptedPasswordInBytes,
                    entropyInBytes,
                    DataProtectionScope.CurrentUser);

                var password = Encoding.UTF8.GetString(passwordInBytes);

                PasswordBox.Password = password;
            }
        }
    }
}

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
    public sealed partial class MainWindow : Window
    {
        private Random _random = new Random();
        private List<(string word, string imagePath)> _vocabulary;

        public MainWindow()
        {
            this.InitializeComponent();
            InitializeVocabulary();
            DisplayRandomVocabulary();
        }

        private void InitializeVocabulary()
        {
            _vocabulary = new List<(string, string)>
            {
                ("Bird", "Assets/Animals/Bird.png"),
                ("Butterfly", "Assets/Animals/Butterfly.png"),
                ("Cat", "Assets/Animals/Cat.png"),
                ("Chicken", "Assets/Animals/Chicken.png"),
                ("Cow", "Assets/Animals/Cow.png"),
                ("Dog", "Assets/Animals/Dog.png"),
                ("Horse", "Assets/Animals/Horse.png"),
                ("Lion", "Assets/Animals/Lion.png"),
                ("Panda", "Assets/Animals/Panda.png"),
                ("Pig", "Assets/Animals/Pig.png")
            };
        }

        private void DisplayRandomVocabulary()
        {
            var randomIndex = _random.Next(_vocabulary.Count - 1);
            var selected = _vocabulary[randomIndex];

            VocabularyText.Text = selected.word;

            var bitmapImage = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage();
            bitmapImage.UriSource = new Uri($"ms-appx:///{selected.imagePath}");
            VocabularyImage.Source = bitmapImage;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayRandomVocabulary();
        }
    }
}

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

    public sealed partial class ExamWindow : Window
    {
        int random_result;
        int score = 0;
        int numberOfQuestions = 10;

        public ExamWindow()
        {
            this.InitializeComponent();
            InitializeVocabulary();
            DisplayRandomVocabulary();
        }

        private Random _random = new Random();
        private List<(string word, string imagePath)> _vocabulary;

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
            var randomIndex1 = _random.Next(_vocabulary.Count - 1);
            var randomIndex2 = _random.Next(_vocabulary.Count - 1);

            while (randomIndex1 == randomIndex2)
            {
                randomIndex2 = _random.Next(_vocabulary.Count - 1);
            }

            random_result = _random.Next(2);
            if (random_result == 0)
            {
                var selected = _vocabulary[randomIndex1];

                VocabularyText.Text = selected.word;

                var bitmapImage = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage();
                bitmapImage.UriSource = new Uri($"ms-appx:///{selected.imagePath}");
                OptionImage1.Source = bitmapImage;

                selected = _vocabulary[randomIndex2];

                bitmapImage = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage();
                bitmapImage.UriSource = new Uri($"ms-appx:///{selected.imagePath}");
                OptionImage2.Source = bitmapImage;
            }
            else
            {
                var selected = _vocabulary[randomIndex2];

                VocabularyText.Text = selected.word;

                var bitmapImage = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage();
                bitmapImage.UriSource = new Uri($"ms-appx:///{selected.imagePath}");
                OptionImage2.Source = bitmapImage;

                selected = _vocabulary[randomIndex1];

                bitmapImage = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage();
                bitmapImage.UriSource = new Uri($"ms-appx:///{selected.imagePath}");
                OptionImage1.Source = bitmapImage;
            }
        }

        private void OptionButton1_Click(object sender, RoutedEventArgs e)
        {
            if (random_result == 0)
            {
                score += 10;
            }
            else
            {
                // Do nothing
            }

            if (numberOfQuestions > 1)
            {
                DisplayRandomVocabulary();
                numberOfQuestions--;
            }
            else
            {
                VocabularyText.Text = "Your score is " + score + "/100!";
                OptionButton1.Visibility = Visibility.Collapsed;
                OptionButton2.Visibility = Visibility.Collapsed;
            }
        }

        private void OptionButton2_Click(object sender, RoutedEventArgs e)
        {
            if (random_result == 1)
            {
                score += 10;
            }
            else
            {
                // Do nothing
            }

            if (numberOfQuestions > 1)
            {
                DisplayRandomVocabulary();
                numberOfQuestions--;
            }
            else
            {
                VocabularyText.Text = "Your score is " + score + "/100!";
                OptionButton1.Visibility = Visibility.Collapsed;
                OptionButton2.Visibility = Visibility.Collapsed;
            }
        }
    }
}

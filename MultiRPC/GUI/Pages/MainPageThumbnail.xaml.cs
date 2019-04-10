﻿using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MultiRPC.GUI.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPageThumbnail : Page
    {
        public MainPageThumbnail(ResourceDictionary resource)
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(resource);
            this.Resources.MergedDictionaries.Add((ResourceDictionary)XamlReader.Parse(File.ReadAllText($"Assets/Icons.xaml")));
            Loaded += MainPageThumbnail_Loaded;
        }

        public async Task UpdateText()
        {
            tbExample.Text = App.Text.WewTextbox;
            cbiExample.Content = App.Text.WewComboboxItem;
            cbiExample2.Content = App.Text.WewComboboxItem2;
            tblExample.Text = App.Text.WewTextBlock;
            btnExample.Content = App.Text.WewButton;
            btnDisabledExample.Content = App.Text.WewDisabledButton;
        }

        private void MainPageThumbnail_Loaded(object sender, RoutedEventArgs e)
        {
            DrawingCollection ButtonDrawing(Button btn)
            {
                return ((DrawingGroup) ((DrawingImage) ((Image) btn.Content).Source).Drawing).Children;
            }

            void UpdateButton(Button btn, SolidColorBrush brushToUpdateTo)
            {
                foreach (DrawingGroup group in ButtonDrawing(btn))
                {
                    foreach (GeometryDrawing drawing in group.Children)
                    {
                        drawing.Brush = brushToUpdateTo;
                    }
                }
            }

            UpdateButton(btnNavButton, (SolidColorBrush)this.Resources["AccentColour3SCBrush"]);
            UpdateButton(btnNavButtonSelected, (SolidColorBrush)this.Resources["NavButtonIconColourSelected"]);
            UpdateText();
        }
    }
}

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
using System.IO;
using Microsoft.Win32;

namespace edytor_text
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SaveFileDialog myDlg = null;
        string pth = null;
        public MainWindow()
        {
           
            InitializeComponent();


            save.IsEnabled = false;
            savem.IsEnabled = false;

            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = RichText.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = RichText.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = RichText.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = RichText.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;
            temp = RichText.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();
        }

        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
                RichText.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
        }

        private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            RichText.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
        }

        
     

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (pth == null && myDlg == null)
            {
                myDlg = new SaveFileDialog();

                myDlg.DefaultExt = "*.rtf";
                myDlg.Filter = "RTF Files|*.rtf";
                Nullable<bool> myResult = myDlg.ShowDialog();
                if (myResult == true)
                {
                    RichText.SelectAll();
                    RichText.Selection.Save(new FileStream(myDlg.FileName, FileMode.OpenOrCreate, FileAccess.Write), DataFormats.Rtf);
                    pth = myDlg.FileName;
                }
            }
            else
            {
                RichText.SelectAll();
                RichText.Selection.Save(new FileStream(pth, FileMode.OpenOrCreate, FileAccess.Write), DataFormats.Rtf);
            }
            save.IsEnabled = false;
            savem.IsEnabled = false;

        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

            myDlg = new SaveFileDialog();

            myDlg.DefaultExt = "*.rtf";
            myDlg.Filter = "RTF Files|*.rtf";
            Nullable<bool> myResult = myDlg.ShowDialog();
            if (myResult == true)
            {
                RichText.SelectAll();
                RichText.Selection.Save(new FileStream(myDlg.FileName, FileMode.OpenOrCreate, FileAccess.Write), DataFormats.Rtf);
                pth = myDlg.FileName;
                save.IsEnabled = false;
                savem.IsEnabled = false;
            }

            //tbx.SelectAll();
            //tbx.Selection.Save(new FileStream(myDlg.FileName, FileMode.OpenOrCreate, FileAccess.Write), DataFormats.Rtf);

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {


            MessageBoxResult res = MessageBox.Show("Save document?", "Save?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (res)
            {
                case MessageBoxResult.Cancel:
                    break;
                case MessageBoxResult.Yes:
                    MenuItem_Click_2(sender, e);
                    save.IsEnabled = false;
                    savem.IsEnabled = false;
                    break;
                case MessageBoxResult.No:
                    RichText.Document.Blocks.Clear();
                    myDlg = null;
                    pth = null;
                    save.IsEnabled = false;
                    savem.IsEnabled = false;
                    break;


            }


        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFile1 = new OpenFileDialog();
            openFile1.FileName = "Document";
            openFile1.DefaultExt = "*.*";
            openFile1.Filter = "All Files|*.*|Rich Text Format|*.rtf|Word Document|*.docx|Word 97-2003 Document|*.doc";

            if (openFile1.ShowDialog() == true)
            {
                var range = new TextRange(RichText.Document.ContentStart, RichText.Document.ContentEnd);

                using (var fStream = new FileStream(openFile1.FileName, FileMode.OpenOrCreate))
                {
                    // load as RTF, text is formatted
                    range.Load(fStream, DataFormats.Rtf);
                    fStream.Close();
                    pth = openFile1.FileName;
                }
                // clear the formatting, turning into plain text
                range.ClearAllProperties();
            }
            save.IsEnabled = false;
            savem.IsEnabled = false;

        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MenuItem_Click_1(sender, e);

        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Button_Click_1(sender, e);
        }




        private void Tbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            save.IsEnabled = true;
            savem.IsEnabled = true;
        }










        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Icons from left side: \n 1. Open file \n 2. Save file as \n 3. Cut the text \n 4. Copy the text \n 5. Paste the text");
        }
        private void New_Executed(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        private void About_Executed(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Icons from left side: \n 1. Open file \n 2. Save file as \n 3. Cut the text \n 4. Copy the text \n 5. Paste the text");
        }
    }
}

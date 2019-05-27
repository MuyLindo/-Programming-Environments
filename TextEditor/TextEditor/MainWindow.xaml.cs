using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileText;

        public MainWindow()
        {
            InitializeComponent();

            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<int>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e) // Function for opening a file
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dialog.FileName, FileMode.Open);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
                fileText = range.Text;
            }            
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e) // Opens a dialog for saving a file
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dialog.FileName, FileMode.Create);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void CMBFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e) // Changes font of the text
        {
            if (cmbFontFamily.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }    
        }

        private void CMBFontSize_TextChanged(object sender, TextChangedEventArgs e) // Changes size of the text
        {
            rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
        }

        private void RtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
                    
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();
        }

        private void BtnHighlight_Click(object sender, RoutedEventArgs e) //Highlight selected text
        {
            rtbEditor.Selection.ApplyPropertyValue(Run.BackgroundProperty, "red");
        }

        private void BtnSubscript_Click(object sender, RoutedEventArgs e) 
        {
            rtbEditor.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Subscript);
        }

        private void BtnSuperscript_Click(object sender, RoutedEventArgs e)
        {
            rtbEditor.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Superscript);
        }

        private void BtnCut_Click(object sender, RoutedEventArgs e) // Cut the selected text
        {
            rtbEditor.Cut();
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e) // Copy the selected text
        {
            rtbEditor.Copy();
        }

        private void BtnPaste_Click(object sender, RoutedEventArgs e) // Paste the selected text
        {
            rtbEditor.Paste();
        }

        private void BtnRedo_Click(object sender, RoutedEventArgs e)
        {
            if(rtbEditor.CanRedo == true)
                rtbEditor.Redo();
        }

        private void BtnUndo_Click(object sender, RoutedEventArgs e)
        {
            if (rtbEditor.CanUndo == true)
                rtbEditor.Undo();
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e) // Find the word which is wrtten in textBox
        {
            string word = textBox.Text;
            TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            string allText = range.Text;

            if (word == string.Empty)
            {
                MessageBox.Show("Please enter a word!", "Exit", MessageBoxButton.OK);
            }

            Regex regex = new Regex(word);
            Match match = regex.Match(allText);
            if (match.Success)
            {
                MessageBox.Show("found");
                //rtbEditor.Selection.Select(match.Index), rtbEditor.Document.ContentStart.GetPositionAtOffset(match.Length));
                //rtbEditor.Selection.ApplyPropertyValue(Run.BackgroundProperty, "yellow");
            }
        }

        private bool IsRichTextBoxEmpty(RichTextBox rtbEditor) // Function for checking if the RichTextBox is empty
        {
            if (rtbEditor.Document.Blocks.Count == 0)
                return true;

            TextPointer startPointer = rtbEditor.Document.ContentStart.GetNextInsertionPosition(LogicalDirection.Forward);
            TextPointer endPointer = rtbEditor.Document.ContentEnd.GetNextInsertionPosition(LogicalDirection.Backward);

            return startPointer.CompareTo(endPointer) == 0; // Compares the start and end position of the written text, if is equal to 0.
        }
        
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) 
        {
            TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            string allText = range.Text;

            if (IsRichTextBoxEmpty(rtbEditor) == false && allText != fileText)
           { 
                MessageBoxResult result = MessageBox.Show("Do you want to save the file?", "Exit", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Save_Executed(this, null);
                        break;
                    case MessageBoxResult.No:
                        e.Cancel = false;
                        base.OnClosing(e);
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break; 
                }
           }
        }
    }
}

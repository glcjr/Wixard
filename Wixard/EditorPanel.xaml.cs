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

namespace Wixard
{
    /// <summary>
    /// Interaction logic for EditorPanel.xaml
    /// </summary>
    public partial class EditorPanel : UserControl
    {
        public GUIInterface win { get; set; }
        public EditorPanel()
        {
            InitializeComponent();
            win = (GUIInterface)this.DataContext;
        }
        public string EditorSource
        {
            get
            {
                return textEditor.Document.Text;
            }
        }
        public void prepareeditor()
        {
            textEditor.ShowLineNumbers = true;
            TextOptions.SetTextFormattingMode(textEditor, TextFormattingMode.Display);
            textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(textEditor.Options); // wish this would update a loaded script to make it look nicer like Visual Studio does...
            textEditor.Load(win.GetCsScriptStream()); // Yes I know about setting it to a string rather than using Load but that results in an error if someone leaves the editor to change something in the GUI and comes back to the script when it updates.

        }
        private void textEditor_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var position = textEditor.GetPositionFromPoint(e.GetPosition(textEditor));
            if (position.HasValue)
            {
                textEditor.TextArea.Caret.Position = position.Value;
            }
        }

        private void btnEditorCopy_Click(object sender, RoutedEventArgs e)
        {
            textEditor.Copy();
        }

        private void btnEditorPaste_Click(object sender, RoutedEventArgs e)
        {
            textEditor.Paste();
        }

        private void btnEditorCut_Click(object sender, RoutedEventArgs e)
        {
            textEditor.Cut();
        }

        private void btnEditorSelectAll_Click(object sender, RoutedEventArgs e)
        {
            textEditor.SelectAll();
        }
    }
}

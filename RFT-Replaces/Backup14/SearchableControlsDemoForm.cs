using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using SearchableControls;

namespace SearchableControlsDemo
{
    /// <summary>
    /// Form to demonstrate the SearchableControl library in action
    /// </summary>
    public partial class SearchableControlsDemoForm : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SearchableControlsDemoForm()
        {
            InitializeComponent();


            // Populate example searchableTextBox
            searchableTextBox1.Text = (string)Resource1.ResourceManager.GetObject("ExampleText");

            // Populate example searchableRichTextBox
            searchableRichTextBox1.Rtf = (string)Resource1.ResourceManager.GetObject("ExampleText1");

            // Populate example searchableTreeView
            // This is just random stuff from an XML file (as it happens, some documentation from the
            // SearchableControls library) prettified to include lots of text for searching.
            XmlTextReader reader = new XmlTextReader(new StringReader((string)Resource1.ResourceManager.GetObject("ExampleTree")));
            TreeNode node = null;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (node == null)
                            node = searchableTreeView1.Nodes.Add(reader.Name);
                        else
                            node = node.Nodes.Add(reader.Name);
                        string name = reader.GetAttribute("name");
                        if (name != null)
                            node.Text = node.Text + " (" + name + ")";
                        break;
                    case XmlNodeType.EndElement:
                        node = node.Parent;
                        break;
                    case XmlNodeType.Text:
                        node.Text = node.Text + " (" + Regex.Replace(reader.Value, @"\s+", " ").Trim() + ")";
                        break;
                    default:
                        break;
                }
            }

            searchableTreeView1.ExpandAll(); // Expand the example tree view

            // Populate view selector for searchableListView
            foreach (View view in Enum.GetValues(typeof(View)))
            {
                comboBox1.Items.Add(CamelToTitleCase(view.ToString()));
            }

            comboBox1.SelectedIndex = (int)searchableListView1.View;

            // Populate searchableListView (make list of system colors)
            foreach (MethodInfo methodInfo in typeof(System.Drawing.Color).GetMethods())
            {
                if (methodInfo.ReturnType == typeof(Color) && ((methodInfo.Attributes & MethodAttributes.Static) != 0) && methodInfo.GetParameters().Length == 0)
                {
                    searchableListView1.Items.Add(CamelToTitleCase(Regex.Replace(methodInfo.Name, "^get_", "")));
                }
            }
        }



        /// <summary>
        /// Allows the user to change view mode on the searchableTestListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchableListView1.View = (View)comboBox1.SelectedIndex;
        }

        /// <summary>
        /// Little utility function to prettify text for the demo
        /// </summary>
        /// <param name="Text">CamelCase text</param>
        /// <returns>Title case text</returns>
        public static string CamelToTitleCase(string Text)
        {
            Text = Text.Substring(0, 1).ToUpper() + Text.Substring(1);
            return Regex.Replace(Text, @"(\B[A-Z])", @" $1");
        }

        /// <summary>
        /// User clicked File->Exit
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// User clicked Edit->Find
        /// </summary>
        /// <remarks>
        /// This calls the utility function OpenDialog with the form's ControlCollection. 
        /// This will open FindDialog() in either the focused control, if it is ISearchable, or the
        /// searchable control with the lowest TabIndex.
        /// </remarks>
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenFindDialog(Controls);
        }

        /// <summary>
        /// User clicked Edit->Find Again
        /// </summary>
        /// <remarks>
        /// This calls the utility function FindNext with the form's ControlCollection. 
        /// </remarks>
        private void findAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.FindNext(Controls);
        }

        /// <summary>
        /// About to paint Edit menu. Mark the menu items in the appropriate enabled state
        /// </summary>
        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            findAgainToolStripMenuItem.Enabled = Utility.FindNextIsAvailable(Controls);
        }

        private void readOnlyCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            searchableTextBox1.ReadOnly = readOnlyCheckBox1.Checked;
        }

        private void readOnlyCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            searchableRichTextBox1.ReadOnly = readOnlyCheckBox2.Checked;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typographer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string RemoveExtraSpace(string EnteredText)
        {
            string result = Regex.Replace(EnteredText, @"\s+", " ");
            return result;
        }

        private string HyphenWithoutSpace(string EnteredText)
        {
            string result = Regex.Replace(EnteredText, @"(?<! )-(?! )", "");
            return result;
        }

        private string ReplacePlusMinus(string EnteredText)
        {
            string result = EnteredText.Replace("+/-", "±");
            return result;
        }

        private string ReplaceTripleDots(string EnteredText)
        {
            string result = Regex.Replace(EnteredText, @"(?<!\.\.\.)(\.\.\.)", "...");
            return result;
        }

        private string FormatArithmeticExpression(string EnteredText)
        {
            string result = EnteredText;
            result = result.Replace("-", "–"); 
            result = Regex.Replace(result, @"(\d+(?:\.\d+)?)\s*([-+*/])\s*(\d+(?:\.\d+)?)", "$1 $2 $3");
            return result;
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            string final = RemoveExtraSpace(EnteredText.Text);
            final = HyphenWithoutSpace(final);
            final = ReplacePlusMinus(final);
            final = ReplaceTripleDots(final);
            final = FormatArithmeticExpression(final);
            ChangedText.Text = final;
        }
    }
}

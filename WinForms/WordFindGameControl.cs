using System.Collections.Generic;
using System.Windows.Forms;

namespace WinForms
{
    public class WordFindGameControl
    {
        public WordFindGameControl()
        {
            Controls = new List<Control>();
            Texts = new List<string>();
        }
        public List<Control> Controls { get; set; }
        public int Count { get; set; }
        public List<string> Texts { get; set; }
        public bool Any { get; set; }
    }
}
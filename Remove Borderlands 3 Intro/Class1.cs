using System.Windows.Forms;

namespace Remove_Borderlands_3_Intro
{
    class CustomContent
    {
        public string filename;
        public bool isEnabled = false;
        public CheckBox checkBox;
        public CustomContent(string filename, CheckBox checkBox)
        {
            this.filename = filename;
            this.checkBox = checkBox;
        }
    }
}

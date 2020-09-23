using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IZ_OOP_2020.Classes
{
    public class LinePart
    {
        public int LineNum;
        public int IDLinePart;
        public ToolTip ErrorTip = new ToolTip();
        public PictureBox Pic;

        public LinePart(int j, int LN)
        {
            LineNum = LN;
            IDLinePart = j;
        }
    }
}

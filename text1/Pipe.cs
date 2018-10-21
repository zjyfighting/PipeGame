using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace text1
{
    class Pipe
    {
        private int state;
        public void spin(object sender,Dictionary<int,Bitmap>s)
        {
            PictureBox pb = (PictureBox)sender;
            if(state==1)
            {
                state = 2;
                pb.Image = s[2];
            }
            else if (state == 2)
            {
                state = 1;
                pb.Image = s[1];
            }
            else if(state==3)
            {
                state = 4;
                pb.Image = s[4];
            }
            else if (state == 4)
            {
                state = 5;
                pb.Image = s[5];
            }
            else if (state == 5)
            {
                state = 6;
                pb.Image = s[6];
            }
            else if (state == 6)
            {
                state = 3;
                pb.Image = s[3];
            }
        }
        public int getState() { return state; }
        public void setState(int st) { this.state = st; }
    }

}














/*enum Days { Saturday=1, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday };
        enum Colors { Red = 1, Green = 2, Blue = 4, Yellow = 8 };

        使用
        Colors myColors = Colors.Red;
string strColor = myColors.tostring();
        int IntColor = (int)myColors;
        */

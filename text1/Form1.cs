using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//add
using System.IO;

namespace text1
{
    public partial class Form1 : Form
    {
        //设置时间
        PipeMatrix pm = new PipeMatrix(3, 3);
        public int currenttime = 0;
        public int step = 0;
        int[] statedia;
        int[] start;
        int[] end;
        Dictionary<int, Bitmap> s = new Dictionary<int, Bitmap>();
        public Form1()
        {
            InitializeComponent();
        }
        //初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            //对开始结束以及当前状态的初始化=======
            int row = pm.row;
            int col = pm.col;
            statedia = new int[] { 4,5,3,
                                   6,1,2,
                                   1,4,6 };
            start = new int[] {   4,5,3,
                                  6,1,2,
                                  1,4,6 };
            end = new int[] {   3,5,3,
                                6,2,2,
                                1,3,5 };
            //对状态转换的初始化===================
            Bitmap[] b = new Bitmap[8];
            b[0]= new Bitmap("henz.PNG");
            b[1] = new Bitmap("shuz.PNG");
            b[2] = new Bitmap("ys.PNG");
            b[3] = new Bitmap("yx.PNG");
            b[4] = new Bitmap("zx.PNG");
            b[5] = new Bitmap("zs.PNG");
            //头和尾两图====================
            b[6] = new Bitmap("t.PNG");
            b[7] = new Bitmap("w.PNG");
            pictureBox10.Image = b[6];
            pictureBox11.Image = b[7];
            //添加==================================
            for (int i = 1; i <= 6; i++)
                s.Add(i, b[i-1]);
            //======================================
            for(int i=1;i<=row*col;i++)
            {
                ((PictureBox)this.Controls.Find("pictureBox" + i, true)[0]).Image =s[start[i-1]];
            }
            this.timer1.Start();
        }
            
        private void On_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            //i表示第几个pictureBox
            int i = int.Parse(pb.Name.Substring(10, 1));
            //方法一
            int row = pm.row;
            int x = (i % row == 0) ? (i / row - 1) : (i/row);
            int y = (i % row == 0) ? (i %row) : (i % row - 1);
            pm.pipeMx[x,y].setState(statedia[i - 1]);
            pm.pipeMx[x,y].spin(pb, s);
            statedia[i - 1] = pm.pipeMx[x,y].getState();
            step++;
            EndDefine();
            //方法二
/*          Pipe pipe = new Pipe();
            pipe.setState(statedia[i-1]);
            pipe.spin(pb, s);
            statedia[i-1] =pipe.getState();
            step++;
            EndDefine();*/
        }
        //结束判断
        private void EndDefine()
        {
            if (statedia[0]==3&& statedia[1] == 5 && statedia[4] == 2 &&
                statedia[7] == 3 && statedia[8] == 5)
            {
                this.timer1.Stop();
                MessageBox.Show("恭喜你完成啦！\n一共用了"+currenttime+"秒"
                                +"\n"+"一共用了"+step+"步");
            }
        }

        private void Time_TIck(object sender, EventArgs e)
        {
            currenttime++;
            this.textBox1.Text = currenttime.ToString().Trim();
        }
    }
}


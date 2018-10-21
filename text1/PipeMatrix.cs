using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace text1
{
    class PipeMatrix
    {
        public int row;
        public int col;
        public Pipe[,] pipeMx;
        public PipeMatrix(int x,int y)
        {
            row = x;
            col = y;
            pipeMx = new Pipe[x,y];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    pipeMx[i,j] = new Pipe();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    interface AIInterface
    {
        void GetNextStep(out int _x, out int _y);
        void Running(int[,] board, int now);
    }
}

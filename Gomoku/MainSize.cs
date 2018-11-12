using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class MainSize
    {
        //主框体大小
        public static int Wid { get { return 1080; } }
        public static int Hei { get { return 900; } }
        //棋盘行数
        public static int CBLine { get { return 15; } }
        //棋盘大小
        public static int CBWid { get { return 1000; } }
        public static int CBHei { get { return 1000; } }
        //棋盘宽度
        public static int CBGap { get { return 50; } }
        //棋子直径
        public static int ChessRadious { get { return 16; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    [Serializable]
    public class Game
    {
        static readonly DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        readonly long gameStartTime = (long)(DateTime.Now - startTime).TotalMilliseconds;


        //是否开始
        public bool Start { get; set; }
        public bool Review { get; set; }
        public int Steps { get; set; }

        public bool AllowToMove { get; set; }
        public bool OldAllowToMove { get; set; }
        public bool HumanVShuman { get; set; }
        public bool HumanVSai { get; set; }

        public int WhoToMove { get; set; }
        public int Winner { get; set; }

        public int BlackTime { get; set; }
        public int WhiteTime { get; set; }
        public int BlackTimeThis { get; set; }
        public int WhiteTimeThis { get; set; }

        // 1 for player 1(black) 2 for player 2(white)
        public int[,] Chess = new int[15, 15];
        public int[,] Moves = new int[230, 6];

        public void Move(int x, int y)
        {
            Chess[x, y] = WhoToMove;

            int moveTime = (int)((long)(DateTime.Now - startTime).TotalMilliseconds - gameStartTime);

            Moves[Steps, 0] = WhoToMove;
            Moves[Steps, 1] = moveTime;
            Moves[Steps, 2] = x;
            Moves[Steps, 3] = y;
            Moves[Steps, 4] = BlackTime;
            Moves[Steps, 5] = WhiteTime;

            Connect.move(x, y, WhoToMove);

            Steps++;
        }

        public Game()
        {

            Start = false;
            Review = false;
            AllowToMove = false;
            OldAllowToMove = false;
            HumanVShuman = false;
            HumanVSai = false;

            WhoToMove = 1;
            Winner = -1;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Chess[i, j] = 0;
                }
            }
            for (int i = 0; i < 230; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Moves[i, j] = 0;
                }
            }

            BlackTime = 0;
            WhiteTime = 0;
            BlackTimeThis = 0;
            WhiteTimeThis = 0;
        }
    }
}

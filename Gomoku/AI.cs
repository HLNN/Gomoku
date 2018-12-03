using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class AI : AIInterface
    {
        static int[] dx = { 0, 1, 1, 1 };
        static int[] dy = { 1, -1, 0, 1 };
        static int size = 15;

        //public int[] minValue = new int[] { 1, 3, 7, 9, 13, 20, 13, 50, 100, 20, 150, 500, 10000 };
        //public int[] maxValue = new int[] { 2, 4, 8, 10, 15, 25, 15, 60, 150, 25, 200, 600, 10000 };

        //public int[] otherMinValue = new int[] { 0, 2, 4, 7, 10, 13, 10, 30, 70, 13, 70, 400, 8000 };
        //public int[] otherMaxValue = new int[] { 0, 3, 5, 8, 12, 15, 12, 40, 120, 15, 120, 500, 8000 };

        public int[] minValue = new int[] { 1, 2, 7, 9, 13, 30, 13, 39, 81, 20, 57, 432, 12065 };
        public int[] maxValue = new int[] { 2, 3, 8, 10, 15, 35, 15, 49, 131, 25, 107, 532, 12065 };

        public int[] otherMinValue = new int[] { 0, 4, 4, 7, 7, 13, 7, 32, 70, 13, 90, 400, 9686 };
        public int[] otherMaxValue = new int[] { 0, 5, 5, 8, 9, 15, 9, 42, 120, 15, 140, 500, 9686 };

        int x, y;

        //假设形成一个棋形，x子连，两头有y个空格，则编码成(x - 1) * 3 + y，编码与12取min
        //cntSelf[i]代表走这个点后自己会形成多少个编码i
        //cntOther[i]代表走这个点后对方会形成多少个编码i

        int[] cntSelf = new int[size];
        int[] cntOther = new int[size];
        int[,] level = new int[size, size];
        int[,] score = new int[size, size];

        public void GetNextStep(out int _x, out int _y)
        {
            _x = x;
            _y = y;
        }

        private static bool InRange(int x, int y)
        {
            return x >= 0 && x < 15 && y >= 0 && y < 15;
        }

        public void Running(int[,] board, int now)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int maxScore = -1, bestLevel = 1000;

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] != 0)
                        continue;
                    for (int k = 0; k <= 12; k++)
                        cntOther[k] = cntSelf[k] = 0;
                    for (int d = 0; d < 4; d++)
                    {
                        int s = 1;
                        int empty = 0;
                        for (int x = 1; true; x++)
                        {
                            int nowX = i + dx[d] * x, nowY = j + dy[d] * x;
                            if (!InRange(nowX, nowY) || board[nowX, nowY] == 3 - now)
                                break;
                            if (board[nowX, nowY] == 0)
                            {
                                empty++;
                                break;
                            }

                            s++;
                        }

                        for (int x = 1; true; x++)
                        {
                            int nowX = i - dx[d] * x, nowY = j - dy[d] * x;
                            if (!InRange(nowX, nowY) || board[nowX, nowY] == 3 - now)
                                break;
                            if (board[nowX, nowY] == 0)
                            {
                                empty++;
                                break;
                            }

                            s++;
                        }

                        cntSelf[Math.Min((s - 1) * 3 + empty, 12)]++;
                    }

                    for (int d = 0; d < 4; d++)
                    {
                        int s = 1;
                        int empty = 0;
                        for (int x = 1; true; x++)
                        {
                            int nowX = i + dx[d] * x, nowY = j + dy[d] * x;
                            if (!InRange(nowX, nowY) || board[nowX, nowY] == now)
                                break;
                            if (board[nowX, nowY] == 0)
                            {
                                empty++;
                                break;
                            }

                            s++;
                        }

                        for (int x = 1; true; x++)
                        {
                            int nowX = i - dx[d] * x, nowY = j - dy[d] * x;
                            if (!InRange(nowX, nowY) || board[nowX, nowY] == now)
                                break;
                            if (board[nowX, nowY] == 0)
                            {
                                empty++;
                                break;
                            }

                            s++;
                        }

                        cntOther[Math.Min((s - 1) * 3 + empty, 12)]++;
                    }

                    if (cntSelf[12] > 0)
                    {
                        x = i;
                        y = j;
                        return;
                    }

                    level[i, j] = 0;
                    if (cntOther[12] > 0)
                        level[i, j] = 1;
                    else if (cntSelf[11] > 0 || cntSelf[10] > 1)
                        level[i, j] = 2;
                    score[i, j] = 0;
                    for (int k = 0; k <= 12; k++)
                    {
                        score[i, j] += cntSelf[k] * (minValue[k] + random.Next(maxValue[k] - minValue[k] + 1));
                        score[i, j] += cntOther[k] * (otherMinValue[k] + random.Next(otherMaxValue[k] - otherMinValue[k] + 1));
                    }

                    score[i, j] += (30 - 2 * (Math.Abs(i - 7) + Math.Abs(j - 7)));
                }
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (board[i, j] == 0)
                    {
                        if (level[i, j] > 0 && level[i, j] < bestLevel)
                        {
                            bestLevel = level[i, j];
                            x = i;
                            y = j;
                        }

                        if (bestLevel == 1000 && score[i, j] > maxScore)
                        {
                            maxScore = score[i, j];
                            x = i;
                            y = j;
                        }
                    }
        }
    }
}

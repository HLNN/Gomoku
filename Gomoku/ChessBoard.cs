﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace Gomoku
{
    class ChessBoard
    {
        static readonly Color color = Color.Black;
        static readonly float penWid = 1.0f;
        static readonly Pen pen = new Pen(color, penWid);

        public static void DrawCB(Graphics gra, PictureBox pic)
        {
            //每排数量
            int horC = MainSize.CBLine;
            //间隔
            int gap = MainSize.CBGap;
            //宽
            int CBWid = (horC - 1) * gap + 1;
            //高
            int CBHei = (horC - 1) * gap + 1;
            //设置字体
            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            //设置棋盘网隔相对于PicBox原点的偏移
            int offsetX = 30;
            int offsetY = 30;
            Image img = new Bitmap(CBWid + offsetX + 10, CBHei + offsetY + 10);
            gra = Graphics.FromImage(img);
            //画棋盘
            for (int i = 0; i < horC; i++)
            {
                gra.DrawLine(pen, 0 + offsetX, i * gap + offsetY, CBWid + offsetX, i * gap + offsetY);
                gra.DrawLine(pen, i * gap + offsetX, 0 + offsetY, i * gap + offsetX, CBHei + offsetY);
                gra.DrawString(Convert.ToString(i + 1), drawFont, drawBrush, 0, i * gap + 20);
                gra.DrawString(Convert.ToString((char)(65 + i)), drawFont, drawBrush, i * gap + 20, 0);
            }
            gra.DrawLine(pen, 0 + offsetX, horC * gap + offsetY, CBWid + offsetX, horC * gap + offsetY);
            gra.DrawLine(pen, horC * gap + offsetX, 0 + offsetY, horC * gap + offsetX, CBHei + offsetY);
            pic.Image = img;
        }
    }
}

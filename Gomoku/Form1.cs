﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace Gomoku
{
    [Serializable]
    public class Game
    {

        Graphics graphic;


        static readonly DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        readonly long gameStartTime = (long)(DateTime.Now - startTime).TotalMilliseconds;


        //是否开始
        public bool Start { get; set; }

        public bool AllowToMove { get; set; }
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

        public Game()
        {

            this.Start = false;
            this.AllowToMove = false;
            this.HumanVShuman = false;
            this.HumanVSai = false;

            this.WhoToMove = 1;
            this.Winner = 0;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Chess[i, j] = 0;
                }
            }

            this.BlackTime = 0;
            this.WhiteTime = 0;
            this.BlackTimeThis = 0;
            this.WhiteTimeThis = 0;

        }
    }

    public partial class Gomoku : Form
    {
        Graphics graphic;

        private

        Game game;
        
        static readonly Pen pen = new Pen(Color.Black, 1.0f);
        static readonly Brush whiteBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
        static readonly Brush blackBrush = new SolidBrush(Color.FromArgb(0, 0, 0));

        public Gomoku()
        {
            InitializeComponent();
            this.Width = MainSize.Wid;
            this.Height = MainSize.Hei;
            this.ChessBox.Width = MainSize.CBWid;
            this.ChessBox.Height = MainSize.CBHei;
        }

        private void Gomoku_Load(object sender, EventArgs e)
        {
            global::Gomoku.ChessBoard.DrawCB(graphic, this.ChessBoard);
        }

        private void restart_for_new_game()
        {
            this.game = new Game();
            global::Gomoku.ChessBoard.DrawCB(graphic, this.ChessBoard);

            this.timer1.Enabled = false;
            this.black_time_all.Text = "局时: 0秒";
            this.black_time_this.Text = "步时: 0秒";
            this.white_time_all.Text = "局时: 0秒";
            this.white_time_this.Text = "步时: 0秒";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.game.Start)
            {
                if (this.game.WhoToMove == 1)
                {
                    this.game.BlackTime++;
                    this.game.BlackTimeThis++;

                    this.black_time_all.Text = "局时: " + Convert.ToString(this.game.BlackTime) + "秒";
                    this.black_time_this.Text = "步时: " + Convert.ToString(this.game.BlackTimeThis) + "秒";

                    if (this.game.BlackTimeThis >= 15)
                    {

                    }
                }
                if (this.game.WhoToMove == 2)
                {
                    this.game.WhiteTime++;
                    this.game.WhiteTimeThis++;

                    this.white_time_all.Text = "局时: " + Convert.ToString(this.game.WhiteTime) + "秒";
                    this.white_time_this.Text = "步时: " + Convert.ToString(this.game.WhiteTimeThis) + "秒";

                    if (this.game.WhiteTimeThis >= 15)
                    {

                    }
                }
            }
        }

        private bool check_win_point(int x, int y)
        {
            if (this.game.Chess[x, y] == 0)
            {
                return false;
            }

            bool f;
            int chessColor = this.game.Chess[x, y];

            // right
            if (x + 5 < 15)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (this.game.Chess[x + k, y] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    this.game.Winner = chessColor;
                    return true;
                }
            }
            // down
            if (y + 5 < 15)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (this.game.Chess[x, y + k] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    this.game.Winner = chessColor;
                    return true;
                }
            }
            // right down
            if (x + 5 < 15 && y + 5 < 15)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (this.game.Chess[x + k, y + k] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    this.game.Winner = chessColor;
                    return true;
                }
            }
            // right up
            if (x + 5 < 15 && y - 5 >= 0)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (this.game.Chess[x + k, y - k] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    this.game.Winner = chessColor;
                    return true;
                }
            }

            return false;
        }

        private bool check_win()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (check_win_point(i, j))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void ChessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.game.Start && this.game.AllowToMove)
            {
                if (this.game.Chess[(e.X - 5) / 50, (e.Y - 5) / 50] != 0)
                {
                    MessageBox.Show("这个地方已经下过了!!!");
                }
                else
                {
                    if (e.X >= 5 && e.X <= 755 && e.Y >= 5 && e.Y <= 755)
                    {
                        this.game.BlackTimeThis = 0;
                        this.game.WhiteTimeThis = 0;
                        this.black_time_this.Text = "步时: 0秒";
                        this.white_time_this.Text = "步时: 0秒";

                        this.game.Chess[(e.X - 5) / 50, (e.Y - 5) / 50] = this.game.WhoToMove;

                        Image img = this.ChessBoard.Image;
                        Graphics gra = Graphics.FromImage(img);
                        // gra.DrawEllipse(pen, e.X, e.Y, 33, 33);
                        switch (this.game.WhoToMove)
                        {
                            case 1:
                                gra.FillEllipse(blackBrush, (e.X - 5) / 50 * 50 + 15, (e.Y - 5) / 50 * 50 + 15, 30, 30);
                                break;
                            case 2:
                                gra.FillEllipse(whiteBrush, (e.X - 5) / 50 * 50 + 15, (e.Y - 5) / 50 * 50 + 15, 30, 30);
                                break;
                        }
                        this.ChessBoard.Image = img;

                        
                        if (this.check_win() )
                        {
                            this.game.Start = false;
                            switch(this.game.Winner)
                            {
                                case 1:
                                    MessageBox.Show("BLACK WIN!!!");
                                    break;
                                case 2:
                                    MessageBox.Show("WHITE WIN!!!");
                                    break;
                            }
                        }

                        if (this.game.HumanVShuman)
                        {
                            this.game.WhoToMove = 3 - this.game.WhoToMove;
                        }
                        if (this.game.HumanVSai)
                        {

                        }
                    }
                }
            }
        }

        private void ChessBoard_Click_1(object sender, EventArgs e)
        {
            
        }

        private void ChessBoard_Click(object sender, EventArgs e)
        {

        }

        private void ChessBox_Click(object sender, EventArgs e)
        {

        }

        private void 玩家VS玩家ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.restart_for_new_game();
            this.game.Start = true;
            this.game.AllowToMove = true;
            this.game.HumanVShuman = true;
            this.timer1.Enabled = true;
        }

        private void 玩家VSAIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 导入棋局ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 保存棋局ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(this.game);
            MessageBox.Show(json);
        }

        private void 复盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Gomoku : Form
    {
        Graphics graphic;
        
        private
        //是否开始
        bool start = false;
        bool allowToMove = false;
        bool humanVShuman = false;
        bool humanVSai = false;

        int whoToMove = 0;
        int winner = 0;

        int blackTime = 0;
        int whiteTime = 0;
        int blackTimeThis = 0;
        int whiteTimeThis = 0;

        // 1 for player 1(black) 2 for player 2(white)
        int[,] Chess = new int[15, 15];
        
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
            global::Gomoku.ChessBoard.DrawCB(graphic, this.ChessBoard);

            this.start = false;
            this.allowToMove = false;
            this.humanVShuman = false;
            this.humanVSai = false;

            this.whoToMove = 1;
            int winner = 0;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Chess[i, j] = 0;
                }
            }

            this.blackTime = 0;
            this.whiteTime = 0;
            this.blackTimeThis = 0;
            this.whiteTimeThis = 0;

            this.timer1.Enabled = false;
            this.black_time_all.Text = "局时: 0秒";
            this.black_time_this.Text = "步时: 0秒";
            this.white_time_all.Text = "局时: 0秒";
            this.white_time_this.Text = "步时: 0秒";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.start)
            {
                if (whoToMove == 1)
                {
                    blackTime++;
                    blackTimeThis++;

                    this.black_time_all.Text = "局时: " + Convert.ToString(blackTime) + "秒";
                    this.black_time_this.Text = "步时: " + Convert.ToString(blackTimeThis) + "秒";

                    if (blackTimeThis >= 15)
                    {

                    }
                }
                if (this.whoToMove == 2)
                {
                    whiteTime++;
                    whiteTimeThis++;

                    this.white_time_all.Text = "局时: " + Convert.ToString(whiteTime) + "秒";
                    this.white_time_this.Text = "步时: " + Convert.ToString(whiteTimeThis) + "秒";

                    if (whiteTimeThis >= 15)
                    {

                    }
                }
            }
        }

        private bool check_win_point(int x, int y)
        {
            if (Chess[x, y] == 0)
            {
                return false;
            }

            bool f;
            int chessColor = Chess[x, y];

            // right
            if (x + 5 < 15)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (Chess[x + k, y] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    this.winner = chessColor;
                    return true;
                }
            }
            // down
            if (y + 5 < 15)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (Chess[x, y + k] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    this.winner = chessColor;
                    return true;
                }
            }
            // right down
            if (x + 5 < 15 && y + 5 < 15)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (Chess[x + k, y + k] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    this.winner = chessColor;
                    return true;
                }
            }
            // right up
            if (x + 5 < 15 && y - 5 >= 0)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (Chess[x + k, y - k] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    this.winner = chessColor;
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
            if (this.start && this.allowToMove)
            {
                if (Chess[(e.X - 5) / 50, (e.Y - 5) / 50] != 0)
                {
                    MessageBox.Show("这个地方已经下过了!!!");
                }
                else
                {
                    if (e.X >= 5 && e.X <= 755 && e.Y >= 5 && e.Y <= 755)
                    {
                        this.blackTimeThis = 0;
                        this.whiteTimeThis = 0;
                        this.black_time_this.Text = "步时: 0秒";
                        this.white_time_this.Text = "步时: 0秒";

                        Chess[(e.X - 5) / 50, (e.Y - 5) / 50] = this.whoToMove;

                        Image img = this.ChessBoard.Image;
                        Graphics gra = Graphics.FromImage(img);
                        // gra.DrawEllipse(pen, e.X, e.Y, 33, 33);
                        switch (this.whoToMove)
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
                            this.start = false;
                            MessageBox.Show(Convert.ToString(this.whoToMove) + " WIN!!!");
                        }

                        if (this.humanVShuman)
                        {
                            this.whoToMove = 3 - this.whoToMove;
                        }
                        if (this.humanVSai)
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
            this.start = true;
            this.allowToMove = true;
            this.humanVShuman = true;
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

        }

        private void 复盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

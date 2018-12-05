using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace Gomoku
{
    public partial class Gomoku : Form
    {
        Graphics graphic;

        private

        Game game;
        Forbidden forbidden;
        AI ai;

        static readonly public Pen pen = new Pen(Color.Black, 1.0f);
        static readonly public Brush whiteBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
        static readonly public Brush blackBrush = new SolidBrush(Color.FromArgb(0, 0, 0));

        public int Ticks { get; set; }
        
        public Gomoku()
        {
            InitializeComponent();
            Width = MainSize.Wid;
            Height = MainSize.Hei;
            ChessBox.Width = MainSize.CBWid;
            ChessBox.Height = MainSize.CBHei;
        }

        private void Gomoku_Load(object sender, EventArgs e)
        {
            global::Gomoku.ChessBoard.DrawCB(this, graphic, ChessBoard);
        }

        private void restart_for_new_game()
        {
            game = new Game();
            forbidden = new Forbidden();
            global::Gomoku.ChessBoard.DrawCB(this, graphic, ChessBoard);

            timer1.Enabled = false;
            black_time_all.Text = "局时: 0秒";
            black_time_this.Text = "步时: 0秒";
            white_time_all.Text = "局时: 0秒";
            white_time_this.Text = "步时: 0秒";

            Connect.new_game();
        }

        private void ai_move()
        {
            ai.Running(game.Chess, game.WhoToMove);
            ai.GetNextStep(out int x, out int y);

            if (x < 0 || x > 14 || y < 0 || y > 14 || game.Chess[x, y] != 0)
            {
                // AI lose
            }


            game.BlackTimeThis = 0;
            game.WhiteTimeThis = 0;
            black_time_this.Text = "步时: 0秒";
            white_time_this.Text = "步时: 0秒";

            game.Move(x, y);

            Image img = ChessBoard.Image;
            Graphics gra = Graphics.FromImage(img);
            switch (game.WhoToMove)
            {
                case 1:
                    gra.FillEllipse(blackBrush, x * 50 + 15, y * 50 + 15, 30, 30);
                    break;
                case 2:
                    gra.FillEllipse(whiteBrush, x * 50 + 15, y * 50 + 15, 30, 30);
                    break;
            }
            ChessBoard.Image = img;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Gomoku gomoku = this;
            if (game.Review)
            {
                Ticks++;
                bool moveFlag = false;

                while(game.Moves[game.Steps, 1] < Ticks * 1000)
                {
                    if (game.Moves[game.Steps, 0] == 0)
                    {
                        game.Review = false;
                        game.AllowToMove = game.OldAllowToMove;
                        check_win();
                        return;
                    }

                    Image img = ChessBoard.Image;
                    Graphics gra = Graphics.FromImage(img);
                    switch (game.Moves[game.Steps, 0])
                    {
                        case 1:
                            gra.FillEllipse(blackBrush, game.Moves[game.Steps, 2] * 50 + 15, game.Moves[game.Steps, 3] * 50 + 15, 30, 30);
                            break;
                        case 2:
                            gra.FillEllipse(whiteBrush, game.Moves[game.Steps, 2] * 50 + 15, game.Moves[game.Steps, 3] * 50 + 15, 30, 30);
                            break;
                    }
                    ChessBoard.Image = img;

                    game.BlackTime = game.Moves[game.Steps, 4];
                    game.WhiteTime = game.Moves[game.Steps, 5];
                    game.BlackTimeThis = 0;
                    game.WhiteTimeThis = 0;
                    white_time_all.Text = "局时: " + Convert.ToString(game.WhiteTime) + "秒";
                    white_time_this.Text = "步时: " + Convert.ToString(game.WhiteTimeThis) + "秒";
                    black_time_all.Text = "局时: " + Convert.ToString(game.BlackTime) + "秒";
                    black_time_this.Text = "步时: " + Convert.ToString(game.BlackTimeThis) + "秒";

                    moveFlag = true;
                    game.Steps++;
                }

                if (!moveFlag)
                {
                    switch (game.Moves[game.Steps, 0])
                    {
                        case 1:
                            game.BlackTime++;
                            game.BlackTimeThis++;
                            black_time_all.Text = "局时: " + Convert.ToString(game.BlackTime) + "秒";
                            black_time_this.Text = "步时: " + Convert.ToString(game.BlackTimeThis) + "秒";
                            break;
                        case 2:
                            game.WhiteTime++;
                            game.WhiteTimeThis++;
                            gomoku.white_time_all.Text = "局时: " + Convert.ToString(gomoku.game.WhiteTime) + "秒";
                            gomoku.white_time_this.Text = "步时: " + Convert.ToString(gomoku.game.WhiteTimeThis) + "秒";
                            break;
                    }
                }
            }
            else if (gomoku.game.Start)
            {
                switch (gomoku.game.WhoToMove)
                {
                    case 1:
                        gomoku.game.BlackTime++;
                        gomoku.game.BlackTimeThis++;

                        gomoku.black_time_all.Text = "局时: " + Convert.ToString(gomoku.game.BlackTime) + "秒";
                        gomoku.black_time_this.Text = "步时: " + Convert.ToString(gomoku.game.BlackTimeThis) + "秒";

                        if (gomoku.game.BlackTimeThis >= 15)
                        {

                        }
                        break;
                    case 2:
                        gomoku.game.WhiteTime++;
                        gomoku.game.WhiteTimeThis++;

                        gomoku.white_time_all.Text = "局时: " + Convert.ToString(gomoku.game.WhiteTime) + "秒";
                        gomoku.white_time_this.Text = "步时: " + Convert.ToString(gomoku.game.WhiteTimeThis) + "秒";

                        if (gomoku.game.WhiteTimeThis >= 15)
                        {

                        }
                        break;
                }
            }
        }

        private bool check_win_point(int x, int y)
        {
            bool f;
            int chessColor = game.Chess[x, y];

            // right
            if (x + 5 <= 15)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (game.Chess[x + k, y] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    game.Winner = chessColor;
                    return true;
                }
            }
            // down
            if (y + 5 <= 15)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (game.Chess[x, y + k] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    game.Winner = chessColor;
                    return true;
                }
            }
            // right down
            if (x + 5 <= 15 && y + 5 <= 15)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (game.Chess[x + k, y + k] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    game.Winner = chessColor;
                    return true;
                }
            }
            // right up
            if (x + 5 <= 15 && y - 5 >= 0)
            {
                f = true;

                for (int k = 1; k <= 4; k++)
                {
                    if (game.Chess[x + k, y - k] != chessColor)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    game.Winner = chessColor;
                    return true;
                }
            }

            return false;
        }

        private bool check_win()
        {
            bool full = true;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (game.Chess[i, j] == 0)
                    {
                        full = false;
                    }
                    else
                    {
                        if (check_win_point(i, j))
                        {
                            game.Start = false;
                            switch (game.Winner)
                            {
                                case 1:
                                    MessageBox.Show("BLACK WIN!!!", "WIN");
                                    break;
                                case 2:
                                    MessageBox.Show("WHITE WIN!!!", "WIN");
                                    break;
                            }

                            return true;
                        }
                    }
                }

                if (full)
                {
                    game.Start = false;
                    game.Winner = 0;
                    MessageBox.Show("DRAW!!!", "DRAW");

                    return true;
                }
            }
            return false;
        }

        private void ChessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (game.Start && game.AllowToMove)
                {
                    game.AllowToMove = false;

                    int x = (e.X - 5) / 50;
                    int y = (e.Y - 5) / 50;

                    if (game.Chess[x, y] != 0)
                    {
                        MessageBox.Show("这个地方已经下过了!!!", "WRONG");
                    }
                    else
                    {
                        if (x >= 0 && x < 15 && y >= 0 && y < 15)
                        {
                            if (game.WhoToMove == 1)
                            {
                                game.Chess[x, y] = 1;
                                int f = forbidden.forbidden(game.Chess, x, y);
                                game.Chess[x, y] = 0;

                                if (f != 0)
                                {
                                    DialogResult dialogResult = DialogResult.Yes;
                                    switch (f)
                                    {
                                        case 1:
                                            dialogResult = MessageBox.Show("三三禁手!!!是否撤回该步？", "FORBIDDEN", MessageBoxButtons.YesNo);
                                            break;
                                        case 2:
                                            dialogResult = MessageBox.Show("四四禁手!!!是否撤回该步？", "FORBIDDEN", MessageBoxButtons.YesNo);
                                            break;
                                        case 3:
                                            dialogResult = MessageBox.Show("长连禁手!!!是否撤回该步？", "FORBIDDEN", MessageBoxButtons.YesNo);
                                            break;
                                    }

                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        game.AllowToMove = true;
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("WHITE WIN!!!", "WIN");
                                        game.Start = false;
                                        return;
                                    }
                                }
                            }

                            game.BlackTimeThis = 0;
                            game.WhiteTimeThis = 0;
                            black_time_this.Text = "步时: 0秒";
                            white_time_this.Text = "步时: 0秒";

                            game.Move(x, y);
                            
                            Image img = ChessBoard.Image;
                            Graphics gra = Graphics.FromImage(img);
                            switch (game.WhoToMove)
                            {
                                case 1:
                                    gra.FillEllipse(blackBrush, x * 50 + 15, y * 50 + 15, 30, 30);
                                    break;
                                case 2:
                                    gra.FillEllipse(whiteBrush, x * 50 + 15, y * 50 + 15, 30, 30);
                                    break;
                            }
                            ChessBoard.Image = img;


                            if (check_win())
                            {
                                return;
                            }

                            if (game.HumanVShuman)
                            {
                                game.WhoToMove = 3 - game.WhoToMove;
                            }

                            if (game.HumanVSai)
                            {
                                game.WhoToMove = 3 - game.WhoToMove;

                                ai_move();

                                if (check_win())
                                {
                                    return;
                                }
                                
                                game.WhoToMove = 3 - game.WhoToMove;
                            }
                        }
                    }

                    game.AllowToMove = true;
                }
            }
            catch
            {
                
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
            try
            {
                restart_for_new_game();
                game.Start = true;
                game.AllowToMove = true;
                game.HumanVShuman = true;
                timer1.Enabled = true;
            }
            catch
            {

            }
        }

        private void 玩家VSAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("AI先生还在和自己下棋练习棋艺，下次再来找AI先生下棋吧!!!", "INFO");

            try
            {
                DialogResult dialogResult = MessageBox.Show("AI先生很厉害的，你要持黑棋吗?", "", MessageBoxButtons.YesNo);
                ai = new AI();
                restart_for_new_game();
                game.Start = true;
                game.HumanVSai = true;
                timer1.Enabled = true;
                if (dialogResult == DialogResult.No)
                {
                    ai_move();
                    game.WhoToMove = 3 - game.WhoToMove;
                }
                game.AllowToMove = true;
            }
            catch
            {

            }

        }

        private void 导入棋局ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "json(*.json)|*.json|txt(*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                    string json = streamReader.ReadToEnd();
                    // MessageBox.Show(json, "INFO");

                    Game loadGame = JsonConvert.DeserializeObject<Game>(json);
                    restart_for_new_game();
                    game = loadGame;
                    timer1.Enabled = true;
                    global::Gomoku.ChessBoard.DrawCB(this, graphic, ChessBoard);
                }
            }
            catch
            {
                MessageBox.Show("READ ERROR!!!", "ERROR");
            }
        }

        private void 保存棋局ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "json(*.json)|*.json|txt(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    string json = JsonConvert.SerializeObject(game);
                    streamWriter.Write(json);
                    streamWriter.Close();
                }
                catch
                {
                    MessageBox.Show("SAVE ERROR!!!", "ERROR");
                }
            }
        }

        private void 复盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.game.Review = true;
                this.game.Start = true;
                this.game.OldAllowToMove = this.game.AllowToMove;
                this.game.AllowToMove = false;

                global::Gomoku.ChessBoard.DrawCB(this, graphic, this.ChessBoard, true);
                Ticks = 0;
                this.game.Steps = 0;
                this.game.BlackTime = 0;
                this.game.WhiteTime = 0;
                this.game.BlackTimeThis = 0;
                this.game.WhiteTimeThis = 0;
                this.white_time_all.Text = "局时: " + Convert.ToString(this.game.WhiteTime) + "秒";
                this.white_time_this.Text = "步时: " + Convert.ToString(this.game.WhiteTimeThis) + "秒";
                this.black_time_all.Text = "局时: " + Convert.ToString(this.game.BlackTime) + "秒";
                this.black_time_this.Text = "步时: " + Convert.ToString(this.game.BlackTimeThis) + "秒";
                this.timer1.Enabled = true;
            }
            catch
            {

            }
        }

        public int Chess(int x, int y)
        {
            if (game == null)
            {
                return 0;
            }
            else
            {
                return game.Chess[x, y];
            }
        }
        public bool Chess(int x, int y, int color)
        {
            if (game == null)
            {
                return false;
            }
            else
            {
                game.Chess[x, y] = color;
                return true;
            }
        }
    }
}

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
        AI ai;

        static readonly public Pen pen = new Pen(Color.Black, 1.0f);
        static readonly public Brush whiteBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
        static readonly public Brush blackBrush = new SolidBrush(Color.FromArgb(0, 0, 0));

        public int Ticks { get; set; }
        
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
            global::Gomoku.ChessBoard.DrawCB(this, graphic, this.ChessBoard);
        }

        private void restart_for_new_game()
        {
            this.game = new Game();
            global::Gomoku.ChessBoard.DrawCB(this, graphic, this.ChessBoard);

            this.timer1.Enabled = false;
            this.black_time_all.Text = "局时: 0秒";
            this.black_time_this.Text = "步时: 0秒";
            this.white_time_all.Text = "局时: 0秒";
            this.white_time_this.Text = "步时: 0秒";
        }

        private void ai_move()
        {
            int x, y;
            ai.Running(this.game.Chess, this.game.WhoToMove);
            ai.GetNextStep(out x, out y);

            if (x < 0 || x > 14 || y < 0 || y > 14 || this.game.Chess[x, y] != 0)
            {
                // AI lose
            }


            this.game.BlackTimeThis = 0;
            this.game.WhiteTimeThis = 0;
            this.black_time_this.Text = "步时: 0秒";
            this.white_time_this.Text = "步时: 0秒";

            this.game.Move(x, y);

            Image img = this.ChessBoard.Image;
            Graphics gra = Graphics.FromImage(img);
            switch (this.game.WhoToMove)
            {
                case 1:
                    gra.FillEllipse(blackBrush, x * 50 + 15, y * 50 + 15, 30, 30);
                    break;
                case 2:
                    gra.FillEllipse(whiteBrush, x * 50 + 15, y * 50 + 15, 30, 30);
                    break;
            }
            this.ChessBoard.Image = img;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.game.Review)
            {
                Ticks++;
                bool moveFlag = false;

                while(this.game.Moves[this.game.Steps, 1] < Ticks * 1000)
                {
                    if (this.game.Moves[this.game.Steps, 0] == 0)
                    {
                        this.game.Review = false;
                        this.game.AllowToMove = this.game.OldAllowToMove;
                        this.check_win();
                        return;
                    }

                    Image img = this.ChessBoard.Image;
                    Graphics gra = Graphics.FromImage(img);
                    switch (this.game.Moves[this.game.Steps, 0])
                    {
                        case 1:
                            gra.FillEllipse(blackBrush, this.game.Moves[this.game.Steps, 2] * 50 + 15, this.game.Moves[this.game.Steps, 3] * 50 + 15, 30, 30);
                            break;
                        case 2:
                            gra.FillEllipse(whiteBrush, this.game.Moves[this.game.Steps, 2] * 50 + 15, this.game.Moves[this.game.Steps, 3] * 50 + 15, 30, 30);
                            break;
                    }
                    this.ChessBoard.Image = img;

                    this.game.BlackTime = this.game.Moves[this.game.Steps, 4];
                    this.game.WhiteTime = this.game.Moves[this.game.Steps, 5];
                    this.game.BlackTimeThis = 0;
                    this.game.WhiteTimeThis = 0;
                    this.white_time_all.Text = "局时: " + Convert.ToString(this.game.WhiteTime) + "秒";
                    this.white_time_this.Text = "步时: " + Convert.ToString(this.game.WhiteTimeThis) + "秒";
                    this.black_time_all.Text = "局时: " + Convert.ToString(this.game.BlackTime) + "秒";
                    this.black_time_this.Text = "步时: " + Convert.ToString(this.game.BlackTimeThis) + "秒";

                    moveFlag = true;
                    this.game.Steps++;
                }

                if (!moveFlag)
                {
                    switch (this.game.Moves[this.game.Steps, 0])
                    {
                        case 1:
                            this.game.BlackTime++;
                            this.game.BlackTimeThis++;
                            this.black_time_all.Text = "局时: " + Convert.ToString(this.game.BlackTime) + "秒";
                            this.black_time_this.Text = "步时: " + Convert.ToString(this.game.BlackTimeThis) + "秒";
                            break;
                        case 2:
                            this.game.WhiteTime++;
                            this.game.WhiteTimeThis++;
                            this.white_time_all.Text = "局时: " + Convert.ToString(this.game.WhiteTime) + "秒";
                            this.white_time_this.Text = "步时: " + Convert.ToString(this.game.WhiteTimeThis) + "秒";
                            break;
                    }
                }
            }
            else if (this.game.Start)
            {
                switch (this.game.WhoToMove)
                {
                    case 1:
                        this.game.BlackTime++;
                        this.game.BlackTimeThis++;

                        this.black_time_all.Text = "局时: " + Convert.ToString(this.game.BlackTime) + "秒";
                        this.black_time_this.Text = "步时: " + Convert.ToString(this.game.BlackTimeThis) + "秒";

                        if (this.game.BlackTimeThis >= 15)
                        {

                        }
                        break;
                    case 2:
                        this.game.WhiteTime++;
                        this.game.WhiteTimeThis++;

                        this.white_time_all.Text = "局时: " + Convert.ToString(this.game.WhiteTime) + "秒";
                        this.white_time_this.Text = "步时: " + Convert.ToString(this.game.WhiteTimeThis) + "秒";

                        if (this.game.WhiteTimeThis >= 15)
                        {

                        }
                        break;
                }
            }
        }

        private bool check_win_point(int x, int y)
        {
            bool f;
            int chessColor = this.game.Chess[x, y];

            // right
            if (x + 5 <= 15)
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
            if (y + 5 <= 15)
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
            if (x + 5 <= 15 && y + 5 <= 15)
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
            if (x + 5 <= 15 && y - 5 >= 0)
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
            bool full = true;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (this.game.Chess[i, j] == 0)
                    {
                        full = false;
                    }
                    else
                    {
                        if (check_win_point(i, j))
                        {
                            this.game.Start = false;
                            switch (this.game.Winner)
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
                    this.game.Start = false;
                    this.game.Winner = 0;
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
                if (this.game.Start && this.game.AllowToMove)
                {
                    this.game.AllowToMove = false;

                    int x = (e.X - 5) / 50;
                    int y = (e.Y - 5) / 50;

                    if (this.game.Chess[x, y] != 0)
                    {
                        MessageBox.Show("这个地方已经下过了!!!", "WRONG");
                    }
                    else
                    {
                        if (x >= 0 && x < 15 && y >= 0 && y < 15)
                        {
                            this.game.BlackTimeThis = 0;
                            this.game.WhiteTimeThis = 0;
                            this.black_time_this.Text = "步时: 0秒";
                            this.white_time_this.Text = "步时: 0秒";

                            this.game.Move(x, y);
                            
                            Image img = this.ChessBoard.Image;
                            Graphics gra = Graphics.FromImage(img);
                            switch (this.game.WhoToMove)
                            {
                                case 1:
                                    gra.FillEllipse(blackBrush, x * 50 + 15, y * 50 + 15, 30, 30);
                                    break;
                                case 2:
                                    gra.FillEllipse(whiteBrush, x * 50 + 15, y * 50 + 15, 30, 30);
                                    break;
                            }
                            this.ChessBoard.Image = img;


                            if (this.check_win())
                            {
                                return;
                            }

                            if (this.game.HumanVShuman)
                            {
                                this.game.WhoToMove = 3 - this.game.WhoToMove;
                            }

                            if (this.game.HumanVSai)
                            {
                                this.game.WhoToMove = 3 - this.game.WhoToMove;

                                ai_move();

                                if (this.check_win())
                                {
                                    return;
                                }
                                
                                this.game.WhoToMove = 3 - this.game.WhoToMove;
                            }
                        }
                    }

                    this.game.AllowToMove = true;
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
                this.restart_for_new_game();
                this.game.Start = true;
                this.game.AllowToMove = true;
                this.game.HumanVShuman = true;
                this.timer1.Enabled = true;
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
                this.ai = new AI();
                this.restart_for_new_game();
                this.game.Start = true;
                this.game.HumanVSai = true;
                this.timer1.Enabled = true;
                if (dialogResult == DialogResult.No)
                {
                    ai_move();
                    this.game.WhoToMove = 3 - this.game.WhoToMove;
                }
                this.game.AllowToMove = true;
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
                    this.restart_for_new_game();
                    this.game = loadGame;
                    this.timer1.Enabled = true;
                    global::Gomoku.ChessBoard.DrawCB(this, graphic, this.ChessBoard);
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
                    string json = JsonConvert.SerializeObject(this.game);
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
            if (this.game == null)
            {
                return 0;
            }
            else
            {
                return this.game.Chess[x, y];
            }
        }
    }
}

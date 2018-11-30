namespace Gomoku
{
    partial class Gomoku
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.新游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.玩家VS玩家ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.玩家VSAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.棋局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入棋局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存棋局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.black = new System.Windows.Forms.Label();
            this.white = new System.Windows.Forms.Label();
            this.black_time_all = new System.Windows.Forms.Label();
            this.white_time_all = new System.Windows.Forms.Label();
            this.black_time_this = new System.Windows.Forms.Label();
            this.white_time_this = new System.Windows.Forms.Label();
            this.ChessBoard = new System.Windows.Forms.PictureBox();
            this.ChessBox = new System.Windows.Forms.PictureBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChessBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChessBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新游戏ToolStripMenuItem,
            this.棋局ToolStripMenuItem,
            this.复盘ToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1064, 25);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // 新游戏ToolStripMenuItem
            // 
            this.新游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.玩家VS玩家ToolStripMenuItem,
            this.玩家VSAIToolStripMenuItem});
            this.新游戏ToolStripMenuItem.Name = "新游戏ToolStripMenuItem";
            this.新游戏ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.新游戏ToolStripMenuItem.Text = "新游戏";
            // 
            // 玩家VS玩家ToolStripMenuItem
            // 
            this.玩家VS玩家ToolStripMenuItem.Name = "玩家VS玩家ToolStripMenuItem";
            this.玩家VS玩家ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.玩家VS玩家ToolStripMenuItem.Text = "玩家 VS 玩家";
            this.玩家VS玩家ToolStripMenuItem.Click += new System.EventHandler(this.玩家VS玩家ToolStripMenuItem_Click);
            // 
            // 玩家VSAIToolStripMenuItem
            // 
            this.玩家VSAIToolStripMenuItem.Name = "玩家VSAIToolStripMenuItem";
            this.玩家VSAIToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.玩家VSAIToolStripMenuItem.Text = "玩家 VS AI";
            this.玩家VSAIToolStripMenuItem.Click += new System.EventHandler(this.玩家VSAIToolStripMenuItem_Click);
            // 
            // 棋局ToolStripMenuItem
            // 
            this.棋局ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入棋局ToolStripMenuItem,
            this.保存棋局ToolStripMenuItem});
            this.棋局ToolStripMenuItem.Name = "棋局ToolStripMenuItem";
            this.棋局ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.棋局ToolStripMenuItem.Text = "棋局";
            // 
            // 导入棋局ToolStripMenuItem
            // 
            this.导入棋局ToolStripMenuItem.Name = "导入棋局ToolStripMenuItem";
            this.导入棋局ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.导入棋局ToolStripMenuItem.Text = "导入棋局";
            this.导入棋局ToolStripMenuItem.Click += new System.EventHandler(this.导入棋局ToolStripMenuItem_Click);
            // 
            // 保存棋局ToolStripMenuItem
            // 
            this.保存棋局ToolStripMenuItem.Name = "保存棋局ToolStripMenuItem";
            this.保存棋局ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存棋局ToolStripMenuItem.Text = "保存棋局";
            this.保存棋局ToolStripMenuItem.Click += new System.EventHandler(this.保存棋局ToolStripMenuItem_Click);
            // 
            // 复盘ToolStripMenuItem
            // 
            this.复盘ToolStripMenuItem.Name = "复盘ToolStripMenuItem";
            this.复盘ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.复盘ToolStripMenuItem.Text = "复盘";
            this.复盘ToolStripMenuItem.Click += new System.EventHandler(this.复盘ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // black
            // 
            this.black.Font = new System.Drawing.Font("宋体", 18F);
            this.black.Location = new System.Drawing.Point(831, 125);
            this.black.Name = "black";
            this.black.Size = new System.Drawing.Size(100, 23);
            this.black.TabIndex = 3;
            this.black.Text = "黑棋";
            // 
            // white
            // 
            this.white.Font = new System.Drawing.Font("宋体", 18F);
            this.white.Location = new System.Drawing.Point(822, 302);
            this.white.Name = "white";
            this.white.Size = new System.Drawing.Size(100, 33);
            this.white.TabIndex = 4;
            this.white.Text = "白棋";
            // 
            // black_time_all
            // 
            this.black_time_all.AutoSize = true;
            this.black_time_all.Location = new System.Drawing.Point(835, 181);
            this.black_time_all.Name = "black_time_all";
            this.black_time_all.Size = new System.Drawing.Size(59, 12);
            this.black_time_all.TabIndex = 9;
            this.black_time_all.Text = "局时: 0秒";
            // 
            // white_time_all
            // 
            this.white_time_all.AutoSize = true;
            this.white_time_all.Location = new System.Drawing.Point(824, 407);
            this.white_time_all.Name = "white_time_all";
            this.white_time_all.Size = new System.Drawing.Size(59, 12);
            this.white_time_all.TabIndex = 10;
            this.white_time_all.Text = "局时: 0秒";
            // 
            // black_time_this
            // 
            this.black_time_this.AutoSize = true;
            this.black_time_this.Location = new System.Drawing.Point(833, 226);
            this.black_time_this.Name = "black_time_this";
            this.black_time_this.Size = new System.Drawing.Size(59, 12);
            this.black_time_this.TabIndex = 11;
            this.black_time_this.Text = "步时: 0秒";
            // 
            // white_time_this
            // 
            this.white_time_this.AutoSize = true;
            this.white_time_this.Location = new System.Drawing.Point(824, 449);
            this.white_time_this.Name = "white_time_this";
            this.white_time_this.Size = new System.Drawing.Size(59, 12);
            this.white_time_this.TabIndex = 12;
            this.white_time_this.Text = "步时: 0秒";
            // 
            // ChessBoard
            // 
            this.ChessBoard.Location = new System.Drawing.Point(10, 28);
            this.ChessBoard.Name = "ChessBoard";
            this.ChessBoard.Size = new System.Drawing.Size(800, 800);
            this.ChessBoard.TabIndex = 1;
            this.ChessBoard.TabStop = false;
            this.ChessBoard.Click += new System.EventHandler(this.ChessBoard_Click_1);
            this.ChessBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChessBoard_MouseClick);
            // 
            // ChessBox
            // 
            this.ChessBox.BackColor = System.Drawing.Color.Transparent;
            this.ChessBox.Location = new System.Drawing.Point(927, 46);
            this.ChessBox.Name = "ChessBox";
            this.ChessBox.Size = new System.Drawing.Size(108, 112);
            this.ChessBox.TabIndex = 13;
            this.ChessBox.TabStop = false;
            this.ChessBox.Click += new System.EventHandler(this.ChessBox_Click);
            // 
            // Gomoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 845);
            this.Controls.Add(this.ChessBox);
            this.Controls.Add(this.white_time_this);
            this.Controls.Add(this.black_time_this);
            this.Controls.Add(this.white_time_all);
            this.Controls.Add(this.black_time_all);
            this.Controls.Add(this.white);
            this.Controls.Add(this.black);
            this.Controls.Add(this.ChessBoard);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Gomoku";
            this.Text = "Gomoku";
            this.Load += new System.EventHandler(this.Gomoku_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChessBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChessBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem 新游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 棋局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入棋局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存棋局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复盘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 玩家VS玩家ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 玩家VSAIToolStripMenuItem;
        private System.Windows.Forms.PictureBox ChessBoard;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label black;
        private System.Windows.Forms.Label white;
        private System.Windows.Forms.Label black_time_all;
        private System.Windows.Forms.Label white_time_all;
        private System.Windows.Forms.Label black_time_this;
        private System.Windows.Forms.Label white_time_this;
        private System.Windows.Forms.PictureBox ChessBox;
    }
}


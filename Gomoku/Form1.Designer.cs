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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.新游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.棋局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入棋局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存棋局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.玩家VS玩家ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.玩家VSAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChessBox = new System.Windows.Forms.PictureBox();
            this.menu.SuspendLayout();
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
            this.menu.Size = new System.Drawing.Size(624, 25);
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
            // 
            // 保存棋局ToolStripMenuItem
            // 
            this.保存棋局ToolStripMenuItem.Name = "保存棋局ToolStripMenuItem";
            this.保存棋局ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存棋局ToolStripMenuItem.Text = "保存棋局";
            // 
            // 复盘ToolStripMenuItem
            // 
            this.复盘ToolStripMenuItem.Name = "复盘ToolStripMenuItem";
            this.复盘ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.复盘ToolStripMenuItem.Text = "复盘";
            // 
            // 玩家VS玩家ToolStripMenuItem
            // 
            this.玩家VS玩家ToolStripMenuItem.Name = "玩家VS玩家ToolStripMenuItem";
            this.玩家VS玩家ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.玩家VS玩家ToolStripMenuItem.Text = "玩家 VS 玩家";
            // 
            // 玩家VSAIToolStripMenuItem
            // 
            this.玩家VSAIToolStripMenuItem.Name = "玩家VSAIToolStripMenuItem";
            this.玩家VSAIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.玩家VSAIToolStripMenuItem.Text = "玩家 VS AI";
            // 
            // ChessBox
            // 
            this.ChessBox.Location = new System.Drawing.Point(10, 30);
            this.ChessBox.Name = "ChessBox";
            this.ChessBox.Size = new System.Drawing.Size(400, 400);
            this.ChessBox.TabIndex = 1;
            this.ChessBox.TabStop = false;
            // 
            // Gomoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.ChessBox);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Gomoku";
            this.Text = "Gomoku";
            this.Load += new System.EventHandler(this.Gomoku_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
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
        private System.Windows.Forms.PictureBox ChessBox;
    }
}


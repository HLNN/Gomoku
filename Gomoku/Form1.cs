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

        //是否开始
        static bool start;

        int[,] ChessBack = new int[20, 20];
        

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
            ChessBoard.DrawCB(graphic, this.ChessBox);
        }
    }
}

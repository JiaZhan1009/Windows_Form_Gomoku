using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    // 將 internal 更改為 abstract, 防止使用者意外建立一個 Piece
    abstract class Piece : PictureBox
    {
        private static readonly int imgWidth = 50;
        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x - imgWidth / 2, y - imgWidth / 2);
            this.Size = new Size(imgWidth, imgWidth);
        }
    }
}

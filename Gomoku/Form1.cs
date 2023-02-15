namespace Gomoku
{
    public partial class Form1 : Form
    {
        Game game = new Game();
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);
            if (piece != null)
            {
                this.Controls.Add(piece);

                // �ˬd�O�_���H���
                if (game.Winner == PieceType.BLACK)
                {
                    MessageBox.Show("�¦����");
                }
                else if (game.Winner == PieceType.WHITE)
                {
                    MessageBox.Show("�զ����");
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
         {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Control> controls = new List<Control>();
            foreach (Control control in this.Controls)
            {
                if (control is Piece)
                {
                    controls.Add(control);
                }
            }

            foreach (Control control in controls)
            {
                this.Controls.Remove(control);
            } 
       
            game.ResetGame();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class Board
    {
        private static readonly int NODE_COUNT = 9;

        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);

        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTRANCE = 75;

        private Piece[,] pieces = new Piece[9, 9];

        public bool CanBePlaced(int x, int y)
        {
            // 找出最近的節點 (Node)
            Point nodeId = findTheCloseNode(x, y);

            // 如果沒有的話, 回傳 false
            if (nodeId == NO_MATCH_NODE)
                return false;

            // 如果有的話, 檢查是否已經有棋子
            return true;
        }

        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            // 找出最近的節點 (Node)
            Point nodeId = findTheCloseNode(x, y);

            // 如果沒有的話, 回傳 null
            if (nodeId == NO_MATCH_NODE)
                return null;

            // 如果有的話, 檢查是否已經有棋子
            if (pieces[nodeId.X, nodeId.Y] != null)
                return null;

            // 根據 type 產生對應的棋子
            Point formPos = convertToFormPosition(nodeId);

            if (type == PieceType.BLACK)
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            else
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y);

            return pieces[nodeId.X, nodeId.Y];
        }

        private Point convertToFormPosition(Point nodeId)
        {
            Point formPosition = new Point();
            formPosition.X = nodeId.X * NODE_DISTRANCE + OFFSET;
            formPosition.Y = nodeId.Y * NODE_DISTRANCE + OFFSET;
            return formPosition;
        }

        private Point findTheCloseNode(int x, int y)
        {
            int NodeIdX = findTheCloseNode(x);

            if (NodeIdX == -1 || NodeIdX >= NODE_COUNT)
                return NO_MATCH_NODE;

            int NodeIdY = findTheCloseNode(y);

            if (NodeIdY == -1 || NodeIdY >= NODE_COUNT)
                return NO_MATCH_NODE;

            return new Point(NodeIdX, NodeIdY);
        }
        private int findTheCloseNode(int pos)
        {
            if (pos < OFFSET - NODE_RADIUS)
                return -1;

            pos -= OFFSET;
            int quotient = pos / NODE_DISTRANCE;
            int remainder = pos % NODE_DISTRANCE;

            if (remainder <= NODE_RADIUS)
                return quotient;
            else if (remainder >= NODE_DISTRANCE - NODE_RADIUS)
                return quotient + 1;
            else
                return -1;
        }

    }
}
;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaperModel
{
    public class Cell
    {
        public int row;
        public int col;
        public int maxRow;
        public int maxCol;
        public int amount;
        public bool isBomb;
        public bool isPushed;

        public Cell(int row, int col, int maxRow, int maxCol)
        {
            this.row = row;
            this.col = col;
            this.maxRow = maxRow;
            this.maxCol = maxCol;
            this.amount = 0;
            this.isBomb = false;
            this.isPushed = false;
        }

        public IEnumerable<(int, int)> GetNeighbors()
        {
            yield return (row - 1, col - 1);
            yield return (row - 1, col);
            yield return (row - 1, col + 1);
            yield return (row, col - 1);
            yield return (row, col + 1);
            yield return (row + 1, col - 1);
            yield return (row + 1, col);
            yield return (row + 1, col + 1);
        }

        public bool IsBomb()
        {
            return isBomb;
        }

        public void MarkAsBomb()
        {
            isBomb = true;
        }

        public bool IsPushed()
        {
            return isPushed;
        }

        public void MarkAsPushed()
        {
            isPushed = true;
        }

        public int Amount
        {
            get { return amount; }
        }

        public void IncrementAmount()
        {
            amount++;
        }
    }
}

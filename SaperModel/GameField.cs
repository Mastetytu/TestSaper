using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaperModel
{
    public class GameField
    {
        public List<List<Cell>> field;
        public Guid gameId;
        public NewGameRequest config;
        public bool completed;

        public GameField(NewGameRequest parameters, Guid gameId)
        {
            this.gameId = gameId;
            this.config = parameters;
            this.completed = false;
            InitializeField();
            CreateMines();
            InitializeRelations();
        }

        public void InitializeField()
        {
            field = new List<List<Cell>>();
            for (int i = 0; i < config.Height; i++)
            {
                List<Cell> row = new List<Cell>();
                for (int j = 0; j < config.Width; j++)
                {
                    row.Add(new Cell(i, j, config.Height - 1, config.Width - 1));
                }
                field.Add(row);
            }
        }

        public void CreateMines()
        {
            int count = config.MinesCount;
            while (count != 0)
            {
                int col = new Random().Next(0, config.Width);
                int row = new Random().Next(0, config.Height);
                Cell cell = GetCell(row, col);
                if (!cell.IsBomb())
                {
                    cell.MarkAsBomb();
                }
                count--;
            }
        }

        public void InitializeRelations()
        {
            IEnumerable<Cell> bombs = GetAllCells().Where(c => c.IsBomb());
            IEnumerable<(int, int)> neighbors = bombs.SelectMany(b => b.GetNeighbors()).Where(n => n.Item1 >= 0 && n.Item1 < config.Height && n.Item2 >= 0 && n.Item2 < config.Width);
            foreach ((int row, int col) in neighbors)
            {
                Cell cell = GetCell(row, col);
                if (!cell.IsBomb())
                {
                    cell.IncrementAmount();
                }
            }
        }

        public void CreateNewTurn(int row, int col)
        {
            if (completed)
            {
                return;
            }
            Cell cell = GetCell(row, col);
            cell.MarkAsPushed();
            if (cell.IsBomb())
            {
                return;
            }
            CheckIfSafeCellsAround(cell);
            if (IsComplete())
            {
                completed = true;
            }
        }

        public bool IsComplete()
        {
            int count = GetAllCells().Count(c => c.IsPushed());
            return count + config.MinesCount == config.Height * config.Width;
        }

        public void CheckIfSafeCellsAround(Cell cell)
        {
            foreach ((int row, int col) in cell.GetNeighbors())
            {
                if (row >= 0 && row < config.Height && col >= 0 && col < config.Width)
                {
                    Cell neighbor = GetCell(row, col);
                    if (neighbor.Amount == 0 && !neighbor.IsPushed())
                    {
                        neighbor.MarkAsPushed();
                        CheckIfSafeCellsAround(neighbor);
                    }
                    else
                    {
                        neighbor.MarkAsPushed();
                    }
                }
            }
        }

        public Cell GetCell(int row, int col)
        {
            return field[row][col];
        }

        public IEnumerable<Cell> GetAllCells()
        {
            return field.SelectMany(row => row);
        }

        public GameInfoResponse GetGameInfoResponse()
        {
            return new GameInfoResponse
            {
                GameId = gameId,
                Completed = completed,
                
            };
        }
    }
}

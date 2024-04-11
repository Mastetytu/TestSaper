using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaperModel
{
    public class GameTurnRequest
    {
        public Guid GameId { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}

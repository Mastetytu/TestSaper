using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaperModel
{
    public class Saper
    {
        public Dictionary<Guid, GameField> games = new Dictionary<Guid, GameField>();

        public GameInfoResponse CreateNewGame(NewGameRequest parameters)
        {
            Guid gameId = Guid.NewGuid();
            games[gameId] = new GameField(parameters, gameId);
            return games[gameId].GetGameInfoResponse();
        }

        public GameInfoResponse CreateNewTurn(GameTurnRequest parameters)
        {
            GameField gameField = games[parameters.GameId];
            gameField.CreateNewTurn(parameters.Row, parameters.Col);
            return gameField.GetGameInfoResponse();
        }
    }
}

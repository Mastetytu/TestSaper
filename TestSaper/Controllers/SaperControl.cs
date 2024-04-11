using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaperModel;
namespace TestSaper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaperControl : Controller
    {
        public readonly Saper _game;

        public SaperControl(Saper game)
        {
            _game = game;
        }

        [HttpPost("new")]
        public async Task<GameInfoResponse> CreateNewGame(NewGameRequest obj_in)
        {
            return _game.CreateNewGame(obj_in);
        }

        [HttpPost("turn")]
        public async Task<GameInfoResponse> CreateNewTurn(GameTurnRequest obj_in)
        {
            return _game.CreateNewTurn(obj_in);
        }
    }
}

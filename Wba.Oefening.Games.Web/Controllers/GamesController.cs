using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;
        public GamesController()
        {
            _gameRepository = new GameRepository();
        }
        public IActionResult Index()
        {
            var games = _gameRepository.GetGames();
            var formattedGames = FormatGameInfo(games);
            return Content(formattedGames,"text/html");
        }
        private string FormatGameInfo(Game game)
        {
            //format game info
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("<h5>Game info</h5>");
            stringBuilder.AppendLine($"<li>Id:{game.Id}</li>");
            stringBuilder.AppendLine($"<li>Title:{game.Title}</li>");
            stringBuilder.AppendLine($"<li>Developer:{game.Developer.Name}</li>");
            stringBuilder.AppendLine($"<li>Rating:{game?.Rating ?? 0}</li>");

            return stringBuilder.ToString();
        }
        private string FormatGameInfo(IEnumerable<Game> games)
        {
            //loop over games and call FormatGameInfo(game)
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("<h4>Our games</h4>");
            stringBuilder.AppendLine("<ul>");
            foreach (var game in games)
            {
                stringBuilder.AppendLine(FormatGameInfo(game));
            }
            stringBuilder.AppendLine("</ul>");
            return stringBuilder.ToString();
        }
    }
}

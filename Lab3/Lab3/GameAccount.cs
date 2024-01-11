using Lab3.DB.Service;
using System.Numerics;

namespace Lab3
{
    internal class GameAccount
    {
        public int Id {  get; set; }
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();
        public GameAccountService Service { get; set; }

        public GameAccount(GameAccountService service, int ID, string userName, int gamesCount = 0)
        {
            Service = service;
            UserName = userName;
            CurrentRating = 100;
            GamesCount = gamesCount;
            Id = ID;
        }
        public void WinGame(Game game, string player, int gameIndex)
        {
            int rating = RatingCalc(game.getPlayRating(this));
            string winner = "Win";
            CurrentRating += rating;
            GamesCount++;
            GameResults.Add(new GameResult(player, winner, rating, gameIndex, CurrentRating));
            Service.Update(this);
        }
        public void LoseGame(Game game, string player, int gameIndex)
        {
            int rating = RatingCalc(game.getPlayRating(this));
            string winner = "Lose";
            if (CurrentRating > 1)
            {
                CurrentRating -= rating;
                if (CurrentRating < 1)
                {
                    CurrentRating = 1;
                }
            }
            GamesCount++;
            GameResults.Add(new GameResult(player, winner, rating, gameIndex, CurrentRating));
            Service.Update(this);
        }
        public void DrawGame(Game game, string player, int gameIndex, int currentRating)
        {
            GamesCount++;
            string winner = "Draw";
            int rating = RatingCalc(game.getPlayRating(this));
            GameResults.Add(new GameResult(player, winner, rating, gameIndex, currentRating));
            Service.Update(this);
        }

        public void GetStats()
        {
            if (GameResults == null)
            {
                Console.WriteLine($"Name:{UserName}, Id: {Id}");
                return;
            }

            Console.WriteLine($"Name:{UserName}, Id: {Id}");
            for (int i = 0; i < GameResults.Count; i++)
            {
                var result = Service.GameResults(this)[i];
                Console.WriteLine($"Against {result.Opponent}, {result.Winner}, Rating: {result.CurrentRating}, Game number #{result.GameIndex}");
            }
            Console.WriteLine($"Current rating for player {UserName}: {CurrentRating}\n" + $"Games played: {GamesCount}\n");
        }
        public virtual int RatingCalc(int rating)
        {
            return rating;
        }
    }
}

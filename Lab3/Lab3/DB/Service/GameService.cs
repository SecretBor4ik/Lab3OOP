using Lab3.DB.Entity;
using Lab3.DB.Repository;
using Lab3.DB.Service.Base;

namespace Lab3.DB.Service
{
    internal class GameService : IGameService
    {
        GameRepository gameRepository;
        public GameService(DbContext context)
        {
            gameRepository = new GameRepository(context);
        }

        public void Create(Game gameEntity)
        {
            gameRepository.Create(Map(gameEntity));
        }

        public void Update(Game gameEntity)
        {
            gameRepository.Update(Map(gameEntity));
        }

        public void Delete(Game gameEntity)
        {
            gameRepository.Delete(Map(gameEntity));
        }

        //Mapers
        private GameEntity Map(Game game)
        {
            return new GameEntity
            {
                Player1 = game.player1,
                Player2 = game.player2,
                PlayRating = game.playRating,
                Winner = game.winner,
            };
        }
    }
}

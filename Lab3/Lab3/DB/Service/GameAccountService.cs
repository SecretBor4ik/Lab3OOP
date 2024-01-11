using Lab3.DB.Entity;
using Lab3.DB.Repository;
using Lab3.DB.Service.Base;
using System.Data;

namespace Lab3.DB.Service
{
    internal class GameAccountService : IGameAccountService
    {
        GameAccountRepository gameAccountRepository;
        public GameAccountService(DbContext context)
        {
            gameAccountRepository = new GameAccountRepository(context);
        }

        public void Create(GameAccount entity)
        {
            gameAccountRepository.Create(Map(entity));
        }

        public List<GameAccount> ReadAll()
        {
            var list = gameAccountRepository.ReadAll().Select(x => x != null ? Map(x) : null).ToList();
            return list;
        }

        public GameAccount ReadById(int id)
        {
            return Map(gameAccountRepository.ReadById(id));
        }
        public void Update(GameAccount entity)
        {
            gameAccountRepository.Update(Map(entity));
        }

        public void Delete(GameAccount entity)
        {
            gameAccountRepository.Delete(Map(entity));
        }

        public List<GameResult> GameResults(GameAccount entity)
        {
            return MapGameResultList(gameAccountRepository.GameResults(Map(entity)));
        }

        public void AddGameResult(GameResult gameResult, GameAccount entity)
        {
            gameAccountRepository.AddGameResult(MapGameResult(gameResult), Map(entity));
        }

        //Mapers
        private GameAccountEntity Map(GameAccount gameAccount)
        {
            if (gameAccount == null)
            {
                return null;
            }
            return new GameAccountEntity
            {
                Id = gameAccount.Id,
                UserName = gameAccount.UserName,
                CurrentRating = gameAccount.CurrentRating,
                GamesCount = gameAccount.GamesCount,
                GameResults = MapGameResultList(gameAccount.GameResults)
            };
        }

        private List<GameResultEntity> MapGameResultList(List<GameResult> gameResultList)
        {
            if (gameResultList == null)
            {
                return null;
            }

            List<GameResultEntity> gameResultEntitieList = new List<GameResultEntity>();

            foreach (var gameResult in gameResultList)
            {
                gameResultEntitieList.Add(new GameResultEntity
                {
                    Opponent = gameResult.Opponent,
                    Winner = gameResult.Winner,
                    Rating = gameResult.Rating,
                    GameIndex = gameResult.GameIndex,
                    CurrentRating = gameResult.CurrentRating
                });
            }
            return gameResultEntitieList;
        }

        private GameAccount Map(GameAccountEntity gameAccount)
        {
            return new GameAccount(this, gameAccount.Id, gameAccount.UserName)
            {
                Service = this,
                UserName = gameAccount.UserName,
                CurrentRating = gameAccount.CurrentRating,
                GamesCount = gameAccount.GamesCount,
                GameResults = MapGameResultList(gameAccount.GameResults)
            };
        }
        private List<GameResult> MapGameResultList(List<GameResultEntity> gameResultEntitieList)
        {
            List<GameResult> gameResultList = new List<GameResult>();
            if (gameResultEntitieList == null)
            {
                return new List<GameResult>();
            }
            foreach (var gameResultEntity in gameResultEntitieList)
            {
                gameResultList.Add(new GameResult
                {
                    Opponent = gameResultEntity.Opponent,
                    Winner = gameResultEntity.Winner,
                    Rating = gameResultEntity.Rating,
                    GameIndex = gameResultEntity.GameIndex,
                    CurrentRating = gameResultEntity.CurrentRating
                });
            }
            return gameResultList;
        }

        private GameResultEntity MapGameResult(GameResult gameResult)
        {
            if (gameResult == null)
            {
                return null;
            }

            return new GameResultEntity
            {
                Opponent = gameResult.Opponent,
                Winner = gameResult.Winner,
                Rating = gameResult.Rating,
                GameIndex = gameResult.GameIndex,
                CurrentRating = gameResult.CurrentRating
            };
        }
    }
}

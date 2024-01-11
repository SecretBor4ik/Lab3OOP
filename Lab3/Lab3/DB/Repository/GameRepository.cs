using Lab3.DB.Entity;
using Lab3.DB.Repository.Base;

namespace Lab3.DB.Repository
{
    internal class GameRepository : IGameRepository
    {
        private DbContext dbContext;
        public GameRepository(DbContext context)
        {
            dbContext = context;
        }
        public void Create(GameEntity gameEntity)
        {
            dbContext.Games.Add(gameEntity);
        }
        public List<GameEntity> ReadAll()
        {
            return dbContext.Games;
        }

        public GameEntity ReadById(int Id)
        {
            return dbContext.Games[Id];
        }

        public void Update(GameEntity gameEntity)
        {
            dbContext.Games.RemoveAt(gameEntity.Id);
            dbContext.Games.Insert(gameEntity.Id, gameEntity);
        }

        public void Delete(GameEntity gameEntity)
        {
            dbContext.Games.RemoveAt(gameEntity.Id);
            int NewId = 1;
            foreach (var game in dbContext.Games)
            {
                dbContext.Games[NewId].Id = NewId;
                NewId++;
            }
        }
    }
}

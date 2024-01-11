using Lab3.DB.Entity;
using Lab3.DB.Repository.Base;

namespace Lab3.DB.Repository
{
    internal class GameAccountRepository : IGameAccountRepository
    {
        DbContext dbContext;
        public GameAccountRepository(DbContext context)
        {
            dbContext = context;
        }

        public void Create(GameAccountEntity entity)
        {
            dbContext.Accounts.Add(entity);
        }

        public List<GameAccountEntity> ReadAll()
        {
            return dbContext.Accounts;
        }

        public GameAccountEntity ReadById(int id)
        {
            return dbContext.Accounts[id];
        }
        public void Update(GameAccountEntity entity)
        {
            dbContext.Accounts.RemoveAt(entity.Id);
            dbContext.Accounts.Insert(entity.Id, entity);
        }

        public void Delete(GameAccountEntity entity)
        {
            dbContext.Accounts.RemoveAt(entity.Id);
            int NewId = 1;
            foreach (var gameAccount in dbContext.Accounts)
            {
                dbContext.Accounts[NewId].Id = NewId;
                NewId++;
            }
        }

        public List<GameResultEntity> GameResults(GameAccountEntity entity)
        {
            return entity.GameResults;
        }

        public void AddGameResult(GameResultEntity gameResult, GameAccountEntity entity)
        {
            dbContext.Accounts[entity.Id].GameResults.Add(gameResult);
        }
    }
}

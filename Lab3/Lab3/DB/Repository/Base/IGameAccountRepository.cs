using Lab3.DB.Entity;

namespace Lab3.DB.Repository.Base
{
    internal interface IGameAccountRepository
    {
        public void Create(GameAccountEntity entity);
        public List<GameAccountEntity> ReadAll();
        public GameAccountEntity ReadById(int id);
        public void Update(GameAccountEntity entity);
        public void Delete(GameAccountEntity entity);
        public List<GameResultEntity> GameResults(GameAccountEntity entity);
        public void AddGameResult(GameResultEntity gameResult, GameAccountEntity entity);
    }
}
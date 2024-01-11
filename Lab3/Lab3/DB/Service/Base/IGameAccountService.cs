
namespace Lab3.DB.Service.Base
{
    internal interface IGameAccountService
    {
        public void Create(GameAccount entity);
        public List<GameAccount> ReadAll();
        public GameAccount ReadById(int id);
        public void Update(GameAccount entity);
        public void Delete(GameAccount entity);
        public List<GameResult> GameResults(GameAccount entity);
        public void AddGameResult(GameResult gameResult, GameAccount entity);
    }
}

using Lab3.DB.Entity;

namespace Lab3.DB
{
    internal class DbContext
    {
        public List<GameEntity> Games { get; set; }
        public List<GameAccountEntity> Accounts { get; set; }
        public List<GameResultEntity> Results { get; set; }

        public DbContext()
        {
            Games = new List<GameEntity>();
            Accounts = new List<GameAccountEntity>();
            Results = new List<GameResultEntity>();
        }
    }
}


namespace Lab3.DB.Entity
{
    internal class GameAccountEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResultEntity> GameResults { get; set; }
    }
}

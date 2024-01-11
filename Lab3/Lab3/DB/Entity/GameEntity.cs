
namespace Lab3.DB.Entity
{
    internal class GameEntity
    {
        public int Id { get; set; }
        public GameAccount Player1 { get; set; }
        public GameAccount Player2 { get; set; }
        public int PlayRating { get; set; }
        public string Winner { get; set; }
    }
}

namespace Lab3.DB.Entity
{
    internal class GameResultEntity
    {
        public string Opponent { get; set; }
        public string Winner { get; set; }
        public int Rating { get; set; }
        public int GameIndex { get; set; }
        public int CurrentRating { get; set; }
    }
}

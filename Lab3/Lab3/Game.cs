using Lab3.DB.Service;

namespace Lab3
{
    abstract class Game
    {
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public int playRating { get; set; }
        public string winner { get; set; }
        public GameService _service { get; set; }
        public Game(GameAccount player1, GameAccount player2, GameService service)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
        }
        public void PlayGame(GameAccount Gamer1, GameAccount Gamer2)
        {
            Console.WriteLine("Write rating: ");
            playRating = int.Parse(Console.ReadLine());
            while (playRating <= 0)
            {
                Console.WriteLine("Rating can`t be less than 0");
                playRating = int.Parse(Console.ReadLine());
            }

            Random random = new Random();
            int gameIndex = player1.GamesCount;
            int a = random.Next(1, 11);
            int b = random.Next(1, 11);
            if (a > b)
            {
                Console.WriteLine("Player 1 win");
                player1.WinGame(this, Gamer2.UserName, gameIndex);
                Console.WriteLine("Player 2 lose");
                player2.LoseGame(this, Gamer1.UserName, gameIndex);
                _service.Create(this);
            }
            if (a < b)
            {
                Console.WriteLine("Player 2 win");
                player2.WinGame(this, Gamer1.UserName, gameIndex);
                Console.WriteLine("Player 1 lose");
                player1.LoseGame(this, Gamer2.UserName, gameIndex);
                _service.Create(this);
            }
            if (a == b)
            {
                Console.WriteLine("Draw");
                player1.DrawGame(this, Gamer2.UserName, gameIndex, Gamer1.CurrentRating);
                player2.DrawGame(this, Gamer1.UserName, gameIndex, Gamer2.CurrentRating);
                _service.Create(this);
            }
        }
        public virtual int getPlayRating(GameAccount player) { return playRating; }
    }
}

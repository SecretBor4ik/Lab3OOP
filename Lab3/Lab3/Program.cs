using Lab3.DB;
using Lab3.DB.Service;
using Lab3.GameAccountTypes;

namespace Lab3
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var context = new DbContext();
            var accountService = new GameAccountService(context);
            var gameService = new GameService(context);
            Program program = new Program();
            program.Compile(accountService, gameService);
        }
        public void Compile(GameAccountService accountService, GameService gameService)
        {
            string answer;
            Console.WriteLine("Write first name player: ");
            string firstUser = Console.ReadLine();
            GameAccount player1 = AccountChose(accountService, firstUser);
            Console.WriteLine("Write second name player: ");
            string secondUser = Console.ReadLine();
            GameAccount player2 = AccountChose(accountService, secondUser);

            Game game = GameType(player1, player2, gameService);
            do
            {
                game.PlayGame(player1, player2);
                Console.WriteLine("Play again? (Y/N)");
                answer = Console.ReadLine();
            } while (answer == "Y" || answer == "y");
            GetStats(accountService);
        }

        public void GetStats(GameAccountService accountService)
        {
            var listAccounts = accountService.ReadAll();
            foreach (var account in listAccounts)
            {
                account.GetStats();
            }
        }

        private GameAccount AccountChose(GameAccountService service, string userName)
        {
            Console.WriteLine("Choose account type: \n1.StandartAccount \n2.HalfAccount \n3.VIPAccount");
            int choose = int.Parse(Console.ReadLine());
            var Id = service.ReadAll().Count();
            switch (choose)
            {
                case 1:
                    var standartGameAccount = new StandartAccount(service, Id, userName);
                    service.Create(standartGameAccount);
                    return standartGameAccount;
                case 2:
                    var unrankedAccount = new UnrankedAccount(service, Id, userName);
                    service.Create(unrankedAccount);
                    return unrankedAccount;
                case 3:
                    var vipAccount = new VIPAccount(service, Id, userName);
                    service.Create(vipAccount);
                    return vipAccount;
                default:
                    Console.WriteLine("Incorrect. Write number between 1-3");
                    return AccountChose(service, userName);
            }
        }

        private Game GameType(GameAccount player1, GameAccount player2, GameService service)
        {
            Console.WriteLine("Choose game type: \n1.StandartGame \n2.HalfGame \n3.DoubleRatingGame");
            int choose = int.Parse(Console.ReadLine());
            GameFactory factory = new GameFactory();
            switch (choose)
            {
                case 1:
                    return factory.CreateStandartGame(player1, player2, service);
                case 2:
                    return factory.CreateHalfGame(player1, player2, service);
                case 3:
                    return factory.CreateDoubleRatingGame(player1, player2, service);
                default:
                    Console.WriteLine("Incorrect. Write number between 1-3");
                    return GameType(player1, player2, service);
            }
        }
    }
}
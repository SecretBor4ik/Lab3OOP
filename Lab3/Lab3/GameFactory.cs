using Lab3.DB.Service;
using Lab3.GameTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class GameFactory
    {
        public Game CreateStandartGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new StandartGame(player1, player2, service);
        }
        public Game CreateHalfGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new HalfGame(player1, player2, service);
        }
        public Game CreateDoubleRatingGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new DoubleRatingGame(player1, player2, service);
        }
    }
}

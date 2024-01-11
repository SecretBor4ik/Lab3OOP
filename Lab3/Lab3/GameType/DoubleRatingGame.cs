using Lab3.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.GameTypes
{
    class DoubleRatingGame : Game
    {
        public DoubleRatingGame(GameAccount player1, GameAccount player2, GameService service) : base(player1, player2, service) { }
        public override int getPlayRating(GameAccount player)
        {
            if (player.UserName == player1.UserName)
            { return playRating + playRating; }
            if (player.UserName == player2.UserName)
            { return playRating + playRating; }
            return 0;
        }
    }
}

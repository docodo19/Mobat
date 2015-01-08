using Mobat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobat.Adapters
{
    interface IGameAdapter
    {
        List<GameViewModel> GetGameViewModel(string userId);
        void AddGameToDatabase(GameViewModel model, string userId);

        void EditGame(GameViewModel model, string userId);
        void DeleteGame(int id);
    }
}

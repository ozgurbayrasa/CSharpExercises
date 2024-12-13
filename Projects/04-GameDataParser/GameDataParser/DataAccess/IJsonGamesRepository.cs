using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDataParser.Games;

namespace GameDataParser.DataAccess
{
    public interface IJsonGamesRepository
    {
        List<Game> Read(string filePath);
    }
}

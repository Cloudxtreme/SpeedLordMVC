using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedLord.Dto;

namespace SpeedLord.Interfaces.Repositories
{
    public interface IMonsterRepository
    {
        Monster GetRandomMonster(int playerLevel);
        Monster GetMonsterByName(string monsterName);
    }
}

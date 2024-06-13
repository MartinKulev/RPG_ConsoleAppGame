using RPG_Console_App_Game.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console_App_Game.Repositories.Interfaces
{
    public interface ICharacterRepository<TEntity>
    {
        Task CreateCharacter(TEntity entity);
    }
}

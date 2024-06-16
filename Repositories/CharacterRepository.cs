using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RPG_Console_App_Game.Data;
using RPG_Console_App_Game.Data.Entities;
using RPG_Console_App_Game.Repositories.Interfaces;

namespace RPG_Console_App_Game.Repositories
{
    public class CharacterRepository<TEntity> : ICharacterRepository<TEntity> where TEntity : class
    {
        private readonly GameDBContext context;

        public CharacterRepository()
        {
            context = new GameDBContext();
        }

        public async Task CreateCharacter(TEntity entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }
}

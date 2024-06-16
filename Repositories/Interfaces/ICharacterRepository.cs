namespace RPG_Console_App_Game.Repositories.Interfaces
{
    public interface ICharacterRepository<TEntity>
    {
        Task CreateCharacter(TEntity entity);
    }
}

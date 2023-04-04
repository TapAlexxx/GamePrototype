using GamePrototype.Scripts.Infrastructure.Services.PersistenceProgress.Player;

namespace GamePrototype.Scripts.Infrastructure.Services.PersistenceProgress
{
    public class PersistenceProgressService : IPersistenceProgressService
    {
        public PlayerData PlayerData { get; set; }
    }
}
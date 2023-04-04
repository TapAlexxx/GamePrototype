using GamePrototype.Scripts.Infrastructure.Services.PersistenceProgress.Player;

namespace GamePrototype.Scripts.Infrastructure.Services.PersistenceProgress
{
    public interface IPersistenceProgressService
    {
        PlayerData PlayerData { get; set; }
    }
}
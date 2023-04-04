using PROJECT_NAME.Scripts.Infrastructure.Services.PersistenceProgress.Player;

namespace PROJECT_NAME.Scripts.Infrastructure.Services.PersistenceProgress
{
    public interface IPersistenceProgressService
    {
        PlayerData PlayerData { get; set; }
    }
}
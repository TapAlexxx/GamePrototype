using PROJECT_NAME.Scripts.Infrastructure.Services.PersistenceProgress.Player;

namespace PROJECT_NAME.Scripts.Infrastructure.Services.PersistenceProgress
{
    public class PersistenceProgressService : IPersistenceProgressService
    {
        public PlayerData PlayerData { get; set; }
    }
}
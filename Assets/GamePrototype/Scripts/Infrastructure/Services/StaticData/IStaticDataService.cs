using PROJECT_NAME.Scripts.StaticData;
using PROJECT_NAME.Scripts.Window;

namespace PROJECT_NAME.Scripts.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void LoadData();
        GameStaticData GameConfig();
        WindowConfig ForWindow(WindowTypeId windowTypeId);
    }
}
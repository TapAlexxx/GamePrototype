using PROJECT_NAME.Scripts.Infrastructure.Services.Factories.UIFactory;
using PROJECT_NAME.Scripts.Window;
using Zenject;

namespace PROJECT_NAME.Scripts.Infrastructure.Services.Window
{
    public class WindowService : IWindowService
    {
        private IUIFactory _uiFactory;

        [Inject]
        public void Constructor(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Open(WindowTypeId windowTypeId)
        {
            _uiFactory.CrateWindow(windowTypeId);
        }
    }
}
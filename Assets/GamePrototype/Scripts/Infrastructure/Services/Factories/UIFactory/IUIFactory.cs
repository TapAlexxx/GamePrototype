using PROJECT_NAME.Scripts.Window;
using UnityEngine;

namespace PROJECT_NAME.Scripts.Infrastructure.Services.Factories.UIFactory
{
  public interface IUIFactory
  {
    void CreateUiRoot();
    RectTransform CrateWindow(WindowTypeId windowTypeId);
  }
}
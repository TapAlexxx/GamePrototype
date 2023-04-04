using GamePrototype.Scripts.Window;
using UnityEngine;

namespace GamePrototype.Scripts.Infrastructure.Services.Factories.UIFactory
{
  public interface IUIFactory
  {
    void CreateUiRoot();
    RectTransform CrateWindow(WindowTypeId windowTypeId);
  }
}
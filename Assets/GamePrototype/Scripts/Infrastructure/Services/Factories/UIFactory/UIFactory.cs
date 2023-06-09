﻿using GamePrototype.Scripts.Infrastructure.Services.StaticData;
using GamePrototype.Scripts.StaticData;
using GamePrototype.Scripts.Window;
using UnityEngine;
using Zenject;

namespace GamePrototype.Scripts.Infrastructure.Services.Factories.UIFactory
{
  public class UIFactory : Factory, IUIFactory
  {
    private const string UiRootPath = "UI/UiRoot";

    private readonly IInstantiator _instantiator;
    private readonly IStaticDataService _staticData;
    
    private Transform _uiRoot;

    public UIFactory(IInstantiator instantiator, IStaticDataService staticDataService) : base(instantiator)
    {
      _instantiator = instantiator;
      _staticData = staticDataService;
    }
    
    public void CreateUiRoot()
    {
      _uiRoot = InstantiateOnActiveScene(UiRootPath).transform;
    }

    public RectTransform CrateWindow(WindowTypeId windowTypeId)
    {
      WindowConfig config = _staticData.ForWindow(windowTypeId);
      GameObject window = InstantiatePrefab(config.Prefab, _uiRoot);
      return window.GetComponent<RectTransform>();
    }
  }
}
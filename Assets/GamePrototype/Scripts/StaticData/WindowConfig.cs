using System;
using GamePrototype.Scripts.Window;
using UnityEngine;

namespace GamePrototype.Scripts.StaticData
{
  [Serializable]
  public class WindowConfig
  {
    public WindowTypeId WindowTypeId;
    public GameObject Prefab;
  }
}
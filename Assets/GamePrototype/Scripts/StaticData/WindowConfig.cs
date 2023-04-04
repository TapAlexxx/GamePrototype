using System;
using PROJECT_NAME.Scripts.Window;
using UnityEngine;

namespace PROJECT_NAME.Scripts.StaticData
{
  [Serializable]
  public class WindowConfig
  {
    public WindowTypeId WindowTypeId;
    public GameObject Prefab;
  }
}
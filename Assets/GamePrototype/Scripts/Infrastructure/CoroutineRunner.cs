using UnityEngine;

namespace GamePrototype.Scripts.Infrastructure
{
  public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
  {
    public void Awake()
    {
      DontDestroyOnLoad(gameObject);
    }
  }
}
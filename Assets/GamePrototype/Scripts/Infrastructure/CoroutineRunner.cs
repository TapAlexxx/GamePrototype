using UnityEngine;

namespace PROJECT_NAME.Scripts.Infrastructure
{
  public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
  {
    public void Awake()
    {
      DontDestroyOnLoad(gameObject);
    }
  }
}
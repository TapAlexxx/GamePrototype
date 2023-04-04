using DG.Tweening;
using UnityEngine;

namespace PROJECT_NAME.Scripts.Logic
{
    public class DoTweenTester : MonoBehaviour
    {
        void Start() => 
            Test();
        
        public void Test() => 
            transform.DOPunchScale(Vector3.left * 1f, 3);
    }
}

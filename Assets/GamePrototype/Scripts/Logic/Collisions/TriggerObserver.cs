using System;
using UnityEngine;

namespace PROJECT_NAME.Scripts.Logic.Collisions
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> TriggerEnter;
        public event Action<Collider> TriggerExit;
        
        private void OnTriggerEnter(Collider other) =>
            TriggerEnter?.Invoke(other);
        
        private void OnTriggerExit(Collider other) =>
            TriggerExit?.Invoke(other);
    }
}

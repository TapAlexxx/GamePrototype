using System;
using UnityEngine;

namespace GamePrototype.Scripts.Logic.PlayerInputControl
{
    public class PlayerDragInput : MonoBehaviour
    {
        [SerializeField] private float _sensativity = 1;
        private bool _active;

        public Vector3 LastMousePosition { get; private set; }
        public Vector3 StartMousePosition { get; private set; }
        public Vector3 Delta { get; private set; }

        private bool IsBeginDrag => Input.GetMouseButtonDown(0);
        private bool IsEndDrag => Input.GetMouseButtonUp(0);

        public event Action StartDrag;
        public event Action EndDrag;


        private void Update()
        {
            if(!_active)
                return;
            
            Vector3 mousePosition = Input.mousePosition;

            if (IsBeginDrag)
            {
                Delta = Vector3.zero;
                LastMousePosition = mousePosition;
                StartMousePosition = mousePosition;
                StartDrag?.Invoke();
            }
            if (IsEndDrag)
            {
                Delta = Vector3.zero;
                EndDrag?.Invoke();
            }

            Delta += (RefreshDelta(mousePosition) / Screen.width) * _sensativity;

            LastMousePosition = mousePosition;
        }

        public void Activate() => 
            _active = true;

        public void Disable() => 
            _active = false;

        private Vector3 RefreshDelta(Vector3 mousePosition) =>
            Input.GetMouseButton(0)
                ? mousePosition - LastMousePosition
                : Vector3.zero;
    }
}
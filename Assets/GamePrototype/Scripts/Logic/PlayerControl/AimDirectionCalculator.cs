using GamePrototype.Scripts.Extensions;
using GamePrototype.Scripts.Logic.PlayerInputControl;
using UnityEngine;

namespace GamePrototype.Scripts.Logic.PlayerControl
{
    public class AimDirectionCalculator : MonoBehaviour
    {
        [SerializeField] private PlayerDragInput _playerDragInput;

        private bool _active;
        private Camera _camera;
        
        public Vector3 Direction { get; private set; }

        private void OnValidate()
        {
            if (!_playerDragInput) TryGetComponent(out _playerDragInput);
        }

        public void Initialize(Camera sceneCamera) => 
            _camera = sceneCamera;

        private void Start() => 
            SubscribeOnInputEvents();

        private void OnDestroy() => 
            UnsubscribeOnInputEvents();

        private void SubscribeOnInputEvents()
        {
            _playerDragInput.StartDrag += OnStartDrag;
            _playerDragInput.EndDrag += OnEndDrag;
        }

        private void UnsubscribeOnInputEvents()
        {
            _playerDragInput.StartDrag -= OnStartDrag;
            _playerDragInput.EndDrag -= OnEndDrag;
        }

        private void Update()
        {
            if(!_active)
                return;

            Direction = _camera.ScreenToWorldPoint(_playerDragInput.StartMousePosition).SetY(transform.position.y) -
                        _camera.ScreenToWorldPoint(_playerDragInput.LastMousePosition).SetY(transform.position.y);
        }

        private void OnStartDrag() => 
            _active = true;

        private void OnEndDrag() => 
            _active = false;
    }
}
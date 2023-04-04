using System;
using GamePrototype.Scripts.Logic.PlayerInputControl;
using UnityEngine;

namespace GamePrototype.Scripts.Logic.PlayerControl
{
    public class AimArrowScaler : MonoBehaviour
    {
        [SerializeField] private GameObject _aimArrow;
        [SerializeField] private PlayerDragInput _playerDragInput;
        [SerializeField] private float _maxArrowLenght = 3f;
        
        private Vector3 _defaultLocalScale;
        private bool _active;

        private void OnValidate()
        {
            if (!_playerDragInput) TryGetComponent(out _playerDragInput);
        }

        private void Start()
        {
            SubscribeOnInputEvents();
            _defaultLocalScale = transform.localScale;
        }

        private void OnDestroy()
        {
            UnsubscribeOnInputEvents();
        }

        private void Update()
        {
            if(!_active)
                return;
            float clampedScale = Mathf.Clamp(_playerDragInput.Delta.magnitude, 0, _maxArrowLenght);
            Rescale(clampedScale);
        }

        private void Rescale(float zScale) => 
            _aimArrow.transform.localScale = new Vector3(_defaultLocalScale.x, _defaultLocalScale.y, zScale);

        private void OnStartDrag()
        {
            _aimArrow.SetActive(true);
            _active = true;
        }

        private void OnEndDrag()
        {
            Rescale(_playerDragInput.Delta.magnitude);
            _aimArrow.SetActive(false);
            _active = false;
        }

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
    }
}
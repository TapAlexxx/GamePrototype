using System;
using GamePrototype.Scripts.Logic.PlayerInputControl;
using UnityEngine;

namespace GamePrototype.Scripts.Logic.PlayerControl
{
    public class AimArrowRotator : MonoBehaviour
    {
        [SerializeField] private PlayerDragInput _playerDragInput;
        [SerializeField] private AimDirectionCalculator _directionCalculator;
        [SerializeField] private GameObject _aimArrow;

        private bool _active;

        private void OnValidate()
        {
            if (!_playerDragInput) TryGetComponent(out _playerDragInput);
            if (!_directionCalculator) TryGetComponent(out _directionCalculator);
        }

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

            _aimArrow.transform.forward = _directionCalculator.Direction;
        }

        private void OnStartDrag() => 
            _active = true;

        private void OnEndDrag() => 
            _active = false;
    }
}
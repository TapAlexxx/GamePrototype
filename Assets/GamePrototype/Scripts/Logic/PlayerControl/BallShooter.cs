using System;
using GamePrototype.Scripts.Logic.PlayerInputControl;
using GamePrototype.Scripts.StaticData;
using UnityEngine;

namespace GamePrototype.Scripts.Logic.PlayerControl
{
    public class BallShooter : MonoBehaviour
    {
        [SerializeField] private PlayerDragInput _playerDragInput;
        [SerializeField] private AimDirectionCalculator _directionCalculator;
        [SerializeField] private Rigidbody _rigidbody;
        private float _shootForce;

        private void OnValidate()
        {
            if (!_playerDragInput) TryGetComponent(out _playerDragInput);
            if (!_directionCalculator) TryGetComponent(out _directionCalculator);
            if (!_rigidbody) TryGetComponent(out _rigidbody);
        }

        public void Initialize(PlayerConfig playerConfig)
        {
            _shootForce = playerConfig.ShootForce;
        }

        private void Start() => 
            _playerDragInput.EndDrag += Shoot;

        private void OnDestroy() => 
            _playerDragInput.EndDrag -= Shoot;

        private void Shoot()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(_directionCalculator.Direction * _shootForce, ForceMode.Impulse);
        }
    }
}
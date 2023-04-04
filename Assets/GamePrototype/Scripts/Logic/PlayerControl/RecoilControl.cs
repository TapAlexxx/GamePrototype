using System;
using System.Collections;
using GamePrototype.Scripts.Logic.PlayerInputControl;
using UnityEngine;

namespace GamePrototype.Scripts.Logic.PlayerControl
{
    public class RecoilControl : MonoBehaviour
    {
        [SerializeField] private PlayerDragInput _playerDragInput;
        [SerializeField] private Rigidbody _rigidbody;
        
        private Coroutine _observeCoroutine;
        private bool _active;
        public event Action MoveEnded;
        public event Action MoveStarted;

        private void OnValidate()
        {
            if (!_playerDragInput) TryGetComponent(out _playerDragInput);
            if (!_rigidbody) TryGetComponent(out _rigidbody);
        }

        private void Start() => 
            _playerDragInput.EndDrag += ObserveEndOfMove;

        private void OnDestroy() => 
            _playerDragInput.EndDrag -= ObserveEndOfMove;

        private void ObserveEndOfMove()
        {
            if(!_active)
                return;
            MoveStarted?.Invoke();
            Debug.Log("Started");
            TryStopCoroutine(ref _observeCoroutine);
            _observeCoroutine = StartCoroutine(Observe());
        }

        private void TryStopCoroutine(ref Coroutine coroutine)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }

        private IEnumerator Observe()
        {
            yield return new WaitForSeconds(1f);
            while (_rigidbody.velocity.magnitude > 0.05f)
            {
                yield return null;
            }

            MoveEnded?.Invoke();
            TryStopCoroutine(ref _observeCoroutine);
        }

        public void Disable()
        {
            TryStopCoroutine(ref _observeCoroutine);
            _active = false;
        }

        public void Activate()
        {
            TryStopCoroutine(ref _observeCoroutine);
            _active = true;
        }
    }
}
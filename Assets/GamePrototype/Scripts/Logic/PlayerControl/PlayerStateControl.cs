using System;
using GamePrototype.Scripts.Logic.PlayerInputControl;
using UnityEngine;

namespace GamePrototype.Scripts.Logic.PlayerControl
{
    public class PlayerStateControl : MonoBehaviour
    {
        [SerializeField] private PlayerDragInput _playerDragInput;
        [SerializeField] private RecoilControl _recoilControl;

        private void OnValidate()
        {
            if (!_playerDragInput) TryGetComponent(out _playerDragInput);
            if (!_recoilControl) TryGetComponent(out _recoilControl);
        }

        private void Start()
        {
            _recoilControl.MoveEnded += EnterPlayState;
            _recoilControl.MoveStarted += EnterWaitState;
        }

        private void OnDestroy()
        {
            _recoilControl.MoveEnded -= EnterPlayState;
            _recoilControl.MoveStarted -= EnterWaitState;
        }

        public void EnterWaitState()
        {
            Debug.Log("WaitState");
            _playerDragInput.Disable();
        }

        public void EnterPlayState()
        {
            Debug.Log("PlayeState");
            _playerDragInput.Activate();
            _recoilControl.Activate();
        }

        public void EnterFinishState()
        {
            _playerDragInput.Disable();
            _recoilControl.Disable();
        }
    }
}
using System;
using GamePrototype.Scripts.Logic.PlayerInputControl;
using UnityEngine;

namespace GamePrototype.Scripts.Logic.PlayerControl
{
    public class ColorReadyChanger : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private RecoilControl _recoilControl;
        [SerializeField] private PlayerDragInput _playerDragInput;

        private void OnValidate()
        {
            if (!_renderer) TryGetComponent(out _renderer);
            if (!_recoilControl) TryGetComponent(out _recoilControl);
            if (!_playerDragInput) TryGetComponent(out _playerDragInput);
        }

        private void Start()
        {
            SetActiveColor();
            _recoilControl.MoveEnded += SetActiveColor;
            _recoilControl.MoveStarted += SetDisabledColor;
        }

        private void OnDestroy()
        {
            _recoilControl.MoveEnded -= SetActiveColor;
            _recoilControl.MoveStarted -= SetDisabledColor;
        }

        private void SetActiveColor()
        {
            Debug.Log("color Active");
            _renderer.sharedMaterial.SetColor("_EmissionColor", Color.yellow * 3);
        }

        private void SetDisabledColor()
        {
            Debug.Log("color disabled");
            _renderer.sharedMaterial.SetColor("_EmissionColor", Color.black * 1);
        }
    }
}
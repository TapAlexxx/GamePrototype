using GamePrototype.Scripts.Infrastructure.Services.Window;
using GamePrototype.Scripts.Logic.Collisions;
using GamePrototype.Scripts.Logic.PlayerControl;
using GamePrototype.Scripts.Logic.PlayerInputControl;
using GamePrototype.Scripts.Window;
using UnityEngine;
using Zenject;

namespace GamePrototype.Scripts.Logic
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        private IWindowService _windowService;
        private bool _opened;

        private void OnValidate()
        {
            if (!_triggerObserver) TryGetComponent(out _triggerObserver);
        }

        [Inject]
        public void Constructor(IWindowService windowService)
        {
            _windowService = windowService;
        }

        private void Start() => 
            _triggerObserver.TriggerEnter += OnTriggerEntered;

        private void OnDestroy() => 
            _triggerObserver.TriggerEnter -= OnTriggerEntered;

        private void OnTriggerEntered(Collider obj)
        {
            if(_opened)
                return;
            if (obj.TryGetComponent(out PlayerStateControl playerStateControl))
            {
                playerStateControl.EnterFinishState();
                _opened = true;
                _windowService.Open(WindowTypeId.Finish);
            }
        }
    }
}
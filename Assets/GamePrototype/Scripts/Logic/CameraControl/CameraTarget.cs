using UnityEngine;

namespace GamePrototype.Scripts.Logic.CameraControl
{
    public class CameraTarget : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Rigidbody _cameraTargetRigidbody;
        [SerializeField] private float _xDamping;
        [SerializeField] private float _yDamping;
        [SerializeField] private float _zDamping;

        private void Start() =>
            transform.parent = null;

        private void FixedUpdate()
        {
            Vector3 rbPos = _cameraTargetRigidbody.position;
            rbPos.x = Mathf.Lerp(rbPos.x, _playerTransform.position.x, _xDamping * Time.fixedDeltaTime);
            rbPos.y = Mathf.Lerp(rbPos.y, _playerTransform.position.y, _yDamping * Time.fixedDeltaTime);
            rbPos.z = Mathf.Lerp(rbPos.z, _playerTransform.position.z, _zDamping * Time.fixedDeltaTime);
            _cameraTargetRigidbody.MoveRotation(_playerTransform.rotation);
            _cameraTargetRigidbody.MovePosition(rbPos);
        }
    }
}
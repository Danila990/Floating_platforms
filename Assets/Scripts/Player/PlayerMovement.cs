using MyCode.Core;
using UnityEngine;

namespace MyCode._Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private IInputService _inputService;
        private Rigidbody _rb;
        private float _inputX;
        private float _inputZ;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 direction = new Vector3(_inputX, 0, _inputZ) * _speed;
            direction.y = _rb.velocity.y;
            _rb.velocity = direction;
        }

        private void OnDestroy() => _inputService.OnMoveInput -= OnMoveInput;
        public void SetInputServce(IInputService inputServce)
        {
            _inputService = inputServce;
            _inputService.OnMoveInput += OnMoveInput;
        }

        private void OnMoveInput(float x, float z)
        {
            _inputX = x;
            _inputZ = z;
        }
    }
}
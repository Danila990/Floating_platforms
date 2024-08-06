using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private IInputService _inputService;
        private Rigidbody _rb;
        private float _inputX;
        private float _inputZ;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnMoveInput += Input;
        }

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

        private void OnDestroy()
        {
            _inputService.OnMoveInput -= Input;
        }

        private void Input(float x, float z)
        {
            _inputX = x;
            _inputZ = z;
        }
    }
}
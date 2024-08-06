using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace MyCode
{
    [Serializable]
    public class PlayerMovement
    {
        [SerializeField] private float _speed;

        private readonly IInputService _inputService;

        public PlayerMovement(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Update()
        {

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MyCode
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public PlayerHealth PlayerHealth { get; private set; }
        [field: SerializeField] public PlayerMovement PlayerMovement { get; private set; }

        [Inject]
        public void Construct(IInputService inputService)
        {
            PlayerMovement = new PlayerMovement(inputService);
        }

        private void Update()
        {
            PlayerMovement?.Update();
        }
    }
}
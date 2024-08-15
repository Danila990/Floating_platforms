using UnityEngine;

namespace MyCode
{
    public class PlayerSpawnPoint : MonoBehaviour
    {
        [SerializeField] private Transform _spawmPoint;

        public Vector3 SpawnPoint => transform.position;
    }
}

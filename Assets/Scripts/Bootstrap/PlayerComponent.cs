using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace MyCode
{
    [Serializable]
    public class PlayerComponent
    {
        [SerializeField] private AssetReferenceGameObject _playerReference;
        [SerializeField] private Transform _playerStartPoint;

        private Player _player;

        public async Task Load()
        {
            _player = await AssetLoader.LoadGameObject<Player>(_playerReference);
        }

        public void Init()
        {
            _player.transform.position = _playerStartPoint.position;
        }

        public void Bind(IContainerBuilder builder)
        {
            builder.RegisterComponent(_player);
            builder.RegisterComponent(_player.GetComponent<PlayerMovement>());
        }
    }
}
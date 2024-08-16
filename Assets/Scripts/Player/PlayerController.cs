using MyCode.Core;
using VContainer.Unity;

namespace MyCode._Player
{
    public class PlayerController : IInitializable
    {
        public readonly IFactory Factory;
        public readonly IImputController ImputController;
        public readonly PlayerSpawnPoint SpawnPoint;

        public Player Player { get; private set; }
        public PlayerMovement PlayerMovement { get; private set; }

        public PlayerController(IFactory factory, IImputController imputController, PlayerSpawnPoint playerSpawnPoint)
        {
            Factory = factory;
            ImputController = imputController;
            SpawnPoint = playerSpawnPoint;
        }

        public void Initialize()
        {
            Player = Factory.CreateAndSetPos<Player>("Player", SpawnPoint.SpawnPoint);
            PlayerMovement = Player.GetComponent<PlayerMovement>();
            PlayerMovement.SetInputServce(ImputController.GetInput());
        }
    }
}

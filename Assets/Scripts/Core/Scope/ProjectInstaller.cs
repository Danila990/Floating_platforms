using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
    [CreateAssetMenu(menuName = "ProjectInstaller", fileName = nameof(ProjectInstaller))]
    public class ProjectInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GameDatabase _database;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent<IDatabase>(_database);
        }
    }
}

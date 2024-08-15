using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core.Scope
{
	public class MonoInstaller : MonoBehaviour, IInstaller
	{
		public virtual void Install(IContainerBuilder builder)
		{
			throw new NotImplementedException();
		}
	}
}
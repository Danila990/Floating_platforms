using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
	public class ScriptableObjectInstaller : ScriptableObject, IInstaller
	{
		public virtual void Install(IContainerBuilder builder)
		{
			throw new NotImplementedException();
		}
	}
}
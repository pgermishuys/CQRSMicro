using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Core
{
	public static class MessageBusExtensions
	{
		public static void Register(this IMessageBus messageBus, IDependencyResolver dependencyResolver, params Assembly[] assembliesToScan)
		{
			var subscribeMethod = messageBus.GetType().GetMethod("Subscribe");
			var types = assembliesToScan.SelectMany(assembly => assembly.GetTypes().Where(x => typeof(IMessageHandler).IsAssignableFrom(x) && !x.IsInterface));
			foreach (var type in types)
			{
				var instanceOfType = dependencyResolver.Get(type);
				var whenMethods = type.GetMethods().Where(x => x.Name == "When");
				foreach (var whenMethod in whenMethods)
				{
					var messageType = whenMethod.GetParameters().First();
					var genericSubscribeMethod = subscribeMethod.MakeGenericMethod(messageType.ParameterType);
					genericSubscribeMethod.Invoke(messageBus, new object[] { instanceOfType });
				}
			}
		}
	}
}

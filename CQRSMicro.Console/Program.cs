using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQRSMicro.Core;
using Ninject;
using CQRSMicro.Console.Commands;

namespace DDD.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var dependencyResolver = new NinjectDependencyResolver();
			dependencyResolver.BindInSingletonScope<IMessageBus, InMemoryBus>();
			var messageBus = dependencyResolver.Get<IMessageBus>();
			messageBus.Register(dependencyResolver, Assembly.GetExecutingAssembly());

			messageBus.PublishMessage(new CompleteAndSubmitOnlineApplication(new Guid(), "Luke Skywalker", "luke@skywalker.com", "I am the jedi you've been looking for", new byte[0]));

			System.Console.ReadLine();
		}
	}
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel kernel;
		public NinjectDependencyResolver()
		{
			kernel = new StandardKernel();
		}
		public T Get<T>()
		{
			return kernel.Get<T>();
		}

		public object Get(Type type)
		{
			return kernel.Get(type);
		}

		public void Bind<Interface, Implementation>() where Implementation : Interface
		{
			kernel.Bind<Interface>().To<Implementation>();
		}
		public void BindInSingletonScope<Interface, Implementation>() where Implementation : Interface
		{
			kernel.Bind<Interface>().To<Implementation>().InSingletonScope();
		}
	}
}

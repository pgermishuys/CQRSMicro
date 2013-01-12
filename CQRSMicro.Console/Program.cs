using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQRSMicro.Core;
using Ninject;

namespace DDD.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var dependencyResolver = new NinjectDependencyResolver();
			dependencyResolver.Bind<IMessageBus, InMemoryBus>();
			var messageBus = dependencyResolver.Get<IMessageBus>();
			messageBus.Register(dependencyResolver, Assembly.GetExecutingAssembly());

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
	}
}

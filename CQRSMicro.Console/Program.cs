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
			InMemoryBus messageBus = new InMemoryBus("Memory Bus");
			dependencyResolver.Bind<AccountApplicationService, AccountApplicationService>();

			Assembly.GetExecutingAssembly().RegisterHandlers(messageBus, dependencyResolver);

			messageBus.PublishMessage(new CreateAccount());

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

	public class CreateAccount : Command
	{
		public CreateAccount()
		{

		}
	}
	public class AccountApplicationService : AbstractApplicationService
	{
		public void When(CreateAccount createAccount)
		{
		}
	}
}

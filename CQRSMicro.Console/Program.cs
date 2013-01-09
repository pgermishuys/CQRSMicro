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
			var messageBus = new InMemoryBus("Memory Bus");
			var applicationService = new AccountApplicationService(messageBus);
			var workflow = new SimpleWorkflow();
			messageBus.Subscribe<CreateAccount>(applicationService);
			messageBus.Subscribe<AccountCreated>(workflow);
			messageBus.PublishMessage(new CreateAccount());

			System.Console.ReadLine();
		}
	}

	public class CreateAccount : Command { }
	public class AccountCreated : Event { }
	public class AccountApplicationService : AbstractApplicationService
	{
		private IMessageBus messageBus;
		public AccountApplicationService(IMessageBus messageBus)
		{
			this.messageBus = messageBus;
		}
		public void When(CreateAccount command) 
		{
			messageBus.PublishMessage(new AccountCreated());
		}
	}
	public class SimpleWorkflow : AbstractApplicationService
	{
		public void When(AccountCreated @event)
		{
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

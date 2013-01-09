CQRSMicro
=========

CQRSMicro Framework for Research Purposes

Getting Started
---------------
1. The IMessageBus provides a contract for the transport mechanism for messages. Currently there is an implementation in the form of [@abdulin's](http://abdullin.com/) InMemoryBus.
2. An AbstractApplicationService which you can inherit from and define methods on (in the form of public void When(YourCommand command)), that will handle commands.

e.g.
	class Program
	{
		static void Main(string[] args)
		{
			var messageBus = new InMemoryBus("Memory Bus");
			var applicationService = new AccountApplicationService();
			messageBus.Subscribe<CreateAccount>(applicationService);
			messageBus.PublishMessage(new CreateAccount());

			System.Console.ReadLine();
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
			System.Console.WriteLine("Called Create Account");
		}
	}

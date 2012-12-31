using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSMicro.Console;
using CQRSMicro.Core;
using System;

namespace CQRSMicro.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var messageBus = new InMemoryBus("In Memory Bus");
			AccountService accountService = new AccountService();
			messageBus.Subscribe<CreateAccount>(accountService);
			messageBus.PublishMessage(new CreateAccount(new AccountID()));
			System.Console.ReadLine();
		}
	}

	public class AccountID : IIdentity
	{
		public Guid id { get; private set; }
		public AccountID()
		{
			id = Guid.NewGuid();
		}
	}

	public class CreateAccount : Command<AccountID>
	{
		public CreateAccount(AccountID accountID)
			: base(accountID)
		{
		}
	}
	public class ResetAccountBalance : Command<AccountID>
	{
		public ResetAccountBalance(AccountID accountID)
			: base(accountID)
		{

		}
	}
	public class AccountCreated : Event<AccountID> { }

	public class AccountService : AbstractApplicationService, IMessageHandler
	{
		public void When(CreateAccount command)
		{
		}

		public void When(ResetAccountBalance command)
		{
		}
	}
}

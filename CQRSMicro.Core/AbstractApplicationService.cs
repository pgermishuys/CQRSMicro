using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Core
{
	public abstract class AbstractApplicationService : IApplicationService, IMessageHandler
	{
		public void Handle(ICommand command)
		{
			RedirectToWhen(command);
		}
		private void RedirectToWhen(ICommand command)
		{
			((dynamic)this).When((dynamic)command);
		}

		public void Handle(IMessage message)
		{
			if (message is ICommand)
			{
				this.Handle((ICommand)message);
			}
		}
	}
}

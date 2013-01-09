using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Core
{
	public class AbstractProcess : IMessageHandler
	{
		public void Handle(IMessage message)
		{
			RedirectToWhen(message);
		}
		private void RedirectToWhen(IMessage message)
		{
			((dynamic)this).When((dynamic)message);
		}
	}
}

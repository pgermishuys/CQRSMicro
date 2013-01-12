using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Core
{
	public class MessageHandler : IMessageHandler
	{
		public virtual void Handle(IMessage message)
		{
			((dynamic)this).When((dynamic)message);
		}
	}
}

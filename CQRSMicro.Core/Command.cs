using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Core
{
	public class Command<TIdentity> : ICommand where TIdentity : IIdentity 
	{
		private IIdentity id;
		public Command(IIdentity id)
		{
			this.id = id;
		}
	}
}

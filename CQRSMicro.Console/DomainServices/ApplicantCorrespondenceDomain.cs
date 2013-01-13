using CQRSMicro.Console.Commands;
using CQRSMicro.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Console.DomainServices
{
	public class ApplicantCorrespondenceDomain : AbstractDomainService
	{
		private IMessageBus messageBus;
		public ApplicantCorrespondenceDomain(IMessageBus messageBus)
		{
			this.messageBus = messageBus;
		}
		public void When(SendApplicationReceivedEmailToApplicant command)
		{
			//send the email, this might fail
		}
	}
}

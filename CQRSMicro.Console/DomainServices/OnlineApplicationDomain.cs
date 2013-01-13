using CQRSMicro.Console.Commands;
using CQRSMicro.Console.Events;
using CQRSMicro.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Console.DomainServices
{
	public class OnlineApplicationDomain : AbstractDomainService
	{
		private IMessageBus messageBus;
		public OnlineApplicationDomain(IMessageBus messageBus)
		{
			this.messageBus = messageBus;
		}
		public void When(CompleteAndSubmitOnlineApplication command)
		{
			//do some validation, check that the application is in order
			messageBus.PublishMessage(new OnlineApplicationCompleteAndSubmitted(command.ApplicationReference, command.ApplicantName, command.ApplicantEmailAddress, command.CoverLetter, command.CurriculumVitae));
		}
		public void When(EmailTheApplicationPackageToHumanResources command)
		{
			//send the application package to human resources
			messageBus.PublishMessage(new ApplicationPackageEmailedToHumanResources(command.ApplicationReference));
		}
	}
}

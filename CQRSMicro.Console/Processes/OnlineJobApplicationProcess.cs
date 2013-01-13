using CQRSMicro.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSMicro.Console.Events;
using CQRSMicro.Console.Commands;

namespace CQRSMicro.Console.Processes
{
	public class OnlineJobApplicationProcess : AbstractProcess
	{
		private IMessageBus messageBus;
		public OnlineJobApplicationProcess(IMessageBus messageBus)
		{
			this.messageBus = messageBus;
		}
		public void When(OnlineApplicationCompleteAndSubmitted @event)
		{
			messageBus.PublishMessage(new SendApplicationReceivedEmailToApplicant(@event.ApplicationReference, @event.ApplicantName, @event.ApplicantEmailAddress));
			messageBus.PublishMessage(new CreatePDFFromOnlineSubmission(@event.ApplicationReference, @event.ApplicantName, @event.ApplicantEmailAddress, @event.CoverLetter, @event.CurriculumVitae));
		}

		public void When(PDFCreatedFromOnlineSubmission @event)
		{
			messageBus.PublishMessage(new AttachPDFToCurriculumVitae(@event.ApplicationReference, @event.ApplicantName, @event.ApplicantEmailAddress, @event.CurriculumVitae, @event.OnlineSubmissionPDF));
		}

		public void When(CurriculumVitaeAttachedToPDF @event)
		{
			messageBus.PublishMessage(new EmailTheApplicationPackageToHumanResources(@event.ApplicationReference, @event.ApplicationPackage));
		}

		public void When(ApplicationPackageEmailedToHumanResources @event)
		{
		}
	}
}

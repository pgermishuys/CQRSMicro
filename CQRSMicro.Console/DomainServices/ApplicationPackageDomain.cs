using CQRSMicro.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSMicro.Console.Commands;
using CQRSMicro.Console.Events;

namespace CQRSMicro.Console.DomainServices
{
	public class ApplicationPackageDomain : AbstractDomainService
	{
		private IMessageBus messageBus;
		public ApplicationPackageDomain(IMessageBus messageBus)
		{
			this.messageBus = messageBus;
		}
		public void When(CreatePDFFromOnlineSubmission command)
		{
			byte[] onlineSubmissionPDF = new byte[0];
			messageBus.PublishMessage(new PDFCreatedFromOnlineSubmission(command.ApplicationReference, command.ApplicantName, command.ApplicantEmailAddress, command.CurriculumVitae, onlineSubmissionPDF));
		}
		public void When(AttachPDFToCurriculumVitae command)
		{
			//Attach the PDF to Curriculum Vitae
			//take the cover letter and merge with curriculum vitae
			byte[] applicationPackage = new byte[0]; //combine command.OnlineSubmissionPDF and command.CurriculumVitae
			messageBus.PublishMessage(new CurriculumVitaeAttachedToPDF(command.ApplicationReference, command.ApplicantName, command.ApplicantEmailAddress, applicationPackage));
		}
	}
}

using CQRSMicro.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Console.Events
{
	public class OnlineApplicationCompleteAndSubmitted : Event
	{
		public Guid ApplicationReference { get; set; }
		public string ApplicantName { get; set; }
		public string ApplicantEmailAddress { get; set; }
		public string CoverLetter { get; set; }
		public byte[] CurriculumVitae { get; set; }
		public OnlineApplicationCompleteAndSubmitted(Guid applicationReference, string applicantName, string applicantEmailAddress, string coverLetter, byte[] curriculumVitae)
		{
			this.ApplicationReference = applicationReference;
			this.ApplicantName = applicantName;
			this.ApplicantEmailAddress = applicantEmailAddress;
			this.CoverLetter = coverLetter;
			this.CurriculumVitae = curriculumVitae;
		}
	}

	public class PDFCreatedFromOnlineSubmission : Event
	{
		public Guid ApplicationReference { get; set; }
		public string ApplicantName { get; set; }
		public string ApplicantEmailAddress { get; set; }
		public byte[] OnlineSubmissionPDF { get; set; }
		public byte[] CurriculumVitae { get; set; }
		public PDFCreatedFromOnlineSubmission(Guid applicationReference, string applicantName, string applicantEmailAddress, byte[] curriculumVitae, byte[] onlineSubmissionPDF)
		{
			this.ApplicationReference = applicationReference;
			this.ApplicantName = applicantName;
			this.ApplicantEmailAddress = applicantEmailAddress;
			this.OnlineSubmissionPDF = onlineSubmissionPDF;
			this.CurriculumVitae = curriculumVitae;
		}
	}

	public class ApplicationReceivedEmailSentToApplicant : Event
	{
	}

	public class CurriculumVitaeAttachedToPDF : Event
	{
		public Guid ApplicationReference { get; set; }
		public string ApplicantName { get; set; }
		public string ApplicantEmailAddress { get; set; }
		public byte[] ApplicationPackage { get; set; }
		public CurriculumVitaeAttachedToPDF(Guid applicationReference, string applicantName, string applicantEmailAddress, byte[] applicationPackage)
		{
			this.ApplicationReference = applicationReference;
			this.ApplicantName = applicantName;
			this.ApplicantEmailAddress = applicantEmailAddress;
			this.ApplicationPackage = applicationPackage;
		}
	}

	public class ApplicationPackageEmailedToHumanResources : Event
	{
		public Guid ApplicationReference { get; set; }
		public ApplicationPackageEmailedToHumanResources(Guid applicationReference)
		{
			this.ApplicationReference = applicationReference;
		}
	}
}

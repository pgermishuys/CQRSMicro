using CQRSMicro.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Console.Commands
{
	public class CompleteAndSubmitOnlineApplication : Command
	{
		public Guid ApplicationReference { get; set; }
		public string ApplicantName { get; set; }
		public string ApplicantEmailAddress { get; set; }
		public string CoverLetter { get; set; }
		public byte[] CurriculumVitae { get; set; }
		public CompleteAndSubmitOnlineApplication(Guid applicationReference, string applicantName, string applicantEmailAddress, string coverLetter, byte[] curriculumVitae)
		{
			this.ApplicationReference = applicationReference;
			this.ApplicantName = applicantName;
			this.ApplicantEmailAddress = applicantEmailAddress;
			this.CoverLetter = coverLetter;
			this.CurriculumVitae = curriculumVitae;
		}
	}

	public class CreatePDFFromOnlineSubmission : Command
	{
		public Guid ApplicationReference { get; set; }
		public string ApplicantName { get; set; }
		public string ApplicantEmailAddress { get; set; }
		public string CoverLetter { get; set; }
		public byte[] CurriculumVitae { get; set; }
		public CreatePDFFromOnlineSubmission(Guid applicationReference, string applicantName, string applicantEmailAddress, string coverLetter, byte[] curriculumVitae)
		{
			this.ApplicationReference = applicationReference;
			this.ApplicantName = applicantName;
			this.ApplicantEmailAddress = applicantEmailAddress;
			this.CoverLetter = coverLetter;
			this.CurriculumVitae = curriculumVitae;
		}
	}

	public class SendApplicationReceivedEmailToApplicant : Command
	{
		public Guid ApplicationReference { get; set; }
		public string ApplicantName { get; set; }
		public string ApplicantEmailAddress { get; set; }
		public SendApplicationReceivedEmailToApplicant(Guid applicationReference, string applicantName, string applicantEmailAddress)
		{
			this.ApplicationReference = applicationReference;
			this.ApplicantName = applicantName;
			this.ApplicantEmailAddress = applicantEmailAddress;
		}
	}

	public class AttachPDFToCurriculumVitae : Command
	{
		public Guid ApplicationReference { get; set; }
		public string ApplicantName { get; set; }
		public string ApplicantEmailAddress { get; set; }
		public byte[] OnlineSubmissionPDF { get; set; }
		public byte[] CurriculumVitae { get; set; }
		public AttachPDFToCurriculumVitae(Guid applicationReference, string applicantName, string applicantEmailAddress, byte[] curriculumVitae, byte[] onlineSubmissionPDF)
		{
			this.ApplicationReference = applicationReference;
			this.ApplicantName = applicantName;
			this.ApplicantEmailAddress = applicantEmailAddress;
			this.OnlineSubmissionPDF = onlineSubmissionPDF;
			this.CurriculumVitae = curriculumVitae;
		}
	}

	public class EmailTheApplicationPackageToHumanResources : Command
	{
		public Guid ApplicationReference { get; set; }
		public byte[] ApplicationPackage { get; set; }
		public EmailTheApplicationPackageToHumanResources(Guid applicationReference, byte[] applicationPackage)
		{
			this.ApplicationReference = applicationReference;
			this.ApplicationPackage = applicationPackage;
		}
	}
}

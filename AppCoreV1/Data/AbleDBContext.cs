using AppCoreV1.ABLEModels;
using AppCoreV1.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppCoreV1.Data;

public partial class AbleDBContext : DbContext
{
    private readonly IConfiguration _configuration;
    private string? connectionString;

    public AbleDBContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AbleDBContext(DbContextOptions<AbleDBContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
        //string encriptedString = _configuration.GetConnectionString("ABLEConnection") ?? string.Empty;
        //connectionString = AESSecurity.Decrypt(encriptedString);

        connectionString = _configuration.GetConnectionString("ABLEConnection") ?? string.Empty;
    }

    public virtual DbSet<SiteLog> SiteLogs { get; set; }
    public virtual DbSet<AbleSiteUser> SiteUsers { get; set; }
    public virtual DbSet<AbleIssue> AbleIssues { get; set; }

    public virtual DbSet<AbleEmail> Emails { get; set; }

    public virtual DbSet<ReportRequest> ReportRequests { get; set; }

    public virtual DbSet<Claimbenefitmv> Claimbenefitmvs { get; set; }

    public virtual DbSet<Paymentsummarymv> Paymentsummarymvs { get; set; }

    public virtual DbSet<RptAbleuser> RptAbleusers { get; set; }

    public virtual DbSet<RptAbleusersallrole> RptAbleusersallroles { get; set; }

    public virtual DbSet<RptActionsservice> RptActionsservices { get; set; }

    public virtual DbSet<RptCaseaction> RptCaseactions { get; set; }

    public virtual DbSet<RptClaimBenefitactuarialrecl> RptClaimBenefitactuarialrecls { get; set; }

    public virtual DbSet<RptClaimbenefitactuarialrec> RptClaimbenefitactuarialrecs { get; set; }

    public virtual DbSet<RptClaimbenefitgroup> RptClaimbenefitgroups { get; set; }

    public virtual DbSet<RptClaimbenefitreinsurance> RptClaimbenefitreinsurances { get; set; }

    public virtual DbSet<RptClaimbenefitw> RptClaimbenefitws { get; set; }

    public virtual DbSet<RptClaimcasedecipha> RptClaimcasedeciphas { get; set; }

    public virtual DbSet<RptClaimexpense> RptClaimexpenses { get; set; }

    public virtual DbSet<RptClaimparticipant> RptClaimparticipants { get; set; }

    public virtual DbSet<RptClosedtaskreport> RptClosedtaskreports { get; set; }

    public virtual DbSet<RptCmpaction> RptCmpactions { get; set; }

    public virtual DbSet<RptCmpgoaldatemovement> RptCmpgoaldatemovements { get; set; }

    public virtual DbSet<RptCmpplanstatus> RptCmpplanstatuses { get; set; }

    public virtual DbSet<RptCmpservice> RptCmpservices { get; set; }

    public virtual DbSet<RptCompliant> RptCompliants { get; set; }

    public virtual DbSet<RptDocumentreport> RptDocumentreports { get; set; }

    public virtual DbSet<RptEnquirycasereport> RptEnquirycasereports { get; set; }

    public virtual DbSet<RptHcrcompletednote> RptHcrcompletednotes { get; set; }

    public virtual DbSet<RptOpentask> RptOpentasks { get; set; }

    public virtual DbSet<RptOverrideriskreport> RptOverrideriskreports { get; set; }

    public virtual DbSet<RptPaymentsummaryl> RptPaymentsummaryls { get; set; }

    public virtual DbSet<RptPhoneenquiry> RptPhoneenquiries { get; set; }

    public virtual DbSet<RptRecoveryrehabnote> RptRecoveryrehabnotes { get; set; }

    public virtual DbSet<RptTaskreportgroup> RptTaskreportgroups { get; set; }

    public virtual DbSet<RptTaskreportreinsurance> RptTaskreportreinsurances { get; set; }

    public virtual DbSet<Taskmv> Taskmvs { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<PartyAddress> PartyAddresses { get; set; }

    public virtual DbSet<PartyCertificate> PartyCertificates { get; set; }

    public virtual DbSet<PartyClassification> PartyClassifications { get; set; }

    public virtual DbSet<PartyConsent> PartyConsents { get; set; }

    public virtual DbSet<PartyContact> PartyContacts { get; set; }

    public virtual DbSet<PartyPolicyRole> PartyPolicyRoles { get; set; }

    public virtual DbSet<PaymentPreference> PaymentPreferences { get; set; }

    public virtual DbSet<Case> Cases { get; set; }

    public virtual DbSet<CaseLinker> CaseLinkers { get; set; }

    public virtual DbSet<CaseParty> CaseParties { get; set; }

    public virtual DbSet<CaseValidation> CaseValidations { get; set; }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<ClaimIncapacityPeriod> ClaimIncapacityPeriods { get; set; }

    public virtual DbSet<ClaimPolicy> ClaimPolicies { get; set; }

    public virtual DbSet<ClaimPolicyCoverage> ClaimPolicyCoverages { get; set; }

    public virtual DbSet<ClaimPolicyEntitlement> ClaimPolicyEntitlements { get; set; }

    public virtual DbSet<ClaimPolicyExclusion> ClaimPolicyExclusions { get; set; }

    public virtual DbSet<ClaimPolicyReinsurance> ClaimPolicyReinsurances { get; set; }

    public virtual DbSet<Benefit> Benefits { get; set; }

    public virtual DbSet<BenefitExclusion> BenefitExclusions { get; set; }

    public virtual DbSet<BenefitReInsurance> BenefitReInsurances { get; set; }

    public virtual DbSet<DocumentA> Documents { get; set; }

    public virtual DbSet<DocumentGroup> DocumentGroups { get; set; }

    public virtual DbSet<DocumentGroupLink> DocumentGroupLinks { get; set; }

    public virtual DbSet<DocumentUser> DocumentUsers { get; set; }

    public virtual DbSet<Earning> Earnings { get; set; }

    public virtual DbSet<EnumField> EnumFields { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<LifeArea> LifeAreas { get; set; }

    public virtual DbSet<MedicalCode> MedicalCodes { get; set; }

    public virtual DbSet<Note1> Note1s { get; set; }

    public virtual DbSet<Note2> Note2s { get; set; }

    public virtual DbSet<OutstandingRequest> OutstandingRequests { get; set; }

    public virtual DbSet<OutstandingRequestDocument> OutstandingRequestDocuments { get; set; }

    public virtual DbSet<OutstandingRequestHistory> OutstandingRequestHistories { get; set; }

    public virtual DbSet<Process> Processes { get; set; }

    public virtual DbSet<ProcessHistory> ProcessHistories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TaskA> Tasks { get; set; }

    public virtual DbSet<TaskHistory> TaskHistories { get; set; }

    public virtual DbSet<ContactDetail> ContactDetails { get; set; }

    public virtual DbSet<DepartmentUser> DepartmentUsers { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    public virtual DbSet<PartySearch> PartySearches { get; set; }

    public virtual DbSet<PolicySearch> PolicySearches { get; set; }

    public virtual DbSet<CoverageSearch> CoverageSearches { get; set; }
    public virtual DbSet<Occupation> Occupations { get; set; }

    public virtual DbSet<ClaimOccupation> ClaimOccupations { get; set; }

    public virtual DbSet<ClaimPeriod> ClaimPeriods { get; set; }

    public virtual DbSet<ClientGoal> ClientGoals { get; set; }

    public virtual DbSet<ActionA> Actions { get; set; }

    public virtual DbSet<ActionHistory> ActionHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SiteLog>(entity =>
        {
            entity.Property(e => e.DateCreated).HasMaxLength(50);
            entity.Property(e => e.LogType).HasMaxLength(50);
            entity.Property(e => e.UserId).HasMaxLength(50);
        });

        modelBuilder.Entity<AbleSiteUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).HasMaxLength(50);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(250);
            entity.Property(e => e.RoleName).HasMaxLength(250);
        });

        modelBuilder.Entity<AbleIssue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FigIssues");

            entity.Property(e => e.DateReported).HasMaxLength(50);
            entity.Property(e => e.ReportedBy).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<AbleEmail>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PK_Emails");

            entity.Property(e => e.DateSent).HasColumnType("datetime");
            entity.Property(e => e.MailSubject).HasMaxLength(500);
            entity.Property(e => e.RecipientEmail).HasMaxLength(500);
            entity.Property(e => e.SenderEmail).HasMaxLength(500);
        });

        modelBuilder.Entity<ReportRequest>(entity =>
        {
            entity.ToTable("ReportRequest");

            entity.Property(e => e.DateRequested).HasColumnType("datetime");
            entity.Property(e => e.DateCompleted).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(500);
            entity.Property(e => e.ReportName).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Claimbenefitmv>(entity =>
        {
            entity.ToTable("CLAIMBENEFITMV");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Accepted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AdmitAdvancePayAndFinalise)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Admit/Advance Pay and Finalise");
            entity.Property(e => e.AdviserSalesId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Adviser Sales ID");
            entity.Property(e => e.AgeAtIncurredDate).HasColumnName("Age At Incurred Date");
            entity.Property(e => e.AgreedValue)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Agreed Value");
            entity.Property(e => e.AllocatedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Allocated By");
            entity.Property(e => e.Assessedunderlimitedcover)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("ASSESSEDUNDERLIMITEDCOVER");
            entity.Property(e => e.AssignedToDept)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Assigned To Dept");
            entity.Property(e => e.BenefitCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Creation Date");
            entity.Property(e => e.BenefitEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit End Date");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.BenefitPaymentFreq)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Benefit Payment Freq");
            entity.Property(e => e.BenefitPeriodAccident)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Accident");
            entity.Property(e => e.BenefitPeriodSickness)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Sickness");
            entity.Property(e => e.BenefitReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Date");
            entity.Property(e => e.BenefitReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Reason");
            entity.Property(e => e.BenefitStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Start Date");
            entity.Property(e => e.BenefitStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Status");
            entity.Property(e => e.BenefitType)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Benefit Type");
            entity.Property(e => e.CalculationEndType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation End Type");
            entity.Property(e => e.CalculationStartType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation Start Type");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.CeasedWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ceased Work Date");
            entity.Property(e => e.ChronicConditionOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Chronic Condition Option");
            entity.Property(e => e.ClaimAllocateNewDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Allocate New Date");
            entity.Property(e => e.ClaimAllowAutoAllocation)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Claim Allow Auto Allocation");
            entity.Property(e => e.ClaimEventType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Claim Event Type");
            entity.Property(e => e.ClaimFinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Date");
            entity.Property(e => e.ClaimFinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Reason");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimReceivedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Received Date");
            entity.Property(e => e.ClaimReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Date");
            entity.Property(e => e.ClaimReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Reason");
            entity.Property(e => e.ClaimStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Status");
            entity.Property(e => e.ClaimTeam)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Claim Team");
            entity.Property(e => e.ClassOfBusiness)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.CmpRequired)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CMP Required");
            entity.Property(e => e.ConcurrentClaimIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Concurrent Claim Indicator");
            entity.Property(e => e.ConcurrentClaimNumbers)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Concurrent Claim Numbers");
            entity.Property(e => e.ContractEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract End Date");
            entity.Property(e => e.ContractStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract Start Date");
            entity.Property(e => e.ContractStatus)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Contract Status");
            entity.Property(e => e.CountryOfIncident)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Country of Incident");
            entity.Property(e => e.CoverType)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Cover Type");
            entity.Property(e => e.CoverageNumber)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Coverage Number");
            entity.Property(e => e.CurrentClaimOwner)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Current Claim Owner");
            entity.Property(e => e.CustomerContactFrequency)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Customer Contact Frequency");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Birth");
            entity.Property(e => e.DateOfDeath)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Death");
            entity.Property(e => e.DateOfDiagnosis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Diagnosis");
            entity.Property(e => e.DateReturnedToWork)
                .HasPrecision(0)
                .HasColumnName("Date returned to work");
            entity.Property(e => e.Day1AccidentOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Day 1 Accident Option");
            entity.Property(e => e.Decision)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DecisionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Decision Date");
            entity.Property(e => e.DecisionReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Decision Reason");
            entity.Property(e => e.Declined)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Entity)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.ExpectedResolutionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Expected Resolution Date");
            entity.Property(e => e.ExpectedReturnToWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Expected Return To Work Date");
            entity.Property(e => e.ExpectedRtwFtRange)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Expected RTW FT Range");
            entity.Property(e => e.ExternalMemberNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("External Member Number");
            entity.Property(e => e.FinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Finalised Date");
            entity.Property(e => e.FinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Finalised Reason");
            entity.Property(e => e.FirstAcceptanceDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("First Acceptance Date");
            entity.Property(e => e.FirstContactDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("First Contact Date");
            entity.Property(e => e.GivenName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Given Name");
            entity.Property(e => e.GroupPlanName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Group Plan Name");
            entity.Property(e => e.GroupPlanNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Group Plan Number");
            entity.Property(e => e.HoursWorkedPerWeek)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("Hours Worked Per Week");
            entity.Property(e => e.IarCode)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("IAR Code");
            entity.Property(e => e.IarDescription)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("IAR Description");
            entity.Property(e => e.IncidentOccurredOverseas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Incident Occurred Overseas");
            entity.Property(e => e.IncurredDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Incurred Date");
            entity.Property(e => e.IndexationFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Indexation Flag");
            entity.Property(e => e.IndexationFrequency)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Indexation Frequency");
            entity.Property(e => e.IndicativeClaimType)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Indicative Claim Type");
            entity.Property(e => e.InitialSumInsured)
                .HasColumnType("numeric(28, 6)")
                .HasColumnName("Initial Sum Insured");
            entity.Property(e => e.InitialSumInsuredFreq)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Initial Sum Insured Freq");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.MaximumIndexationRate).HasColumnName("Maximum Indexation Rate");
            entity.Property(e => e.NonDisclosure)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Non Disclosure");
            entity.Property(e => e.Occupation)
                .HasMaxLength(353)
                .IsUnicode(false);
            entity.Property(e => e.OccupationCategory)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Occupation Category");
            entity.Property(e => e.OverrideRiskCategory)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category");
            entity.Property(e => e.OverrideRiskCategoryReason)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category Reason");
            entity.Property(e => e.PartialEarningsIncome)
                .HasColumnType("numeric(28, 6)")
                .HasColumnName("Partial Earnings Income");
            entity.Property(e => e.PartyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Party Id");
            entity.Property(e => e.PaymentAuthorized)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Payment Authorized");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy Number");
            entity.Property(e => e.PostCode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Post Code");
            entity.Property(e => e.PreDisabilityIncome)
                .HasColumnType("numeric(28, 6)")
                .HasColumnName("Pre-disability Income");
            entity.Property(e => e.PrimaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Code");
            entity.Property(e => e.PrimaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Date");
            entity.Property(e => e.PrimaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Description");
            entity.Property(e => e.PrimaryOccSelfEmployedInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Primary Occ Self Employed Ind");
            entity.Property(e => e.PrimaryOccupationEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation End Date");
            entity.Property(e => e.PrimaryOccupationStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation Start Date");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.QualifyingPeriod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Qualifying Period");
            entity.Property(e => e.ReInsurerName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Re insurer Name");
            entity.Property(e => e.RegistrationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Registration Date");
            entity.Property(e => e.ReinsurancePercent).HasColumnName("Reinsurance Percent");
            entity.Property(e => e.ReinsuranceTreatyType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Reinsurance Treaty Type");
            entity.Property(e => e.RiskCategory)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Risk Category");
            entity.Property(e => e.RiskCommencedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Commenced Date");
            entity.Property(e => e.RiskExpiryDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Expiry Date");
            entity.Property(e => e.SecondaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Code");
            entity.Property(e => e.SecondaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Date");
            entity.Property(e => e.SecondaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Description");
            entity.Property(e => e.Sex)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Source)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.SourceBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Code");
            entity.Property(e => e.SourceBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Description");
            entity.Property(e => e.SourceBenefitSelected)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Source Benefit Selected");
            entity.Property(e => e.SourceBenefitType)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Type");
            entity.Property(e => e.SourceSystem)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Source System");
            entity.Property(e => e.SpecialArrangementDuration)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Special Arrangement Duration");
            entity.Property(e => e.SpecialArrangementFlag)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("Special Arrangement Flag");
            entity.Property(e => e.StaffInd)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("Staff Ind");
            entity.Property(e => e.State)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.SumInsured).HasColumnName("Sum Insured");
            entity.Property(e => e.SumReInsured).HasColumnName("Sum Re-insured");
            entity.Property(e => e.SuperContributionPercent).HasColumnName("Super Contribution Percent");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TargetBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Code");
            entity.Property(e => e.TargetBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Description");
            entity.Property(e => e.TargetBenefitType)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Type");
            entity.Property(e => e.TpdDefinition)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("TPD Definition");
            entity.Property(e => e.TpdSubDefinition)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("TPD Sub Definition");
            entity.Property(e => e.TraumaDefinition)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Trauma Definition");
            entity.Property(e => e.UnexpectedCircumstances)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Unexpected Circumstances");
            entity.Property(e => e.UnexpectedCircumstancesApply)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Unexpected Circumstances Apply");
            entity.Property(e => e.UrgentFinancialNeedsFlag).HasColumnName("Urgent Financial Needs Flag");
            entity.Property(e => e.WaitingPeriodAccident)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Accident");
            entity.Property(e => e.WaitingPeriodSickness)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Sickness");
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<Paymentsummarymv>(entity =>
        {
            entity.ToTable("PAYMENTSUMMARYMV");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AcceptFrom)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Accept From");
            entity.Property(e => e.AdminAuthorisedByInitials)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Admin Authorised By -Initials");
            entity.Property(e => e.AdminAuthorisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Admin Authorised Date");
            entity.Property(e => e.AdminDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Admin Date");
            entity.Property(e => e.AdminInitials)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Admin Initials");
            entity.Property(e => e.BenefitAmount).HasColumnName("Benefit Amount (+$)");
            entity.Property(e => e.BenefitAmountInfo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Benefit Amount Info");
            entity.Property(e => e.BenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Benefit Code");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.BenefitPayment)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Benefit Payment");
            entity.Property(e => e.BenefitType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Type");
            entity.Property(e => e.CalculationDescription)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Calculation Description");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClassOfBusiness)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.CpiEbrClaimsEscalDes)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("CPI-EBR/Claims Escal Des");
            entity.Property(e => e.CpiEbrClaimsEscalation)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("CPI-EBR/Claims Escalation(%)");
            entity.Property(e => e.DateCreated)
                .HasPrecision(0)
                .HasColumnName("Date Created");
            entity.Property(e => e.EFormId).HasColumnName("e-Form ID");
            entity.Property(e => e.From)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.GroupPayee)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Group Payee");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.NoClaimBonus).HasColumnName("No Claim Bonus (+$)");
            entity.Property(e => e.NoClaimBonusInfo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("No Claim Bonus Info");
            entity.Property(e => e.NumberOfPayments).HasColumnName("Number of Payments");
            entity.Property(e => e.Offsets).HasColumnName("Offsets (-$)");
            entity.Property(e => e.OffsetsInfo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Offsets Info");
            entity.Property(e => e.OtherInformationEnd)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Other information end");
            entity.Property(e => e.Others).HasColumnName("Others (+$)");
            entity.Property(e => e.OthersInfo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Others Info");
            entity.Property(e => e.PartialBenefit)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Partial Benefit%");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Payment Method");
            entity.Property(e => e.PaymentReference)
                .HasMaxLength(960)
                .IsUnicode(false)
                .HasColumnName("Payment Reference");
            entity.Property(e => e.PeopleSoftScoReference)
                .HasMaxLength(960)
                .IsUnicode(false)
                .HasColumnName("PeopleSoft SCO Reference");
            entity.Property(e => e.PremiumRefund).HasColumnName("Premium Refund (+$)");
            entity.Property(e => e.PremiumRefundInfo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Premium Refund Info");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.PsoftPayAuthBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PSoft Pay Auth By");
            entity.Property(e => e.PsoftPayAuthDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PSoft Pay AuthDate");
            entity.Property(e => e.PsoftPayAuthDate1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PSoft  Pay Auth Date");
            entity.Property(e => e.PsoftRefForWaivPremiums)
                .HasMaxLength(960)
                .IsUnicode(false)
                .HasColumnName("PSoft Ref for Waiv Premiums");
            entity.Property(e => e.PsoftWvedPremiumAuthBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PSoft Wved Premium Auth By");
            entity.Property(e => e.ServiceRequestScoReference)
                .HasMaxLength(960)
                .IsUnicode(false)
                .HasColumnName("Service Request SCO Reference");
            entity.Property(e => e.StampDuty).HasColumnName("Stamp Duty (+$) ");
            entity.Property(e => e.StampDutyInfo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Stamp Duty Info");
            entity.Property(e => e.SuperContributions).HasColumnName("Super Contributions (-$)");
            entity.Property(e => e.SuperContributionsInfo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Super Contributions Info");
            entity.Property(e => e.Tax).HasColumnName("Tax (-$)");
            entity.Property(e => e.TaxInfo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Tax Info");
            entity.Property(e => e.To)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnName("Total ($)");
            entity.Property(e => e.StaffInd).HasColumnType("int");
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<RptAbleuser>(entity =>
        {
            entity.HasKey(e => e.ClaimUserId);

            entity.ToTable("RPT_ABLEUSERS");

            entity.Property(e => e.ClaimUserId)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Claim User ID");
            entity.Property(e => e.DefaultDepartment)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Default Department");
            entity.Property(e => e.DepartmentNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Department Number");
            entity.Property(e => e.FullName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Full Name");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Job Title");
            entity.Property(e => e.LanId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LAN ID");
            entity.Property(e => e.LastLogonDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Last Logon Date");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ManagerLanId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Manager LAN ID");
            entity.Property(e => e.ManagerMobile)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Manager Mobile");
            entity.Property(e => e.ManagerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Manager Name");
            entity.Property(e => e.Mobile)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RptAbleusersallrole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RPT_ABLEUSERSALLROLES");

            entity.Property(e => e.ClaimUserId)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Claim User ID");
            entity.Property(e => e.DefaultDepartment)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Default Department");
            entity.Property(e => e.DepartmentNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Department Number");
            entity.Property(e => e.FullName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Full Name");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Job Title");
            entity.Property(e => e.LanId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LAN ID");
            entity.Property(e => e.LastLogonDate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("Last Logon Date");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ManagerLanId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Manager LAN ID");
            entity.Property(e => e.ManagerMobile)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Manager Mobile");
            entity.Property(e => e.ManagerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Manager Name");
            entity.Property(e => e.Mobile)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RptActionsservice>(entity =>
        {
            entity.ToTable("RPT_ACTIONSSERVICES");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ActionName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Action Name");
            entity.Property(e => e.ActionOpenDuration).HasColumnName("Action Open Duration");
            entity.Property(e => e.ActionOutcome)
                .IsUnicode(false)
                .HasColumnName("Action Outcome");
            entity.Property(e => e.ActionOutcomeComments)
                .IsUnicode(false)
                .HasColumnName("Action Outcome Comments");
            entity.Property(e => e.ActionOutcomeDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Action Outcome Date");
            entity.Property(e => e.ActionOutcomeReason)
                .IsUnicode(false)
                .HasColumnName("Action Outcome Reason");
            entity.Property(e => e.ActionStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Action Start Date");
            entity.Property(e => e.BexBenefitCase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BEX Benefit Case");
            entity.Property(e => e.CaseManager)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Case Manager");
            entity.Property(e => e.ClaimCase)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Case");
            entity.Property(e => e.ClaimCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Creation Date");
            entity.Property(e => e.CmpCustomerGoal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CMP Customer Goal");
            entity.Property(e => e.CmpGoalDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CMP Goal Date");
            entity.Property(e => e.DeathBenefitCase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Death Benefit Case");
            entity.Property(e => e.DepartmentOfCase)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Department of Case");
            entity.Property(e => e.IncurredDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Incurred Date");
            entity.Property(e => e.IpBenefitCase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IP Benefit Case");
            entity.Property(e => e.NotificationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Notification Date");
            entity.Property(e => e.Occupation)
                .HasMaxLength(353)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Description");
            entity.Property(e => e.PrimaryDiagnosis)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Primary Diagnosis");
            entity.Property(e => e.RatePerHour)
                .HasColumnType("numeric(28, 6)")
                .HasColumnName("Rate per Hour");
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Service Code");
            entity.Property(e => e.ServiceCreatorActionOwner)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Service Creator (Action Owner)");
            entity.Property(e => e.ServiceEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Service End Date");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Service Name");
            entity.Property(e => e.ServiceProvider)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Service Provider");
            entity.Property(e => e.ServiceStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Service Start Date");
            entity.Property(e => e.StandAloneWopBenefitCase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Stand Alone WOP Benefit Case");
            entity.Property(e => e.TeamManager)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Team Manager");
            entity.Property(e => e.TotalCosts)
                .HasColumnType("numeric(28, 6)")
                .HasColumnName("Total Costs");
            entity.Property(e => e.TpdBenefitCase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TPD Benefit Case");
            entity.Property(e => e.TraumaBenefitCase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Trauma Benefit Case");
            entity.Property(e => e.TriageSegment)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Triage Segment");
            entity.Property(e => e.TtdBenefitCase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TTD Benefit Case");
            entity.Property(e => e.UnitsOfferedNumberOfHours)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Units Offered/NUMBER OF HOURS");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptCaseaction>(entity =>
        {
            entity.ToTable("RPT_CASEACTIONS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ActionDate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("Action Date");
            entity.Property(e => e.ActionedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Actioned By");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.Reason).IsUnicode(false);
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.StaffInd).HasColumnType("int");
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<RptClaimBenefitactuarialrecl>(entity =>
        {
            entity.ToTable("RPT_CLAIM_BENEFITACTUARIALRECLS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Accepted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AdmitAdvancePayAndFinalise)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Admit/Advance Pay and Finalise");
            entity.Property(e => e.AdviserSalesId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Adviser Sales ID");
            entity.Property(e => e.AgeAtIncurredDate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Age At Incurred Date");
            entity.Property(e => e.AgreedValue)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Agreed Value");
            entity.Property(e => e.BenefitCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Creation Date");
            entity.Property(e => e.BenefitEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit End Date");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.BenefitPeriodAccident)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Accident");
            entity.Property(e => e.BenefitPeriodSickness)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Sickness");
            entity.Property(e => e.BenefitReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Date");
            entity.Property(e => e.BenefitReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Reason");
            entity.Property(e => e.BenefitStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Start Date");
            entity.Property(e => e.BenefitStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Status");
            entity.Property(e => e.BenefitType)
                .IsUnicode(false)
                .HasColumnName("Benefit Type");
            entity.Property(e => e.CalculationEndType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation End Type");
            entity.Property(e => e.CalculationStartType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation Start Type");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.CeasedWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ceased Work Date");
            entity.Property(e => e.ChronicConditionOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Chronic Condition Option");
            entity.Property(e => e.ClaimEventType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Claim Event Type");
            entity.Property(e => e.ClaimFinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Date");
            entity.Property(e => e.ClaimFinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Reason");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Date");
            entity.Property(e => e.ClaimReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Reason");
            entity.Property(e => e.ClaimStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Status");
            entity.Property(e => e.ClaimTeam)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Claim Team");
            entity.Property(e => e.ClassOfBusiness)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.CmpRequired)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CMP Required");
            entity.Property(e => e.ConcurrentClaimIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Concurrent Claim Indicator");
            entity.Property(e => e.ConcurrentClaimNumbers)
                .IsUnicode(false)
                .HasColumnName("Concurrent Claim Numbers");
            entity.Property(e => e.ContractEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract End Date");
            entity.Property(e => e.ContractStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract Start Date");
            entity.Property(e => e.ContractStatus)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Contract Status");
            entity.Property(e => e.CountryOfIncident)
                .IsUnicode(false)
                .HasColumnName("Country of Incident");
            entity.Property(e => e.CoverType)
                .IsUnicode(false)
                .HasColumnName("Cover Type");
            entity.Property(e => e.CurrentClaimOwner)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Current Claim Owner");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Birth");
            entity.Property(e => e.DateOfDeath)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Death");
            entity.Property(e => e.DateOfDiagnosis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Diagnosis");
            entity.Property(e => e.DateReturnedToWork)
                .HasColumnType("date")
                .HasColumnName("Date returned to work");
            entity.Property(e => e.Day1AccidentOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Day 1 Accident Option");
            entity.Property(e => e.Decision)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DecisionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Decision Date");
            entity.Property(e => e.DecisionReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Decision Reason");
            entity.Property(e => e.ExpectedReturnToWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Expected Return To Work Date");
            entity.Property(e => e.ExpectedRtwFtRange)
                .IsUnicode(false)
                .HasColumnName("Expected RTW FT Range");
            entity.Property(e => e.ExternalMemberNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("External Member Number");
            entity.Property(e => e.FinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Finalised Date");
            entity.Property(e => e.FinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Finalised Reason");
            entity.Property(e => e.FirstContactDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("First Contact Date");
            entity.Property(e => e.GivenName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Given Name");
            entity.Property(e => e.GroupPlanName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Group Plan Name");
            entity.Property(e => e.GroupPlanNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Group Plan Number");
            entity.Property(e => e.HoursWorkedPerWeek)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Hours Worked Per Week");
            entity.Property(e => e.IncidentOccurredOverseas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Incident Occurred Overseas");
            entity.Property(e => e.IncurredDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Incurred Date");
            entity.Property(e => e.IndexationFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Indexation Flag");
            entity.Property(e => e.IndexationFrequency)
                .IsUnicode(false)
                .HasColumnName("Indexation Frequency");
            entity.Property(e => e.IndicativeClaimType)
                .IsUnicode(false)
                .HasColumnName("Indicative Claim Type");
            entity.Property(e => e.InitialSumInsured)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Initial Sum Insured");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.MaximumIndexationRate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Maximum Indexation Rate");
            entity.Property(e => e.MonthEffectiveDate)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Month Effective Date");
            entity.Property(e => e.NonDisclosure)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Non Disclosure");
            entity.Property(e => e.NumberOfReinsurers)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Number of Reinsurers");
            entity.Property(e => e.Occupation)
                .HasMaxLength(353)
                .IsUnicode(false);
            entity.Property(e => e.OccupationCategory)
                .IsUnicode(false)
                .HasColumnName("Occupation Category");
            entity.Property(e => e.OverrideRiskCategory)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category");
            entity.Property(e => e.OverrideRiskCategoryReason)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category Reason");
            entity.Property(e => e.PartialEarningsIncome)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Partial Earnings Income");
            entity.Property(e => e.PartyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Party Id");
            entity.Property(e => e.PaymentAuthorized)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Payment Authorized");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy Number");
            entity.Property(e => e.PostCode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Post Code");
            entity.Property(e => e.PreDisabilityIncome)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Pre-disability Income");
            entity.Property(e => e.PrimaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Code");
            entity.Property(e => e.PrimaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Date");
            entity.Property(e => e.PrimaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Description");
            entity.Property(e => e.PrimaryOccupationEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation End Date");
            entity.Property(e => e.PrimaryOccupationStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation Start Date");
            entity.Property(e => e.ProductCode)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.QualifyingPeriod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Qualifying Period");
            entity.Property(e => e.RegistrationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Registration Date");
            entity.Property(e => e.RiskCategory)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Risk Category");
            entity.Property(e => e.RiskCommencedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Commenced Date");
            entity.Property(e => e.RiskExpiryDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Expiry Date");
            entity.Property(e => e.SecondaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Code");
            entity.Property(e => e.SecondaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Date");
            entity.Property(e => e.SecondaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Description");
            entity.Property(e => e.Sex)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Source)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.SourceBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Code");
            entity.Property(e => e.SourceBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Description");
            entity.Property(e => e.SourceBenefitSelected)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Source Benefit Selected");
            entity.Property(e => e.SourceBenefitType)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Type");
            entity.Property(e => e.SourceSystem)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Source System");
            entity.Property(e => e.SpecialArrangementDuration)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Special Arrangement Duration");
            entity.Property(e => e.SpecialArrangementFlag)
                .HasColumnType("decimal(1, 0)")
                .HasColumnName("Special Arrangement Flag");
            entity.Property(e => e.State)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.SuperContributionPercent)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Super Contribution Percent");
            entity.Property(e => e.Surname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TargetBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Code");
            entity.Property(e => e.TargetBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Description");
            entity.Property(e => e.TargetSumInsured)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Target Sum Insured");
            entity.Property(e => e.TargetSumInsuredFreq)
                .IsUnicode(false)
                .HasColumnName("Target Sum Insured Freq");
            entity.Property(e => e.TotalReinsurancePercent)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Total Reinsurance Percent");
            entity.Property(e => e.UnexpectedCircumstances)
                .IsUnicode(false)
                .HasColumnName("Unexpected Circumstances");
            entity.Property(e => e.UrgentFinancialNeedsFlag)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Urgent Financial Needs Flag");
            entity.Property(e => e.WaitingPeriodAccident)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Accident");
            entity.Property(e => e.WaitingPeriodSickness)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Sickness");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptClaimbenefitactuarialrec>(entity =>
        {
            entity.ToTable("RPT_CLAIMBENEFITACTUARIALREC");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Accepted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AdmitAdvancePayAndFinalise)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Admit/Advance Pay and Finalise");
            entity.Property(e => e.AdviserSalesId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Adviser Sales ID");
            entity.Property(e => e.AgeAtIncurredDate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Age At Incurred Date");
            entity.Property(e => e.AgreedValue)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Agreed Value");
            entity.Property(e => e.BenefitCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Creation Date");
            entity.Property(e => e.BenefitEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit End Date");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.BenefitPeriodAccident)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Accident");
            entity.Property(e => e.BenefitPeriodSickness)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Sickness");
            entity.Property(e => e.BenefitReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Date");
            entity.Property(e => e.BenefitReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Reason");
            entity.Property(e => e.BenefitStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Start Date");
            entity.Property(e => e.BenefitStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Status");
            entity.Property(e => e.BenefitType)
                .IsUnicode(false)
                .HasColumnName("Benefit Type");
            entity.Property(e => e.CalculationEndType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation End Type");
            entity.Property(e => e.CalculationStartType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation Start Type");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.CeasedWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ceased Work Date");
            entity.Property(e => e.ChronicConditionOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Chronic Condition Option");
            entity.Property(e => e.ClaimEventType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Claim Event Type");
            entity.Property(e => e.ClaimFinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Date");
            entity.Property(e => e.ClaimFinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Reason");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Date");
            entity.Property(e => e.ClaimReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Reason");
            entity.Property(e => e.ClaimStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Status");
            entity.Property(e => e.ClaimTeam)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Claim Team");
            entity.Property(e => e.ClassOfBusiness)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.CmpRequired)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CMP Required");
            entity.Property(e => e.ConcurrentClaimIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Concurrent Claim Indicator");
            entity.Property(e => e.ConcurrentClaimNumbers)
                .IsUnicode(false)
                .HasColumnName("Concurrent Claim Numbers");
            entity.Property(e => e.ContractEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract End Date");
            entity.Property(e => e.ContractStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract Start Date");
            entity.Property(e => e.ContractStatus)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Contract Status");
            entity.Property(e => e.CountryOfIncident)
                .IsUnicode(false)
                .HasColumnName("Country of Incident");
            entity.Property(e => e.CoverType)
                .IsUnicode(false)
                .HasColumnName("Cover Type");
            entity.Property(e => e.CurrentClaimOwner)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Current Claim Owner");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Birth");
            entity.Property(e => e.DateOfDeath)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Death");
            entity.Property(e => e.DateOfDiagnosis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Diagnosis");
            entity.Property(e => e.DateReturnedToWork)
                .HasColumnType("date")
                .HasColumnName("Date returned to work");
            entity.Property(e => e.Day1AccidentOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Day 1 Accident Option");
            entity.Property(e => e.Decision)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DecisionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Decision Date");
            entity.Property(e => e.DecisionReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Decision Reason");
            entity.Property(e => e.ExpectedReturnToWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Expected Return To Work Date");
            entity.Property(e => e.ExpectedRtwFtRange)
                .IsUnicode(false)
                .HasColumnName("Expected RTW FT Range");
            entity.Property(e => e.ExternalMemberNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("External Member Number");
            entity.Property(e => e.FinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Finalised Date");
            entity.Property(e => e.FinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Finalised Reason");
            entity.Property(e => e.FirstContactDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("First Contact Date");
            entity.Property(e => e.GivenName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Given Name");
            entity.Property(e => e.GroupPlanName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Group Plan Name");
            entity.Property(e => e.GroupPlanNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Group Plan Number");
            entity.Property(e => e.HoursWorkedPerWeek)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Hours Worked Per Week");
            entity.Property(e => e.IncidentOccurredOverseas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Incident Occurred Overseas");
            entity.Property(e => e.IncurredDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Incurred Date");
            entity.Property(e => e.IndexationFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Indexation Flag");
            entity.Property(e => e.IndexationFrequency)
                .IsUnicode(false)
                .HasColumnName("Indexation Frequency");
            entity.Property(e => e.IndicativeClaimType)
                .IsUnicode(false)
                .HasColumnName("Indicative Claim Type");
            entity.Property(e => e.InitialSumInsured)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Initial Sum Insured");
            entity.Property(e => e.InitialSumInsuredFreq)
                .IsUnicode(false)
                .HasColumnName("Initial Sum Insured Freq");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.MaximumIndexationRate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Maximum Indexation Rate");
            entity.Property(e => e.MonthEffectiveDate)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Month Effective Date");
            entity.Property(e => e.NonDisclosure)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Non Disclosure");
            entity.Property(e => e.NumberOfReinsurers)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Number of Reinsurers");
            entity.Property(e => e.Occupation)
                .HasMaxLength(353)
                .IsUnicode(false);
            entity.Property(e => e.OccupationCategory)
                .IsUnicode(false)
                .HasColumnName("Occupation Category");
            entity.Property(e => e.OverrideRiskCategory)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category");
            entity.Property(e => e.OverrideRiskCategoryReason)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category Reason");
            entity.Property(e => e.PartialEarningsIncome)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Partial Earnings Income");
            entity.Property(e => e.PartyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Party Id");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy Number");
            entity.Property(e => e.PostCode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Post Code");
            entity.Property(e => e.PreDisabilityIncome)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Pre-disability Income");
            entity.Property(e => e.PrimaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Code");
            entity.Property(e => e.PrimaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Date");
            entity.Property(e => e.PrimaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Description");
            entity.Property(e => e.PrimaryOccupationEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation End Date");
            entity.Property(e => e.PrimaryOccupationStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation Start Date");
            entity.Property(e => e.ProductCode)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.RegistrationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Registration Date");
            entity.Property(e => e.RiskCategory)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Risk Category");
            entity.Property(e => e.RiskCommencedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Commenced Date");
            entity.Property(e => e.RiskExpiryDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Expiry Date");
            entity.Property(e => e.SecondaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Code");
            entity.Property(e => e.SecondaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Date");
            entity.Property(e => e.SecondaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Description");
            entity.Property(e => e.Sex)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Source)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.SourceBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Code");
            entity.Property(e => e.SourceBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Description");
            entity.Property(e => e.SourceBenefitSelected)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Source Benefit Selected");
            entity.Property(e => e.SourceBenefitType)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Type");
            entity.Property(e => e.SourceSystem)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Source System");
            entity.Property(e => e.SpecialArrangementDuration)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Special Arrangement Duration");
            entity.Property(e => e.SpecialArrangementFlag)
                .HasColumnType("decimal(1, 0)")
                .HasColumnName("Special Arrangement Flag");
            entity.Property(e => e.State)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.SuperContributionPercent)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Super Contribution Percent");
            entity.Property(e => e.Surname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TargetBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Code");
            entity.Property(e => e.TargetBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Description");
            entity.Property(e => e.TargetSumInsured)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Target Sum Insured");
            entity.Property(e => e.TargetSumInsuredFreq)
                .IsUnicode(false)
                .HasColumnName("Target Sum Insured Freq");
            entity.Property(e => e.TotalReinsurancePercent)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Total Reinsurance Percent");
            entity.Property(e => e.UnexpectedCircumstances)
                .IsUnicode(false)
                .HasColumnName("Unexpected Circumstances");
            entity.Property(e => e.UrgentFinancialNeedsFlag)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Urgent Financial Needs Flag");
            entity.Property(e => e.WaitingPeriodAccident)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Accident");
            entity.Property(e => e.WaitingPeriodSickness)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Sickness");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptClaimbenefitgroup>(entity =>
        {
            entity.ToTable("RPT_CLAIMBENEFITGROUP");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Accepted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AdmitAdvancePayAndFinalise)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Admit/Advance Pay and Finalise");
            entity.Property(e => e.AdviserSalesId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Adviser Sales ID");
            entity.Property(e => e.AgeAtIncurredDate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Age At Incurred Date");
            entity.Property(e => e.AgreedValue)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Agreed Value");
            entity.Property(e => e.AssessedUnderLimitedCover)
                .HasColumnType("decimal(1, 0)")
                .HasColumnName("Assessed Under Limited Cover");
            entity.Property(e => e.BenefitCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Creation Date");
            entity.Property(e => e.BenefitEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit End Date");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.BenefitPeriodAccident)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Accident");
            entity.Property(e => e.BenefitPeriodSickness)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Sickness");
            entity.Property(e => e.BenefitReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Date");
            entity.Property(e => e.BenefitReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Reason");
            entity.Property(e => e.BenefitStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Start Date");
            entity.Property(e => e.BenefitStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Status");
            entity.Property(e => e.CalculationEndType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation End Type");
            entity.Property(e => e.CalculationStartType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation Start Type");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.CeasedWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ceased Work Date");
            entity.Property(e => e.ChronicConditionOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Chronic Condition Option");
            entity.Property(e => e.ClaimEventType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Claim Event Type");
            entity.Property(e => e.ClaimFinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Date");
            entity.Property(e => e.ClaimFinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Reason");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimReceivedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Received Date");
            entity.Property(e => e.ClaimReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Date");
            entity.Property(e => e.ClaimReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Reason");
            entity.Property(e => e.ClaimStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Status");
            entity.Property(e => e.ClaimTeam)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Claim Team");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClassOfBusiness)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.CmpRequired)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CMP Required");
            entity.Property(e => e.ConcurrentClaimIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Concurrent Claim Indicator");
            entity.Property(e => e.ConcurrentClaimNumbers)
                .IsUnicode(false)
                .HasColumnName("Concurrent Claim Numbers");
            entity.Property(e => e.ContractEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract End Date");
            entity.Property(e => e.ContractStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract Start Date");
            entity.Property(e => e.ContractStatus)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Contract Status");
            entity.Property(e => e.CountryOfIncident)
                .IsUnicode(false)
                .HasColumnName("Country of Incident");
            entity.Property(e => e.CoverageNumber)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Coverage Number");
            entity.Property(e => e.CurrentClaimOwner)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Current Claim Owner");
            entity.Property(e => e.CustomerContactFrequency)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Customer Contact Frequency");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Birth");
            entity.Property(e => e.DateOfDeath)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Death");
            entity.Property(e => e.DateOfDiagnosis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Diagnosis");
            entity.Property(e => e.DateReturnedToWork)
                .HasColumnType("date")
                .HasColumnName("Date returned to work");
            entity.Property(e => e.Day1AccidentOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Day 1 Accident Option");
            entity.Property(e => e.Decision)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DecisionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Decision Date");
            entity.Property(e => e.DecisionReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Decision Reason");
            entity.Property(e => e.Declined)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExpectedResolutionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Expected Resolution Date");
            entity.Property(e => e.ExpectedReturnToWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Expected Return To Work Date");
            entity.Property(e => e.ExpectedRtwFtRange)
                .IsUnicode(false)
                .HasColumnName("Expected RTW FT Range");
            entity.Property(e => e.ExternalMemberNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("External Member Number");
            entity.Property(e => e.FinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Finalised Date");
            entity.Property(e => e.FinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Finalised Reason");
            entity.Property(e => e.FirstContactDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("First Contact Date");
            entity.Property(e => e.GivenName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Given Name");
            entity.Property(e => e.GroupPlanName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Group Plan Name");
            entity.Property(e => e.GroupPlanNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Group Plan Number");
            entity.Property(e => e.HoursWorkedPerWeek)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Hours Worked Per Week");
            entity.Property(e => e.IncidentOccurredOverseas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Incident Occurred Overseas");
            entity.Property(e => e.IncurredDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Incurred Date");
            entity.Property(e => e.IndexationFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Indexation Flag");
            entity.Property(e => e.InitialSumInsured)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Initial Sum Insured");
            entity.Property(e => e.InitialSumInsuredFreq)
                .IsUnicode(false)
                .HasColumnName("Initial Sum Insured Freq");
            entity.Property(e => e.InitialSumInsuredX12)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Initial Sum Insured x 12");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.MaximumIndexationRate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Maximum Indexation Rate");
            entity.Property(e => e.NonDisclosure)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Non Disclosure");
            entity.Property(e => e.Occupation)
                .HasMaxLength(353)
                .IsUnicode(false);
            entity.Property(e => e.OverrideRiskCategory)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category");
            entity.Property(e => e.OverrideRiskCategoryReason)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category Reason");
            entity.Property(e => e.PartialEarningsIncome)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Partial Earnings Income");
            entity.Property(e => e.PartyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Party Id");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy Number");
            entity.Property(e => e.PostCode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Post Code");
            entity.Property(e => e.PreDisabilityIncome)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Pre-disability Income");
            entity.Property(e => e.PrimaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Code");
            entity.Property(e => e.PrimaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Date");
            entity.Property(e => e.PrimaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Description");
            entity.Property(e => e.PrimaryOccSelfEmployedInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Primary Occ Self Employed Ind");
            entity.Property(e => e.PrimaryOccupationEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation End Date");
            entity.Property(e => e.PrimaryOccupationStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation Start Date");
            entity.Property(e => e.ProductCode)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.QualifyingPeriod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Qualifying Period");
            entity.Property(e => e.ReInsurerName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Re insurer Name");
            entity.Property(e => e.RegistrationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Registration Date");
            entity.Property(e => e.ReinsurancePercent)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Reinsurance Percent");
            entity.Property(e => e.ReinsuranceTreatyType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Reinsurance Treaty Type");
            entity.Property(e => e.RiskCategory)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Risk Category");
            entity.Property(e => e.RiskCommencedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Commenced Date");
            entity.Property(e => e.RiskExpiryDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Expiry Date");
            entity.Property(e => e.SecondaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Code");
            entity.Property(e => e.SecondaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Date");
            entity.Property(e => e.SecondaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Description");
            entity.Property(e => e.Sex)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Source)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.SourceBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Code");
            entity.Property(e => e.SourceBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Description");
            entity.Property(e => e.SourceBenefitSelected)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Source Benefit Selected");
            entity.Property(e => e.SourceBenefitType)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Type");
            entity.Property(e => e.SourceSystem)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Source System");
            entity.Property(e => e.SpecialArrangementDuration)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Special Arrangement Duration");
            entity.Property(e => e.SpecialArrangementFlag)
                .HasColumnType("decimal(1, 0)")
                .HasColumnName("Special Arrangement Flag");
            entity.Property(e => e.State)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.SumInsured)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Sum Insured");
            entity.Property(e => e.SumReInsured)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Sum Re-insured");
            entity.Property(e => e.SuperContributionPercent)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Super Contribution Percent");
            entity.Property(e => e.Surname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TargetBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Code");
            entity.Property(e => e.TargetBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Description");
            entity.Property(e => e.TargetBenefitType)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Type");
            entity.Property(e => e.TpdDefinition)
                .IsUnicode(false)
                .HasColumnName("TPD Definition");
            entity.Property(e => e.TpdSubDefinition)
                .IsUnicode(false)
                .HasColumnName("TPD Sub Definition");
            entity.Property(e => e.TraumaDefinition)
                .IsUnicode(false)
                .HasColumnName("Trauma Definition");
            entity.Property(e => e.UnexpectedCircumstances)
                .IsUnicode(false)
                .HasColumnName("Unexpected Circumstances");
            entity.Property(e => e.UnexpectedCircumstancesApply)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Unexpected Circumstances Apply");
            entity.Property(e => e.UrgentFinancialNeedsFlag)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Urgent Financial Needs Flag");
            entity.Property(e => e.WaitingPeriodAccident)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Accident");
            entity.Property(e => e.WaitingPeriodSickness)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Sickness");
            entity.Property(e => e.StaffInd).HasColumnType("int");

        });

        modelBuilder.Entity<RptClaimbenefitreinsurance>(entity =>
        {
            entity.ToTable("RPT_CLAIMBENEFITREINSURANCE");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Accepted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AdmitAdvancePayAndFinalise)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Admit/Advance Pay and Finalise");
            entity.Property(e => e.AdviserSalesId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Adviser Sales ID");
            entity.Property(e => e.AgeAtIncurredDate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Age At Incurred Date");
            entity.Property(e => e.AgreedValue)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Agreed Value");
            entity.Property(e => e.AssessedUnderLimitedCover)
                .HasColumnType("decimal(1, 0)")
                .HasColumnName("Assessed Under Limited Cover");
            entity.Property(e => e.BenefitCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Creation Date");
            entity.Property(e => e.BenefitEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit End Date");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.BenefitPeriodAccident)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Accident");
            entity.Property(e => e.BenefitPeriodSickness)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Sickness");
            entity.Property(e => e.BenefitReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Date");
            entity.Property(e => e.BenefitReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Reason");
            entity.Property(e => e.BenefitStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Start Date");
            entity.Property(e => e.BenefitStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Status");
            entity.Property(e => e.CalculationEndType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation End Type");
            entity.Property(e => e.CalculationStartType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation Start Type");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.CeasedWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ceased Work Date");
            entity.Property(e => e.ChronicConditionOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Chronic Condition Option");
            entity.Property(e => e.ClaimEventType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Claim Event Type");
            entity.Property(e => e.ClaimFinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Date");
            entity.Property(e => e.ClaimFinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Reason");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimReceivedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Received Date");
            entity.Property(e => e.ClaimReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Date");
            entity.Property(e => e.ClaimReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Reason");
            entity.Property(e => e.ClaimStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Status");
            entity.Property(e => e.ClaimTeam)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Claim Team");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClassOfBusiness)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.CmpRequired)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CMP Required");
            entity.Property(e => e.ConcurrentClaimIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Concurrent Claim Indicator");
            entity.Property(e => e.ConcurrentClaimNumbers)
                .IsUnicode(false)
                .HasColumnName("Concurrent Claim Numbers");
            entity.Property(e => e.ContractEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract End Date");
            entity.Property(e => e.ContractStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract Start Date");
            entity.Property(e => e.ContractStatus)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Contract Status");
            entity.Property(e => e.CountryOfIncident)
                .IsUnicode(false)
                .HasColumnName("Country of Incident");
            entity.Property(e => e.CoverageNumber)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Coverage Number");
            entity.Property(e => e.CurrentClaimOwner)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Current Claim Owner");
            entity.Property(e => e.CustomerContactFrequency)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Customer Contact Frequency");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Birth");
            entity.Property(e => e.DateOfDeath)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Death");
            entity.Property(e => e.DateOfDiagnosis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Diagnosis");
            entity.Property(e => e.DateReturnedToWork)
                .HasColumnType("date")
                .HasColumnName("Date returned to work");
            entity.Property(e => e.Day1AccidentOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Day 1 Accident Option");
            entity.Property(e => e.Decision)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DecisionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Decision Date");
            entity.Property(e => e.DecisionReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Decision Reason");
            entity.Property(e => e.Declined)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExpectedResolutionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Expected Resolution Date");
            entity.Property(e => e.ExpectedReturnToWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Expected Return To Work Date");
            entity.Property(e => e.ExpectedRtwFtRange)
                .IsUnicode(false)
                .HasColumnName("Expected RTW FT Range");
            entity.Property(e => e.ExternalMemberNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("External Member Number");
            entity.Property(e => e.FinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Finalised Date");
            entity.Property(e => e.FinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Finalised Reason");
            entity.Property(e => e.FirstContactDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("First Contact Date");
            entity.Property(e => e.GivenName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Given Name");
            entity.Property(e => e.GroupPlanName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Group Plan Name");
            entity.Property(e => e.GroupPlanNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Group Plan Number");
            entity.Property(e => e.HoursWorkedPerWeek)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Hours Worked Per Week");
            entity.Property(e => e.IncidentOccurredOverseas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Incident Occurred Overseas");
            entity.Property(e => e.IncurredDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Incurred Date");
            entity.Property(e => e.IndexationFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Indexation Flag");
            entity.Property(e => e.InitialSumInsured)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Initial Sum Insured");
            entity.Property(e => e.InitialSumInsuredFreq)
                .IsUnicode(false)
                .HasColumnName("Initial Sum Insured Freq");
            entity.Property(e => e.InitialSumInsuredX12)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Initial Sum Insured x 12");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.MaximumIndexationRate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Maximum Indexation Rate");
            entity.Property(e => e.NonDisclosure)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Non Disclosure");
            entity.Property(e => e.Occupation)
                .HasMaxLength(353)
                .IsUnicode(false);
            entity.Property(e => e.OverrideRiskCategory)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category");
            entity.Property(e => e.OverrideRiskCategoryReason)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category Reason");
            entity.Property(e => e.PartialEarningsIncome)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Partial Earnings Income");
            entity.Property(e => e.PartyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Party Id");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy Number");
            entity.Property(e => e.PostCode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Post Code");
            entity.Property(e => e.PreDisabilityIncome)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Pre-disability Income");
            entity.Property(e => e.PrimaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Code");
            entity.Property(e => e.PrimaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Date");
            entity.Property(e => e.PrimaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Description");
            entity.Property(e => e.PrimaryOccSelfEmployedInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Primary Occ Self Employed Ind");
            entity.Property(e => e.PrimaryOccupationEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation End Date");
            entity.Property(e => e.PrimaryOccupationStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation Start Date");
            entity.Property(e => e.ProductCode)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.QualifyingPeriod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Qualifying Period");
            entity.Property(e => e.ReInsurerName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Re insurer Name");
            entity.Property(e => e.RegistrationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Registration Date");
            entity.Property(e => e.ReinsurancePercent)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Reinsurance Percent");
            entity.Property(e => e.ReinsuranceTreatyType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Reinsurance Treaty Type");
            entity.Property(e => e.RiskCategory)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Risk Category");
            entity.Property(e => e.RiskCommencedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Commenced Date");
            entity.Property(e => e.RiskExpiryDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Expiry Date");
            entity.Property(e => e.SecondaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Code");
            entity.Property(e => e.SecondaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Date");
            entity.Property(e => e.SecondaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Description");
            entity.Property(e => e.Sex)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Source)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.SourceBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Code");
            entity.Property(e => e.SourceBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Description");
            entity.Property(e => e.SourceBenefitSelected)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Source Benefit Selected");
            entity.Property(e => e.SourceBenefitType)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Type");
            entity.Property(e => e.SourceSystem)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Source System");
            entity.Property(e => e.SpecialArrangementDuration)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Special Arrangement Duration");
            entity.Property(e => e.SpecialArrangementFlag)
                .HasColumnType("decimal(1, 0)")
                .HasColumnName("Special Arrangement Flag");
            entity.Property(e => e.State)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.SumInsured)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Sum Insured");
            entity.Property(e => e.SumReInsured)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Sum Re-insured");
            entity.Property(e => e.SuperContributionPercent)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Super Contribution Percent");
            entity.Property(e => e.Surname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TargetBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Code");
            entity.Property(e => e.TargetBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Description");
            entity.Property(e => e.TargetBenefitType)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Type");
            entity.Property(e => e.TpdDefinition)
                .IsUnicode(false)
                .HasColumnName("TPD Definition");
            entity.Property(e => e.TpdSubDefinition)
                .IsUnicode(false)
                .HasColumnName("TPD Sub Definition");
            entity.Property(e => e.TraumaDefinition)
                .IsUnicode(false)
                .HasColumnName("Trauma Definition");
            entity.Property(e => e.UnexpectedCircumstances)
                .IsUnicode(false)
                .HasColumnName("Unexpected Circumstances");
            entity.Property(e => e.UnexpectedCircumstancesApply)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Unexpected Circumstances Apply");
            entity.Property(e => e.UrgentFinancialNeedsFlag)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Urgent Financial Needs Flag");
            entity.Property(e => e.WaitingPeriodAccident)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Accident");
            entity.Property(e => e.WaitingPeriodSickness)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Sickness");
        });

        modelBuilder.Entity<RptClaimbenefitw>(entity =>
        {
            entity.ToTable("RPT_CLAIMBENEFITWS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Accepted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AdmitAdvancePayAndFinalise)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Admit/Advance Pay and Finalise");
            entity.Property(e => e.AdviserSalesId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Adviser Sales ID");
            entity.Property(e => e.AgeAtIncurredDate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Age At Incurred Date");
            entity.Property(e => e.AgreedValue)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Agreed Value");
            entity.Property(e => e.AssessedUnderLimitedCover)
                .HasColumnType("decimal(1, 0)")
                .HasColumnName("Assessed Under Limited Cover");
            entity.Property(e => e.BenefitCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Creation Date");
            entity.Property(e => e.BenefitEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit End Date");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.BenefitPeriodAccident)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Accident");
            entity.Property(e => e.BenefitPeriodSickness)
                .IsUnicode(false)
                .HasColumnName("Benefit Period Sickness");
            entity.Property(e => e.BenefitReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Date");
            entity.Property(e => e.BenefitReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Reopen Reason");
            entity.Property(e => e.BenefitStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benefit Start Date");
            entity.Property(e => e.BenefitStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Status");
            entity.Property(e => e.CalculationEndType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation End Type");
            entity.Property(e => e.CalculationStartType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Calculation Start Type");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.CeasedWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ceased Work Date");
            entity.Property(e => e.ChronicConditionOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Chronic Condition Option");
            entity.Property(e => e.ClaimEventType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Claim Event Type");
            entity.Property(e => e.ClaimFinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Date");
            entity.Property(e => e.ClaimFinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Finalised Reason");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimReceivedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Received Date");
            entity.Property(e => e.ClaimReopenDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Date");
            entity.Property(e => e.ClaimReopenReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Reopen Reason");
            entity.Property(e => e.ClaimStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Status");
            entity.Property(e => e.ClaimTeam)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Claim Team");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClassOfBusiness)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.CmpRequired)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CMP Required");
            entity.Property(e => e.ConcurrentClaimIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Concurrent Claim Indicator");
            entity.Property(e => e.ConcurrentClaimNumbers)
                .IsUnicode(false)
                .HasColumnName("Concurrent Claim Numbers");
            entity.Property(e => e.ContractEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract End Date");
            entity.Property(e => e.ContractStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contract Start Date");
            entity.Property(e => e.ContractStatus)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Contract Status");
            entity.Property(e => e.CountryOfIncident)
                .IsUnicode(false)
                .HasColumnName("Country of Incident");
            entity.Property(e => e.CoverageNumber)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Coverage Number");
            entity.Property(e => e.CurrentClaimOwner)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Current Claim Owner");
            entity.Property(e => e.CustomerContactFrequency)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Customer Contact Frequency");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Birth");
            entity.Property(e => e.DateOfDeath)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Death");
            entity.Property(e => e.DateOfDiagnosis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Diagnosis");
            entity.Property(e => e.DateReturnedToWork)
                .HasColumnType("date")
                .HasColumnName("Date returned to work");
            entity.Property(e => e.Day1AccidentOption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Day 1 Accident Option");
            entity.Property(e => e.Decision)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DecisionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Decision Date");
            entity.Property(e => e.DecisionReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Decision Reason");
            entity.Property(e => e.Declined)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.EndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("End Date");
            entity.Property(e => e.ExpectedResolutionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Expected Resolution Date");
            entity.Property(e => e.ExpectedReturnToWorkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Expected Return To Work Date");
            entity.Property(e => e.ExpectedRtwFtRange)
                .IsUnicode(false)
                .HasColumnName("Expected RTW FT Range");
            entity.Property(e => e.ExternalMemberNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("External Member Number");
            entity.Property(e => e.FinalisedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Finalised Date");
            entity.Property(e => e.FinalisedReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Finalised Reason");
            entity.Property(e => e.FirstContactDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("First Contact Date");
            entity.Property(e => e.GivenName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Given Name");
            entity.Property(e => e.GroupPlanName)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Group Plan Name");
            entity.Property(e => e.GroupPlanNumber)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Group Plan Number");
            entity.Property(e => e.HoursWorkedPerWeek)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Hours Worked Per Week");
            entity.Property(e => e.IarCode)
                .IsUnicode(false)
                .HasColumnName("IAR Code");
            entity.Property(e => e.IarDescription)
                .IsUnicode(false)
                .HasColumnName("IAR Description");
            entity.Property(e => e.IncidentOccurredOverseas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Incident Occurred Overseas");
            entity.Property(e => e.IncurredDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Incurred Date");
            entity.Property(e => e.IndexationFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Indexation Flag");
            entity.Property(e => e.InitialSumInsured)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Initial Sum Insured");
            entity.Property(e => e.InitialSumInsuredFreq)
                .IsUnicode(false)
                .HasColumnName("Initial Sum Insured Freq");
            entity.Property(e => e.InitialSumInsuredX12)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Initial Sum Insured x 12");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.MaximumIndexationRate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Maximum Indexation Rate");
            entity.Property(e => e.NonDisclosure)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Non Disclosure");
            entity.Property(e => e.Occupation)
                .HasMaxLength(353)
                .IsUnicode(false);
            entity.Property(e => e.OverrideRiskCategory)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category");
            entity.Property(e => e.OverrideRiskCategoryReason)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category Reason");
            entity.Property(e => e.PartialCapacity)
                .IsUnicode(false)
                .HasColumnName("Partial Capacity");
            entity.Property(e => e.PartialEarningsIncome)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Partial Earnings Income");
            entity.Property(e => e.PartyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Party Id");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy Number");
            entity.Property(e => e.PostCode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Post Code");
            entity.Property(e => e.PreDisabilityIncome)
                .HasColumnType("decimal(28, 6)")
                .HasColumnName("Pre-disability Income");
            entity.Property(e => e.PrimaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Code");
            entity.Property(e => e.PrimaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Date");
            entity.Property(e => e.PrimaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Primary Cause Description");
            entity.Property(e => e.PrimaryOccSelfEmployedInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Primary Occ Self Employed Ind");
            entity.Property(e => e.PrimaryOccupationEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation End Date");
            entity.Property(e => e.PrimaryOccupationStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Primary Occupation Start Date");
            entity.Property(e => e.ProductCode)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.QualifyingPeriod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Qualifying Period");
            entity.Property(e => e.ReInsurerName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Re insurer Name");
            entity.Property(e => e.RegistrationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Registration Date");
            entity.Property(e => e.ReinsurancePercent)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Reinsurance Percent");
            entity.Property(e => e.ReinsuranceTreatyType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Reinsurance Treaty Type");
            entity.Property(e => e.RiskCategory)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Risk Category");
            entity.Property(e => e.RiskCommencedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Commenced Date");
            entity.Property(e => e.RiskExpiryDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Risk Expiry Date");
            entity.Property(e => e.SecondaryCauseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Code");
            entity.Property(e => e.SecondaryCauseDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Date");
            entity.Property(e => e.SecondaryCauseDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Secondary Cause Description");
            entity.Property(e => e.Sex)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Source)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.SourceBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Code");
            entity.Property(e => e.SourceBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Description");
            entity.Property(e => e.SourceBenefitSelected)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Source Benefit Selected");
            entity.Property(e => e.SourceBenefitType)
                .IsUnicode(false)
                .HasColumnName("Source Benefit Type");
            entity.Property(e => e.SourceSystem)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Source System");
            entity.Property(e => e.SpecialArrangementDuration)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Special Arrangement Duration");
            entity.Property(e => e.SpecialArrangementFlag)
                .HasColumnType("decimal(1, 0)")
                .HasColumnName("Special Arrangement Flag");
            entity.Property(e => e.StartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Start Date");
            entity.Property(e => e.State)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.SumInsured)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Sum Insured");
            entity.Property(e => e.SumReInsured)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Sum Re-insured");
            entity.Property(e => e.SuperContributionPercent)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Super Contribution Percent");
            entity.Property(e => e.Surname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TargetBenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Code");
            entity.Property(e => e.TargetBenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Description");
            entity.Property(e => e.TargetBenefitType)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Type");
            entity.Property(e => e.TpdDefinition)
                .IsUnicode(false)
                .HasColumnName("TPD Definition");
            entity.Property(e => e.TpdSubDefinition)
                .IsUnicode(false)
                .HasColumnName("TPD Sub Definition");
            entity.Property(e => e.TraumaDefinition)
                .IsUnicode(false)
                .HasColumnName("Trauma Definition");
            entity.Property(e => e.UnexpectedCircumstances)
                .IsUnicode(false)
                .HasColumnName("Unexpected Circumstances");
            entity.Property(e => e.UnexpectedCircumstancesApply)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Unexpected Circumstances Apply");
            entity.Property(e => e.UrgentFinancialNeedsFlag)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Urgent Financial Needs Flag");
            entity.Property(e => e.WaitingPeriodAccident)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Accident");
            entity.Property(e => e.WaitingPeriodSickness)
                .HasMaxLength(441)
                .IsUnicode(false)
                .HasColumnName("Waiting Period Sickness");
            entity.Property(e => e.WorkStatusType)
                .IsUnicode(false)
                .HasColumnName("Work Status Type");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptClaimcasedecipha>(entity =>
        {
            entity.ToTable("RPT_CLAIMCASEDECIPHA");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimsTeamDepartment)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Claims Team Department");
            entity.Property(e => e.CustomerFirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Customer First Name");
            entity.Property(e => e.CustomerLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Customer Last Name");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy Number");
            entity.Property(e => e.PostCode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Post Code");
            entity.Property(e => e.State)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RptClaimexpense>(entity =>
        {
            entity.ToTable("RPT_CLAIMEXPENSES");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AdminInitials)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Admin Initials");
            entity.Property(e => e.AmountIncGst)
                .HasColumnType("numeric(28, 6)")
                .HasColumnName("Amount (inc GST ) ($)");
            entity.Property(e => e.AuthorisationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Authorisation Date");
            entity.Property(e => e.AuthorisedBy)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Authorised By");
            entity.Property(e => e.BenefitCode)
                .HasMaxLength(26)
                .IsUnicode(false)
                .HasColumnName("Benefit Code");
            entity.Property(e => e.ClaimExpenseGuid)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Claim Expense GUID");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClassOfBusiness)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.Gst)
                .HasColumnType("numeric(28, 6)")
                .HasColumnName("GST($)");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Invoice Number");
            entity.Property(e => e.InvoiceType)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Invoice Type");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.Payee)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.PaymentCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Payment Creation Date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Payment Method");
            entity.Property(e => e.PaymentReference)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Payment Reference");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Policy Number");
            entity.Property(e => e.ProductCode)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.TargetBenefitType)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Type");
            entity.Property(e => e.VendorId)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Vendor Id");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptClaimparticipant>(entity =>
        {
            entity.ToTable("RPT_CLAIMPARTICIPANT");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.AddressType)
                .IsUnicode(false)
                .HasColumnName("Address Type");
            entity.Property(e => e.BusinessAreaCode)
                .IsUnicode(false)
                .HasColumnName("Business Area Code");
            entity.Property(e => e.BusinessExtension)
                .IsUnicode(false)
                .HasColumnName("Business Extension");
            entity.Property(e => e.BusinessInternationalCode)
                .IsUnicode(false)
                .HasColumnName("Business International Code");
            entity.Property(e => e.BusinessPhone)
                .IsUnicode(false)
                .HasColumnName("Business Phone");
            entity.Property(e => e.ClaimNumber)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimStatus)
                .IsUnicode(false)
                .HasColumnName("Claim Status");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.FaxAreaCode)
                .IsUnicode(false)
                .HasColumnName("Fax Area Code");
            entity.Property(e => e.FaxExtension)
                .IsUnicode(false)
                .HasColumnName("Fax Extension");
            entity.Property(e => e.FaxInternationalCode)
                .IsUnicode(false)
                .HasColumnName("Fax International Code");
            entity.Property(e => e.FaxPhone)
                .IsUnicode(false)
                .HasColumnName("Fax Phone");
            entity.Property(e => e.Hva)
                .IsUnicode(false)
                .HasColumnName("HVA");
            entity.Property(e => e.LumpsumIpIndicator)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.MobileAreaCode)
                .IsUnicode(false)
                .HasColumnName("Mobile Area Code");
            entity.Property(e => e.MobileExtension)
                .IsUnicode(false)
                .HasColumnName("Mobile Extension");
            entity.Property(e => e.MobileInternationalCode)
                .IsUnicode(false)
                .HasColumnName("Mobile International Code");
            entity.Property(e => e.MobilePhone)
                .IsUnicode(false)
                .HasColumnName("Mobile Phone");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.ParticipantEffectiveDate)
                .IsUnicode(false)
                .HasColumnName("Participant Effective Date");
            entity.Property(e => e.PersonOrganisation)
                .IsUnicode(false)
                .HasColumnName("Person/Organisation");
            entity.Property(e => e.PostCode)
                .IsUnicode(false)
                .HasColumnName("Post Code");
            entity.Property(e => e.ResidentialAreaCode)
                .IsUnicode(false)
                .HasColumnName("Residential Area Code");
            entity.Property(e => e.ResidentialExtension)
                .IsUnicode(false)
                .HasColumnName("Residential Extension");
            entity.Property(e => e.ResidentialInternationalCode)
                .IsUnicode(false)
                .HasColumnName("Residential International Code");
            entity.Property(e => e.ResidentialPhone)
                .IsUnicode(false)
                .HasColumnName("Residential Phone");
            entity.Property(e => e.State).IsUnicode(false);
            entity.Property(e => e.Suburb).IsUnicode(false);
            entity.Property(e => e.TypeOfParticipant)
                .IsUnicode(false)
                .HasColumnName("Type of Participant");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptClosedtaskreport>(entity =>
        {
            entity.ToTable("RPT_CLOSEDTASKREPORT");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BenchmarkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benchmark Date");
            entity.Property(e => e.BenchmarkDays)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("Benchmark Days");
            entity.Property(e => e.BenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Benefit Code");
            entity.Property(e => e.BenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Benefit Description");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.CaseManager)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Case Manager");
            entity.Property(e => e.CaseStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Case Status");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Claim Team");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClaimantName)
                .HasMaxLength(401)
                .IsUnicode(false)
                .HasColumnName("Claimant Name");
            entity.Property(e => e.ClassOfBusiness)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.OriginalTaskTargetDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Original Task Target Date");
            entity.Property(e => e.ProductCode)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.TargetBenefitType)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Type");
            entity.Property(e => e.TaskAssignedToRole)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Assigned To Role");
            entity.Property(e => e.TaskAssignedToUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Assigned To User");
            entity.Property(e => e.TaskCode)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Task Code");
            entity.Property(e => e.TaskCompletedByTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Task Completed By Team");
            entity.Property(e => e.TaskCompletedByUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Completed By User");
            entity.Property(e => e.TaskCompletedDate)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("Task Completed Date");
            entity.Property(e => e.TaskCreatedByTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Task Created By Team");
            entity.Property(e => e.TaskCreatedByUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Created By User");
            entity.Property(e => e.TaskCreatedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Task Created Date");
            entity.Property(e => e.TaskDescription)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Task Description");
            entity.Property(e => e.TaskId)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Task Id");
            entity.Property(e => e.TaskName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Name");
            entity.Property(e => e.TaskProcessStep)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Process Step");
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Task Status");
            entity.Property(e => e.TaskTeamQueue)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Team Queue");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptCmpaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CMPACTIONS");

            entity.ToTable("RPT_CMPACTIONS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ActionLastUpdated)
                .HasColumnType("date")
                .HasColumnName("Action Last Updated");
            entity.Property(e => e.ActionName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Action Name");
            entity.Property(e => e.ActionOutcome)
                .IsUnicode(false)
                .HasColumnName("Action Outcome");
            entity.Property(e => e.ActionOutcomeDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Action Outcome Date");
            entity.Property(e => e.ActionOutcomeReason)
                .IsUnicode(false)
                .HasColumnName("Action Outcome Reason");
            entity.Property(e => e.ActionOwner)
                .HasMaxLength(152)
                .IsUnicode(false)
                .HasColumnName("Action Owner");
            entity.Property(e => e.ActionOwnerTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Action Owner Team");
            entity.Property(e => e.ActionOwnerType)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Action Owner Type");
            entity.Property(e => e.ActionStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Action Start Date");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.CmpGoalDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CMP Goal Date");
            entity.Property(e => e.CmpStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CMP Status");
            entity.Property(e => e.CommenceDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Commence Date");
            entity.Property(e => e.DocumentUploadDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Document Upload Date");
            entity.Property(e => e.FactorDescription)
                .IsUnicode(false)
                .HasColumnName("Factor Description");
            entity.Property(e => e.FactorName)
                .IsUnicode(false)
                .HasColumnName("Factor Name");
            entity.Property(e => e.FactorStatus)
                .IsUnicode(false)
                .HasColumnName("Factor Status");
            entity.Property(e => e.Factors).IsUnicode(false);
            entity.Property(e => e.GoalCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Goal Creation Date");
            entity.Property(e => e.GoalDescription)
                .IsUnicode(false)
                .HasColumnName("Goal Description");
            entity.Property(e => e.GoalName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Goal Name");
            entity.Property(e => e.GoalOutcome)
                .IsUnicode(false)
                .HasColumnName("Goal Outcome");
            entity.Property(e => e.GoalOutcomeDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Goal Outcome Date");
            entity.Property(e => e.GoalReason)
                .IsUnicode(false)
                .HasColumnName("Goal Reason");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.PlanCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Plan Creation Date");
            entity.Property(e => e.PlanName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Plan Name");
            entity.Property(e => e.PlanNotes)
                .IsUnicode(false)
                .HasColumnName("Plan Notes");
            entity.Property(e => e.PlanStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Plan Status");
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Service Code");
            entity.Property(e => e.ServiceCreator)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Service Creator");
            entity.Property(e => e.ServiceDescription)
                .HasMaxLength(1600)
                .IsUnicode(false)
                .HasColumnName("Service Description");
            entity.Property(e => e.ServiceEndDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Service End Date");
            entity.Property(e => e.ServiceNotes)
                .IsUnicode(false)
                .HasColumnName("Service Notes");
            entity.Property(e => e.ServicePractitioner)
                .HasMaxLength(152)
                .IsUnicode(false)
                .HasColumnName("Service Practitioner");
            entity.Property(e => e.ServiceStartDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Service Start Date");
            entity.Property(e => e.StrategyCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Strategy Creation Date");
            entity.Property(e => e.StrategyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Strategy Name");
            entity.Property(e => e.StrategyOutcome)
                .IsUnicode(false)
                .HasColumnName("Strategy Outcome");
            entity.Property(e => e.StrategyOutcomeDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Strategy Outcome Date");
            entity.Property(e => e.StrategyTargetDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Strategy Target Date");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptCmpgoaldatemovement>(entity =>
        {
            entity.ToTable("RPT_CMPGOALDATEMOVEMENTS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.CmpGoalCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CMP Goal Creation Date");
            entity.Property(e => e.CmpGoalDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CMP Goal Date");
            entity.Property(e => e.CmpGoalUpdatedByUserName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CMP Goal Updated by User Name");
            entity.Property(e => e.CmpGoalUpdatedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CMP Goal Updated Date");
            entity.Property(e => e.CmpStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CMP Status");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.PlanCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Plan Creation Date");
            entity.Property(e => e.PlanName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Plan Name");
        });

        modelBuilder.Entity<RptCmpplanstatus>(entity =>
        {
            entity.ToTable("RPT_CMPPLANSTATUS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.CmpGoalDate)
                .IsUnicode(false)
                .HasColumnName("CMP Goal Date");
            entity.Property(e => e.CmpStatus)
                .IsUnicode(false)
                .HasColumnName("CMP Status");
            entity.Property(e => e.LumpsumIpIndicator)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.PlanCreationDate)
                .IsUnicode(false)
                .HasColumnName("Plan Creation Date");
            entity.Property(e => e.PlanName)
                .IsUnicode(false)
                .HasColumnName("Plan Name");
            entity.Property(e => e.PlanNotes)
                .IsUnicode(false)
                .HasColumnName("Plan Notes");
            entity.Property(e => e.PlanStatus)
                .IsUnicode(false)
                .HasColumnName("Plan Status");
            entity.Property(e => e.PlanStatusDate)
                .IsUnicode(false)
                .HasColumnName("Plan Status Date");
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Service Code");
            entity.Property(e => e.ServiceCreator)
                .IsUnicode(false)
                .HasColumnName("Service Creator");
            entity.Property(e => e.ServiceDescription)
                .IsUnicode(false)
                .HasColumnName("Service Description");
            entity.Property(e => e.ServiceEndDate)
                .IsUnicode(false)
                .HasColumnName("Service End Date");
            entity.Property(e => e.ServiceStartDate)
                .IsUnicode(false)
                .HasColumnName("Service Start Date");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptCmpservice>(entity =>
        {
            entity.ToTable("RPT_CMPSERVICES");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.CmpGoalDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CMP Goal Date");
            entity.Property(e => e.CmpStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CMP Status");
            entity.Property(e => e.GoalCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Goal Creation Date");
            entity.Property(e => e.GoalDescription)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Goal Description");
            entity.Property(e => e.GoalName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Goal Name");
            entity.Property(e => e.GoalOutcome)
                .IsUnicode(false)
                .HasColumnName("Goal Outcome");
            entity.Property(e => e.GoalOutcomeDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Goal Outcome Date");
            entity.Property(e => e.GoalReason)
                .IsUnicode(false)
                .HasColumnName("Goal Reason");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.PlanCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Plan Creation Date");
            entity.Property(e => e.PlanName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Plan Name");
            entity.Property(e => e.PlanNotes)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Plan Notes");
            entity.Property(e => e.PlanStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Plan Status");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptCompliant>(entity =>
        {
            entity.ToTable("RPT_COMPLIANTS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AcknowLetterSlaMetYN)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Acknow. Letter SLA Met? Y/N");
            entity.Property(e => e.BenefitStatus1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Status1");
            entity.Property(e => e.BenefitStatus2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Status2");
            entity.Property(e => e.BenefitStatus3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Status3");
            entity.Property(e => e.BenefitStatus4)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Benefit Status4");
            entity.Property(e => e.BenefitType1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Benefit Type1");
            entity.Property(e => e.BenefitType2)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Benefit Type2");
            entity.Property(e => e.BenefitType3)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Benefit Type3");
            entity.Property(e => e.BenefitType4)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Benefit Type4");
            entity.Property(e => e.CatEscalationApproved)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CAT Escalation Approved?");
            entity.Property(e => e.CatEscalationDeclined)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CAT Escalation Declined?");
            entity.Property(e => e.ClaimNo)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim No.");
            entity.Property(e => e.ClaimStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Claim Status");
            entity.Property(e => e.ClassOfBusiness)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.ClosureDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Closure Date");
            entity.Property(e => e.ClosureReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Closure Reason");
            entity.Property(e => e.ComplaintIdNo)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Complaint ID No.");
            entity.Property(e => e.ComplaintNotificationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Complaint Notification Date");
            entity.Property(e => e.ComplaintOwner)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Complaint Owner");
            entity.Property(e => e.ComplaintRecordTeamName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Complaint Record Team Name");
            entity.Property(e => e.ComplaintSource1)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Complaint Source1");
            entity.Property(e => e.ComplaintSource2)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Complaint Source2");
            entity.Property(e => e.ComplaintSource3)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Complaint Source3");
            entity.Property(e => e.ComplaintStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Complaint Status");
            entity.Property(e => e.ComplaintTheme1)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Complaint Theme1");
            entity.Property(e => e.ComplaintTheme2)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Complaint Theme2");
            entity.Property(e => e.ComplaintTheme3)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Complaint Theme3");
            entity.Property(e => e.ComplaintTheme4)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Complaint Theme4");
            entity.Property(e => e.ComplaintTheme5)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Complaint Theme5");
            entity.Property(e => e.ComplaintType)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Complaint Type");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Birth");
            entity.Property(e => e.DaysToSendAcknowLetter).HasColumnName("Days to send Acknow. Letter");
            entity.Property(e => e.DaysToSendNonSuperLetter).HasColumnName("Days to send Non Super Letter");
            entity.Property(e => e.DaysToSendSuperLetter).HasColumnName("Days to send Super Letter");
            entity.Property(e => e.DaysToSendTrusteeLetter).HasColumnName("Days to send Trustee Letter");
            entity.Property(e => e.EscalationApprovedByTm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Escalation Approved by TM?");
            entity.Property(e => e.EscalationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Escalation Date");
            entity.Property(e => e.EscalationDeclinedByTm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Escalation Declined by TM?");
            entity.Property(e => e.EscalationToCat)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Escalation to CAT?");
            entity.Property(e => e.EscalationToTm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Escalation to TM?");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.GroupRetail1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Group/Retail1");
            entity.Property(e => e.GroupRetail2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Group/Retail2");
            entity.Property(e => e.GroupRetail3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Group/Retail3");
            entity.Property(e => e.GroupRetail4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Group/Retail4");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last Name");
            entity.Property(e => e.LetterToTrusteeSlaMetYN)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Letter to Trustee SLA Met? Y/N");
            entity.Property(e => e.Method1)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Method2)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Method3)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.NoOfDaysComplaintOpen)
                .HasColumnType("numeric(38, 0)")
                .HasColumnName("No. of Days Complaint Open");
            entity.Property(e => e.NonSuperLetterSlaMetYN)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Non Super Letter SLA Met? Y/N");
            entity.Property(e => e.PolicyNo1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy No1");
            entity.Property(e => e.PolicyNo2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy No2");
            entity.Property(e => e.PolicyNo3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy No3");
            entity.Property(e => e.PolicyNo4)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy No4");
            entity.Property(e => e.RaisedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Raised By");
            entity.Property(e => e.SuperLetterSlaMetYN)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Super Letter SLA Met? Y/N");
            entity.Property(e => e.TmOfClaimCaseOwner)
                .IsUnicode(false)
                .HasColumnName("TM of claim case owner");
            entity.Property(e => e.TmOfComplaintRecordOwner)
                .IsUnicode(false)
                .HasColumnName("TM of complaint record owner");
        });

        modelBuilder.Entity<RptDocumentreport>(entity =>
        {
            entity.ToTable("RPT_DOCUMENTREPORT");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.CaseNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Case Number");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Created By");
            entity.Property(e => e.DateCreatedInAble)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date Created in ABLE");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.DocumentId)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Document ID");
            entity.Property(e => e.DocumentType)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Document Type");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Last Updated By");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.StaffInd).HasColumnType("int");
            entity.Property(e => e.ApplicationId)
            .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<RptEnquirycasereport>(entity =>
        {
            entity.ToTable("RPT_ENQUIRYCASEREPORT");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CaseManager)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Case Manager");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.CommencementDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Commencement Date");
            entity.Property(e => e.ContactDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contact Date");
            entity.Property(e => e.ContractStatus)
                .IsUnicode(false)
                .HasColumnName("Contract Status");
            entity.Property(e => e.CreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Creation Date");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date Of Birth");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.EnquiryCaseStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Enquiry Case Status");
            entity.Property(e => e.EnquiryNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Enquiry Number");
            entity.Property(e => e.GivenName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Given Name");
            entity.Property(e => e.IfOther)
                .HasMaxLength(1600)
                .IsUnicode(false)
                .HasColumnName("If Other");
            entity.Property(e => e.IncurredDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Incurred Date");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.NatureOfIllnessOrInjury)
                .IsUnicode(false)
                .HasColumnName("Nature of Illness or Injury");
            entity.Property(e => e.NatureOfIncident)
                .IsUnicode(false)
                .HasColumnName("Nature of Incident");
            entity.Property(e => e.Notifier)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy Number");
            entity.Property(e => e.PostCode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Post Code");
            entity.Property(e => e.Product)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Source)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Team)
                .HasMaxLength(120)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RptHcrcompletednote>(entity =>
        {
            entity.ToTable("RPT_HCRCOMPLETEDNOTES");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.DateCreated)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date Created");
            entity.Property(e => e.DateOfStatusChange)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Status Change");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.NoteType)
                .HasMaxLength(29)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Note Type");
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptOpentask>(entity =>
        {
            entity.ToTable("RPT_OPENTASK");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BenchmarkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benchmark Date");
            entity.Property(e => e.BenchmarkDays)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("Benchmark Days");
            entity.Property(e => e.BenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Benefit Code");
            entity.Property(e => e.BenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Benefit Description");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.CaseManager)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Case Manager");
            entity.Property(e => e.CaseStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Case Status");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Claim Team");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClaimantName)
                .HasMaxLength(401)
                .IsUnicode(false)
                .HasColumnName("Claimant Name");
            entity.Property(e => e.ClassOfBusiness)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.OriginalTaskTargetDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Original Task Target Date");
            entity.Property(e => e.ProductCode)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.TargetBenefitType)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Type");
            entity.Property(e => e.TaskAssignedToRole)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Assigned To Role");
            entity.Property(e => e.TaskAssignedToUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Assigned To User");
            entity.Property(e => e.TaskCode)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Task Code");
            entity.Property(e => e.TaskCompletedByTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Task Completed By Team");
            entity.Property(e => e.TaskCompletedByUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Completed By User");
            entity.Property(e => e.TaskCompletedDate)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("Task Completed Date");
            entity.Property(e => e.TaskCreatedByTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Task Created By Team");
            entity.Property(e => e.TaskCreatedByUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Created By User");
            entity.Property(e => e.TaskCreatedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Task Created Date");
            entity.Property(e => e.TaskDescription)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Task Description");
            entity.Property(e => e.TaskId)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Task Id");
            entity.Property(e => e.TaskName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Name");
            entity.Property(e => e.TaskProcessStep)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Process Step");
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Task Status");
            entity.Property(e => e.TaskTeamQueue)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Team Queue");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptOverrideriskreport>(entity =>
        {
            entity.ToTable("RPT_OVERRIDERISKREPORT");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.LumpsumIpIndicator)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.OverrideProcessedBy)
                .IsUnicode(false)
                .HasColumnName("Override Processed By");
            entity.Property(e => e.OverrideRiskCategory)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category");
            entity.Property(e => e.OverrideRiskCategoryReason)
                .IsUnicode(false)
                .HasColumnName("Override Risk Category Reason");
            entity.Property(e => e.RiskCategory)
                .IsUnicode(false)
                .HasColumnName("Risk Category");
            entity.Property(e => e.RiskCategoryCreationDate)
                .IsUnicode(false)
                .HasColumnName("Risk Category Creation Date");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptPaymentsummaryl>(entity =>
        {
            entity.ToTable("RPT_PAYMENTSUMMARYLS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AcceptFrom)
                .HasColumnType("date")
                .HasColumnName("Accept From");
            entity.Property(e => e.AdminDeletePolicyYN)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Admin Delete Policy (Y/N)");
            entity.Property(e => e.AdminDeleteProcDate)
                .HasColumnType("date")
                .HasColumnName("Admin Delete Proc Date");
            entity.Property(e => e.AdminReqdWdrawal)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Admin Reqd Wdrawal");
            entity.Property(e => e.AuthoriseDate)
                .HasColumnType("date")
                .HasColumnName("Authorise Date");
            entity.Property(e => e.BenefitAmtCalc)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Benefit amt calc");
            entity.Property(e => e.BenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Benefit Code");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.BenefitPayable)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Benefit Payable(+)");
            entity.Property(e => e.BenefitType)
                .IsUnicode(false)
                .HasColumnName("Benefit Type");
            entity.Property(e => e.Bonus)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Bonus (+$)");
            entity.Property(e => e.BuyBackOption)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Buy Back Option");
            entity.Property(e => e.BuyBackOptionEffDate)
                .HasColumnType("date")
                .HasColumnName("Buy back option Eff Date");
            entity.Property(e => e.CaldNetAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Cald Net Amount");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClaimTypeIpLs)
                .IsUnicode(false)
                .HasColumnName("Claim Type IP LS");
            entity.Property(e => e.ClassOfBusiness)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.ConcurrentClaimYN)
                .HasColumnType("decimal(1, 0)")
                .HasColumnName("Concurrent Claim (Y/N)");
            entity.Property(e => e.DateCeasedWork)
                .HasColumnType("date")
                .HasColumnName("Date Ceased Work");
            entity.Property(e => e.DelinkedPolicyDetails)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Delinked Policy Details");
            entity.Property(e => e.EFormId)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("e-Form ID");
            entity.Property(e => e.FinancialPlanningBftAmt)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Financial Planning Bft Amt");
            entity.Property(e => e.FinancialPlanningBftYN)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Financial Planning Bft (Y/N)");
            entity.Property(e => e.ForGroupPayee)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("For Group, Payee");
            entity.Property(e => e.GroupOrRetail)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Group or Retail");
            entity.Property(e => e.IncurredDate)
                .HasColumnType("date")
                .HasColumnName("Incurred Date");
            entity.Property(e => e.InvestmentAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Investment Amount  (+$) ");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("date")
                .HasColumnName("Last Update Date");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.OtherAdminInfo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Other Admin Info");
            entity.Property(e => e.OtherNonTaxable)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Other (Non Taxable) (+$)");
            entity.Property(e => e.OtherPaymentInfo)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Other Payment Info");
            entity.Property(e => e.OtherTaxable)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Other (Taxable)  (+$)");
            entity.Property(e => e.PartialWdrawalTferAmt)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Partial Wdrawal Tfer Amt");
            entity.Property(e => e.PartialWdrwlTferReq)
                .HasColumnType("decimal(1, 0)")
                .HasColumnName("Partial Wdrwl/Tfer Req");
            entity.Property(e => e.PaymentAddtnlInfo)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Payment Addtnl Info");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Payment Method");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Payment Type");
            entity.Property(e => e.PolicyDelinkedYN)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Policy Delinked (Y/N)");
            entity.Property(e => e.PolicyType)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Policy Type");
            entity.Property(e => e.PremRefundReqdYN)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Prem Refund Reqd (Y/N)");
            entity.Property(e => e.ProcessDate)
                .HasColumnType("date")
                .HasColumnName("Process date");
            entity.Property(e => e.ProductCode)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.RemaingCoverYN)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Remaing Cover (Y/N)");
            entity.Property(e => e.TaxDollar)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Tax Dollar (-$)");
            entity.Property(e => e.TaxValue)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Tax Value (-$)");
            entity.Property(e => e.TotalGrossAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TOTAL Gross Amount");
            entity.Property(e => e.TotalNetAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TOTAL Net Amount (+)");
            entity.Property(e => e.TrmaReinstmntApplYN)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Trma Reinstmnt Appl (Y/N)");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptPhoneenquiry>(entity =>
        {
            entity.ToTable("RPT_PHONEENQUIRY");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClaimantName)
                .HasMaxLength(410)
                .IsUnicode(false)
                .HasColumnName("Claimant Name");
            entity.Property(e => e.ContactDescription)
                .IsUnicode(false)
                .HasColumnName("Contact Description");
            entity.Property(e => e.ContactMadeIndicator)
                .IsUnicode(false)
                .HasColumnName("Contact Made Indicator");
            entity.Property(e => e.ContactName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contact Name");
            entity.Property(e => e.DateOfContact)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date Of Contact");
            entity.Property(e => e.Decision)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DecisionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Decision Date");
            entity.Property(e => e.DecisionReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Decision Reason");
            entity.Property(e => e.DirectionOfContact)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Direction Of Contact");
            entity.Property(e => e.DurationOfContact)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("Duration Of Contact");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.MethodOfContact)
                .IsUnicode(false)
                .HasColumnName("Method Of Contact");
            entity.Property(e => e.PhoneRecordingLink)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Phone Recording Link");
            entity.Property(e => e.ReasonForContact)
                .IsUnicode(false)
                .HasColumnName("Reason For Contact");
            entity.Property(e => e.UserName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("User Name");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptRecoveryrehabnote>(entity =>
        {
            entity.ToTable("RPT_RECOVERYREHABNOTES");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.DateCreated)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date Created");
            entity.Property(e => e.DateOfStatusChange)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Date of Status Change");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.NoteType)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Note Type");
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<RptTaskreportgroup>(entity =>
        {
            entity.ToTable("RPT_TASKREPORTGROUP");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BenchmarkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benchmark Date");
            entity.Property(e => e.BenchmarkDays)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("Benchmark Days");
            entity.Property(e => e.BenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Benefit Code");
            entity.Property(e => e.BenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Benefit Description");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.CaseManager)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Case Manager");
            entity.Property(e => e.CaseStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Case Status");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Claim Team");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClaimantName)
                .HasMaxLength(401)
                .IsUnicode(false)
                .HasColumnName("Claimant Name");
            entity.Property(e => e.ClassOfBusiness)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.OriginalTaskTargetDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Original Task Target Date");
            entity.Property(e => e.ProductCode)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.TargetBenefitType)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Type");
            entity.Property(e => e.TaskAssignedToRole)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Assigned To Role");
            entity.Property(e => e.TaskAssignedToUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Assigned To User");
            entity.Property(e => e.TaskCode)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Task Code");
            entity.Property(e => e.TaskCompletedByTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Task Completed By Team");
            entity.Property(e => e.TaskCompletedByUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Completed By User");
            entity.Property(e => e.TaskCompletedDate)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("Task Completed Date");
            entity.Property(e => e.TaskCreatedByTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Task Created By Team");
            entity.Property(e => e.TaskCreatedByUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Created By User");
            entity.Property(e => e.TaskCreatedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Task Created Date");
            entity.Property(e => e.TaskDescription)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Task Description");
            entity.Property(e => e.TaskId)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Task Id");
            entity.Property(e => e.TaskName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Name");
            entity.Property(e => e.TaskProcessStep)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Process Step");
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Task Status");
            entity.Property(e => e.StaffInd).HasColumnType("int");

        });

        modelBuilder.Entity<RptTaskreportreinsurance>(entity =>
        {
            entity.ToTable("RPT_TASKREPORTREINSURANCE");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BenchmarkDate)
                .IsUnicode(false)
                .HasColumnName("Benchmark Date");
            entity.Property(e => e.BenchmarkDays)
                .IsUnicode(false)
                .HasColumnName("Benchmark Days");
            entity.Property(e => e.BenefitCode)
                .IsUnicode(false)
                .HasColumnName("Benefit Code");
            entity.Property(e => e.BenefitDescription)
                .IsUnicode(false)
                .HasColumnName("Benefit Description");
            entity.Property(e => e.BenefitNumber)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.CaseManager)
                .IsUnicode(false)
                .HasColumnName("Case Manager");
            entity.Property(e => e.CaseStatus)
                .IsUnicode(false)
                .HasColumnName("Case Status");
            entity.Property(e => e.CaseType)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.ClaimNumber)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimTeam)
                .IsUnicode(false)
                .HasColumnName("Claim Team");
            entity.Property(e => e.ClaimType)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClaimantName)
                .IsUnicode(false)
                .HasColumnName("Claimant Name");
            entity.Property(e => e.ClassOfBusiness)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.LumpsumIpIndicator)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.OriginalTaskTargetDate)
                .IsUnicode(false)
                .HasColumnName("Original Task Target Date");
            entity.Property(e => e.ProductCode)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.ProductName)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.TargetBenefitType)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Type");
            entity.Property(e => e.TaskAssignedToRole)
                .IsUnicode(false)
                .HasColumnName("Task Assigned To Role");
            entity.Property(e => e.TaskAssignedToUser)
                .IsUnicode(false)
                .HasColumnName("Task Assigned To User");
            entity.Property(e => e.TaskCode)
                .IsUnicode(false)
                .HasColumnName("Task Code");
            entity.Property(e => e.TaskCompletedByTeam)
                .IsUnicode(false)
                .HasColumnName("Task Completed By Team");
            entity.Property(e => e.TaskCompletedByUser)
                .IsUnicode(false)
                .HasColumnName("Task Completed By User");
            entity.Property(e => e.TaskCompletedDate)
                .IsUnicode(false)
                .HasColumnName("Task Completed Date");
            entity.Property(e => e.TaskCreatedByTeam)
                .IsUnicode(false)
                .HasColumnName("Task Created By Team");
            entity.Property(e => e.TaskCreatedByUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Created By User");
            entity.Property(e => e.TaskCreatedDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Created Date");
            entity.Property(e => e.TaskDescription)
                .IsUnicode(false)
                .HasColumnName("Task Description");
            entity.Property(e => e.TaskId)
                .IsUnicode(false)
                .HasColumnName("Task Id");
            entity.Property(e => e.TaskName)
                .IsUnicode(false)
                .HasColumnName("Task Name");
            entity.Property(e => e.TaskProcessStep)
                .IsUnicode(false)
                .HasColumnName("Task Process Step");
            entity.Property(e => e.TaskStatus)
                .IsUnicode(false)
                .HasColumnName("Task Status");
            entity.Property(e => e.StaffInd).HasColumnType("int");
        });

        modelBuilder.Entity<Taskmv>(entity =>
        {
            entity.ToTable("TASKMV");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BenchmarkDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Benchmark Date");
            entity.Property(e => e.BenchmarkDays)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("Benchmark Days");
            entity.Property(e => e.BenefitCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Benefit Code");
            entity.Property(e => e.BenefitDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Benefit Description");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Benefit Number");
            entity.Property(e => e.CaseManager)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Case Manager");
            entity.Property(e => e.CaseStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Case Status");
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Case Type");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("Claim Number");
            entity.Property(e => e.ClaimTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Claim Team");
            entity.Property(e => e.ClaimType)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Claim Type");
            entity.Property(e => e.ClaimantName)
                .HasMaxLength(401)
                .IsUnicode(false)
                .HasColumnName("Claimant Name");
            entity.Property(e => e.ClassOfBusiness)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Class of Business");
            entity.Property(e => e.GroupPlanName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Group Plan Name");
            entity.Property(e => e.GroupPlanNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Group Plan Number");
            entity.Property(e => e.LumpsumIpIndicator)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lumpsum IP Indicator");
            entity.Property(e => e.OriginalTaskTargetDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Original Task Target Date");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Product Code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.TargetBenefitType)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Target Benefit Type");
            entity.Property(e => e.TaskAssignedToDepartment)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Assigned To Department");
            entity.Property(e => e.TaskAssignedToRole)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Assigned To Role");
            entity.Property(e => e.TaskAssignedToUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Assigned To User");
            entity.Property(e => e.TaskCode)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Task Code");
            entity.Property(e => e.TaskCompletedByTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Task Completed By Team");
            entity.Property(e => e.TaskCompletedByUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Completed By User");
            entity.Property(e => e.TaskCompletedDate)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("Task Completed Date");
            entity.Property(e => e.TaskCreatedByTeam)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Task Created By Team");
            entity.Property(e => e.TaskCreatedByUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task Created By User");
            entity.Property(e => e.TaskCreatedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Task Created Date");
            entity.Property(e => e.TaskDescription)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Task Description");
            entity.Property(e => e.TaskId)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Task Id");
            entity.Property(e => e.TaskInDepartment)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Task In Department");
            entity.Property(e => e.TaskName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Name");
            entity.Property(e => e.TaskProcessStep)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Task Process Step");
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Task Status");
            entity.Property(e => e.StaffInd).HasColumnType("int");
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");

        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PARTY_ID");

            entity.ToTable("Party");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CorrespondenceTranslationRequired).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CountryOfBirth).IsUnicode(false);
            entity.Property(e => e.CulturalConsiderations)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.DateOfDeath).HasColumnType("date");
            entity.Property(e => e.Deceased).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Gender).IsUnicode(false);
            entity.Property(e => e.GroupClient).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HazardousPursuit).IsUnicode(false);
            entity.Property(e => e.HighValueAdvisor).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.InterpreterRequired).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.MaritalStatus).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(233)
                .IsUnicode(false);
            entity.Property(e => e.Nationality).IsUnicode(false);
            entity.Property(e => e.NotificationsIssued).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Occupation).IsUnicode(false);
            entity.Property(e => e.PartyType).IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PreferredName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.PreviousName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecuredClient).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StaffMember).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Tenure).HasColumnType("date");
            entity.Property(e => e.Title).IsUnicode(false);
            entity.Property(e => e.Verified).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DOB)
               .HasMaxLength(30)
               .IsUnicode(false);
            entity.Property(e => e.DOD)
               .HasMaxLength(30)
               .IsUnicode(false);
        });

        modelBuilder.Entity<PartyAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PARTYADDRESS_ID");

            entity.ToTable("PartyAddress");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.AddressLine1).IsUnicode(false);
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.AddressLine3)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.AddressType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.BuildingName1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.BuildingName2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DisplayExtend).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.Dpid)
                .HasColumnType("decimal(8, 0)")
                .HasColumnName("DPID");
            entity.Property(e => e.EffectiveFrom)
                .HasMaxLength(19)
                .IsUnicode(false);
            entity.Property(e => e.EffectiveTo)
                .HasMaxLength(19)
                .IsUnicode(false);
            entity.Property(e => e.FloorLevelNum)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.FloorLevelTyp).IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.LotNumber)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("PARTY_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("PARTY_I");
            entity.Property(e => e.PostCode)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.PostalNumber)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.PostalNumberP)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.PostalNumberS)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.PostalType).IsUnicode(false);
            entity.Property(e => e.PremiseNoSuff)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PremiseNoTo).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.PremiseNoToSu)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.StreetSuffix).IsUnicode(false);
            entity.Property(e => e.Suburb)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartyName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<PartyCertificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PARTYCERTIFICATS_ID");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CertificationGroup).IsUnicode(false);
            entity.Property(e => e.CertificationIssued).IsUnicode(false);
            entity.Property(e => e.CertificationStatus).IsUnicode(false);
            entity.Property(e => e.CertificationType).IsUnicode(false);
            entity.Property(e => e.DocumentIdentifier)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EffectiveFrom).HasColumnType("date");
            entity.Property(e => e.EffectiveTo).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("PARTY_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("PARTY_I");
        });

        modelBuilder.Entity<PartyClassification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PARTYCLASSIFICATIONS_ID");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClasificationType).IsUnicode(false);
            entity.Property(e => e.EffectiveFrom).HasColumnType("date");
            entity.Property(e => e.EffectiveTo).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("PARTY_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("PARTY_I");
            entity.Property(e => e.Speciality).IsUnicode(false);
        });

        modelBuilder.Entity<PartyConsent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PARTYCONSENTS_ID");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ConsentStatus).IsUnicode(false);
            entity.Property(e => e.ConsentType).IsUnicode(false);
            entity.Property(e => e.EffectiveDate).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("PARTY_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("PARTY_I");
        });

        modelBuilder.Entity<PartyContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PARTYCONTACTS_ID");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.AreaCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ContactMethod).IsUnicode(false);
            entity.Property(e => e.ContactTime).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.ExtNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.IntCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsExDir).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("PARTY_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("PARTY_I");
            entity.Property(e => e.TelNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Verificaton).IsUnicode(false);
        });

        modelBuilder.Entity<PartyPolicyRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PARTYPOLICYROLESS_ID");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CommenceDate).HasColumnType("date");
            entity.Property(e => e.Erole)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("ERole");
            entity.Property(e => e.Estatus)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("EStatus");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.OrderNo).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("PARTY_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("PARTY_I");
            entity.Property(e => e.PolicyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("POLICY_C");
            entity.Property(e => e.PolicyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("POLICY_I");
            entity.Property(e => e.Role).IsUnicode(false);
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.TerminationDate).HasColumnType("date");
        });

        modelBuilder.Entity<PaymentPreference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PAYMENTPREFERENCES_ID");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.BulkPayee).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CategoryOfService).IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EffectiveFrom).HasColumnType("date");
            entity.Property(e => e.EffectiveTo).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Identifier)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameToPrintOnCheque)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NominatedPayee).IsUnicode(false);
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("PARTY_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("PARTY_I");
            entity.Property(e => e.PaymentDay).IsUnicode(false);
            entity.Property(e => e.PaymentMethod).IsUnicode(false);
            entity.Property(e => e.PaymentPeriod).IsUnicode(false);
            entity.Property(e => e.UseForBilling).HasColumnType("decimal(1, 0)");
        });

        modelBuilder.Entity<Case>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CASE_ID");

            entity.ToTable("Case");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.CaseNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.CaseOwnerComment)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CaseType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Context)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.CustomerContactFrequency).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.IncuredDate).HasColumnType("date");
            entity.Property(e => e.OpportunityToInfluenceExhausted).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.OverrideTriageSegmentReason)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TriageSegment).IsUnicode(false);
            entity.Property(e => e.UnexpectedCircumstances).IsUnicode(false);
            entity.Property(e => e.UrgentFinancialNeed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<CaseLinker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CASELINKER_ID");

            entity.ToTable("CaseLinker");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseBackwardC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("CaseBackward_C");
            entity.Property(e => e.CaseBackwardI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("CaseBackward_I");
            entity.Property(e => e.CaseForwardC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("CaseForward_C");
            entity.Property(e => e.CaseForwardI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("CaseForward_I");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.LastUpdated).HasColumnType("date");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CaseParty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CASEPARTY_ID");

            entity.ToTable("CaseParty");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I");
            entity.Property(e => e.RoleC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Role_C");
            entity.Property(e => e.RoleI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Role_I");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.UseDefaultPaymentDetailsForParty).HasColumnType("decimal(1, 0)");
        });

        modelBuilder.Entity<CaseValidation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CASVALIDATION_ID");

            entity.ToTable("CaseValidation");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate).HasColumnType("date");
            entity.Property(e => e.Message)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ReasonForSuppression).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.UserC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("User_C");
            entity.Property(e => e.UserI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("User_I");
                entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.ApplicationId)
            .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLAIM_ID");

            entity.ToTable("Claim");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.AccidentSickness).IsUnicode(false);
            entity.Property(e => e.AdditionalInformation)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.ClaimReceivedDate).HasColumnType("date");
            entity.Property(e => e.ClaimantIsNotifier).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.DateReturnedToWork).HasColumnType("date");
            entity.Property(e => e.DisableAutoUpdates).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.ExpectedRtwftdateIfKnown)
                .HasColumnType("date")
                .HasColumnName("ExpectedRTWFTDateIfKnown");
            entity.Property(e => e.FatalClaim).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.GuidelinesDate).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.IncurredDateOnLastUpdate).HasColumnType("date");
            entity.Property(e => e.InsuredClaimCorrespondence).IsUnicode(false);
            entity.Property(e => e.Max).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Max1).HasColumnType("date");
            entity.Property(e => e.Min).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Min1).HasColumnType("date");
            entity.Property(e => e.OccurredInAnotherCountry).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.Opt).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Opt1).HasColumnType("date");
            entity.Property(e => e.RecoveryDurationUnit).IsUnicode(false);
            entity.Property(e => e.Source).IsUnicode(false);
            entity.Property(e => e.TpdsubDefinition)
                .IsUnicode(false)
                .HasColumnName("TPDSubDefinition");
            entity.Property(e => e.TraumaDefinition).IsUnicode(false);
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<ClaimIncapacityPeriod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLAIMINCAPACITYPERIOD_ID");

            entity.ToTable("ClaimIncapacityPeriod");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClaimC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Claim_C");
            entity.Property(e => e.ClaimI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Claim_I");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Notes)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.PartC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Part_C");
            entity.Property(e => e.PartI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Part_I");
            entity.Property(e => e.PartialCapacity)
                .HasMaxLength(123)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.ApplicationId)
            .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<ClaimPolicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLAIMPOLICY_ID");

            entity.ToTable("ClaimPolicy");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClaimC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Claim_C");
            entity.Property(e => e.ClaimI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Claim_I");
            entity.Property(e => e.Commencementd).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.InternalEndDate).HasColumnType("date");
            entity.Property(e => e.LastRefreshDate).HasColumnType("date");
            entity.Property(e => e.PolicyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Policy_C");
            entity.Property(e => e.PolicyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Policy_I");
        });

        modelBuilder.Entity<ClaimPolicyCoverage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLAIMPOLICYCOVERAGE_ID");

            entity.ToTable("ClaimPolicyCoverage");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClaimPolicyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("ClaimPolicy_C");
            entity.Property(e => e.ClaimPolicyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("ClaimPolicy_I");
            entity.Property(e => e.Coverage).IsUnicode(false);
            entity.Property(e => e.CoverageCode).IsUnicode(false);
            entity.Property(e => e.EffectiveDate).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Status).IsUnicode(false);
        });

        modelBuilder.Entity<ClaimPolicyEntitlement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLAIMPOLICYENTITLEMENT_ID");

            entity.ToTable("ClaimPolicyEntitlement");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.BenefitEntitlementDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.BenefitSelected)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClaimPolicyCoverageC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("ClaimPolicyCoverage_C");
            entity.Property(e => e.ClaimPolicyCoverageI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("ClaimPolicyCoverage_I");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.PasriskOptionCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PASRiskOptionCode");
            entity.Property(e => e.Type).IsUnicode(false);
        });

        modelBuilder.Entity<ClaimPolicyExclusion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLAIMPOLICYEXCLUSIONS_ID");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClaimPolicyEntitlementC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("ClaimPolicyEntitlement_C");
            entity.Property(e => e.ClaimPolicyEntitlementI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("ClaimPolicyEntitlement_I");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
        });

        modelBuilder.Entity<ClaimPolicyReinsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLAIMPOLICYREINSURANCE_ID");

            entity.ToTable("ClaimPolicyReinsurance");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClaimPolicyEntitlementC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("ClaimPolicyEntitlement_C");
            entity.Property(e => e.ClaimPolicyEntitlementI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("ClaimPolicyEntitlement_I");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
        });

        modelBuilder.Entity<Benefit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BENEFIT_ID");

            entity.ToTable("Benefit");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.AccidentWaitingPeriod).HasColumnType("decimal(16, 0)");
            entity.Property(e => e.AccidentWaitingPeriodBasis).IsUnicode(false);
            entity.Property(e => e.AdjustBenefit).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.AdjustmentTypeName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AgeroundingPrecision)
                .IsUnicode(false)
                .HasColumnName("AGERoundingPrecision");
            entity.Property(e => e.AgeroundingRule)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("AGERoundingRule");
            entity.Property(e => e.AgreedValue).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.AnyAllReviewDate).HasColumnType("date");
            entity.Property(e => e.AnyAllStatus).IsUnicode(false);
            entity.Property(e => e.AutomaticAcceptanceLimit).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.BenefitDecision).IsUnicode(false);
            entity.Property(e => e.BenefitDecisionDate).HasColumnType("date");
            entity.Property(e => e.BenefitEndDate).HasColumnType("date");
            entity.Property(e => e.BenefitExpiryDate).HasColumnType("date");
            entity.Property(e => e.BenefitSelected)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BenefitStartDate).HasColumnType("date");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.ChangeInClaimDefinitionDate).HasColumnType("date");
            entity.Property(e => e.ChronicConditionOption).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.DateBenefitsWithheld).HasColumnType("date");
            entity.Property(e => e.Day1AccidentOption).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.DuesCreatedInArrears).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.EffectiveDateOfCoverage).HasColumnType("date");
            entity.Property(e => e.EliminationPeriod).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.EliminationPeriodBasis).IsUnicode(false);
            entity.Property(e => e.EndDateCalculationType).IsUnicode(false);
            entity.Property(e => e.ExpectedBenefitClosureDate).HasColumnType("date");
            entity.Property(e => e.FullyRetained).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.GroupId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GroupID");
            entity.Property(e => e.HospitalWaitingPeriod).HasColumnType("decimal(16, 0)");
            entity.Property(e => e.HospitalWaitingPeriodBasis).IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Iar)
                .IsUnicode(false)
                .HasColumnName("IAR");
            entity.Property(e => e.IndexLeadTime).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.IndexationApplies).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.LastUpdateUserNameC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("LastUpdateUserName_C");
            entity.Property(e => e.LastUpdateUserNameI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("LastUpdateUserName_I");
            entity.Property(e => e.MaxNumberIndexations).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.MaxThresholdApplies).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.MaximumAggregateAmount).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.MaximumAmount).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.MaximumBenefitPeriod).HasColumnType("decimal(16, 0)");
            entity.Property(e => e.MaximumBenefitPeriodAccident).HasColumnType("decimal(16, 0)");
            entity.Property(e => e.MaximumBenefitPeriodAccidentBasis).IsUnicode(false);
            entity.Property(e => e.MaximumBenefitPeriodBasis).IsUnicode(false);
            entity.Property(e => e.MaximumBenefitPeriodHospital).HasColumnType("decimal(16, 0)");
            entity.Property(e => e.MaximumBenefitPeriodHospitalBasis).IsUnicode(false);
            entity.Property(e => e.MaximumCalculationType).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.MaximumCumulativeRate).HasColumnType("decimal(19, 6)");
            entity.Property(e => e.MaximumPercentage).HasColumnType("decimal(13, 6)");
            entity.Property(e => e.MaximumRate).HasColumnType("decimal(19, 6)");
            entity.Property(e => e.MinThresholdApplies).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.MinimumAmount).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.MinimumCalculationType).IsUnicode(false);
            entity.Property(e => e.MinimumPercentage).HasColumnType("decimal(13, 6)");
            entity.Property(e => e.MinimumRate).HasColumnType("decimal(19, 6)");
            entity.Property(e => e.OccupationalCategory).IsUnicode(false);
            entity.Property(e => e.OverrideChangeInDefinitionDate).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.OverrideClaimIncurredDate).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.PasriskOptionCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PASRiskOptionCode");
            entity.Property(e => e.PasriskOptionDesc)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("PASRiskOptionDesc");
            entity.Property(e => e.ProofOfLossDate).HasColumnType("date");
            entity.Property(e => e.ReasonBenefitsWithheld).IsUnicode(false);
            entity.Property(e => e.ReasonForBenefitDecision).IsUnicode(false);
            entity.Property(e => e.ReinsurerLiabilityApprovedToDate).HasColumnType("date");
            entity.Property(e => e.RoundInstruction).IsUnicode(false);
            entity.Property(e => e.RoundUnit).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.SicknessWaitingPeriod).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.Source).IsUnicode(false);
            entity.Property(e => e.StartDateCalculationType).IsUnicode(false);
            entity.Property(e => e.SubBenefitFlag).IsUnicode(false);
            entity.Property(e => e.SumInsured).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.SuperContributionPct).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ToEndOfBenefit).HasColumnType("date");
            entity.Property(e => e.Type).IsUnicode(false);
            entity.Property(e => e.Underwritten).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.WaitingPeriod).HasColumnType("decimal(16, 0)");
            entity.Property(e => e.WaitingPeriodBasis).IsUnicode(false);
            entity.Property(e => e.WaitingPeriodBasis1)
                .IsUnicode(false)
                .HasColumnName("WaitingPeriodBasis_1");
            entity.Property(e => e.WhenAnyAllDecisionMade).HasColumnType("date");
            entity.Property(e => e.WhoAuthorizedBenefitsWithheldC)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("WhoAuthorizedBenefitsWithheld_C");
            entity.Property(e => e.WhoAuthorizedBenefitsWithheldI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("WhoAuthorizedBenefitsWithheld_I");
            entity.Property(e => e.ClaimNumber)
               .HasMaxLength(254)
               .IsUnicode(false)
               .HasColumnName("ClaimNumber");
            entity.Property(e => e.StaffInd).HasColumnType("int");
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<BenefitExclusion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BENEFITEXCLUSIONS_ID");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.BenefitC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Benefit_C");
            entity.Property(e => e.BenefitI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Benefit_I");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Duration)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.DurationUnit).IsUnicode(false);
            entity.Property(e => e.EndDate)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.LastStatusChanged)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.StatusUpdatedByC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("StatusUpdatedBy_C");
            entity.Property(e => e.StatusUpdatedByI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("StatusUpdatedBy_I");
            entity.Property(e => e.Type).IsUnicode(false);
        });

        modelBuilder.Entity<BenefitReInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BENEFITREINSURANCE_ID");

            entity.ToTable("BenefitReInsurance");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.BenefitC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Benefit_C");
            entity.Property(e => e.BenefitI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Benefit_I");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ExcessLossFlag).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.ExcessPoolAmount).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.MandatoryReferralLimit).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.PoolPercentage).HasColumnType("decimal(13, 6)");
            entity.Property(e => e.QuotaSharePercentage).HasColumnType("decimal(13, 6)");
            entity.Property(e => e.ReinsuranceCode).IsUnicode(false);
            entity.Property(e => e.ReinsuredFromReinsuredAmount).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.ReinsurerName).IsUnicode(false);
            entity.Property(e => e.ReinsurerNotificationDate).HasColumnType("date");
            entity.Property(e => e.RetentionSurplusLimit).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.TreatyEffectiveFrom).HasColumnType("date");
            entity.Property(e => e.TreatyEffectiveTo).HasColumnType("date");
        });

        modelBuilder.Entity<DocumentA>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DOCUMENT_ID");

            entity.ToTable("Document");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.ContactC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Contact_C");
            entity.Property(e => e.ContactI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Contact_I");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.DocumentType)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EffectiveFrom).HasColumnType("date");
            entity.Property(e => e.EffectiveTo).HasColumnType("date");
            entity.Property(e => e.EnvelopId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EnvelopID");
            entity.Property(e => e.FileName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.FileType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.KeyDocument).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.LastUpdated).HasColumnType("date");
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I");
            entity.Property(e => e.Tag).IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.ApplicationId)
               .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<DocumentGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DOCUMENTGROUP_ID");

            entity.ToTable("DocumentGroup");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.DocumentGroup1)
                .IsUnicode(false)
                .HasColumnName("DocumentGroup");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I");
        });

        modelBuilder.Entity<DocumentGroupLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DOCUMENTGROUPLINK_ID");

            entity.ToTable("DocumentGroupLink");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.CFrom)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("C_FROM");
            entity.Property(e => e.CTo)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("C_TO");
            entity.Property(e => e.DocumentC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Document_C");
            entity.Property(e => e.DocumentGroupC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("DocumentGroup_C");
            entity.Property(e => e.DocumentGroupI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("DocumentGroup_I");
            entity.Property(e => e.DocumentI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Document_I");
            entity.Property(e => e.IFrom)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("I_FROM");
            entity.Property(e => e.ITo)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("I_TO");
        });

        modelBuilder.Entity<DocumentUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DOCUMENTUSER_ID");

            entity.ToTable("DocumentUser");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.DepartmentDefaultC)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Department_Default_C");
            entity.Property(e => e.DepartmentDefaultI)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Department_Default_I");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.UserEnabled).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Earning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EARNING_ID");

            entity.ToTable("Earning");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.ActualGross).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.AdditionalNotes)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.BiWeekly).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.EffectiveFrom).HasColumnType("date");
            entity.Property(e => e.EffectiveTo).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Monthly).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.OccupationC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Occupation_C");
            entity.Property(e => e.OccupationI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Occupation_I");
            entity.Property(e => e.OverrideWeeklyEarnings).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.OvertimeHourlyRate).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.OvertimeHours).HasColumnType("decimal(13, 6)");
            entity.Property(e => e.SalaryAmountBasis).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.SemiMonthly).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.ShiftDifferential).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.ShiftEarnings).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.ShiftHours).HasColumnType("decimal(13, 6)");
            entity.Property(e => e.ShiftPay).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.StandardEarnings).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.StandardHours).HasColumnType("decimal(13, 6)");
            entity.Property(e => e.Type).IsUnicode(false);
            entity.Property(e => e.VacationStatutoryEarnings).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.VacationStatutoryTime).HasColumnType("decimal(26, 6)");
            entity.Property(e => e.Yearly).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.Yearly1).HasColumnType("decimal(28, 6)");
        });

        modelBuilder.Entity<EnumField>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ENUMFIELDS_ID");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DomainName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.InstanceName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Retired).HasColumnType("decimal(1, 0)");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GOAL_ID");

            entity.ToTable("Goal");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClientGoalC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("ClientGoal_C");
            entity.Property(e => e.ClientGoalI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("ClientGoal_I");
            entity.Property(e => e.CustomerStrategyStatus).IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.LifeAreaC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("LifeArea_C");
            entity.Property(e => e.LifeAreaI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("LifeArea_I");
            entity.Property(e => e.StrategyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SummarySnapshot)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.TargetDate).HasColumnType("date");
        });

        modelBuilder.Entity<LifeArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LIFEAREA_ID");

            entity.ToTable("LifeArea");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.FactorStatus).IsUnicode(false);
            entity.Property(e => e.Factors).IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Notes).IsUnicode(false);
        });

        modelBuilder.Entity<MedicalCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MEDICALCODE_ID");

            entity.ToTable("MedicalCode");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.ApprovalDate).HasColumnType("date");
            entity.Property(e => e.BodyLocation).IsUnicode(false);
            entity.Property(e => e.BodySide).IsUnicode(false);
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClaimC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Claim_C");
            entity.Property(e => e.ClaimI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Claim_I");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerDominantSide).IsUnicode(false);
            entity.Property(e => e.DateOfDiagnosis).HasColumnType("date");
            entity.Property(e => e.DateOfFirstConsultation).HasColumnType("date");
            entity.Property(e => e.DateOfFirstTreatment).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Diagnosis)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DurationClass)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EffectiveFrom).HasColumnType("date");
            entity.Property(e => e.EffectiveTo).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.ImpactOnActivityLevels)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Level).IsUnicode(false);
            entity.Property(e => e.LevelIndicator).IsUnicode(false);
            entity.Property(e => e.LifeExpectancy).IsUnicode(false);
            entity.Property(e => e.MedicalCondition).IsUnicode(false);
            entity.Property(e => e.PreExistingCondition).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.RequestDate).HasColumnType("date");
            entity.Property(e => e.Severity).IsUnicode(false);
            entity.Property(e => e.Source).IsUnicode(false);
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.Type).IsUnicode(false);
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");

        });

        modelBuilder.Entity<Note1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NOTE_ID");

            entity.ToTable("Note1");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.ContactC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Contact_C");
            entity.Property(e => e.ContactI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Contact_I");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.DocumentType)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EffectiveFrom).HasColumnType("date");
            entity.Property(e => e.EffectiveTo).HasColumnType("date");
            entity.Property(e => e.EnvelopId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EnvelopID");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.KeyDocument).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.LastUpdated).HasColumnType("date");
            entity.Property(e => e.PackedData).IsUnicode(false);
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I");
            entity.Property(e => e.Tag).IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .IsUnicode(false);
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.StaffInd).HasColumnType("int");
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<Note2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NOTE2_ID");

            entity.ToTable("Note2");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.ContactC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Contact_C");
            entity.Property(e => e.ContactI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Contact_I");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.DocumentType)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EffectiveFrom).HasColumnType("date");
            entity.Property(e => e.EffectiveTo).HasColumnType("date");
            entity.Property(e => e.EnvelopId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EnvelopID");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.KeyDocument).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.LastUpdated).HasColumnType("date");
            entity.Property(e => e.PackedData).IsUnicode(false);
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I");
            entity.Property(e => e.Tag).IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .IsUnicode(false);
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OutstandingRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OUTSTANDINGREQUEST_ID");

            entity.ToTable("OutstandingRequest");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompletionNotes)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CompletionReason).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.DateCompleted).HasColumnType("date");
            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.DateLastFollowedUp).HasColumnType("date");
            entity.Property(e => e.DateRequested).HasColumnType("date");
            entity.Property(e => e.DateSuppressed).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DocumentC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Document_C");
            entity.Property(e => e.DocumentI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Document_I");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.LastFollowedUpBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NextFollowUpDate).HasColumnType("date");
            entity.Property(e => e.NotProceedingWithDate).HasColumnType("date");
            entity.Property(e => e.PartySourceC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("PartySource_C");
            entity.Property(e => e.PartySourceI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("PartySource_I");
            entity.Property(e => e.PartySubjectC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("PartySubject_C");
            entity.Property(e => e.PartySubjectI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("PartySubject_I");
            entity.Property(e => e.ProcessC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Process_C");
            entity.Property(e => e.ProcessI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Process_I");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.SelectedCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SelectedType)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.SuppressedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.SuppressionNotes)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.SuppressionReason).IsUnicode(false);
            entity.Property(e => e.TaskC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Task_C");
            entity.Property(e => e.TaskI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Task_I");
            entity.Property(e => e.Type)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.UserCreated)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.UserLastUpdated)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.ClaimNumber)
                 .HasMaxLength(254)
                 .IsUnicode(false);
            entity.Property(e => e.ApplicationId)
            .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<OutstandingRequestDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OUTSTANDINGREQUESTDOCUMENT_ID");

            entity.ToTable("OutstandingRequestDocument");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.CFrom)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("C_FROM");
            entity.Property(e => e.CTo)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("C_TO");
            entity.Property(e => e.DocumentC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Document_C");
            entity.Property(e => e.DocumentI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Document_I");
            entity.Property(e => e.IFrom)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("I_FROM");
            entity.Property(e => e.ITo)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("I_TO");
            entity.Property(e => e.OutstandingRqtC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("OutstandingRqt_C");
            entity.Property(e => e.OutstandingRqtI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("OutstandingRqt_I");
        });

        modelBuilder.Entity<OutstandingRequestHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OUTSTANDINGREQUESTHISTORY_ID");

            entity.ToTable("OutstandingRequestHistory");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CompletionNotes)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.OutstandingRqtC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("OutstandingRqt_C");
            entity.Property(e => e.OutstandingRqtI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("OutstandingRqt_I");
            entity.Property(e => e.ReasonForCompletion).IsUnicode(false);
            entity.Property(e => e.ReasonForSuppression).IsUnicode(false);
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.SupressionNotes)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("date");
        });

        modelBuilder.Entity<Process>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PROCESS_ID");

            entity.ToTable("Process");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.AssignedTo)
                .HasMaxLength(260)
                .IsUnicode(false);
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.CaseManager)
                .HasMaxLength(260)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.DocumentC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Document_C");
            entity.Property(e => e.DocumentI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Document_I");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.InDepartment)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I");
            entity.Property(e => e.PlicyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Plicy_C");
            entity.Property(e => e.PlicyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Plicy_I");
            entity.Property(e => e.ProcessC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Process_C");
            entity.Property(e => e.ProcessI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Process_I");
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TargetDate).HasColumnType("date");
            entity.Property(e => e.TaskC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Task_C");
            entity.Property(e => e.TaskI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Task_I");
            entity.Property(e => e.WorkType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProcessHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PROCESSHISTORY_ID");

            entity.ToTable("ProcessHistory");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.ActionDate).HasColumnType("date");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.ProcessC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Process_C");
            entity.Property(e => e.ProcessI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Process_I");
            entity.Property(e => e.Reason)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Roles_ID");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.Department)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.IsEnabled).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.Role1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<TaskA>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TASK_ID");

            entity.ToTable("Task");

            entity.HasIndex(e => e.ClaimNumber, "IDX_TASK_CLAIMNUMBER");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.Assignee)
                .HasMaxLength(260)
                .IsUnicode(false);
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(260)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.CreationDate1).HasColumnType("datetime");
            entity.Property(e => e.DefaultDepartment)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.DocumentC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Document_C");
            entity.Property(e => e.DocumentI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Document_I");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.OnHoldUntil).HasColumnType("date");
            entity.Property(e => e.OriginalTargetDate).HasColumnType("date");
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I");
            entity.Property(e => e.PlicyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Plicy_C");
            entity.Property(e => e.PlicyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Plicy_I");
            entity.Property(e => e.Priority).IsUnicode(false);
            entity.Property(e => e.ProcessC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Process_C");
            entity.Property(e => e.ProcessI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Process_I");
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(233)
                .IsUnicode(false);
            entity.Property(e => e.Target).HasColumnType("date");
            entity.Property(e => e.TargetDate).HasColumnType("datetime");
            entity.Property(e => e.TaskC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Task_C");
            entity.Property(e => e.TaskI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Task_I");
            entity.Property(e => e.TaskType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(260)
                .IsUnicode(false);
            entity.Property(e => e.ApplicationId)
               .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<TaskHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TASKHISTORY_ID");

            entity.ToTable("TaskHistory");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.ActionedBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.ActionedDate).HasColumnType("date");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.TaskC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Task_C");
            entity.Property(e => e.TaskI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Task_I");
        });

        modelBuilder.Entity<ContactDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CONTACTDETAILS_ID");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.AreaCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ContactMediumPartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("ContactMedium_Party_C");
            entity.Property(e => e.ContactMediumPartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("ContactMedium_Party_I");
            entity.Property(e => e.ContactMethod).IsUnicode(false);
            entity.Property(e => e.ContactTime).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.ExtnNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.IntCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsExDir).HasColumnType("decimal(1, 0)");
            entity.Property(e => e.PartyAddressPartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("PartyAddress_Party_C");
            entity.Property(e => e.PartyAddressPartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("PartyAddress_Party_I");
            entity.Property(e => e.SendEmailTo)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.TelNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Verificaton).IsUnicode(false);
        });

        modelBuilder.Entity<DepartmentUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DEPARTMENTUSER_ID");

            entity.ToTable("DepartmentUser");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.DepartmentDefaultC)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Department_Default_C");
            entity.Property(e => e.DepartmentDefaultI)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Department_Default_I");
            entity.Property(e => e.DepartmentUserC)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("DepartmentUser_C");
            entity.Property(e => e.DepartmentUserI)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("DepartmentUser_I");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.UserEnabled).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CONTACT_ID");

            entity.ToTable("Contact");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.ContactDuration).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ContactSuccessful).IsUnicode(false);
            entity.Property(e => e.CustomerRepresentative)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateTime).HasColumnType("date");
            entity.Property(e => e.DealtWithBy)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.Direction).IsUnicode(false);
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Method).IsUnicode(false);
            entity.Property(e => e.MethodOfContact).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.PhoneRecordingLink)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PrivacyTag).IsUnicode(false);
            entity.Property(e => e.Reason).IsUnicode(false);
            entity.Property(e => e.User)
                .HasMaxLength(163)
                .IsUnicode(false);
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.ApplicationId)
            .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_POLICY_ID");

            entity.ToTable("Policy");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ContractStatus).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.ContractStatusName).IsUnicode(false);
            entity.Property(e => e.EffectiveDate).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Product).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.ProductName).IsUnicode(false);
            entity.Property(e => e.SourceSystem).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.SourceSystemName).IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.TerminationDate).HasColumnType("date");
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<PartySearch>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("PartySearch");

            entity.Property(e => e.Pid).HasColumnName("PID");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DOB");
            entity.Property(e => e.Dod)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DOD");
            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.Name)
                .HasMaxLength(233)
                .IsUnicode(false);
            entity.Property(e => e.Title).IsUnicode(false);
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<PolicySearch>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("PolicySearch");

            entity.Property(e => e.Pid).HasColumnName("PID");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.ContractStatusName).IsUnicode(false);
            entity.Property(e => e.EffectiveDate).HasColumnType("date");
            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductName).IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.TerminationDate).HasColumnType("date");
            entity.Property(e => e.ApplicationId)
                .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<CoverageSearch>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("CoverageSearch");

            entity.Property(e => e.Pid).HasColumnName("PID");
            entity.Property(e => e.BenefitEntitlementDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.BenefitSelected)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.ClaimPolicyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("ClaimPolicy_C");
            entity.Property(e => e.ClaimPolicyCoverageC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("ClaimPolicyCoverage_C");
            entity.Property(e => e.ClaimPolicyCoverageI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("ClaimPolicyCoverage_I");
            entity.Property(e => e.ClaimPolicyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("ClaimPolicy_I");
            entity.Property(e => e.ContractStatus).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.ContractStatusName).IsUnicode(false);
            entity.Property(e => e.Coverage).IsUnicode(false);
            entity.Property(e => e.CoverageCode).IsUnicode(false);
            entity.Property(e => e.EffectiveDate).HasColumnType("date");
            entity.Property(e => e.EffectiveDate1).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.PasriskOptionCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PASRiskOptionCode");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Product).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.ProductName).IsUnicode(false);
            entity.Property(e => e.SourceSystem).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.SourceSystemName).IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.TerminationDate).HasColumnType("date");
            entity.Property(e => e.Type).IsUnicode(false);
            entity.Property(e => e.ApplicationId)
            .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<Occupation>(entity =>
        {
            entity.ToTable("Occupation");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BusinessStructure)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClaimC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Claim_C");
            entity.Property(e => e.ClaimI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Claim_I");
            entity.Property(e => e.DateJobEnded).HasColumnType("date");
            entity.Property(e => e.DateOfHire).HasColumnType("date");
            entity.Property(e => e.DaysWorkedPerWeek).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.EmploymentStatus).IsUnicode(false);
            entity.Property(e => e.HoursWorkedPerWeek).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.NatureOfWorkDuties)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.OccupationCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I");
            entity.Property(e => e.ReasonForCeasingPosition)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.SelfEmployed).HasColumnType("decimal(1, 0)");
        });

        modelBuilder.Entity<ClaimOccupation>(entity =>
        {
            entity.ToTable("ClaimOccupation");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BusinessStructure)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.ClaimC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Claim_C");
            entity.Property(e => e.ClaimI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Claim_I");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.DateJobEnded).HasColumnType("date");
            entity.Property(e => e.DateOfHire).HasColumnType("date");
            entity.Property(e => e.DaysWorkedPerWeek).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.EmploymentStatus).IsUnicode(false);
            entity.Property(e => e.GrossAmt).HasColumnType("decimal(28, 6)");
            entity.Property(e => e.HoursWorkedPerWeek).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.IncomeType).IsUnicode(false);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NatureOfWorkDuties)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Occupation)
                .HasMaxLength(353)
                .IsUnicode(false);
            entity.Property(e => e.OccupationCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PartyC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C");
            entity.Property(e => e.PartyI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I");
            entity.Property(e => e.Rank).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ReasonForCeasingPosition)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.SelfEmployed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApplicationId)
            .HasColumnName("ApplicationId");
        });

        modelBuilder.Entity<ClaimPeriod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLAIMPERIOD_ID");

            entity.ToTable("ClaimPeriod");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.ClaimC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Claim_C");
            entity.Property(e => e.ClaimI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Claim_I");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.PartyCFacility)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C_Facility");
            entity.Property(e => e.PartyIFacility)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I_Facility");
            entity.Property(e => e.StartDate).HasColumnType("date");
        });

        modelBuilder.Entity<ClientGoal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLIENTGOAL_ID");

            entity.ToTable("ClientGoal");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.AchievementTimeframe).IsUnicode(false);
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.CaseC)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Case_C");
            entity.Property(e => e.CaseI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Case_I");
            entity.Property(e => e.CreateDate).HasColumnType("date");
            entity.Property(e => e.CustomerGoalName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GoalDateRationale)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.GoalDescription)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.GoalReason).IsUnicode(false);
            entity.Property(e => e.GoalTargetDate).HasColumnType("date");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.OutcomeDate).HasColumnType("date");
            entity.Property(e => e.OutcomeNotes)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.Status).IsUnicode(false);
        });

        modelBuilder.Entity<ActionA>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ACTION_ID");

            entity.ToTable("Action");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.ActionName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ActionOutcome).IsUnicode(false);
            entity.Property(e => e.C).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.GoalC)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Goal_C");
            entity.Property(e => e.GoalI)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Goal_I");
            entity.Property(e => e.I).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.OutcomeComments).IsUnicode(false);
            entity.Property(e => e.PartyCResponsibilityOfClient)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C_ResponsibilityOfClient");
            entity.Property(e => e.PartyCResponsibilityOfServiceProvider)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("Party_C_ResponsibilityOfServiceProvider");
            entity.Property(e => e.PartyIResponsibilityOfClient)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I_ResponsibilityOfClient");
            entity.Property(e => e.PartyIResponsibilityOfServiceProvider)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Party_I_ResponsibilityOfServiceProvider");
            entity.Property(e => e.Rationale).IsUnicode(false);
            entity.Property(e => e.ReviewDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.UserCResponsibilityOfStaffMember)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("User_C_ResponsibilityOfStaffMember");
            entity.Property(e => e.UserIResponsibilityOfStaffMember)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("User_I_ResponsibilityOfStaffMember");
        });

        modelBuilder.Entity<ActionHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ACTIONHISTORY_ID");

            entity.ToTable("ActionHistory");

            entity.Property(e => e.Id).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.BenefitNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(4268)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdated).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(254)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

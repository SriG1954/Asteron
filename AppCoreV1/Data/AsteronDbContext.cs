using AppCoreV1.AsteronModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace AppCoreV1.Data;

public partial class AsteronDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private string? connectionString;

    public AsteronDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AsteronDbContext(DbContextOptions<AsteronDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
        connectionString = _configuration.GetConnectionString("AsteronConnection");
    }

    public virtual DbSet<Actassignhistory> Actassignhistories { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Activitydocument> Activitydocuments { get; set; }

    public virtual DbSet<Activitypattern> Activitypatterns { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Allocatedclaimnumber> Allocatedclaimnumbers { get; set; }

    public virtual DbSet<Authorityprofile> Authorityprofiles { get; set; }

    public virtual DbSet<Bodypart> Bodyparts { get; set; }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<Claimaccess> Claimaccesses { get; set; }

    public virtual DbSet<Claimassociation> Claimassociations { get; set; }

    public virtual DbSet<Claimauto> Claimautos { get; set; }

    public virtual DbSet<Claimcontact> Claimcontacts { get; set; }

    public virtual DbSet<Claimcontactrole> Claimcontactroles { get; set; }

    public virtual DbSet<Claimeventquestion> Claimeventquestions { get; set; }

    public virtual DbSet<Claimexception> Claimexceptions { get; set; }

    public virtual DbSet<Claiminassociation> Claiminassociations { get; set; }

    public virtual DbSet<Claimindicator> Claimindicators { get; set; }

    public virtual DbSet<Claiminfo> Claiminfos { get; set; }

    public virtual DbSet<Claimmetric> Claimmetrics { get; set; }

    public virtual DbSet<Claimmetricrecalctime> Claimmetricrecalctimes { get; set; }

    public virtual DbSet<Claimrpt> Claimrpts { get; set; }

    public virtual DbSet<Claimsignificantdate> Claimsignificantdates { get; set; }

    public virtual DbSet<Claimsnapshot> Claimsnapshots { get; set; }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<Complaintcategory> Complaintcategories { get; set; }

    public virtual DbSet<Complainthandler> Complainthandlers { get; set; }

    public virtual DbSet<Complainthistory> Complainthistories { get; set; }

    public virtual DbSet<Complaintnote> Complaintnotes { get; set; }

    public virtual DbSet<Complaintparty> Complaintparties { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Coverage> Coverages { get; set; }

    public virtual DbSet<Credential> Credentials { get; set; }

    public virtual DbSet<CsvdataFile> CsvdataFiles { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Empldatatoinjincident> Empldatatoinjincidents { get; set; }

    public virtual DbSet<Employmentdatum> Employmentdata { get; set; }

    public virtual DbSet<Evaluation> Evaluations { get; set; }

    public virtual DbSet<Exposure> Exposures { get; set; }

    public virtual DbSet<Exposuremetric> Exposuremetrics { get; set; }

    public virtual DbSet<Exposurerpt> Exposurerpts { get; set; }

    public virtual DbSet<Fllog> Fllogs { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Incident> Incidents { get; set; }

    public virtual DbSet<Incidentaddress> Incidentaddresses { get; set; }

    public virtual DbSet<Incidentcontact> Incidentcontacts { get; set; }

    public virtual DbSet<Injuryquestion> Injuryquestions { get; set; }

    public virtual DbSet<Legacyclaimdetail> Legacyclaimdetails { get; set; }

    public virtual DbSet<Legalengagement> Legalengagements { get; set; }

    public virtual DbSet<Litstatustypeline> Litstatustypelines { get; set; }

    public virtual DbSet<Matter> Matters { get; set; }

    public virtual DbSet<Matterexposure> Matterexposures { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    public virtual DbSet<Policylocation> Policylocations { get; set; }

    public virtual DbSet<Riskunit> Riskunits { get; set; }

    public virtual DbSet<Scheduledevent> Scheduledevents { get; set; }

    public virtual DbSet<Securityzone> Securityzones { get; set; }

    public virtual DbSet<Specialneed> Specialneeds { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userroleassign> Userroleassigns { get; set; }

    public virtual DbSet<Usersetting> Usersettings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=WLF1P1PAZ1MDB16.wlife.com.au;Database=Asteron;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actassignhistory>(entity =>
        {
            entity.ToTable("ACTASSIGNHISTORY");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScActivity).HasColumnName("SC_ACTIVITY");
            entity.Property(e => e.ScAssignedgroup).HasColumnName("SC_ASSIGNEDGROUP");
            entity.Property(e => e.ScAssignedqueue).HasColumnName("SC_ASSIGNEDQUEUE");
            entity.Property(e => e.ScAssigneduser).HasColumnName("SC_ASSIGNEDUSER");
            entity.Property(e => e.ScReassignmentenddate).HasColumnName("SC_REASSIGNMENTENDDATE");
            entity.Property(e => e.ScUserorqueue)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_USERORQUEUE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.ToTable("ACTIVITY");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Activityclass).HasColumnName("ACTIVITYCLASS");
            entity.Property(e => e.Activitypatternid).HasColumnName("ACTIVITYPATTERNID");
            entity.Property(e => e.Assignedbyuserid).HasColumnName("ASSIGNEDBYUSERID");
            entity.Property(e => e.Assignedgroupid).HasColumnName("ASSIGNEDGROUPID");
            entity.Property(e => e.Assignedqueueid).HasColumnName("ASSIGNEDQUEUEID");
            entity.Property(e => e.Assigneduserid).HasColumnName("ASSIGNEDUSERID");
            entity.Property(e => e.Assignmentdate)
                .HasColumnType("datetime")
                .HasColumnName("ASSIGNMENTDATE");
            entity.Property(e => e.Assignmentstatus).HasColumnName("ASSIGNMENTSTATUS");
            entity.Property(e => e.Autogenerated)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AUTOGENERATED");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimcontactid).HasColumnName("CLAIMCONTACTID");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Closedate)
                .HasColumnType("datetime")
                .HasColumnName("CLOSEDATE");
            entity.Property(e => e.Closeuserid).HasColumnName("CLOSEUSERID");
            entity.Property(e => e.ComplaintExtid).HasColumnName("COMPLAINT_EXTID");
            entity.Property(e => e.Createtime)
                .HasColumnType("datetime")
                .HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Escalated)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ESCALATED");
            entity.Property(e => e.Escalationdate)
                .HasColumnType("datetime")
                .HasColumnName("ESCALATIONDATE");
            entity.Property(e => e.Exposureid).HasColumnName("EXPOSUREID");
            entity.Property(e => e.Externallyowned)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EXTERNALLYOWNED");
            entity.Property(e => e.Externalownerccid).HasColumnName("EXTERNALOWNERCCID");
            entity.Property(e => e.Generatedsource)
                .HasMaxLength(255)
                .HasColumnName("GENERATEDSOURCE");
            entity.Property(e => e.Importance).HasColumnName("IMPORTANCE");
            entity.Property(e => e.InitialescalationdateExt)
                .HasColumnType("datetime")
                .HasColumnName("INITIALESCALATIONDATE_EXT");
            entity.Property(e => e.InitialtargetdateExt)
                .HasColumnType("datetime")
                .HasColumnName("INITIALTARGETDATE_EXT");
            entity.Property(e => e.Lastvieweddate)
                .HasColumnType("datetime")
                .HasColumnName("LASTVIEWEDDATE");
            entity.Property(e => e.Mandatory)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MANDATORY");
            entity.Property(e => e.Previousgroupid).HasColumnName("PREVIOUSGROUPID");
            entity.Property(e => e.Previousqueueid).HasColumnName("PREVIOUSQUEUEID");
            entity.Property(e => e.Previoususerid).HasColumnName("PREVIOUSUSERID");
            entity.Property(e => e.Priority).HasColumnName("PRIORITY");
            entity.Property(e => e.Publicid)
                .HasMaxLength(64)
                .HasColumnName("PUBLICID");
            entity.Property(e => e.Recurring)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RECURRING");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScRejectreason).HasColumnName("SC_REJECTREASON");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Targetdate)
                .HasColumnType("datetime")
                .HasColumnName("TARGETDATE");
            entity.Property(e => e.Type).HasColumnName("TYPE");
            entity.Property(e => e.Updatetime)
                .HasColumnType("datetime")
                .HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Validationlevel).HasColumnName("VALIDATIONLEVEL");
        });

        modelBuilder.Entity<Activitydocument>(entity =>
        {
            entity.ToTable("ACTIVITYDOCUMENT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Activityid).HasColumnName("ACTIVITYID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Documentid).HasColumnName("DOCUMENTID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
        });

        modelBuilder.Entity<Activitypattern>(entity =>
        {
            entity.ToTable("ACTIVITYPATTERN");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Activityclass).HasColumnName("ACTIVITYCLASS");
            entity.Property(e => e.Automatedonly)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AUTOMATEDONLY");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Category).HasColumnName("CATEGORY");
            entity.Property(e => e.Claimlosstype).HasColumnName("CLAIMLOSSTYPE");
            entity.Property(e => e.Closedclaimavlble)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLOSEDCLAIMAVLBLE");
            entity.Property(e => e.Code).HasColumnName("CODE");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Escalationbuscaltag).HasColumnName("ESCALATIONBUSCALTAG");
            entity.Property(e => e.Escalationdays).HasColumnName("ESCALATIONDAYS");
            entity.Property(e => e.Escalationhours).HasColumnName("ESCALATIONHOURS");
            entity.Property(e => e.Escalationincldays).HasColumnName("ESCALATIONINCLDAYS");
            entity.Property(e => e.Escalationstartpt).HasColumnName("ESCALATIONSTARTPT");
            entity.Property(e => e.Escbuscallocpath).HasColumnName("ESCBUSCALLOCPATH");
            entity.Property(e => e.Externallyowned)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EXTERNALLYOWNED");
            entity.Property(e => e.Importance).HasColumnName("IMPORTANCE");
            entity.Property(e => e.Mandatory)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MANDATORY");
            entity.Property(e => e.Priority).HasColumnName("PRIORITY");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Recurring)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RECURRING");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScActautoassigntype).HasColumnName("SC_ACTAUTOASSIGNTYPE");
            entity.Property(e => e.ScAutoassigntogroup).HasColumnName("SC_AUTOASSIGNTOGROUP");
            entity.Property(e => e.ScAutoassigntoqueue).HasColumnName("SC_AUTOASSIGNTOQUEUE");
            entity.Property(e => e.ScCancompleteonworkplan)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_CANCOMPLETEONWORKPLAN");
            entity.Property(e => e.ScDefaultassigntype).HasColumnName("SC_DEFAULTASSIGNTYPE");
            entity.Property(e => e.ScIsreassignablewithclaim)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ISREASSIGNABLEWITHCLAIM");
            entity.Property(e => e.ScIssubjecteditable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ISSUBJECTEDITABLE");
            entity.Property(e => e.ScScanneddocumentactivity)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_SCANNEDDOCUMENTACTIVITY");
            entity.Property(e => e.Shortsubject).HasColumnName("SHORTSUBJECT");
            entity.Property(e => e.Subject).HasColumnName("SUBJECT");
            entity.Property(e => e.Targetbuscallocpath).HasColumnName("TARGETBUSCALLOCPATH");
            entity.Property(e => e.Targetbuscaltag).HasColumnName("TARGETBUSCALTAG");
            entity.Property(e => e.Targetdays).HasColumnName("TARGETDAYS");
            entity.Property(e => e.Targethours).HasColumnName("TARGETHOURS");
            entity.Property(e => e.Targetincludedays).HasColumnName("TARGETINCLUDEDAYS");
            entity.Property(e => e.Targetstartpoint).HasColumnName("TARGETSTARTPOINT");
            entity.Property(e => e.Type).HasColumnName("TYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("ADDRESS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Addressline1).HasColumnName("ADDRESSLINE1");
            entity.Property(e => e.Addressline2).HasColumnName("ADDRESSLINE2");
            entity.Property(e => e.Addressline3).HasColumnName("ADDRESSLINE3");
            entity.Property(e => e.Addresstype).HasColumnName("ADDRESSTYPE");
            entity.Property(e => e.Batchgeocode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BATCHGEOCODE");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.City).HasColumnName("CITY");
            entity.Property(e => e.Citydenorm).HasColumnName("CITYDENORM");
            entity.Property(e => e.Country).HasColumnName("COUNTRY");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Geocodestatus).HasColumnName("GEOCODESTATUS");
            entity.Property(e => e.Postalcode).HasColumnName("POSTALCODE");
            entity.Property(e => e.Postalcodedenorm).HasColumnName("POSTALCODEDENORM");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScAddressformat).HasColumnName("SC_ADDRESSFORMAT");
            entity.Property(e => e.ScPermanentchange).HasColumnName("SC_PERMANENTCHANGE");
            entity.Property(e => e.State).HasColumnName("STATE");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Validuntil).HasColumnName("VALIDUNTIL");
        });

        modelBuilder.Entity<Allocatedclaimnumber>(entity =>
        {
            entity.ToTable("ALLOCATEDCLAIMNUMBER");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Claimnumber).HasColumnName("CLAIMNUMBER");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Authorityprofile>(entity =>
        {
            entity.ToTable("AUTHORITYPROFILE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Currency).HasColumnName("CURRENCY");
            entity.Property(e => e.Custom)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CUSTOM");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScAdditionalslimit).HasColumnName("SC_ADDITIONALSLIMIT");
            entity.Property(e => e.ScAuthjoblimit).HasColumnName("SC_AUTHJOBLIMIT");
            entity.Property(e => e.ScExgratialimit).HasColumnName("SC_EXGRATIALIMIT");
            entity.Property(e => e.ScRecoverywriteofflimit).HasColumnName("SC_RECOVERYWRITEOFFLIMIT");
            entity.Property(e => e.ScRejectclaimlimit).HasColumnName("SC_REJECTCLAIMLIMIT");
            entity.Property(e => e.ScTotallosslimit).HasColumnName("SC_TOTALLOSSLIMIT");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Bodypart>(entity =>
        {
            entity.ToTable("BODYPART");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Detailedbodypart).HasColumnName("DETAILEDBODYPART");
            entity.Property(e => e.Incidentid).HasColumnName("INCIDENTID");
            entity.Property(e => e.Ordering).HasColumnName("ORDERING");
            entity.Property(e => e.Primarybodypart).HasColumnName("PRIMARYBODYPART");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Claim>(entity =>
        {
            entity.ToTable("CLAIM");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Assignedbyuserid).HasColumnName("ASSIGNEDBYUSERID");
            entity.Property(e => e.Assignedgroupid).HasColumnName("ASSIGNEDGROUPID");
            entity.Property(e => e.Assigneduserid).HasColumnName("ASSIGNEDUSERID");
            entity.Property(e => e.Assignmentdate).HasColumnName("ASSIGNMENTDATE");
            entity.Property(e => e.Assignmentstatus).HasColumnName("ASSIGNMENTSTATUS");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimantdenormid).HasColumnName("CLAIMANTDENORMID");
            entity.Property(e => e.Claimnumber).HasColumnName("CLAIMNUMBER");
            entity.Property(e => e.Claimtier).HasColumnName("CLAIMTIER");
            entity.Property(e => e.Closedate).HasColumnName("CLOSEDATE");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Currency).HasColumnName("CURRENCY");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Donotdestroy)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DONOTDESTROY");
            entity.Property(e => e.Flagged).HasColumnName("FLAGGED");
            entity.Property(e => e.Flaggeddate).HasColumnName("FLAGGEDDATE");
            entity.Property(e => e.Flaggedreason).HasColumnName("FLAGGEDREASON");
            entity.Property(e => e.Incidentreport)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INCIDENTREPORT");
            entity.Property(e => e.Insureddenormid).HasColumnName("INSUREDDENORMID");
            entity.Property(e => e.Insuredpremises)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INSUREDPREMISES");
            entity.Property(e => e.Isoenabled)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISOENABLED");
            entity.Property(e => e.Isostatus).HasColumnName("ISOSTATUS");
            entity.Property(e => e.Lobcode).HasColumnName("LOBCODE");
            entity.Property(e => e.Lockingcolumn).HasColumnName("LOCKINGCOLUMN");
            entity.Property(e => e.Losscause).HasColumnName("LOSSCAUSE");
            entity.Property(e => e.Lossdate).HasColumnName("LOSSDATE");
            entity.Property(e => e.Losslocationid).HasColumnName("LOSSLOCATIONID");
            entity.Property(e => e.Losstype).HasColumnName("LOSSTYPE");
            entity.Property(e => e.Maincontacttype).HasColumnName("MAINCONTACTTYPE");
            entity.Property(e => e.Permissionrequired).HasColumnName("PERMISSIONREQUIRED");
            entity.Property(e => e.Policyid).HasColumnName("POLICYID");
            entity.Property(e => e.Preexdisblty)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PREEXDISBLTY");
            entity.Property(e => e.Previousgroupid).HasColumnName("PREVIOUSGROUPID");
            entity.Property(e => e.Previoususerid).HasColumnName("PREVIOUSUSERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Reopendate).HasColumnName("REOPENDATE");
            entity.Property(e => e.Reopenedreason).HasColumnName("REOPENEDREASON");
            entity.Property(e => e.Reportedbytype).HasColumnName("REPORTEDBYTYPE");
            entity.Property(e => e.Reporteddate).HasColumnName("REPORTEDDATE");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScAlternateclaimnumber1).HasColumnName("SC_ALTERNATECLAIMNUMBER1");
            entity.Property(e => e.ScClaimauto).HasColumnName("SC_CLAIMAUTO");
            entity.Property(e => e.ScClaimdecision).HasColumnName("SC_CLAIMDECISION");
            entity.Property(e => e.ScClaimdecisioncomments).HasColumnName("SC_CLAIMDECISIONCOMMENTS");
            entity.Property(e => e.ScClaimeventquestions).HasColumnName("SC_CLAIMEVENTQUESTIONS");
            entity.Property(e => e.ScClaimproctype).HasColumnName("SC_CLAIMPROCTYPE");
            entity.Property(e => e.ScClaimreconcilereport).HasColumnName("SC_CLAIMRECONCILEREPORT");
            entity.Property(e => e.ScClaimrejectreason).HasColumnName("SC_CLAIMREJECTREASON");
            entity.Property(e => e.ScClosedoutcome).HasColumnName("SC_CLOSEDOUTCOME");
            entity.Property(e => e.ScDependentsequencenumber).HasColumnName("SC_DEPENDENTSEQUENCENUMBER");
            entity.Property(e => e.ScDuplicate).HasColumnName("SC_DUPLICATE");
            entity.Property(e => e.ScIdrstatus).HasColumnName("SC_IDRSTATUS");
            entity.Property(e => e.ScIsaccidentclaim)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ISACCIDENTCLAIM");
            entity.Property(e => e.ScLegacyclaimno).HasColumnName("SC_LEGACYCLAIMNO");
            entity.Property(e => e.ScLosscause).HasColumnName("SC_LOSSCAUSE");
            entity.Property(e => e.ScPolicybrand).HasColumnName("SC_POLICYBRAND");
            entity.Property(e => e.ScSignificantinjurydate).HasColumnName("SC_SIGNIFICANTINJURYDATE");
            entity.Property(e => e.ScWpreasoncode).HasColumnName("SC_WPREASONCODE");
            entity.Property(e => e.Segment).HasColumnName("SEGMENT");
            entity.Property(e => e.Showmedicalfirstinfo).HasColumnName("SHOWMEDICALFIRSTINFO");
            entity.Property(e => e.Siescalatesiu).HasColumnName("SIESCALATESIU");
            entity.Property(e => e.Siscore).HasColumnName("SISCORE");
            entity.Property(e => e.Siustatus).HasColumnName("SIUSTATUS");
            entity.Property(e => e.State).HasColumnName("STATE");
            entity.Property(e => e.Strategy).HasColumnName("STRATEGY");
            entity.Property(e => e.Supplementalworkloadweight).HasColumnName("SUPPLEMENTALWORKLOADWEIGHT");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Validationlevel).HasColumnName("VALIDATIONLEVEL");
            entity.Property(e => e.Workloadweight).HasColumnName("WORKLOADWEIGHT");
        });

        modelBuilder.Entity<Claimaccess>(entity =>
        {
            entity.ToTable("CLAIMACCESS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Anyone)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ANYONE");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Groupid).HasColumnName("GROUPID");
            entity.Property(e => e.Permission).HasColumnName("PERMISSION");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Securityzoneid).HasColumnName("SECURITYZONEID");
            entity.Property(e => e.Userid).HasColumnName("USERID");
        });

        modelBuilder.Entity<Claimassociation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLAIMASSOC");

            entity.ToTable("CLAIMASSOCIATION");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimassoctype).HasColumnName("CLAIMASSOCTYPE");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Title).HasColumnName("TITLE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Claimauto>(entity =>
        {
            entity.ToTable("CLAIMAUTO");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Differentialpricingind)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DIFFERENTIALPRICINGIND");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Updatedfromcentretab)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UPDATEDFROMCENTRETAB");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Claimcontact>(entity =>
        {
            entity.ToTable("CLAIMCONTACT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimantflag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLAIMANTFLAG");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Contactid).HasColumnName("CONTACTID");
            entity.Property(e => e.Contactnamedenorm).HasColumnName("CONTACTNAMEDENORM");
            entity.Property(e => e.Contactprohibited)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CONTACTPROHIBITED");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Personfirstnamedenorm).HasColumnName("PERSONFIRSTNAMEDENORM");
            entity.Property(e => e.Personlastnamedenorm).HasColumnName("PERSONLASTNAMEDENORM");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Claimcontactrole>(entity =>
        {
            entity.ToTable("CLAIMCONTACTROLE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ACTIVE");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimcontactid).HasColumnName("CLAIMCONTACTID");
            entity.Property(e => e.Comments).HasColumnName("COMMENTS");
            entity.Property(e => e.Coveredpartytype).HasColumnName("COVEREDPARTYTYPE");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Exposureid).HasColumnName("EXPOSUREID");
            entity.Property(e => e.Incidentid).HasColumnName("INCIDENTID");
            entity.Property(e => e.Matterid).HasColumnName("MATTERID");
            entity.Property(e => e.Partynumber).HasColumnName("PARTYNUMBER");
            entity.Property(e => e.Policyid).HasColumnName("POLICYID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Role).HasColumnName("ROLE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Claimeventquestion>(entity =>
        {
            entity.ToTable("CLAIMEVENTQUESTIONS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Interimclosure)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INTERIMCLOSURE");
            entity.Property(e => e.Isdisputeoccurred)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISDISPUTEOCCURRED");
            entity.Property(e => e.Nominaldefendantaccident)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NOMINALDEFENDANTACCIDENT");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Claimexception>(entity =>
        {
            entity.ToTable("CLAIMEXCEPTION");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Exchecktime).HasColumnName("EXCHECKTIME");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
        });

        modelBuilder.Entity<Claiminassociation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLAIMINASSOC");

            entity.ToTable("CLAIMINASSOCIATION");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimassociationid).HasColumnName("CLAIMASSOCIATIONID");
            entity.Property(e => e.Claiminfoid).HasColumnName("CLAIMINFOID");
            entity.Property(e => e.Primaryclaim)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRIMARYCLAIM");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
        });

        modelBuilder.Entity<Claimindicator>(entity =>
        {
            entity.ToTable("CLAIMINDICATOR");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Ison)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISON");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Whenon).HasColumnName("WHENON");
        });

        modelBuilder.Entity<Claiminfo>(entity =>
        {
            entity.ToTable("CLAIMINFO");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Claimnumber).HasColumnName("CLAIMNUMBER");
            entity.Property(e => e.Coveragelinematchdatainfovalid)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COVERAGELINEMATCHDATAINFOVALID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Donotdestroy)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DONOTDESTROY");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Rootpublicid).HasColumnName("ROOTPUBLICID");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Claimmetric>(entity =>
        {
            entity.ToTable("CLAIMMETRIC");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Activityskipped)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ACTIVITYSKIPPED");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Claimmetriccategory).HasColumnName("CLAIMMETRICCATEGORY");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Initialreserve).HasColumnName("INITIALRESERVE");
            entity.Property(e => e.Integervalue).HasColumnName("INTEGERVALUE");
            entity.Property(e => e.Isopen)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISOPEN");
            entity.Property(e => e.Nextoverduetime).HasColumnName("NEXTOVERDUETIME");
            entity.Property(e => e.Percentvalue).HasColumnName("PERCENTVALUE");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Skipped)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SKIPPED");
            entity.Property(e => e.Starttime).HasColumnName("STARTTIME");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Totalreservechange).HasColumnName("TOTALRESERVECHANGE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Claimmetricrecalctime>(entity =>
        {
            entity.ToTable("CLAIMMETRICRECALCTIME");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Lockingcolumn).HasColumnName("LOCKINGCOLUMN");
            entity.Property(e => e.Metriclimitgeneration).HasColumnName("METRICLIMITGENERATION");
            entity.Property(e => e.Nextrecalculationtime).HasColumnName("NEXTRECALCULATIONTIME");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Claimrpt>(entity =>
        {
            entity.ToTable("CLAIMRPT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Availablereserves).HasColumnName("AVAILABLERESERVES");
            entity.Property(e => e.Availableresrvrprtng).HasColumnName("AVAILABLERESRVRPRTNG");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Futurepayments).HasColumnName("FUTUREPAYMENTS");
            entity.Property(e => e.Futurepaymentsrprtng).HasColumnName("FUTUREPAYMENTSRPRTNG");
            entity.Property(e => e.Openrecoveryreserves).HasColumnName("OPENRECOVERYRESERVES");
            entity.Property(e => e.Openrecoveryresrprtng).HasColumnName("OPENRECOVERYRESRPRTNG");
            entity.Property(e => e.Openreserves).HasColumnName("OPENRESERVES");
            entity.Property(e => e.Openreservesrprtng).HasColumnName("OPENRESERVESRPRTNG");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Remainingreserves).HasColumnName("REMAININGRESERVES");
            entity.Property(e => e.Remainingresrvrprtng).HasColumnName("REMAININGRESRVRPRTNG");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Totalpayments).HasColumnName("TOTALPAYMENTS");
            entity.Property(e => e.Totalpaymentsrprtng).HasColumnName("TOTALPAYMENTSRPRTNG");
            entity.Property(e => e.Totalrecoveries).HasColumnName("TOTALRECOVERIES");
            entity.Property(e => e.Totalrecoveriesrprtng).HasColumnName("TOTALRECOVERIESRPRTNG");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Claimsignificantdate>(entity =>
        {
            entity.ToTable("CLAIMSIGNIFICANTDATE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Significantdate).HasColumnName("SIGNIFICANTDATE");
            entity.Property(e => e.Significantdatetype).HasColumnName("SIGNIFICANTDATETYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Claimsnapshot>(entity =>
        {
            entity.ToTable("CLAIMSNAPSHOT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimdata).HasColumnName("CLAIMDATA");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Compressed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COMPRESSED");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Encryptionversion).HasColumnName("ENCRYPTIONVERSION");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Snapshotdate).HasColumnName("SNAPSHOTDATE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.ToTable("COMPLAINT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Assignedbyuserid).HasColumnName("ASSIGNEDBYUSERID");
            entity.Property(e => e.Assignedgroupid).HasColumnName("ASSIGNEDGROUPID");
            entity.Property(e => e.Assigneduserid).HasColumnName("ASSIGNEDUSERID");
            entity.Property(e => e.Assignmentdate).HasColumnName("ASSIGNMENTDATE");
            entity.Property(e => e.Assignmentstatus).HasColumnName("ASSIGNMENTSTATUS");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Complainantexpectationdesc).HasColumnName("COMPLAINANTEXPECTATIONDESC");
            entity.Property(e => e.ComplaintcategoryExtid).HasColumnName("COMPLAINTCATEGORY_EXTID");
            entity.Property(e => e.Complaintnumber).HasColumnName("COMPLAINTNUMBER");
            entity.Property(e => e.Contactid).HasColumnName("CONTACTID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Extendedresolutiondate).HasColumnName("EXTENDEDRESOLUTIONDATE");
            entity.Property(e => e.Howreported).HasColumnName("HOWREPORTED");
            entity.Property(e => e.Incidentdate).HasColumnName("INCIDENTDATE");
            entity.Property(e => e.Iscostforactualamount)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISCOSTFORACTUALAMOUNT");
            entity.Property(e => e.Mediadescription).HasColumnName("MEDIADESCRIPTION");
            entity.Property(e => e.Mediainvolvedflag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MEDIAINVOLVEDFLAG");
            entity.Property(e => e.Previousgroupid).HasColumnName("PREVIOUSGROUPID");
            entity.Property(e => e.Previoususerid).HasColumnName("PREVIOUSUSERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Receiveddate).HasColumnName("RECEIVEDDATE");
            entity.Property(e => e.Resolutiondate).HasColumnName("RESOLUTIONDATE");
            entity.Property(e => e.Resolutiondescription).HasColumnName("RESOLUTIONDESCRIPTION");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Complaintcategory>(entity =>
        {
            entity.ToTable("COMPLAINTCATEGORY");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Categorydescription).HasColumnName("CATEGORYDESCRIPTION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Isdisabled)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISDISABLED");
            entity.Property(e => e.Isinuse)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISINUSE");
            entity.Property(e => e.Policytype).HasColumnName("POLICYTYPE");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Subcategorydescription).HasColumnName("SUBCATEGORYDESCRIPTION");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Complainthandler>(entity =>
        {
            entity.ToTable("COMPLAINTHANDLER");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Complaintid).HasColumnName("COMPLAINTID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Userid).HasColumnName("USERID");
        });

        modelBuilder.Entity<Complainthistory>(entity =>
        {
            entity.ToTable("COMPLAINTHISTORY");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.ComplaintcategoryExtid).HasColumnName("COMPLAINTCATEGORY_EXTID");
            entity.Property(e => e.Complaintid).HasColumnName("COMPLAINTID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Extendedresolutiondate).HasColumnName("EXTENDEDRESOLUTIONDATE");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Receiveddate).HasColumnName("RECEIVEDDATE");
            entity.Property(e => e.Resolutiondate).HasColumnName("RESOLUTIONDATE");
            entity.Property(e => e.Resolutiondescription).HasColumnName("RESOLUTIONDESCRIPTION");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Userid).HasColumnName("USERID");
        });

        modelBuilder.Entity<Complaintnote>(entity =>
        {
            entity.ToTable("COMPLAINTNOTE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Adviceinstructions).HasColumnName("ADVICEINSTRUCTIONS");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Complaintid).HasColumnName("COMPLAINTID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Isrepeatcall)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISREPEATCALL");
            entity.Property(e => e.Nextaction).HasColumnName("NEXTACTION");
            entity.Property(e => e.Noteid).HasColumnName("NOTEID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Complaintparty>(entity =>
        {
            entity.ToTable("COMPLAINTPARTY");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Comments).HasColumnName("COMMENTS");
            entity.Property(e => e.Complaintid).HasColumnName("COMPLAINTID");
            entity.Property(e => e.Contactid).HasColumnName("CONTACTID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Preferedcontactmethod).HasColumnName("PREFEREDCONTACTMETHOD");
            entity.Property(e => e.Preferedcontacttime).HasColumnName("PREFEREDCONTACTTIME");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("CONTACT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Addressbookuid).HasColumnName("ADDRESSBOOKUID");
            entity.Property(e => e.Afterhours)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AFTERHOURS");
            entity.Property(e => e.Attorneylicense).HasColumnName("ATTORNEYLICENSE");
            entity.Property(e => e.AutopaymentallowedExt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AUTOPAYMENTALLOWED_EXT");
            entity.Property(e => e.Autosync).HasColumnName("AUTOSYNC");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Canmanageprojects)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CANMANAGEPROJECTS");
            entity.Property(e => e.Cellphone).HasColumnName("CELLPHONE");
            entity.Property(e => e.Claimantidtype).HasColumnName("CLAIMANTIDTYPE");
            entity.Property(e => e.CommentsExt).HasColumnName("COMMENTS_EXT");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Dateofbirth).HasColumnName("DATEOFBIRTH");
            entity.Property(e => e.DayperiodExt).HasColumnName("DAYPERIOD_EXT");
            entity.Property(e => e.Donotdestroy)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DONOTDESTROY");
            entity.Property(e => e.Emailaddress1).HasColumnName("EMAILADDRESS1");
            entity.Property(e => e.Emailaddress2).HasColumnName("EMAILADDRESS2");
            entity.Property(e => e.Employeenumber).HasColumnName("EMPLOYEENUMBER");
            entity.Property(e => e.Faxphone).HasColumnName("FAXPHONE");
            entity.Property(e => e.Firstname).HasColumnName("FIRSTNAME");
            entity.Property(e => e.Firstnamedenorm).HasColumnName("FIRSTNAMEDENORM");
            entity.Property(e => e.Formername).HasColumnName("FORMERNAME");
            entity.Property(e => e.Gender).HasColumnName("GENDER");
            entity.Property(e => e.Homephone).HasColumnName("HOMEPHONE");
            entity.Property(e => e.IssensitiveExt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISSENSITIVE_EXT");
            entity.Property(e => e.Lastname).HasColumnName("LASTNAME");
            entity.Property(e => e.Lastnamedenorm).HasColumnName("LASTNAMEDENORM");
            entity.Property(e => e.Loadrelatedcontacts)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LOADRELATEDCONTACTS");
            entity.Property(e => e.LocationrepairtypeExt).HasColumnName("LOCATIONREPAIRTYPE_EXT");
            entity.Property(e => e.Makesafe)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAKESAFE");
            entity.Property(e => e.Middlename).HasColumnName("MIDDLENAME");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.Namedenorm).HasColumnName("NAMEDENORM");
            entity.Property(e => e.Obfuscatedinternal)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OBFUSCATEDINTERNAL");
            entity.Property(e => e.Pendinglinkmessage)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PENDINGLINKMESSAGE");
            entity.Property(e => e.Postaladdress).HasColumnName("POSTALADDRESS");
            entity.Property(e => e.Preferred)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PREFERRED");
            entity.Property(e => e.Prefix).HasColumnName("PREFIX");
            entity.Property(e => e.Primaryaddressid).HasColumnName("PRIMARYADDRESSID");
            entity.Property(e => e.Primaryphone).HasColumnName("PRIMARYPHONE");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.RepairerrelationshipExt).HasColumnName("REPAIRERRELATIONSHIP_EXT");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScAcceptsawpclaims)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ACCEPTSAWPCLAIMS");
            entity.Property(e => e.ScAcceptsdriveable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ACCEPTSDRIVEABLE");
            entity.Property(e => e.ScAcceptsnondriveable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ACCEPTSNONDRIVEABLE");
            entity.Property(e => e.ScAcceptssms)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ACCEPTSSMS");
            entity.Property(e => e.ScAcceptstpafclaims)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ACCEPTSTPAFCLAIMS");
            entity.Property(e => e.ScAcceptstpvehicles)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ACCEPTSTPVEHICLES");
            entity.Property(e => e.ScAcceptsume)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ACCEPTSUME");
            entity.Property(e => e.ScAccidentsequencekey).HasColumnName("SC_ACCIDENTSEQUENCEKEY");
            entity.Property(e => e.ScAccountname).HasColumnName("SC_ACCOUNTNAME");
            entity.Property(e => e.ScAccountnumber).HasColumnName("SC_ACCOUNTNUMBER");
            entity.Property(e => e.ScActivecontact)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ACTIVECONTACT");
            entity.Property(e => e.ScActivepnetaccount)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ACTIVEPNETACCOUNT");
            entity.Property(e => e.ScAuthparty)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_AUTHPARTY");
            entity.Property(e => e.ScB2bEnabled)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_B2B_ENABLED");
            entity.Property(e => e.ScBankname).HasColumnName("SC_BANKNAME");
            entity.Property(e => e.ScBsb).HasColumnName("SC_BSB");
            entity.Property(e => e.ScBulkpayments)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_BULKPAYMENTS");
            entity.Property(e => e.ScBusinesstype).HasColumnName("SC_BUSINESSTYPE");
            entity.Property(e => e.ScCellphone).HasColumnName("SC_CELLPHONE");
            entity.Property(e => e.ScCentralbillservice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_CENTRALBILLSERVICE");
            entity.Property(e => e.ScConsolvendor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_CONSOLVENDOR");
            entity.Property(e => e.ScContactpaymentaccountseq).HasColumnName("SC_CONTACTPAYMENTACCOUNTSEQ");
            entity.Property(e => e.ScCorrespondencedelivery).HasColumnName("SC_CORRESPONDENCEDELIVERY");
            entity.Property(e => e.ScDeceased)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_DECEASED");
            entity.Property(e => e.ScFormerfirstname).HasColumnName("SC_FORMERFIRSTNAME");
            entity.Property(e => e.ScFormermiddlename).HasColumnName("SC_FORMERMIDDLENAME");
            entity.Property(e => e.ScGstregistered)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_GSTREGISTERED");
            entity.Property(e => e.ScHospitalname).HasColumnName("SC_HOSPITALNAME");
            entity.Property(e => e.ScInterpreterreqd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_INTERPRETERREQD");
            entity.Property(e => e.ScLanguage).HasColumnName("SC_LANGUAGE");
            entity.Property(e => e.ScLanguagepref).HasColumnName("SC_LANGUAGEPREF");
            entity.Property(e => e.ScLocationtype).HasColumnName("SC_LOCATIONTYPE");
            entity.Property(e => e.ScNodependantadults).HasColumnName("SC_NODEPENDANTADULTS");
            entity.Property(e => e.ScNodependantchildren).HasColumnName("SC_NODEPENDANTCHILDREN");
            entity.Property(e => e.ScOpenfriday)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_OPENFRIDAY");
            entity.Property(e => e.ScOpenmonday)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_OPENMONDAY");
            entity.Property(e => e.ScOpensaturday)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_OPENSATURDAY");
            entity.Property(e => e.ScOpensunday)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_OPENSUNDAY");
            entity.Property(e => e.ScOpenthursday)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_OPENTHURSDAY");
            entity.Property(e => e.ScOpentuesday)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_OPENTUESDAY");
            entity.Property(e => e.ScOpenwednesday)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_OPENWEDNESDAY");
            entity.Property(e => e.ScOtherphone).HasColumnName("SC_OTHERPHONE");
            entity.Property(e => e.ScOtherphonedesc).HasColumnName("SC_OTHERPHONEDESC");
            entity.Property(e => e.ScPayable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_PAYABLE");
            entity.Property(e => e.ScPaymentmethod).HasColumnName("SC_PAYMENTMETHOD");
            entity.Property(e => e.ScPaymentname).HasColumnName("SC_PAYMENTNAME");
            entity.Property(e => e.ScPaymentserviceackdate).HasColumnName("SC_PAYMENTSERVICEACKDATE");
            entity.Property(e => e.ScPaymentservicecorrid).HasColumnName("SC_PAYMENTSERVICECORRID");
            entity.Property(e => e.ScPaymentservicevendorid).HasColumnName("SC_PAYMENTSERVICEVENDORID");
            entity.Property(e => e.ScPaymentterms).HasColumnName("SC_PAYMENTTERMS");
            entity.Property(e => e.ScPaystartdate).HasColumnName("SC_PAYSTARTDATE");
            entity.Property(e => e.ScPolicytype).HasColumnName("SC_POLICYTYPE");
            entity.Property(e => e.ScPortfoliocode).HasColumnName("SC_PORTFOLIOCODE");
            entity.Property(e => e.ScProcesstypeexists)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_PROCESSTYPEEXISTS");
            entity.Property(e => e.ScRecommended)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_RECOMMENDED");
            entity.Property(e => e.ScRemittancedelivery).HasColumnName("SC_REMITTANCEDELIVERY");
            entity.Property(e => e.ScRemittancenotificationemail).HasColumnName("SC_REMITTANCENOTIFICATIONEMAIL");
            entity.Property(e => e.ScSamenotificationemail)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_SAMENOTIFICATIONEMAIL");
            entity.Property(e => e.ScSamenotificationsms)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_SAMENOTIFICATIONSMS");
            entity.Property(e => e.ScServiceablepostcodenational)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_SERVICEABLEPOSTCODENATIONAL");
            entity.Property(e => e.ScStaffnumber).HasColumnName("SC_STAFFNUMBER");
            entity.Property(e => e.ScSuspended)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_SUSPENDED");
            entity.Property(e => e.ScTradingname).HasColumnName("SC_TRADINGNAME");
            entity.Property(e => e.ScVendorengagementtype).HasColumnName("SC_VENDORENGAGEMENTTYPE");
            entity.Property(e => e.ScVendortype).HasColumnName("SC_VENDORTYPE");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Suffix).HasColumnName("SUFFIX");
            entity.Property(e => e.Taxid).HasColumnName("TAXID");
            entity.Property(e => e.Taxstatus).HasColumnName("TAXSTATUS");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Validationlevel).HasColumnName("VALIDATIONLEVEL");
            entity.Property(e => e.Vendortype).HasColumnName("VENDORTYPE");
            entity.Property(e => e.W9received)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("W9RECEIVED");
            entity.Property(e => e.WatchlistproviderExt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("WATCHLISTPROVIDER_EXT");
            entity.Property(e => e.Workphone).HasColumnName("WORKPHONE");
        });

        modelBuilder.Entity<Coverage>(entity =>
        {
            entity.ToTable("COVERAGE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Currency).HasColumnName("CURRENCY");
            entity.Property(e => e.Effectivedate).HasColumnName("EFFECTIVEDATE");
            entity.Property(e => e.Expirationdate).HasColumnName("EXPIRATIONDATE");
            entity.Property(e => e.OccupationExt).HasColumnName("OCCUPATION_EXT");
            entity.Property(e => e.Policyid).HasColumnName("POLICYID");
            entity.Property(e => e.PremiumstatusExt).HasColumnName("PREMIUMSTATUS_EXT");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Riskunitid).HasColumnName("RISKUNITID");
            entity.Property(e => e.ScCoveragesourcekey).HasColumnName("SC_COVERAGESOURCEKEY");
            entity.Property(e => e.ScRawproduct).HasColumnName("SC_RAWPRODUCT");
            entity.Property(e => e.ScStatus).HasColumnName("SC_STATUS");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.TermenddateExt).HasColumnName("TERMENDDATE_EXT");
            entity.Property(e => e.TermstartdateExt).HasColumnName("TERMSTARTDATE_EXT");
            entity.Property(e => e.Type).HasColumnName("TYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Credential>(entity =>
        {
            entity.ToTable("CREDENTIAL");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ACTIVE");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Failedattempts).HasColumnName("FAILEDATTEMPTS");
            entity.Property(e => e.Lockdate).HasColumnName("LOCKDATE");
            entity.Property(e => e.Obfuscatedinternal)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OBFUSCATEDINTERNAL");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Username).HasColumnName("USERNAME");
            entity.Property(e => e.Usernamedenorm).HasColumnName("USERNAMEDENORM");
        });

        modelBuilder.Entity<CsvdataFile>(entity =>
        {
            entity.ToTable("CSVDataFiles");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FileName).HasMaxLength(1000);
            entity.Property(e => e.FilePath).HasMaxLength(1000);
            entity.Property(e => e.TableName).HasMaxLength(500);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("DOCUMENT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Author).HasColumnName("AUTHOR");
            entity.Property(e => e.Authordenorm).HasColumnName("AUTHORDENORM");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimcontactid).HasColumnName("CLAIMCONTACTID");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Datemodified).HasColumnName("DATEMODIFIED");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Dms)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DMS");
            entity.Property(e => e.Docuid).HasColumnName("DOCUID");
            entity.Property(e => e.Documentidentifier).HasColumnName("DOCUMENTIDENTIFIER");
            entity.Property(e => e.Documentidentifierdenorm).HasColumnName("DOCUMENTIDENTIFIERDENORM");
            entity.Property(e => e.ExposetocustomerExt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EXPOSETOCUSTOMER_EXT");
            entity.Property(e => e.Exposureid).HasColumnName("EXPOSUREID");
            entity.Property(e => e.Inbound)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INBOUND");
            entity.Property(e => e.Mimetype).HasColumnName("MIMETYPE");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.Namedenorm).HasColumnName("NAMEDENORM");
            entity.Property(e => e.Obsolete)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OBSOLETE");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Recipient).HasColumnName("RECIPIENT");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScActivitystatus).HasColumnName("SC_ACTIVITYSTATUS");
            entity.Property(e => e.ScArchiveonly).HasColumnName("SC_ARCHIVEONLY");
            entity.Property(e => e.ScBatchid).HasColumnName("SC_BATCHID");
            entity.Property(e => e.ScDisclosurestatus).HasColumnName("SC_DISCLOSURESTATUS");
            entity.Property(e => e.ScDocsource).HasColumnName("SC_DOCSOURCE");
            entity.Property(e => e.ScDocumentdate).HasColumnName("SC_DOCUMENTDATE");
            entity.Property(e => e.ScDocumentsize).HasColumnName("SC_DOCUMENTSIZE");
            entity.Property(e => e.ScIsversion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ISVERSION");
            entity.Property(e => e.Securitytype).HasColumnName("SECURITYTYPE");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Type).HasColumnName("TYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Empldatatoinjincident>(entity =>
        {
            entity.ToTable("EMPLDATATOINJINCIDENT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Foreignentityid).HasColumnName("FOREIGNENTITYID");
            entity.Property(e => e.Ownerid).HasColumnName("OWNERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
        });

        modelBuilder.Entity<Employmentdatum>(entity =>
        {
            entity.ToTable("EMPLOYMENTDATA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScWorkplacesize).HasColumnName("SC_WORKPLACESIZE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.WcworkweekSp).HasColumnName("WCWORKWEEK_SP");
        });

        modelBuilder.Entity<Evaluation>(entity =>
        {
            entity.ToTable("EVALUATION");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Exposureid).HasColumnName("EXPOSUREID");
            entity.Property(e => e.IsvupliftapplicableExt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISVUPLIFTAPPLICABLE_EXT");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScCollectexcessind)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_COLLECTEXCESSIND");
            entity.Property(e => e.ScSettlingtpinsurance)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_SETTLINGTPINSURANCE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Exposure>(entity =>
        {
            entity.ToTable("EXPOSURE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Assignedbyuserid).HasColumnName("ASSIGNEDBYUSERID");
            entity.Property(e => e.Assignedgroupid).HasColumnName("ASSIGNEDGROUPID");
            entity.Property(e => e.Assigneduserid).HasColumnName("ASSIGNEDUSERID");
            entity.Property(e => e.Assignmentdate).HasColumnName("ASSIGNMENTDATE");
            entity.Property(e => e.Assignmentstatus).HasColumnName("ASSIGNMENTSTATUS");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimantdenormid).HasColumnName("CLAIMANTDENORMID");
            entity.Property(e => e.Claimanttype).HasColumnName("CLAIMANTTYPE");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Claimorder).HasColumnName("CLAIMORDER");
            entity.Property(e => e.Closedate).HasColumnName("CLOSEDATE");
            entity.Property(e => e.Closedoutcome).HasColumnName("CLOSEDOUTCOME");
            entity.Property(e => e.Contactpermitted)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CONTACTPERMITTED");
            entity.Property(e => e.Coverageid).HasColumnName("COVERAGEID");
            entity.Property(e => e.Coveragesubtype).HasColumnName("COVERAGESUBTYPE");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.DecisionExt).HasColumnName("DECISION_EXT");
            entity.Property(e => e.DecisioncommentsExt).HasColumnName("DECISIONCOMMENTS_EXT");
            entity.Property(e => e.ExposurereferencenumberExt).HasColumnName("EXPOSUREREFERENCENUMBER_EXT");
            entity.Property(e => e.Exposuretier).HasColumnName("EXPOSURETIER");
            entity.Property(e => e.Exposuretype).HasColumnName("EXPOSURETYPE");
            entity.Property(e => e.Incidentid).HasColumnName("INCIDENTID");
            entity.Property(e => e.Isostatus).HasColumnName("ISOSTATUS");
            entity.Property(e => e.Jurisdictionstate).HasColumnName("JURISDICTIONSTATE");
            entity.Property(e => e.LitigationstatusExt).HasColumnName("LITIGATIONSTATUS_EXT");
            entity.Property(e => e.MaterialdamageExt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MATERIALDAMAGE_EXT");
            entity.Property(e => e.Metriclimitgeneration).HasColumnName("METRICLIMITGENERATION");
            entity.Property(e => e.Previousgroupid).HasColumnName("PREVIOUSGROUPID");
            entity.Property(e => e.Previoususerid).HasColumnName("PREVIOUSUSERID");
            entity.Property(e => e.Primarycoverage).HasColumnName("PRIMARYCOVERAGE");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.ReasonwithoutprejudiceExt).HasColumnName("REASONWITHOUTPREJUDICE_EXT");
            entity.Property(e => e.Reopendate).HasColumnName("REOPENDATE");
            entity.Property(e => e.Reopenedreason).HasColumnName("REOPENEDREASON");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Rigroupsetexternally)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RIGROUPSETEXTERNALLY");
            entity.Property(e => e.Segment).HasColumnName("SEGMENT");
            entity.Property(e => e.Settledate).HasColumnName("SETTLEDATE");
            entity.Property(e => e.State).HasColumnName("STATE");
            entity.Property(e => e.Strategy).HasColumnName("STRATEGY");
            entity.Property(e => e.Supplementalworkloadweight).HasColumnName("SUPPLEMENTALWORKLOADWEIGHT");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Validationlevel).HasColumnName("VALIDATIONLEVEL");
            entity.Property(e => e.Wcpreexdisblty)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("WCPREEXDISBLTY");
            entity.Property(e => e.Workloadweight).HasColumnName("WORKLOADWEIGHT");
        });

        modelBuilder.Entity<Exposuremetric>(entity =>
        {
            entity.ToTable("EXPOSUREMETRIC");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Activityskipped)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ACTIVITYSKIPPED");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Exposureid).HasColumnName("EXPOSUREID");
            entity.Property(e => e.Integervalue).HasColumnName("INTEGERVALUE");
            entity.Property(e => e.Isopen)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISOPEN");
            entity.Property(e => e.Percentvalue).HasColumnName("PERCENTVALUE");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Skipped)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SKIPPED");
            entity.Property(e => e.Starttime).HasColumnName("STARTTIME");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Exposurerpt>(entity =>
        {
            entity.ToTable("EXPOSURERPT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Availablereserves).HasColumnName("AVAILABLERESERVES");
            entity.Property(e => e.Availableresrvrprtng).HasColumnName("AVAILABLERESRVRPRTNG");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Exposureid).HasColumnName("EXPOSUREID");
            entity.Property(e => e.Futurepayments).HasColumnName("FUTUREPAYMENTS");
            entity.Property(e => e.Futurepaymentsrprtng).HasColumnName("FUTUREPAYMENTSRPRTNG");
            entity.Property(e => e.Openrecoveryreserves).HasColumnName("OPENRECOVERYRESERVES");
            entity.Property(e => e.Openrecoveryresrprtng).HasColumnName("OPENRECOVERYRESRPRTNG");
            entity.Property(e => e.Openreserves).HasColumnName("OPENRESERVES");
            entity.Property(e => e.Openreservesrprtng).HasColumnName("OPENRESERVESRPRTNG");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Remainingreserves).HasColumnName("REMAININGRESERVES");
            entity.Property(e => e.Remainingresrvrprtng).HasColumnName("REMAININGRESRVRPRTNG");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Totalpayments).HasColumnName("TOTALPAYMENTS");
            entity.Property(e => e.Totalpaymentsrprtng).HasColumnName("TOTALPAYMENTSRPRTNG");
            entity.Property(e => e.Totalrecoveries).HasColumnName("TOTALRECOVERIES");
            entity.Property(e => e.Totalrecoveriesrprtng).HasColumnName("TOTALRECOVERIESRPRTNG");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Fllog>(entity =>
        {
            entity.ToTable("FLLogs");

            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("GROUP");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Grouptype).HasColumnName("GROUPTYPE");
            entity.Property(e => e.Loadfactor).HasColumnName("LOADFACTOR");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScGroupstrategy).HasColumnName("SC_GROUPSTRATEGY");
            entity.Property(e => e.Securityzoneid).HasColumnName("SECURITYZONEID");
            entity.Property(e => e.Supervisorid).HasColumnName("SUPERVISORID");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Validationlevel).HasColumnName("VALIDATIONLEVEL");
            entity.Property(e => e.Worldvisible)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("WORLDVISIBLE");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.ToTable("HISTORY");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Customtype).HasColumnName("CUSTOMTYPE");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Eventtimestamp).HasColumnName("EVENTTIMESTAMP");
            entity.Property(e => e.Exposureid).HasColumnName("EXPOSUREID");
            entity.Property(e => e.Matterid).HasColumnName("MATTERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Type).HasColumnName("TYPE");
            entity.Property(e => e.Userid).HasColumnName("USERID");
        });

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.ToTable("INCIDENT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Ambulanceused)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AMBULANCEUSED");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.ClaimanttypeExt).HasColumnName("CLAIMANTTYPE_EXT");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Detailedinjurytype).HasColumnName("DETAILEDINJURYTYPE");
            entity.Property(e => e.Employmentdataid).HasColumnName("EMPLOYMENTDATAID");
            entity.Property(e => e.FaultratingExt).HasColumnName("FAULTRATING_EXT");
            entity.Property(e => e.FirstnoticeindicatorExt).HasColumnName("FIRSTNOTICEINDICATOR_EXT");
            entity.Property(e => e.Generalinjurytype).HasColumnName("GENERALINJURYTYPE");
            entity.Property(e => e.HowreportedExt).HasColumnName("HOWREPORTED_EXT");
            entity.Property(e => e.LosscauseExt).HasColumnName("LOSSCAUSE_EXT");
            entity.Property(e => e.Lostwages)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LOSTWAGES");
            entity.Property(e => e.PrimarybodyfunctionExt).HasColumnName("PRIMARYBODYFUNCTION_EXT");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.RehabilitationreferralindExt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("REHABILITATIONREFERRALIND_EXT");
            entity.Property(e => e.ReportedbytypeExt).HasColumnName("REPORTEDBYTYPE_EXT");
            entity.Property(e => e.ReporteddateExt).HasColumnName("REPORTEDDATE_EXT");
            entity.Property(e => e.ReportonlyExt).HasColumnName("REPORTONLY_EXT");
            entity.Property(e => e.ResultofinjuryExt).HasColumnName("RESULTOFINJURY_EXT");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScClaimeventquestions).HasColumnName("SC_CLAIMEVENTQUESTIONS");
            entity.Property(e => e.ScInjuryquestions).HasColumnName("SC_INJURYQUESTIONS");
            entity.Property(e => e.Severity).HasColumnName("SEVERITY");
            entity.Property(e => e.StatutorybenefitsExt).HasColumnName("STATUTORYBENEFITS_EXT");
            entity.Property(e => e.StatutorycareExtid).HasColumnName("STATUTORYCARE_EXTID");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Incidentaddress>(entity =>
        {
            entity.ToTable("INCIDENTADDRESS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasColumnName("ADDRESS");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Incidentid).HasColumnName("INCIDENTID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Incidentcontact>(entity =>
        {
            entity.ToTable("INCIDENTCONTACT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Contact).HasColumnName("CONTACT");
            entity.Property(e => e.ContactroleExt).HasColumnName("CONTACTROLE_EXT");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Incidentid).HasColumnName("INCIDENTID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Injuryquestion>(entity =>
        {
            entity.ToTable("INJURYQUESTIONS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimantdied)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLAIMANTDIED");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Deathdate).HasColumnName("DEATHDATE");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScRehabstatusid).HasColumnName("SC_REHABSTATUSID");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Legacyclaimdetail>(entity =>
        {
            entity.ToTable("LEGACYCLAIMDETAILS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Legacyclaimcategory).HasColumnName("LEGACYCLAIMCATEGORY");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Legalengagement>(entity =>
        {
            entity.ToTable("LEGALENGAGEMENT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Externalreference).HasColumnName("EXTERNALREFERENCE");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Requeststatus).HasColumnName("REQUESTSTATUS");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Litstatustypeline>(entity =>
        {
            entity.ToTable("LITSTATUSTYPELINE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Completiondate).HasColumnName("COMPLETIONDATE");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Litigationstatus).HasColumnName("LITIGATIONSTATUS");
            entity.Property(e => e.Matterid).HasColumnName("MATTERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Startdate).HasColumnName("STARTDATE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Matter>(entity =>
        {
            entity.ToTable("MATTER");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Assignedbyuserid).HasColumnName("ASSIGNEDBYUSERID");
            entity.Property(e => e.Assignedgroupid).HasColumnName("ASSIGNEDGROUPID");
            entity.Property(e => e.Assigneduserid).HasColumnName("ASSIGNEDUSERID");
            entity.Property(e => e.Assignmentdate).HasColumnName("ASSIGNMENTDATE");
            entity.Property(e => e.Assignmentstatus).HasColumnName("ASSIGNMENTSTATUS");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Closedate).HasColumnName("CLOSEDATE");
            entity.Property(e => e.Courttype).HasColumnName("COURTTYPE");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Legalspecialty).HasColumnName("LEGALSPECIALTY");
            entity.Property(e => e.Mattertype).HasColumnName("MATTERTYPE");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.Previousgroupid).HasColumnName("PREVIOUSGROUPID");
            entity.Property(e => e.Previoususerid).HasColumnName("PREVIOUSUSERID");
            entity.Property(e => e.Primarycause).HasColumnName("PRIMARYCAUSE");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Reopenedreason).HasColumnName("REOPENEDREASON");
            entity.Property(e => e.Resolution).HasColumnName("RESOLUTION");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Subrorelated)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SUBRORELATED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Validationlevel).HasColumnName("VALIDATIONLEVEL");
        });

        modelBuilder.Entity<Matterexposure>(entity =>
        {
            entity.ToTable("MATTEREXPOSURE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Exposureid).HasColumnName("EXPOSUREID");
            entity.Property(e => e.Matterid).HasColumnName("MATTERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("NOTE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Activityid).HasColumnName("ACTIVITYID");
            entity.Property(e => e.Authorid).HasColumnName("AUTHORID");
            entity.Property(e => e.Authoringdate).HasColumnName("AUTHORINGDATE");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Body).HasColumnName("BODY");
            entity.Property(e => e.Claimcontactid).HasColumnName("CLAIMCONTACTID");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.ClaimnumberRefOnly).HasColumnName("CLAIMNUMBER_REF_ONLY");
            entity.Property(e => e.Confidential)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CONFIDENTIAL");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.ExpcustomernoteExt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EXPCUSTOMERNOTE_EXT");
            entity.Property(e => e.Exposureid).HasColumnName("EXPOSUREID");
            entity.Property(e => e.ExptocustselfserviceExt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EXPTOCUSTSELFSERVICE_EXT");
            entity.Property(e => e.Language).HasColumnName("LANGUAGE");
            entity.Property(e => e.Matterid).HasColumnName("MATTERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScIsmanualnote)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_ISMANUALNOTE");
            entity.Property(e => e.Securitytype).HasColumnName("SECURITYTYPE");
            entity.Property(e => e.Subject).HasColumnName("SUBJECT");
            entity.Property(e => e.Topic).HasColumnName("TOPIC");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.ToTable("POLICY");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Accountnumber).HasColumnName("ACCOUNTNUMBER");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Cancellationdate).HasColumnName("CANCELLATIONDATE");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Currency).HasColumnName("CURRENCY");
            entity.Property(e => e.Effectivedate).HasColumnName("EFFECTIVEDATE");
            entity.Property(e => e.Expirationdate).HasColumnName("EXPIRATIONDATE");
            entity.Property(e => e.Foreigncoverage)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FOREIGNCOVERAGE");
            entity.Property(e => e.Origeffectivedate).HasColumnName("ORIGEFFECTIVEDATE");
            entity.Property(e => e.Otherinsurance)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OTHERINSURANCE");
            entity.Property(e => e.Policynumber).HasColumnName("POLICYNUMBER");
            entity.Property(e => e.Policytype).HasColumnName("POLICYTYPE");
            entity.Property(e => e.Producercode).HasColumnName("PRODUCERCODE");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Retroactivedate).HasColumnName("RETROACTIVEDATE");
            entity.Property(e => e.Returntoworkprgm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RETURNTOWORKPRGM");
            entity.Property(e => e.ScBrand).HasColumnName("SC_BRAND");
            entity.Property(e => e.ScGstexempt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_GSTEXEMPT");
            entity.Property(e => e.ScGstregistered)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_GSTREGISTERED");
            entity.Property(e => e.ScIntermedtype).HasColumnName("SC_INTERMEDTYPE");
            entity.Property(e => e.ScStampdutyexempt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SC_STAMPDUTYEXEMPT");
            entity.Property(e => e.ScUnderwritingcompany).HasColumnName("SC_UNDERWRITINGCOMPANY");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Totalproperties).HasColumnName("TOTALPROPERTIES");
            entity.Property(e => e.Totalvehicles).HasColumnName("TOTALVEHICLES");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Validationlevel).HasColumnName("VALIDATIONLEVEL");
            entity.Property(e => e.Verified)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VERIFIED");
        });

        modelBuilder.Entity<Policylocation>(entity =>
        {
            entity.ToTable("POLICYLOCATION");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Addressid).HasColumnName("ADDRESSID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Locationnumber).HasColumnName("LOCATIONNUMBER");
            entity.Property(e => e.Policyid).HasColumnName("POLICYID");
            entity.Property(e => e.Primarylocation)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRIMARYLOCATION");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Riskunit>(entity =>
        {
            entity.ToTable("RISKUNIT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Policyid).HasColumnName("POLICYID");
            entity.Property(e => e.Policylocationid).HasColumnName("POLICYLOCATIONID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Runumber).HasColumnName("RUNUMBER");
            entity.Property(e => e.Subtype).HasColumnName("SUBTYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Scheduledevent>(entity =>
        {
            entity.ToTable("SCHEDULEDEVENT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Comments).HasColumnName("COMMENTS");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Eventname).HasColumnName("EVENTNAME");
            entity.Property(e => e.Paramname1).HasColumnName("PARAMNAME1");
            entity.Property(e => e.Paramname2).HasColumnName("PARAMNAME2");
            entity.Property(e => e.Paramtype1).HasColumnName("PARAMTYPE1");
            entity.Property(e => e.Paramtype2).HasColumnName("PARAMTYPE2");
            entity.Property(e => e.Paramvalue1).HasColumnName("PARAMVALUE1");
            entity.Property(e => e.Paramvalue2).HasColumnName("PARAMVALUE2");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Retrycount).HasColumnName("RETRYCOUNT");
            entity.Property(e => e.Scheduleddatetime).HasColumnName("SCHEDULEDDATETIME");
            entity.Property(e => e.Type).HasColumnName("TYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Securityzone>(entity =>
        {
            entity.ToTable("SECURITYZONE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Specialneed>(entity =>
        {
            entity.ToTable("SPECIALNEED");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimfkid).HasColumnName("CLAIMFKID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.ScSpecialneed).HasColumnName("SC_SPECIALNEED");
            entity.Property(e => e.ScSpecialneedcomment).HasColumnName("SC_SPECIALNEEDCOMMENT");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USER");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Authorityprofileid).HasColumnName("AUTHORITYPROFILEID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Contactid).HasColumnName("CONTACTID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Credentialid).HasColumnName("CREDENTIALID");
            entity.Property(e => e.Defaultcountry).HasColumnName("DEFAULTCOUNTRY");
            entity.Property(e => e.Defaultphonecountry).HasColumnName("DEFAULTPHONECOUNTRY");
            entity.Property(e => e.Department).HasColumnName("DEPARTMENT");
            entity.Property(e => e.Externaluser)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EXTERNALUSER");
            entity.Property(e => e.Jobtitle).HasColumnName("JOBTITLE");
            entity.Property(e => e.Language).HasColumnName("LANGUAGE");
            entity.Property(e => e.Locale).HasColumnName("LOCALE");
            entity.Property(e => e.Obfuscatedinternal)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OBFUSCATEDINTERNAL");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Systemusertype).HasColumnName("SYSTEMUSERTYPE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
            entity.Property(e => e.Usersettingsid).HasColumnName("USERSETTINGSID");
            entity.Property(e => e.Vacationstatus).HasColumnName("VACATIONSTATUS");
            entity.Property(e => e.Validationlevel).HasColumnName("VALIDATIONLEVEL");
        });

        modelBuilder.Entity<Userroleassign>(entity =>
        {
            entity.ToTable("USERROLEASSIGN");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ACTIVE");
            entity.Property(e => e.Assignedgroupid).HasColumnName("ASSIGNEDGROUPID");
            entity.Property(e => e.Assigneduserid).HasColumnName("ASSIGNEDUSERID");
            entity.Property(e => e.Assignmentstatus).HasColumnName("ASSIGNMENTSTATUS");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Claimid).HasColumnName("CLAIMID");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Role).HasColumnName("ROLE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        modelBuilder.Entity<Usersetting>(entity =>
        {
            entity.ToTable("USERSETTINGS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beanversion).HasColumnName("BEANVERSION");
            entity.Property(e => e.Createtime).HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid).HasColumnName("CREATEUSERID");
            entity.Property(e => e.Lastnclaims).HasColumnName("LASTNCLAIMS");
            entity.Property(e => e.Numopenclaims).HasColumnName("NUMOPENCLAIMS");
            entity.Property(e => e.Publicid).HasColumnName("PUBLICID");
            entity.Property(e => e.Retired).HasColumnName("RETIRED");
            entity.Property(e => e.Startuppage).HasColumnName("STARTUPPAGE");
            entity.Property(e => e.Updatetime).HasColumnName("UPDATETIME");
            entity.Property(e => e.Updateuserid).HasColumnName("UPDATEUSERID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

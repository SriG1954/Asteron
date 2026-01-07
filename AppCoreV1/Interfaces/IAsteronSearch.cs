using AppCoreV1.AsteronModels;
using AppCoreV1.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreV1.Interfaces
{
    public interface IAsteronSearch
    {
        Task<PaginatedList<Actassignhistory>> SearchActassignhistory(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Actassignhistory> GetActassignhistory(string id);

        Task<PaginatedList<Activity>> SearchActivity(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Activity> GetActivity(string id);

        Task<PaginatedList<Activitydocument>> SearchActivitydocument(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Activitydocument> GetActivitydocument(string id);

        Task<PaginatedList<Activitypattern>> SearchActivitypattern(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Activitypattern> GetActivitypattern(string id);

        Task<PaginatedList<Address>> SearchAddress(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Address> GetAddress(string id);

        Task<PaginatedList<Allocatedclaimnumber>> SearchAllocatedclaimnumber(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Allocatedclaimnumber> GetAllocatedclaimnumber(string id);

        Task<PaginatedList<Authorityprofile>> SearchAuthorityprofile(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Authorityprofile> GetAuthorityprofile(string id);

        Task<PaginatedList<Bodypart>> SearchBodypart(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Bodypart> GetBodypart(string id);

        Task<PaginatedList<Claim>> SearchClaim(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claim> GetClaim(string id);

        Task<PaginatedList<Claimaccess>> SearchClaimaccess(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimaccess> GetClaimaccess(string id);

        Task<PaginatedList<Claimassociation>> SearchClaimassociation(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimassociation> GetClaimassociation(string id);

        Task<PaginatedList<Claimauto>> SearchClaimauto(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimauto> GetClaimauto(string id);

        Task<PaginatedList<Claimcontact>> SearchClaimcontact(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimcontact> GetClaimcontact(string id);

        Task<PaginatedList<Claimcontactrole>> SearchClaimcontactrole(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimcontactrole> GetClaimcontactrole(string id);

        Task<PaginatedList<Claimeventquestion>> SearchClaimeventquestion(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimeventquestion> GetClaimeventquestion(string id);

        Task<PaginatedList<Claimexception>> SearchClaimexception(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimexception> GetClaimexception(string id);

        Task<PaginatedList<Claiminassociation>> SearchClaiminassociation(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claiminassociation> GetClaiminassociation(string id);

        Task<PaginatedList<Claimindicator>> SearchClaimindicator(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimindicator> GetClaimindicator(string id);

        Task<PaginatedList<Claiminfo>> SearchClaiminfo(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claiminfo> GetClaiminfo(string id);

        Task<PaginatedList<Claimmetric>> SearchClaimmetric(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimmetric> GetClaimmetric(string id);

        Task<PaginatedList<Claimmetricrecalctime>> SearchClaimmetricrecalctime(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimmetricrecalctime> GetClaimmetricrecalctime(string id);

        Task<PaginatedList<Claimrpt>> SearchClaimrpt(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimrpt> GetClaimrpt(string id);

        Task<PaginatedList<Claimsignificantdate>> SearchClaimsignificantdate(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimsignificantdate> GetClaimsignificantdate(string id);

        Task<PaginatedList<Claimsnapshot>> SearchClaimsnapshot(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claimsnapshot> GetClaimsnapshot(string id);

        Task<PaginatedList<Complaint>> SearchComplaint(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Complaint> GetComplaint(string id);

        Task<PaginatedList<Complaintcategory>> SearchComplaintcategory(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Complaintcategory> GetComplaintcategory(string id);

        Task<PaginatedList<Complainthandler>> SearchComplainthandler(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Complainthandler> GetComplainthandler(string id);

        Task<PaginatedList<Complainthistory>> SearchComplainthistory(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Complainthistory> GetComplainthistory(string id);

        Task<PaginatedList<Complaintnote>> SearchComplaintnote(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Complaintnote> GetComplaintnote(string id);

        Task<PaginatedList<Complaintparty>> SearchComplaintparty(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Complaintparty> GetComplaintparty(string id);

        Task<PaginatedList<Contact>> SearchContact(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Contact> GetContact(string id);

        Task<PaginatedList<Coverage>> SearchCoverage(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Coverage> GetCoverage(string id);

        Task<PaginatedList<Credential>> SearchCredential(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Credential> GetCredential(string id);

        Task<PaginatedList<CsvdataFile>> SearchCsvdataFile(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<CsvdataFile> GetCsvdataFile(string id);

        Task<PaginatedList<Document>> SearchDocument(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Document> GetDocument(string id);

        Task<PaginatedList<Empldatatoinjincident>> SearchEmpldatatoinjincident(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Empldatatoinjincident> GetEmpldatatoinjincident(string id);

        Task<PaginatedList<Employmentdatum>> SearchEmploymentdatum(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Employmentdatum> GetEmploymentdatum(string id);

        Task<PaginatedList<Evaluation>> SearchEvaluation(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Evaluation> GetEvaluation(string id);

        Task<PaginatedList<Exposure>> SearchExposure(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Exposure> GetExposure(string id);

        Task<PaginatedList<Exposuremetric>> SearchExposuremetric(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Exposuremetric> GetExposuremetric(string id);

        Task<PaginatedList<Exposurerpt>> SearchExposurerpt(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Exposurerpt> GetExposurerpt(string id);

        Task<PaginatedList<Fllog>> SearchFllog(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Fllog> GetFllog(string id);

        Task<PaginatedList<Group>> SearchGroup(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Group> GetGroup(string id);

        Task<PaginatedList<History>> SearchHistory(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<History> GetHistory(string id);

        Task<PaginatedList<Incident>> SearchIncident(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Incident> GetIncident(string id);

        Task<PaginatedList<Incidentaddress>> SearchIncidentaddress(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Incidentaddress> GetIncidentaddress(string id);

        Task<PaginatedList<Incidentcontact>> SearchIncidentcontact(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Incidentcontact> GetIncidentcontact(string id);

        Task<PaginatedList<Injuryquestion>> SearchInjuryquestion(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Injuryquestion> GetInjuryquestion(string id);

        Task<PaginatedList<Legacyclaimdetail>> SearchLegacyclaimdetail(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Legacyclaimdetail> GetLegacyclaimdetail(string id);

        Task<PaginatedList<Legalengagement>> SearchLegalengagement(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Legalengagement> GetLegalengagement(string id);

        Task<PaginatedList<Litstatustypeline>> SearchLitstatustypeline(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Litstatustypeline> GetLitstatustypeline(string id);

        Task<PaginatedList<Matter>> SearchMatter(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Matter> GetMatter(string id);

        Task<PaginatedList<Matterexposure>> SearchMatterexposure(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Matterexposure> GetMatterexposure(string id);

        Task<PaginatedList<Note>> SearchNote(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Note> GetNote(string id);

        Task<PaginatedList<Policy>> SearchPolicy(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Policy> GetPolicy(string id);

        Task<PaginatedList<Policylocation>> SearchPolicylocation(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Policylocation> GetPolicylocation(string id);

        Task<PaginatedList<Riskunit>> SearchRiskunit(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Riskunit> GetRiskunit(string id);

        Task<PaginatedList<Scheduledevent>> SearchScheduledevent(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Scheduledevent> GetScheduledevent(string id);

        Task<PaginatedList<Securityzone>> SearchSecurityzone(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Securityzone> GetSecurityzone(string id);

        Task<PaginatedList<Specialneed>> SearchSpecialneed(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Specialneed> GetSpecialneed(string id);

        Task<PaginatedList<User>> SearchUser(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<User> GetUser(string id);

        Task<PaginatedList<Userroleassign>> SearchUserroleassign(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Userroleassign> GetUserroleassign(string id);

        Task<PaginatedList<Usersetting>> SearchUsersetting(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Usersetting> GetUsersetting(string id);

    }
}

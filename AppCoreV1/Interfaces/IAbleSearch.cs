using AppCoreV1.ABLEModels;
using AppCoreV1.Data;
using AppCoreV1.Helper;
using System.Threading.Tasks;

namespace AppCoreV1.Interfaces
{
    public interface IAbleSearch
    {
        AbleDBContext GetAbleContext();
        Task<bool> AddSiteLog(SiteLog sitelog);
        Task<bool> AddSiteLog(string message, string type);
        Task<PaginatedList<AbleSiteUser>> SearchAbleSiteUser(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<AbleSiteUser> GetAbleSiteUser(string id);
        Task<PaginatedList<SiteLog>> SearchSiteLog(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<SiteLog> GetSiteLog(string id);
        Task<AbleSiteUser> GetSiteUser(string id);
        Task<PaginatedList<ReportRequest>> SearchReportRequest(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ReportRequest> GetReportRequest(string id);
        Task<PaginatedList<ReportRequest>> SearchNewRequest(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ReportRequest> UpdateReportRequest(int id, int status);

        Task<bool> CreatePageAndClassesV1();
        List<string> GetModelSearchColumnsV1(string modelname);
        Task<PaginatedList<Claimbenefitmv>> SearchClaimbenefitmv(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);
        Task<PaginatedList<Claimbenefitmv>> SearchClaimbenefitmvD(string column, string search, string column1, string search1, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);

        Task<Claimbenefitmv> GetClaimbenefitmv(string id, int appflag = 1);
        Task<Claimbenefitmv> GetClaimbenefitmvByClaimNo(string id);

        Task<PaginatedList<Paymentsummarymv>> SearchPaymentsummarymv(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);
        Task<Paymentsummarymv> GetPaymentsummarymv(string id);

        Task<PaginatedList<Taskmv>> SearchTaskmv(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);
        Task<Taskmv> GetTaskmv(string id);

        Task<PaginatedList<RptAbleuser>> SearchRptAbleuser(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<RptAbleuser> GetRptAbleuser(string id);

        Task<PaginatedList<RptAbleusersallrole>> SearchRptAbleusersallrole(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<RptAbleusersallrole> GetRptAbleusersallrole(string id);


        Task<PaginatedList<RptActionsservice>> SearchRptActionsservice(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptActionsservice> GetRptActionsservice(string id);

        Task<PaginatedList<RptCaseaction>> SearchRptCaseaction(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);
        Task<RptCaseaction> GetRptCaseaction(string id);
        Task<RptCaseaction> GetRptCaseactionByClaimNo(string id);

        Task<PaginatedList<RptClaimbenefitactuarialrec>> SearchRptClaimbenefitactuarialrec(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptClaimbenefitactuarialrec> GetRptClaimbenefitactuarialrec(string id);

        Task<PaginatedList<RptClaimBenefitactuarialrecl>> SearchRptClaimBenefitactuarialrecl(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptClaimBenefitactuarialrecl> GetRptClaimBenefitactuarialrecl(string id);

        Task<PaginatedList<RptClaimbenefitgroup>> SearchRptClaimbenefitgroup(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptClaimbenefitgroup> GetRptClaimbenefitgroup(string id);

        Task<PaginatedList<RptClaimbenefitreinsurance>> SearchRptClaimbenefitreinsurance(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptClaimbenefitreinsurance> GetRptClaimbenefitreinsurance(string id);

        Task<PaginatedList<RptClaimbenefitw>> SearchRptClaimbenefitw(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptClaimbenefitw> GetRptClaimbenefitw(string id);

        Task<PaginatedList<RptClaimcasedecipha>> SearchRptClaimcasedecipha(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptClaimcasedecipha> GetRptClaimcasedecipha(string id);


        Task<PaginatedList<RptClaimexpense>> SearchRptClaimexpense(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptClaimexpense> GetRptClaimexpense(string id);

        Task<PaginatedList<RptClaimparticipant>> SearchRptClaimparticipant(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptClaimparticipant> GetRptClaimparticipant(string id);

        Task<PaginatedList<RptClosedtaskreport>> SearchRptClosedtaskreport(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptClosedtaskreport> GetRptClosedtaskreport(string id);

        Task<PaginatedList<RptCmpaction>> SearchRptCmpaction(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptCmpaction> GetRptCmpaction(string id);

        Task<PaginatedList<RptCmpgoaldatemovement>> SearchRptCmpgoaldatemovement(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptCmpgoaldatemovement> GetRptCmpgoaldatemovement(string id);

        Task<PaginatedList<RptCmpplanstatus>> SearchRptCmpplanstatus(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptCmpplanstatus> GetRptCmpplanstatus(string id);

        Task<PaginatedList<RptCmpservice>> SearchRptCmpservice(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);
        Task<RptCmpservice> GetRptCmpservice(string id);

        Task<PaginatedList<RptCompliant>> SearchRptCompliant(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptCompliant> GetRptCompliant(string id);

        Task<PaginatedList<RptDocumentreport>> SearchRptDocumentreport(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);
        Task<RptDocumentreport> GetRptDocumentreport(string id);

        Task<PaginatedList<RptEnquirycasereport>> SearchRptEnquirycasereport(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<RptEnquirycasereport> GetRptEnquirycasereport(string id);

        Task<PaginatedList<RptHcrcompletednote>> SearchRptHcrcompletednote(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptHcrcompletednote> GetRptHcrcompletednote(string id);

        Task<PaginatedList<RptOpentask>> SearchRptOpentask(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptOpentask> GetRptOpentask(string id);

        Task<PaginatedList<RptOverrideriskreport>> SearchRptOverrideriskreport(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptOverrideriskreport> GetRptOverrideriskreport(string id);

        Task<PaginatedList<RptPaymentsummaryl>> SearchRptPaymentsummaryl(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptPaymentsummaryl> GetRptPaymentsummaryl(string id);

        Task<PaginatedList<RptPhoneenquiry>> SearchRptPhoneenquiry(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptPhoneenquiry> GetRptPhoneenquiry(string id);

        Task<PaginatedList<RptRecoveryrehabnote>> SearchRptRecoveryrehabnote(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptRecoveryrehabnote> GetRptRecoveryrehabnote(string id);

        Task<PaginatedList<RptTaskreportgroup>> SearchRptTaskreportgroup(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptTaskreportgroup> GetRptTaskreportgroup(string id);

        Task<PaginatedList<RptTaskreportreinsurance>> SearchRptTaskreportreinsurance(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0);
        Task<RptTaskreportreinsurance> GetRptTaskreportreinsurance(string id);
        Task<PartySearch> GetPartySearch(string id);

        Task<PaginatedList<Party>> SearchParty(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Party> GetParty(string id);
        Task<PaginatedList<PartySearch>> SearchPartySearch(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);


        Task<PaginatedList<PartyAddress>> SearchPartyAddress(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<PartyAddress> GetPartyAddress(string id, int appflag = 1);
        Task<PartyAddress> GetPartyAddressById(string pc, string pi);

        Task<PaginatedList<PartyContact>> SearchPartyContact(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<PartyContact> GetPartyContact(string id);
        Task<PartyContact> GetPartyContactById(string pc, string pi);

        Task<PaginatedList<Case>> SearchCase(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Case> GetCase(string id);
        Task<Case> GetCaseByClaimNo(string id, int appflag = 1);
        Task<PaginatedList<Case>> GetChildCases(string id, int appflag = 1);
        Task<List<Case>> GetLinkedCases(string id, int appflag = 1);

        Task<PaginatedList<CaseLinker>> SearchCaseLinker(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<CaseLinker> GetCaseLinker(string id);

        Task<PaginatedList<CaseParty>> SearchCaseParty(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<CaseParty> GetCaseParty(string id);

        Task<PaginatedList<CaseValidation>> SearchCaseValidation(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<CaseValidation> GetCaseValidation(string id);

        Task<PaginatedList<Claim>> SearchClaim(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Claim> GetClaim(string id);
        Task<Claim> GetClaimByClaimNumber(string id, int appflag = 1);
        Task<Claim> GetClaimByClaimNumberV1(string id);

        Task<PaginatedList<ClaimIncapacityPeriod>> SearchClaimIncapacityPeriod(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<ClaimIncapacityPeriod> GetClaimIncapacityPeriod(string id);

        Task<PaginatedList<ClaimPolicy>> SearchClaimPolicy(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ClaimPolicy> GetClaimPolicy(string id);

        Task<PaginatedList<ClaimPolicyCoverage>> SearchClaimPolicyCoverage(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ClaimPolicyCoverage> GetClaimPolicyCoverage(string id);

        Task<PaginatedList<ClaimPolicyEntitlement>> SearchClaimPolicyEntitlement(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ClaimPolicyEntitlement> GetClaimPolicyEntitlement(string id);

        Task<PaginatedList<ClaimPolicyExclusion>> SearchClaimPolicyExclusion(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ClaimPolicyExclusion> GetClaimPolicyExclusion(string id);

        Task<PaginatedList<ClaimPolicyReinsurance>> SearchClaimPolicyReinsurance(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ClaimPolicyReinsurance> GetClaimPolicyReinsurance(string id);

        Task<PaginatedList<Note1>> SearchNote1(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<PaginatedList<CaseNotes>> SearchNotes(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);

        Task<Note1> GetNote1(string id, int appflag = 1);
        Task<PaginatedList<Note1>> SearchNotesPS(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);

        Task<PaginatedList<ContactDetail>> SearchContactDetail(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ContactDetail> GetContactDetail(string id);

        Task<PaginatedList<DepartmentUser>> SearchDepartmentUser(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<DepartmentUser> GetDepartmentUser(string id);

        Task<PaginatedList<Benefit>> SearchBenefit(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);
        Task<Benefit> GetBenefit(string id, int appflag = 1);

        Task<PaginatedList<BenefitExclusion>> SearchBenefitExclusion(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<BenefitExclusion> GetBenefitExclusion(string id);

        Task<PaginatedList<BenefitReInsurance>> SearchBenefitReInsurance(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<BenefitReInsurance> GetBenefitReInsurance(string id);

        Task<PaginatedList<DocumentA>> SearchDocument(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<DocumentA> GetDocument(string id, int appflag = 1);
        Task<PaginatedList<DocumentA>> SearchDocumentA(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);


        Task<PaginatedList<DocumentGroup>> SearchDocumentGroup(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<DocumentGroup> GetDocumentGroup(string id);

        Task<PaginatedList<DocumentGroupLink>> SearchDocumentGroupLink(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<DocumentGroupLink> GetDocumentGroupLink(string id);

        Task<PaginatedList<DocumentUser>> SearchDocumentUser(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<DocumentUser> GetDocumentUser(string id);

        Task<PaginatedList<Earning>> SearchEarning(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Earning> GetEarning(string id);

        Task<PaginatedList<Goal>> SearchGoal(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Goal> GetGoal(string id);

        Task<PaginatedList<LifeArea>> SearchLifeArea(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<LifeArea> GetLifeArea(string id);

        Task<PaginatedList<MedicalCode>> SearchMedicalCode(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<MedicalCode> GetMedicalCode(string id, int appflag = 1);

        Task<PaginatedList<Note2>> SearchNote2(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<Note2> GetNote2(string id, int appflag = 1);

        Task<PaginatedList<OutstandingRequest>> SearchOutstandingRequest(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<OutstandingRequest> GetOutstandingRequest(string id);

        Task<PaginatedList<OutstandingRequestDocument>> SearchOutstandingRequestDocument(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<OutstandingRequestDocument> GetOutstandingRequestDocument(string id);

        Task<PaginatedList<OutstandingRequestHistory>> SearchOutstandingRequestHistory(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<OutstandingRequestHistory> GetOutstandingRequestHistory(string id);

        Task<PaginatedList<Process>> SearchProcess(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Process> GetProcess(string id);

        Task<PaginatedList<ProcessHistory>> SearchProcessHistory(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ProcessHistory> GetProcessHistory(string id);

        Task<PaginatedList<TaskA>> SearchTaskA(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<TaskA> GetTaskA(string id);

        Task<PaginatedList<TaskHistory>> SearchTaskHistory(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<TaskHistory> GetTaskHistory(string id);

        Task<GeneralClaim> GetGeneralClaim(string id);

        Task<PaginatedList<Policy>> SearchPolicy(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<Policy> GetPolicy(string id, int appflag = 1);
        Task<PaginatedList<PolicySearch>> SearchPolicySearch(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1);

        Task<PaginatedList<Contact>> SearchContact(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<Contact> GetContact(string id, int appflag = 1);

        Task<PaginatedList<CoverageSearch>> SearchCoverageSearch(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<CoverageSearch> GetCoverageSearch(string id, int appflag = 1);


        Task<PaginatedList<Occupation>> SearchOccupation(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<Occupation> GetOccupation(string id);
        Task<List<Occupation>> GetOccupationByClaimNumber(string id);


        Task<PaginatedList<ClaimOccupation>> SearchClaimOccupation(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<ClaimOccupation> GetClaimOccupation(string id);


        Task<PaginatedList<ClaimPeriod>> SearchClaimPeriod(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ClaimPeriod> GetClaimPeriod(string id);

        Task<TabCMP> GetTabCMP(string id, int appflag);


        Task<PaginatedList<ClientGoal>> SearchClientGoal(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ClientGoal> GetClientGoal(string id);

 
        Task<PaginatedList<ActionA>> SearchActionA(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ActionA> GetActionA(string id);

        Task<List<CaseAction>> SearchCaseAction(string search, int appId);


        Task<PaginatedList<ActionHistory>> SearchActionHistory(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<ActionHistoryEx> GetActionHistory(string id);

        Task<PaginatedList<AbleEmail>> SearchEmail(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<AbleEmail> GetEmail(string id);

        Task<PaginatedList<AbleIssue>> SearchAbleIssue(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<AbleIssue> GetAbleIssue(string id);
    }
}

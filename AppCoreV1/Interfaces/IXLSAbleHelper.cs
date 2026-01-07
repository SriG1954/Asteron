using AppCoreV1.ABLEModels;
using AppCoreV1.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreV1.Interfaces
{
    public interface IXLSAbleHelper
    {
        Task<byte[]> GetClaimbenefitmvs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetClaimbenefitmv(string id, int appflag = 1);

        Task<byte[]> GetPaymentsummarymvs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetPaymentsummarymv(string id);

        Task<byte[]> GetTaskmvs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetTaskmv(string id);

        Task<byte[]> GetRptAbleusers(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptAbleuser(string id);

        Task<byte[]> GetRptAbleusersallroles(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptAbleusersallrole(string id);


        Task<byte[]> GetRptActionsservices(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptActionsservice(string id);

        Task<byte[]> GetRptCaseactions(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetRptCaseaction(string id);

        Task<byte[]> GetRptClaimbenefitactuarialrecs(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptClaimbenefitactuarialrec(string id);

        Task<byte[]> GetRptClaimBenefitactuarialrecls(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptClaimBenefitactuarialrecl(string id);

        Task<byte[]> GetRptClaimbenefitgroups(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptClaimbenefitgroup(string id);

        Task<byte[]> GetRptClaimbenefitreinsurances(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptClaimbenefitreinsurance(string id);

        Task<byte[]> GetRptClaimbenefitws(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptClaimbenefitw(string id);

        Task<byte[]> GetRptClaimcasedeciphas(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptClaimcasedecipha(string id);


        Task<byte[]> GetRptClaimexpenses(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptClaimexpense(string id);

        Task<byte[]> GetRptClaimparticipants(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptClaimparticipant(string id);

        Task<byte[]> GetRptClosedtaskreports(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptClosedtaskreport(string id);

        Task<byte[]> GetRptCmpactions(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptCmpaction(string id);

        Task<byte[]> GetRptCmpgoaldatemovements(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptCmpgoaldatemovement(string id);

        Task<byte[]> GetRptCmpplanstatuss(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptCmpplanstatus(string id);

        Task<byte[]> GetRptCmpservices(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptCmpservice(string id);

        Task<byte[]> GetRptCompliants(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptCompliant(string id);

        Task<byte[]> GetRptDocumentreports(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetRptDocumentreport(string id);

        Task<byte[]> GetRptEnquirycasereports(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptEnquirycasereport(string id);

        Task<byte[]> GetRptHcrcompletednotes(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptHcrcompletednote(string id);

        Task<byte[]> GetRptOpentasks(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptOpentask(string id);

        Task<byte[]> GetRptOverrideriskreports(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptOverrideriskreport(string id);

        Task<byte[]> GetRptPaymentsummaryls(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptPaymentsummaryl(string id);

        Task<byte[]> GetRptPhoneenquirys(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptPhoneenquiry(string id);

        Task<byte[]> GetRptRecoveryrehabnotes(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptRecoveryrehabnote(string id);

        Task<byte[]> GetRptTaskreportgroups(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptTaskreportgroup(string id);

        Task<byte[]> GetRptTaskreportreinsurances(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetRptTaskreportreinsurance(string id);

        Task<byte[]> GetPartys(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetParty(string id);

        Task<byte[]> GetPartyAddresss(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetPartyAddress(string id, int appflag = 1);

        Task<byte[]> GetPartyContacts(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetPartyContact(string id);

        Task<byte[]> GetCases(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetCase(string id);

        Task<byte[]> GetClaims(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetClaim(string id);

        Task<byte[]> GetPolicys(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetPolicy(string id, int appflag = 1);

        Task<byte[]> GetBenefits(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetBenefit(string id, int appflag = 1);

        Task<byte[]> GetNote1s(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetNote1(string id, int appflag = 1);

        Task<byte[]> GetMedicalCodes(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetMedicalCode(string id, int appflag = 1);

        Task<byte[]> GetCoverageSearchs(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetCoverageSearch(string id);

        Task<byte[]> GetPartySearchs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetPartySearch(string id);

        Task<byte[]> GetDocuments(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetDocument(string id, int appflag = 1);

        Task<byte[]> GetCaseValidations(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetCaseValidation(string id);

        Task<byte[]> GetOutstandingRequests(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetOutstandingRequest(string id);

        Task<byte[]> GetTaskAs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetTaskA(string id);

        Task<byte[]> GetContacts(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1);
        Task<byte[]> GetContact(string id, int appflag = 1);


        Task<byte[]> GetOccupations(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetOccupation(string id);


        Task<byte[]> GetClaimOccupations(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetClaimOccupation(string id);


        Task<byte[]> GetClaimPeriods(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetClaimPeriod(string id);

        Task<byte[]> GetClientGoals(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetClientGoal(string id);

        Task<byte[]> GetGoals(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetGoal(string id);

        Task<byte[]> GetActionAs(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetActionA(string id);

        Task<byte[]> GetLifeAreas(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetLifeArea(string id);


        Task<byte[]> GetActionHistorys(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetActionHistory(string id);

        Task<byte[]> GetAbleIssues(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetAbleIssue(string id);

        Task<byte[]> GetSiteLogs(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetSiteLog(string id);

        Task<byte[]> GetAbleSiteUsers(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetAbleSiteUser(string id);

    }
}

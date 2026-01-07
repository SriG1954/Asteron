using AppCoreV1.ABLEModels;
using AppCoreV1.Helper;

namespace AppCoreV1.Interfaces
{
    public interface IABLEExport
    {
        Task<bool> RptAbleUser();
        Task<bool> RptAbleUserRole();
        Task<bool> RptActionService();
        Task<bool> RptCaseAction();
        Task<bool> RptClaimBenefit();

        Task<bool> RptClaimBenefitActuarialRec();
        Task<bool> RptClaimBenefitGroup();
        Task<bool> RptClaimBenefitReinsurance();
        Task<bool> RptClaimBenefitWS();
        Task<bool> RptClaimCaseDecipha();
        Task<bool> RptClaimExpense();
        Task<bool> RptClaimParticipant();
        Task<bool> RptClosedTaskReport();
        Task<bool> RptCMPActions();
        Task<bool> RptCMPGDMovements();
        Task<bool> RptCMPPlanStatus();
        Task<bool> RptCMPService();
        Task<bool> RptComplaints();
        Task<bool> RptDocumentReport();
        Task<bool> RptEnquiryCaseReport();
        Task<bool> RptHCRCompletedNotes();
        Task<bool> RptOpenTask();
        Task<bool> RptOverrideRiskReport();
        Task<bool> RptPaymentSummary();

        Task<bool> RptPaymentSummaryLS();
        Task<bool> RptPhoneEnquiry();
        Task<bool> RptRecoveryRehabNote();
        Task<bool> RptTaskReport();
        Task<bool> RptTaskReportGroup();
        Task<bool> RptTaskReportReinsurance();


    }
}

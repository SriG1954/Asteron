using AppCoreV1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAppV1.Controllers
{
    public class AbleDownloadController : Controller
    {
        private readonly IXLSAbleHelper _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AbleDownloadController> _logger;

        public AbleDownloadController(IXLSAbleHelper context, IConfiguration configuration, ILogger<AbleDownloadController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<FileResult> GetClaimbenefitmvs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            try
            {
                byte[] data = null!;
                data = await _context.GetClaimbenefitmvs(column, search, pageIndex, pageSize, appflag);

                string filename = "Claimbenefitmvs" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
                return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return null!;
        }

        // Details Download
        public async Task<FileResult> GetClaimbenefitmv(string id, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetClaimbenefitmv(id, appflag);

            string filename = "Claimbenefitmv" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetPaymentsummarymvs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetPaymentsummarymvs(column, search, pageIndex, pageSize, appflag);

            string filename = "Paymentsummarymvs" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetPaymentsummarymv(string id)
        {
            byte[] data = null!;
            data = await _context.GetPaymentsummarymv(id);

            string filename = "Paymentsummarymv" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetTaskmvs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetTaskmvs(column, search, pageIndex, pageSize, appflag);

            string filename = "Taskmvs" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetTaskmv(string id)
        {
            byte[] data = null!;
            data = await _context.GetTaskmv(id);

            string filename = "Taskmv" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptAbleusers(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptAbleusers(column, search, pageIndex, pageSize);

            string filename = "RptAbleusers" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptAbleuser(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptAbleuser(id);

            string filename = "RptAbleuser" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptAbleusersallroles(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptAbleusersallroles(column, search, pageIndex, pageSize);

            string filename = "RptAbleusersallroles" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptAbleusersallrole(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptAbleusersallrole(id);

            string filename = "RptAbleusersallrole" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


        public async Task<FileResult> GetRptActionsservices(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptActionsservices(column, search, pageIndex, pageSize);

            string filename = "RptActionsservices" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptActionsservice(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptActionsservice(id);

            string filename = "RptActionsservice" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptCaseactions(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetRptCaseactions(column, search, pageIndex, pageSize, appflag);

            string filename = "RptCaseactions" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptCaseaction(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptCaseaction(id);

            string filename = "RptCaseaction" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptClaimbenefitactuarialrecs(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimbenefitactuarialrecs(column, search, pageIndex, pageSize);

            string filename = "RptClaimbenefitactuarialrecs" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptClaimbenefitactuarialrec(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimbenefitactuarialrec(id);

            string filename = "RptClaimbenefitactuarialrec" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptClaimBenefitactuarialrecls(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimBenefitactuarialrecls(column, search, pageIndex, pageSize);

            string filename = "RptClaimBenefitactuarialrecls" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptClaimBenefitactuarialrecl(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimBenefitactuarialrecl(id);

            string filename = "RptClaimBenefitactuarialrecl" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptClaimbenefitgroups(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimbenefitgroups(column, search, pageIndex, pageSize);

            string filename = "RptClaimbenefitgroups" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptClaimbenefitgroup(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimbenefitgroup(id);

            string filename = "RptClaimbenefitgroup" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptClaimbenefitreinsurances(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimbenefitreinsurances(column, search, pageIndex, pageSize);

            string filename = "RptClaimbenefitreinsurances" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptClaimbenefitreinsurance(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimbenefitreinsurance(id);

            string filename = "RptClaimbenefitreinsurance" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptClaimbenefitws(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimbenefitws(column, search, pageIndex, pageSize);

            string filename = "RptClaimbenefitws" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptClaimbenefitw(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimbenefitw(id);

            string filename = "RptClaimbenefitw" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptClaimcasedeciphas(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimcasedeciphas(column, search, pageIndex, pageSize);

            string filename = "RptClaimcasedeciphas" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptClaimcasedecipha(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimcasedecipha(id);

            string filename = "RptClaimcasedecipha" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


        public async Task<FileResult> GetRptClaimexpenses(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimexpenses(column, search, pageIndex, pageSize);

            string filename = "RptClaimexpenses" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptClaimexpense(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimexpense(id);

            string filename = "RptClaimexpense" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptClaimparticipants(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimparticipants(column, search, pageIndex, pageSize);

            string filename = "RptClaimparticipants" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptClaimparticipant(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptClaimparticipant(id);

            string filename = "RptClaimparticipant" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptClosedtaskreports(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptClosedtaskreports(column, search, pageIndex, pageSize);

            string filename = "RptClosedtaskreports" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptClosedtaskreport(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptClosedtaskreport(id);

            string filename = "RptClosedtaskreport" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptCmpactions(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptCmpactions(column, search, pageIndex, pageSize);

            string filename = "RptCmpactions" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptCmpaction(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptCmpaction(id);

            string filename = "RptCmpaction" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptCmpgoaldatemovements(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptCmpgoaldatemovements(column, search, pageIndex, pageSize);

            string filename = "RptCmpgoaldatemovements" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptCmpgoaldatemovement(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptCmpgoaldatemovement(id);

            string filename = "RptCmpgoaldatemovement" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptCmpplanstatuss(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptCmpplanstatuss(column, search, pageIndex, pageSize);

            string filename = "RptCmpplanstatuss" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptCmpplanstatus(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptCmpplanstatus(id);

            string filename = "RptCmpplanstatus" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptCmpservices(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptCmpservices(column, search, pageIndex, pageSize);

            string filename = "RptCmpservices" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptCmpservice(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptCmpservice(id);

            string filename = "RptCmpservice" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptCompliants(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptCompliants(column, search, pageIndex, pageSize);

            string filename = "RptCompliants" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptCompliant(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptCompliant(id);

            string filename = "RptCompliant" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptDocumentreports(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetRptDocumentreports(column, search, pageIndex, pageSize, appflag);

            string filename = "RptDocumentreports" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptDocumentreport(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptDocumentreport(id);

            string filename = "RptDocumentreport" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptEnquirycasereports(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptEnquirycasereports(column, search, pageIndex, pageSize);

            string filename = "RptEnquirycasereports" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptEnquirycasereport(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptEnquirycasereport(id);

            string filename = "RptEnquirycasereport" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptHcrcompletednotes(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptHcrcompletednotes(column, search, pageIndex, pageSize);

            string filename = "RptHcrcompletednotes" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptHcrcompletednote(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptHcrcompletednote(id);

            string filename = "RptHcrcompletednote" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptOpentasks(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptOpentasks(column, search, pageIndex, pageSize);

            string filename = "RptOpentasks" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptOpentask(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptOpentask(id);

            string filename = "RptOpentask" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptOverrideriskreports(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptOverrideriskreports(column, search, pageIndex, pageSize);

            string filename = "RptOverrideriskreports" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptOverrideriskreport(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptOverrideriskreport(id);

            string filename = "RptOverrideriskreport" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


        public async Task<FileResult> GetRptPaymentsummaryls(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptPaymentsummaryls(column, search, pageIndex, pageSize);

            string filename = "RptPaymentsummaryls" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptPaymentsummaryl(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptPaymentsummaryl(id);

            string filename = "RptPaymentsummaryl" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptPhoneenquirys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptPhoneenquirys(column, search, pageIndex, pageSize);

            string filename = "RptPhoneenquirys" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptPhoneenquiry(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptPhoneenquiry(id);

            string filename = "RptPhoneenquiry" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptRecoveryrehabnotes(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptRecoveryrehabnotes(column, search, pageIndex, pageSize);

            string filename = "RptRecoveryrehabnotes" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptRecoveryrehabnote(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptRecoveryrehabnote(id);

            string filename = "RptRecoveryrehabnote" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptTaskreportgroups(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptTaskreportgroups(column, search, pageIndex, pageSize);

            string filename = "RptTaskreportgroups" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptTaskreportgroup(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptTaskreportgroup(id);

            string filename = "RptTaskreportgroup" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetRptTaskreportreinsurances(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetRptTaskreportreinsurances(column, search, pageIndex, pageSize);

            string filename = "RptTaskreportreinsurances" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetRptTaskreportreinsurance(string id)
        {
            byte[] data = null!;
            data = await _context.GetRptTaskreportreinsurance(id);

            string filename = "RptTaskreportreinsurance" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetPartys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetPartys(column, search, pageIndex, pageSize);

            string filename = "Partys" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetParty(string id)
        {
            byte[] data = null!;
            data = await _context.GetParty(id);

            string filename = "Party" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetPartyAddresss(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetPartyAddresss(column, search, pageIndex, pageSize, appflag);

            string filename = "PartyAddresss" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetPartyAddress(string id, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetPartyAddress(id, appflag);

            string filename = "PartyAddress" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetPartyContacts(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetPartyContacts(column, search, pageIndex, pageSize);

            string filename = "PartyContacts" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetPartyContact(string id)
        {
            byte[] data = null!;
            data = await _context.GetPartyContact(id);

            string filename = "PartyContact" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetCases(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetCases(column, search, pageIndex, pageSize);

            string filename = "Cases" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetCase(string id)
        {
            byte[] data = null!;
            data = await _context.GetCase(id);

            string filename = "Case" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetClaims(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetClaims(column, search, pageIndex, pageSize);

            string filename = "Claims" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetClaim(string id)
        {
            byte[] data = null!;
            data = await _context.GetClaim(id);

            string filename = "Claim" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetPolicys(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetPolicys(column, search, pageIndex, pageSize, appflag);

            string filename = "Policys" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetPolicy(string id, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetPolicy(id, appflag);

            string filename = "Policy" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetBenefits(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetBenefits(column, search, pageIndex, pageSize, appflag);

            string filename = "Benefits" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetBenefit(string id, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetBenefit(id, appflag);

            string filename = "Benefit" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetNote1s(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetNote1s(column, search, pageIndex, pageSize, appflag);

            string filename = "PaymentSummary" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetNote1(string id, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetNote1(id, appflag);

            string filename = "Note2" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetMedicalCodes(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetMedicalCodes(column, search, pageIndex, pageSize, appflag);

            string filename = "MedicalCodes" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetMedicalCode(string id)
        {
            byte[] data = null!;
            data = await _context.GetMedicalCode(id);

            string filename = "MedicalCode" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetCoverageSearchs(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetCoverageSearchs(column, search, pageIndex, pageSize);

            string filename = "CoverageSearchs" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetCoverageSearch(string id)
        {
            byte[] data = null!;
            data = await _context.GetCoverageSearch(id);

            string filename = "CoverageSearch" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetPartySearchs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetPartySearchs(column, search, pageIndex, pageSize, appflag);

            string filename = "PartySearchs" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetPartySearch(string id)
        {
            byte[] data = null!;
            data = await _context.GetPartySearch(id);

            string filename = "PartySearch" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetDocuments(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetDocuments(column, search, pageIndex, pageSize, appflag);

            string filename = "Documents" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetDocument(string id, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetDocument(id, appflag);

            string filename = "Document" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetCaseValidations(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetCaseValidations(column, search, pageIndex, pageSize);

            string filename = "CaseValidations" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetOutstandingRequests(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetOutstandingRequests(column, search, pageIndex, pageSize, appflag);

            string filename = "OutstandingRequests" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetOutstandingRequest(string id)
        {
            byte[] data = null!;
            data = await _context.GetOutstandingRequest(id);

            string filename = "OutstandingRequest" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetTaskAs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetTaskAs(column, search, pageIndex, pageSize, appflag);

            string filename = "TaskAs" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetTaskA(string id)
        {
            byte[] data = null!;
            data = await _context.GetTaskA(id);

            string filename = "TaskA" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


        public async Task<FileResult> GetContacts(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            data = await _context.GetContacts(column, search, pageIndex, pageSize, appflag);

            string filename = "Contacts" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetContact(string id)
        {
            byte[] data = null!;
            data = await _context.GetContact(id);

            string filename = "Contact" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


        public async Task<FileResult> GetOccupations(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetOccupations(column, search, pageIndex, pageSize);

            string filename = "Occupations" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetOccupation(string id)
        {
            byte[] data = null!;
            data = await _context.GetOccupation(id);

            string filename = "Occupation" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


        public async Task<FileResult> GetClaimOccupations(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetClaimOccupations(column, search, pageIndex, pageSize);

            string filename = "ClaimOccupations" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetClaimOccupation(string id)
        {
            byte[] data = null!;
            data = await _context.GetClaimOccupation(id);

            string filename = "ClaimOccupation" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


        public async Task<FileResult> GetClaimPeriods(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetClaimPeriods(column, search, pageIndex, pageSize);

            string filename = "ClaimPeriods" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetClaimPeriod(string id)
        {
            byte[] data = null!;
            data = await _context.GetClaimPeriod(id);

            string filename = "ClaimPeriod" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


        public async Task<FileResult> GetClientGoals(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetClientGoals(column, search, pageIndex, pageSize);

            string filename = "ClientGoals" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetClientGoal(string id)
        {
            byte[] data = null!;
            data = await _context.GetClientGoal(id);

            string filename = "ClientGoal" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetGoals(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetGoals(column, search, pageIndex, pageSize);

            string filename = "Goals" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetGoal(string id)
        {
            byte[] data = null!;
            data = await _context.GetGoal(id);

            string filename = "Goal" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetActionAs(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetActionAs(column, search, pageIndex, pageSize);

            string filename = "ActionAs" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetActionA(string id)
        {
            byte[] data = null!;
            data = await _context.GetActionA(id);

            string filename = "ActionA" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetLifeAreas(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetLifeAreas(column, search, pageIndex, pageSize);

            string filename = "LifeAreas" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetLifeArea(string id)
        {
            byte[] data = null!;
            data = await _context.GetLifeArea(id);

            string filename = "LifeArea" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


        public async Task<FileResult> GetActionHistorys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetActionHistorys(column, search, pageIndex, pageSize);

            string filename = "ActionHistorys" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetActionHistory(string id)
        {
            byte[] data = null!;
            data = await _context.GetActionHistory(id);

            string filename = "ActionHistory" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetAbleIssues(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetAbleIssues(column, search, pageIndex, pageSize);

            string filename = "AbleIssues" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetAbleIssue(string id)
        {
            byte[] data = null!;
            data = await _context.GetAbleIssue(id);

            string filename = "AbleIssue" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetSiteLogs(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetSiteLogs(column, search, pageIndex, pageSize);

            string filename = "SiteLogs" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetSiteLog(string id)
        {
            byte[] data = null!;
            data = await _context.GetSiteLog(id);

            string filename = "SiteLog" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetAbleSiteUsers(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetAbleSiteUsers(column, search, pageIndex, pageSize);

            string filename = "AbleSiteUsers" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetAbleSiteUser(string id)
        {
            byte[] data = null!;
            data = await _context.GetAbleSiteUser(id);

            string filename = "AbleSiteUser" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


    }
}

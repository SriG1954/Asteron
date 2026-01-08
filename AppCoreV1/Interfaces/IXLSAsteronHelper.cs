using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreV1.Interfaces
{
    public interface IXLSAsteronHelper
    {
        Task<byte[]> GetClaims(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetClaim(string id);
        Task<byte[]> GetPolicys(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetPolicy(string id);
        Task<byte[]> GetNotes(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetNote(string id);
        Task<byte[]> GetDocuments(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetDocument(string id);
        Task<byte[]> GetActivitys(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetActivity(string id);
        Task<byte[]> GetHistorys(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetHistory(string id);
        Task<byte[]> GetContacts(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetContact(string id);
        Task<byte[]> GetAddresss(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetAddress(string id);
        Task<byte[]> GetCoverages(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetCoverage(string id);
        Task<byte[]> GetIncidents(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetIncident(string id);
        Task<byte[]> GetComplaints(string column, string search, int pageIndex = 1, int pageSize = 25);
        Task<byte[]> GetComplaint(string id);
    }
}

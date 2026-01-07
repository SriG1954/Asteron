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

    }
}

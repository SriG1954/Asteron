using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreV1.ABLEModels
{

    public class SearchFormViewModel
    {
        public string? Action { get; set; }     // Controller action to submit to
        public string? Controller { get; set; } // Controller name
        public string? Id { get; set; }         // Optional route param to preserve
        public string? Column { get; set; }     // Selected column
        public string? Search { get; set; }     // Search text
        public int PageIndex { get; set; } = 1; // Reset to first page on submit (optional)
        public int PageSize { get; set; } = 25; // Page size
    }


    public class PaginationViewModel
    {
        // Required
        public string Action { get; set; } = "Index";
        public string Controller { get; set; } = "Home";

        public int PageIndex { get; set; }           // current page (1-based)
        public int TotalPages { get; set; }          // total pages
        public int PageSize { get; set; } = 25;      // items per page

        // Optional labels (for localization/customization)
        public string FirstLabel { get; set; } = "First";
        public string PrevLabel { get; set; } = "Prev";
        public string NextLabel { get; set; } = "Next";
        public string LastLabel { get; set; } = "Last";

        // Optional: preserve context across pages
        public string? Id { get; set; }
        public string? Column { get; set; }
        public string? Search { get; set; }

        // Optional: any extra route values as key=value pairs
        public IDictionary<string, object>? ExtraRouteValues { get; set; }
    }

}

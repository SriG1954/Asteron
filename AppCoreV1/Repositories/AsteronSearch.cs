using AppCoreV1.AsteronModels;
using AppCoreV1.Data;
using AppCoreV1.Helper;
using AppCoreV1.Interfaces;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AppCoreV1.Repositories
{

    public class AsteronSearch: IAsteronSearch
    {
        private readonly AsteronDbContext _context;
        private readonly ILogger<AsteronSearch> _logger;
        public AsteronSearch(AsteronDbContext context, ILogger<AsteronSearch> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PaginatedList<Actassignhistory>> SearchActassignhistory(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Actassignhistory> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Actassignhistories
                            orderby c.Id ascending
                            select new Actassignhistory
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                ScActivity = c.ScActivity,
                                ScAssignedgroup = c.ScAssignedgroup,
                                ScAssignedqueue = c.ScAssignedqueue,
                                ScAssigneduser = c.ScAssigneduser,
                                ScReassignmentenddate = c.ScReassignmentenddate,
                                ScUserorqueue = c.ScUserorqueue,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString().Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;
                        case "Publicid":
                            query = query.Where(c => c.Publicid!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Actassignhistory>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Actassignhistory> GetActassignhistory(string id)
        {
            Actassignhistory item = null!;
            try
            {
                var c = await _context.Actassignhistories.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Actassignhistory
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        ScActivity = c.ScActivity,
                        ScAssignedgroup = c.ScAssignedgroup,
                        ScAssignedqueue = c.ScAssignedqueue,
                        ScAssigneduser = c.ScAssigneduser,
                        ScReassignmentenddate = c.ScReassignmentenddate,
                        ScUserorqueue = c.ScUserorqueue,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Actassignhistory();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Actassignhistory();
            }

            return item;
        }

        public async Task<PaginatedList<AsteronModels.Activity>> SearchActivity(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<AsteronModels.Activity> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Activities
                            orderby c.Id ascending
                            select new AsteronModels.Activity
                            {
                                Id = c.Id,
                                Activityclass = c.Activityclass,
                                Activitypatternid = c.Activitypatternid,
                                Assignedbyuserid = c.Assignedbyuserid,
                                Assignedgroupid = c.Assignedgroupid,
                                Assignedqueueid = c.Assignedqueueid,
                                Assigneduserid = c.Assigneduserid,
                                Assignmentdate = c.Assignmentdate,
                                Assignmentstatus = c.Assignmentstatus,
                                Autogenerated = c.Autogenerated,
                                Beanversion = c.Beanversion,
                                Claimcontactid = c.Claimcontactid,
                                Claimid = c.Claimid,
                                Closedate = c.Closedate,
                                Closeuserid = c.Closeuserid,
                                ComplaintExtid = c.ComplaintExtid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Description = c.Description,
                                Escalated = c.Escalated,
                                Escalationdate = c.Escalationdate,
                                Exposureid = c.Exposureid,
                                Externallyowned = c.Externallyowned,
                                Externalownerccid = c.Externalownerccid,
                                Generatedsource = c.Generatedsource,
                                Importance = c.Importance,
                                InitialescalationdateExt = c.InitialescalationdateExt,
                                InitialtargetdateExt = c.InitialtargetdateExt,
                                Lastvieweddate = c.Lastvieweddate,
                                Mandatory = c.Mandatory,
                                Previousgroupid = c.Previousgroupid,
                                Previousqueueid = c.Previousqueueid,
                                Previoususerid = c.Previoususerid,
                                Priority = c.Priority,
                                Publicid = c.Publicid,
                                Recurring = c.Recurring,
                                Retired = c.Retired,
                                ScRejectreason = c.ScRejectreason,
                                Status = c.Status,
                                Subject = c.Subject,
                                Subtype = c.Subtype,
                                Targetdate = c.Targetdate,
                                Type = c.Type,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Subject":
                            query = query.Where(c => c.Subject!.Contains(search));
                            break;
                        case "Subtype":
                            query = query.Where(c => c.Subtype!.ToString()!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Publicid":
                            query = query.Where(c => c.Publicid!.ToString()!.Contains(search));
                            break;

                    }
                }

                list = await PaginatedList<AsteronModels.Activity>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<AsteronModels.Activity> GetActivity(string id)
        {
            AsteronModels.Activity item = null!;
            try
            {
                var c = await _context.Activities.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new AsteronModels.Activity
                    {
                        Id = c.Id,
                        Activityclass = c.Activityclass,
                        Activitypatternid = c.Activitypatternid,
                        Assignedbyuserid = c.Assignedbyuserid,
                        Assignedgroupid = c.Assignedgroupid,
                        Assignedqueueid = c.Assignedqueueid,
                        Assigneduserid = c.Assigneduserid,
                        Assignmentdate = c.Assignmentdate,
                        Assignmentstatus = c.Assignmentstatus,
                        Autogenerated = c.Autogenerated,
                        Beanversion = c.Beanversion,
                        Claimcontactid = c.Claimcontactid,
                        Claimid = c.Claimid,
                        Closedate = c.Closedate,
                        Closeuserid = c.Closeuserid,
                        ComplaintExtid = c.ComplaintExtid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Description = c.Description,
                        Escalated = c.Escalated,
                        Escalationdate = c.Escalationdate,
                        Exposureid = c.Exposureid,
                        Externallyowned = c.Externallyowned,
                        Externalownerccid = c.Externalownerccid,
                        Generatedsource = c.Generatedsource,
                        Importance = c.Importance,
                        InitialescalationdateExt = c.InitialescalationdateExt,
                        InitialtargetdateExt = c.InitialtargetdateExt,
                        Lastvieweddate = c.Lastvieweddate,
                        Mandatory = c.Mandatory,
                        Previousgroupid = c.Previousgroupid,
                        Previousqueueid = c.Previousqueueid,
                        Previoususerid = c.Previoususerid,
                        Priority = c.Priority,
                        Publicid = c.Publicid,
                        Recurring = c.Recurring,
                        Retired = c.Retired,
                        ScRejectreason = c.ScRejectreason,
                        Status = c.Status,
                        Subject = c.Subject,
                        Subtype = c.Subtype,
                        Targetdate = c.Targetdate,
                        Type = c.Type,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Validationlevel = c.Validationlevel,
                    };
                }
                else
                {
                    item = new AsteronModels.Activity();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new AsteronModels.Activity();
            }

            return item;
        }

        public async Task<PaginatedList<Activitydocument>> SearchActivitydocument(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Activitydocument> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Activitydocuments
                            orderby c.Id ascending
                            select new Activitydocument
                            {
                                Id = c.Id,
                                Activityid = c.Activityid,
                                Beanversion = c.Beanversion,
                                Documentid = c.Documentid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Activityid":
                            query = query.Where(c => c.Activityid!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Documentid":
                            query = query.Where(c => c.Documentid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Activitydocument>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Activitydocument> GetActivitydocument(string id)
        {
            Activitydocument item = null!;
            try
            {
                var c = await _context.Activitydocuments.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Activitydocument
                    {
                        Id = c.Id,
                        Activityid = c.Activityid,
                        Beanversion = c.Beanversion,
                        Documentid = c.Documentid,
                        Publicid = c.Publicid,
                    };
                }
                else
                {
                    item = new Activitydocument();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Activitydocument();
            }

            return item;
        }

        public async Task<PaginatedList<Activitypattern>> SearchActivitypattern(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Activitypattern> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Activitypatterns
                            orderby c.Id ascending
                            select new Activitypattern
                            {
                                Id = c.Id,
                                Activityclass = c.Activityclass,
                                Automatedonly = c.Automatedonly,
                                Beanversion = c.Beanversion,
                                Category = c.Category,
                                Claimlosstype = c.Claimlosstype,
                                Closedclaimavlble = c.Closedclaimavlble,
                                Code = c.Code,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Description = c.Description,
                                Escalationbuscaltag = c.Escalationbuscaltag,
                                Escalationdays = c.Escalationdays,
                                Escalationhours = c.Escalationhours,
                                Escalationincldays = c.Escalationincldays,
                                Escalationstartpt = c.Escalationstartpt,
                                Escbuscallocpath = c.Escbuscallocpath,
                                Externallyowned = c.Externallyowned,
                                Importance = c.Importance,
                                Mandatory = c.Mandatory,
                                Priority = c.Priority,
                                Publicid = c.Publicid,
                                Recurring = c.Recurring,
                                Retired = c.Retired,
                                ScActautoassigntype = c.ScActautoassigntype,
                                ScAutoassigntogroup = c.ScAutoassigntogroup,
                                ScAutoassigntoqueue = c.ScAutoassigntoqueue,
                                ScCancompleteonworkplan = c.ScCancompleteonworkplan,
                                ScDefaultassigntype = c.ScDefaultassigntype,
                                ScIsreassignablewithclaim = c.ScIsreassignablewithclaim,
                                ScIssubjecteditable = c.ScIssubjecteditable,
                                ScScanneddocumentactivity = c.ScScanneddocumentactivity,
                                Shortsubject = c.Shortsubject,
                                Subject = c.Subject,
                                Targetbuscallocpath = c.Targetbuscallocpath,
                                Targetbuscaltag = c.Targetbuscaltag,
                                Targetdays = c.Targetdays,
                                Targethours = c.Targethours,
                                Targetincludedays = c.Targetincludedays,
                                Targetstartpoint = c.Targetstartpoint,
                                Type = c.Type,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Activityclass":
                            query = query.Where(c => c.Activityclass!.ToString()!.Contains(search));
                            break;
                        case "Automatedonly":
                            query = query.Where(c => c.Automatedonly!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Category":
                            query = query.Where(c => c.Category!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Activitypattern>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Activitypattern> GetActivitypattern(string id)
        {
            Activitypattern item = null!;
            try
            {
                var c = await _context.Activitypatterns.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Activitypattern
                    {
                        Id = c.Id,
                        Activityclass = c.Activityclass,
                        Automatedonly = c.Automatedonly,
                        Beanversion = c.Beanversion,
                        Category = c.Category,
                        Claimlosstype = c.Claimlosstype,
                        Closedclaimavlble = c.Closedclaimavlble,
                        Code = c.Code,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Description = c.Description,
                        Escalationbuscaltag = c.Escalationbuscaltag,
                        Escalationdays = c.Escalationdays,
                        Escalationhours = c.Escalationhours,
                        Escalationincldays = c.Escalationincldays,
                        Escalationstartpt = c.Escalationstartpt,
                        Escbuscallocpath = c.Escbuscallocpath,
                        Externallyowned = c.Externallyowned,
                        Importance = c.Importance,
                        Mandatory = c.Mandatory,
                        Priority = c.Priority,
                        Publicid = c.Publicid,
                        Recurring = c.Recurring,
                        Retired = c.Retired,
                        ScActautoassigntype = c.ScActautoassigntype,
                        ScAutoassigntogroup = c.ScAutoassigntogroup,
                        ScAutoassigntoqueue = c.ScAutoassigntoqueue,
                        ScCancompleteonworkplan = c.ScCancompleteonworkplan,
                        ScDefaultassigntype = c.ScDefaultassigntype,
                        ScIsreassignablewithclaim = c.ScIsreassignablewithclaim,
                        ScIssubjecteditable = c.ScIssubjecteditable,
                        ScScanneddocumentactivity = c.ScScanneddocumentactivity,
                        Shortsubject = c.Shortsubject,
                        Subject = c.Subject,
                        Targetbuscallocpath = c.Targetbuscallocpath,
                        Targetbuscaltag = c.Targetbuscaltag,
                        Targetdays = c.Targetdays,
                        Targethours = c.Targethours,
                        Targetincludedays = c.Targetincludedays,
                        Targetstartpoint = c.Targetstartpoint,
                        Type = c.Type,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Activitypattern();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Activitypattern();
            }

            return item;
        }

        public async Task<PaginatedList<Address>> SearchAddress(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Address> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Addresses
                            orderby c.Id ascending
                            select new Address
                            {
                                Id = c.Id,
                                Addressline1 = c.Addressline1,
                                Addressline2 = c.Addressline2,
                                Addressline3 = c.Addressline3,
                                Addresstype = c.Addresstype,
                                Batchgeocode = c.Batchgeocode,
                                Beanversion = c.Beanversion,
                                City = c.City,
                                Citydenorm = c.Citydenorm,
                                Country = c.Country,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Description = c.Description,
                                Geocodestatus = c.Geocodestatus,
                                Postalcode = c.Postalcode,
                                Postalcodedenorm = c.Postalcodedenorm,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                ScAddressformat = c.ScAddressformat,
                                ScPermanentchange = c.ScPermanentchange,
                                State = c.State,
                                Subtype = c.Subtype,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Addressline1":
                            query = query.Where(c => c.Addressline1!.Contains(search));
                            break;
                        case "Addressline2":
                            query = query.Where(c => c.Addressline2!.Contains(search));
                            break;
                        case "City":
                            query = query.Where(c => c.City!.Contains(search));
                            break;
                        case "Country":
                            query = query.Where(c => c.Country!.ToString()!.Contains(search));
                            break;
                        case "Postalcode":
                            query = query.Where(c => c.Postalcode!.ToString()!.Contains(search));
                            break;
                        case "Publicid":
                            query = query.Where(c => c.Publicid!.Contains(search));
                            break;

                    }
                }

                list = await PaginatedList<Address>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Address> GetAddress(string id)
        {
            Address item = null!;
            try
            {
                var c = await _context.Addresses.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Address
                    {
                        Id = c.Id,
                        Addressline1 = c.Addressline1,
                        Addressline2 = c.Addressline2,
                        Addressline3 = c.Addressline3,
                        Addresstype = c.Addresstype,
                        Batchgeocode = c.Batchgeocode,
                        Beanversion = c.Beanversion,
                        City = c.City,
                        Citydenorm = c.Citydenorm,
                        Country = c.Country,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Description = c.Description,
                        Geocodestatus = c.Geocodestatus,
                        Postalcode = c.Postalcode,
                        Postalcodedenorm = c.Postalcodedenorm,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        ScAddressformat = c.ScAddressformat,
                        ScPermanentchange = c.ScPermanentchange,
                        State = c.State,
                        Subtype = c.Subtype,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Validuntil = c.Validuntil,
                    };
                }
                else
                {
                    item = new Address();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Address();
            }

            return item;
        }

        public async Task<PaginatedList<Allocatedclaimnumber>> SearchAllocatedclaimnumber(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Allocatedclaimnumber> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Allocatedclaimnumbers
                            orderby c.Id ascending
                            select new Allocatedclaimnumber
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Claimnumber = c.Claimnumber,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Publicid = c.Publicid,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Claimnumber":
                            query = query.Where(c => c.Claimnumber!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Allocatedclaimnumber>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Allocatedclaimnumber> GetAllocatedclaimnumber(string id)
        {
            Allocatedclaimnumber item = null!;
            try
            {
                var c = await _context.Allocatedclaimnumbers.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Allocatedclaimnumber
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Claimnumber = c.Claimnumber,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Publicid = c.Publicid,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Allocatedclaimnumber();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Allocatedclaimnumber();
            }

            return item;
        }

        public async Task<PaginatedList<Authorityprofile>> SearchAuthorityprofile(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Authorityprofile> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Authorityprofiles
                            orderby c.Id ascending
                            select new Authorityprofile
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Currency = c.Currency,
                                Custom = c.Custom,
                                Description = c.Description,
                                Name = c.Name,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                ScAdditionalslimit = c.ScAdditionalslimit,
                                ScAuthjoblimit = c.ScAuthjoblimit,
                                ScExgratialimit = c.ScExgratialimit,
                                ScRecoverywriteofflimit = c.ScRecoverywriteofflimit,
                                ScRejectclaimlimit = c.ScRejectclaimlimit,
                                ScTotallosslimit = c.ScTotallosslimit,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;
                        case "Currency":
                            query = query.Where(c => c.Currency!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Authorityprofile>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Authorityprofile> GetAuthorityprofile(string id)
        {
            Authorityprofile item = null!;
            try
            {
                var c = await _context.Authorityprofiles.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Authorityprofile
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Currency = c.Currency,
                        Custom = c.Custom,
                        Description = c.Description,
                        Name = c.Name,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        ScAdditionalslimit = c.ScAdditionalslimit,
                        ScAuthjoblimit = c.ScAuthjoblimit,
                        ScExgratialimit = c.ScExgratialimit,
                        ScRecoverywriteofflimit = c.ScRecoverywriteofflimit,
                        ScRejectclaimlimit = c.ScRejectclaimlimit,
                        ScTotallosslimit = c.ScTotallosslimit,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Authorityprofile();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Authorityprofile();
            }

            return item;
        }

        public async Task<PaginatedList<Bodypart>> SearchBodypart(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Bodypart> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Bodyparts
                            orderby c.Id ascending
                            select new Bodypart
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Detailedbodypart = c.Detailedbodypart,
                                Incidentid = c.Incidentid,
                                Ordering = c.Ordering,
                                Primarybodypart = c.Primarybodypart,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;
                        case "Detailedbodypart":
                            query = query.Where(c => c.Detailedbodypart!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Bodypart>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Bodypart> GetBodypart(string id)
        {
            Bodypart item = null!;
            try
            {
                var c = await _context.Bodyparts.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Bodypart
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Detailedbodypart = c.Detailedbodypart,
                        Incidentid = c.Incidentid,
                        Ordering = c.Ordering,
                        Primarybodypart = c.Primarybodypart,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Bodypart();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Bodypart();
            }

            return item;
        }

        public async Task<PaginatedList<Claim>> SearchClaim(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claim> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claims
                            orderby c.Id ascending
                            select new Claim
                            {
                                Id = c.Id,
                                Assignedbyuserid = c.Assignedbyuserid,
                                Assignedgroupid = c.Assignedgroupid,
                                Assigneduserid = c.Assigneduserid,
                                Assignmentdate = c.Assignmentdate,
                                Assignmentstatus = c.Assignmentstatus,
                                Beanversion = c.Beanversion,
                                Claimantdenormid = c.Claimantdenormid,
                                Claimnumber = c.Claimnumber,
                                Claimtier = c.Claimtier,
                                Closedate = c.Closedate,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Currency = c.Currency,
                                Description = c.Description,
                                Donotdestroy = c.Donotdestroy,
                                Flagged = c.Flagged,
                                Flaggeddate = c.Flaggeddate,
                                Flaggedreason = c.Flaggedreason,
                                Incidentreport = c.Incidentreport,
                                Insureddenormid = c.Insureddenormid,
                                Insuredpremises = c.Insuredpremises,
                                Isoenabled = c.Isoenabled,
                                Isostatus = c.Isostatus,
                                Lobcode = c.Lobcode,
                                Lockingcolumn = c.Lockingcolumn,
                                Losscause = c.Losscause,
                                Lossdate = c.Lossdate,
                                Losslocationid = c.Losslocationid,
                                Losstype = c.Losstype,
                                Maincontacttype = c.Maincontacttype,
                                Permissionrequired = c.Permissionrequired,
                                Policyid = c.Policyid,
                                Preexdisblty = c.Preexdisblty,
                                Previousgroupid = c.Previousgroupid,
                                Previoususerid = c.Previoususerid,
                                Publicid = c.Publicid,
                                Reopendate = c.Reopendate,
                                Reopenedreason = c.Reopenedreason,
                                Reportedbytype = c.Reportedbytype,
                                Reporteddate = c.Reporteddate,
                                Retired = c.Retired,
                                ScAlternateclaimnumber1 = c.ScAlternateclaimnumber1,
                                ScClaimauto = c.ScClaimauto,
                                ScClaimdecision = c.ScClaimdecision,
                                ScClaimdecisioncomments = c.ScClaimdecisioncomments,
                                ScClaimeventquestions = c.ScClaimeventquestions,
                                ScClaimproctype = c.ScClaimproctype,
                                ScClaimreconcilereport = c.ScClaimreconcilereport,
                                ScClaimrejectreason = c.ScClaimrejectreason,
                                ScClosedoutcome = c.ScClosedoutcome,
                                ScDependentsequencenumber = c.ScDependentsequencenumber,
                                ScDuplicate = c.ScDuplicate,
                                ScIdrstatus = c.ScIdrstatus,
                                ScIsaccidentclaim = c.ScIsaccidentclaim,
                                ScLegacyclaimno = c.ScLegacyclaimno,
                                ScLosscause = c.ScLosscause,
                                ScPolicybrand = c.ScPolicybrand,
                                ScSignificantinjurydate = c.ScSignificantinjurydate,
                                ScWpreasoncode = c.ScWpreasoncode,
                                Segment = c.Segment,
                                Showmedicalfirstinfo = c.Showmedicalfirstinfo,
                                Siescalatesiu = c.Siescalatesiu,
                                Siscore = c.Siscore,
                                Siustatus = c.Siustatus,
                                State = c.State,
                                Strategy = c.Strategy,
                                Supplementalworkloadweight = c.Supplementalworkloadweight,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,
                                Validationlevel = c.Validationlevel,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Claimnumber":
                            query = query.Where(c => c.Claimnumber!.Contains(search));
                            break;
                        case "Policyid":
                            query = query.Where(c => c.Policyid!.ToString()!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Closedate":
                            query = query.Where(c => c.Closedate!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claim>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claim> GetClaim(string id)
        {
            Claim item = null!;
            try
            {
                var c = await _context.Claims.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claim
                    {
                        Id = c.Id,
                        Assignedbyuserid = c.Assignedbyuserid,
                        Assignedgroupid = c.Assignedgroupid,
                        Assigneduserid = c.Assigneduserid,
                        Assignmentdate = c.Assignmentdate,
                        Assignmentstatus = c.Assignmentstatus,
                        Beanversion = c.Beanversion,
                        Claimantdenormid = c.Claimantdenormid,
                        Claimnumber = c.Claimnumber,
                        Claimtier = c.Claimtier,
                        Closedate = c.Closedate,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Currency = c.Currency,
                        Description = c.Description,
                        Donotdestroy = c.Donotdestroy,
                        Flagged = c.Flagged,
                        Flaggeddate = c.Flaggeddate,
                        Flaggedreason = c.Flaggedreason,
                        Incidentreport = c.Incidentreport,
                        Insureddenormid = c.Insureddenormid,
                        Insuredpremises = c.Insuredpremises,
                        Isoenabled = c.Isoenabled,
                        Isostatus = c.Isostatus,
                        Lobcode = c.Lobcode,
                        Lockingcolumn = c.Lockingcolumn,
                        Losscause = c.Losscause,
                        Lossdate = c.Lossdate,
                        Losslocationid = c.Losslocationid,
                        Losstype = c.Losstype,
                        Maincontacttype = c.Maincontacttype,
                        Permissionrequired = c.Permissionrequired,
                        Policyid = c.Policyid,
                        Preexdisblty = c.Preexdisblty,
                        Previousgroupid = c.Previousgroupid,
                        Previoususerid = c.Previoususerid,
                        Publicid = c.Publicid,
                        Reopendate = c.Reopendate,
                        Reopenedreason = c.Reopenedreason,
                        Reportedbytype = c.Reportedbytype,
                        Reporteddate = c.Reporteddate,
                        Retired = c.Retired,
                        ScAlternateclaimnumber1 = c.ScAlternateclaimnumber1,
                        ScClaimauto = c.ScClaimauto,
                        ScClaimdecision = c.ScClaimdecision,
                        ScClaimdecisioncomments = c.ScClaimdecisioncomments,
                        ScClaimeventquestions = c.ScClaimeventquestions,
                        ScClaimproctype = c.ScClaimproctype,
                        ScClaimreconcilereport = c.ScClaimreconcilereport,
                        ScClaimrejectreason = c.ScClaimrejectreason,
                        ScClosedoutcome = c.ScClosedoutcome,
                        ScDependentsequencenumber = c.ScDependentsequencenumber,
                        ScDuplicate = c.ScDuplicate,
                        ScIdrstatus = c.ScIdrstatus,
                        ScIsaccidentclaim = c.ScIsaccidentclaim,
                        ScLegacyclaimno = c.ScLegacyclaimno,
                        ScLosscause = c.ScLosscause,
                        ScPolicybrand = c.ScPolicybrand,
                        ScSignificantinjurydate = c.ScSignificantinjurydate,
                        ScWpreasoncode = c.ScWpreasoncode,
                        Segment = c.Segment,
                        Showmedicalfirstinfo = c.Showmedicalfirstinfo,
                        Siescalatesiu = c.Siescalatesiu,
                        Siscore = c.Siscore,
                        Siustatus = c.Siustatus,
                        State = c.State,
                        Strategy = c.Strategy,
                        Supplementalworkloadweight = c.Supplementalworkloadweight,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Validationlevel = c.Validationlevel,
                        Workloadweight = c.Workloadweight,
                    };
                }
                else
                {
                    item = new Claim();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claim();
            }

            return item;
        }

        public async Task<PaginatedList<Claimaccess>> SearchClaimaccess(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimaccess> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimaccesses
                            orderby c.Id ascending
                            select new Claimaccess
                            {
                                Id = c.Id,
                                Anyone = c.Anyone,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Groupid = c.Groupid,
                                Permission = c.Permission,
                                Publicid = c.Publicid,
                                Securityzoneid = c.Securityzoneid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Anyone":
                            query = query.Where(c => c.Anyone!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Groupid":
                            query = query.Where(c => c.Groupid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimaccess>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimaccess> GetClaimaccess(string id)
        {
            Claimaccess item = null!;
            try
            {
                var c = await _context.Claimaccesses.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimaccess
                    {
                        Id = c.Id,
                        Anyone = c.Anyone,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Groupid = c.Groupid,
                        Permission = c.Permission,
                        Publicid = c.Publicid,
                        Securityzoneid = c.Securityzoneid,
                        Userid = c.Userid,
                    };
                }
                else
                {
                    item = new Claimaccess();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimaccess();
            }

            return item;
        }

        public async Task<PaginatedList<Claimassociation>> SearchClaimassociation(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimassociation> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimassociations
                            orderby c.Id ascending
                            select new Claimassociation
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimassoctype = c.Claimassoctype,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Description = c.Description,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Title = c.Title,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimassoctype":
                            query = query.Where(c => c.Claimassoctype!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimassociation>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimassociation> GetClaimassociation(string id)
        {
            Claimassociation item = null!;
            try
            {
                var c = await _context.Claimassociations.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimassociation
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimassoctype = c.Claimassoctype,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Description = c.Description,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Title = c.Title,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Claimassociation();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimassociation();
            }

            return item;
        }

        public async Task<PaginatedList<Claimauto>> SearchClaimauto(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimauto> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimautos
                            orderby c.Id ascending
                            select new Claimauto
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Differentialpricingind = c.Differentialpricingind,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Subtype = c.Subtype,
                                Updatedfromcentretab = c.Updatedfromcentretab,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;
                        case "Differentialpricingind":
                            query = query.Where(c => c.Differentialpricingind!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimauto>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimauto> GetClaimauto(string id)
        {
            Claimauto item = null!;
            try
            {
                var c = await _context.Claimautos.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimauto
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Differentialpricingind = c.Differentialpricingind,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Subtype = c.Subtype,
                        Updatedfromcentretab = c.Updatedfromcentretab,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Claimauto();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimauto();
            }

            return item;
        }

        public async Task<PaginatedList<Claimcontact>> SearchClaimcontact(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimcontact> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimcontacts
                            orderby c.Id ascending
                            select new Claimcontact
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimantflag = c.Claimantflag,
                                Claimid = c.Claimid,
                                Contactid = c.Contactid,
                                Contactnamedenorm = c.Contactnamedenorm,
                                Contactprohibited = c.Contactprohibited,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Personfirstnamedenorm = c.Personfirstnamedenorm,
                                Personlastnamedenorm = c.Personlastnamedenorm,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimantflag":
                            query = query.Where(c => c.Claimantflag!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Contactid":
                            query = query.Where(c => c.Contactid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimcontact>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimcontact> GetClaimcontact(string id)
        {
            Claimcontact item = null!;
            try
            {
                var c = await _context.Claimcontacts.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimcontact
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimantflag = c.Claimantflag,
                        Claimid = c.Claimid,
                        Contactid = c.Contactid,
                        Contactnamedenorm = c.Contactnamedenorm,
                        Contactprohibited = c.Contactprohibited,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Personfirstnamedenorm = c.Personfirstnamedenorm,
                        Personlastnamedenorm = c.Personlastnamedenorm,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Claimcontact();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimcontact();
            }

            return item;
        }

        public async Task<PaginatedList<Claimcontactrole>> SearchClaimcontactrole(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimcontactrole> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimcontactroles
                            orderby c.Id ascending
                            select new Claimcontactrole
                            {
                                Id = c.Id,
                                Active = c.Active,
                                Beanversion = c.Beanversion,
                                Claimcontactid = c.Claimcontactid,
                                Comments = c.Comments,
                                Coveredpartytype = c.Coveredpartytype,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Exposureid = c.Exposureid,
                                Incidentid = c.Incidentid,
                                Matterid = c.Matterid,
                                Partynumber = c.Partynumber,
                                Policyid = c.Policyid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Role = c.Role,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Active":
                            query = query.Where(c => c.Active!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimcontactid":
                            query = query.Where(c => c.Claimcontactid!.ToString()!.Contains(search));
                            break;
                        case "Comments":
                            query = query.Where(c => c.Comments!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimcontactrole>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimcontactrole> GetClaimcontactrole(string id)
        {
            Claimcontactrole item = null!;
            try
            {
                var c = await _context.Claimcontactroles.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimcontactrole
                    {
                        Id = c.Id,
                        Active = c.Active,
                        Beanversion = c.Beanversion,
                        Claimcontactid = c.Claimcontactid,
                        Comments = c.Comments,
                        Coveredpartytype = c.Coveredpartytype,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Exposureid = c.Exposureid,
                        Incidentid = c.Incidentid,
                        Matterid = c.Matterid,
                        Partynumber = c.Partynumber,
                        Policyid = c.Policyid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Role = c.Role,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Claimcontactrole();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimcontactrole();
            }

            return item;
        }

        public async Task<PaginatedList<Claimeventquestion>> SearchClaimeventquestion(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimeventquestion> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimeventquestions
                            orderby c.Id ascending
                            select new Claimeventquestion
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Interimclosure = c.Interimclosure,
                                Isdisputeoccurred = c.Isdisputeoccurred,
                                Nominaldefendantaccident = c.Nominaldefendantaccident,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Subtype = c.Subtype,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;
                        case "Interimclosure":
                            query = query.Where(c => c.Interimclosure!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimeventquestion>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimeventquestion> GetClaimeventquestion(string id)
        {
            Claimeventquestion item = null!;
            try
            {
                var c = await _context.Claimeventquestions.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimeventquestion
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Interimclosure = c.Interimclosure,
                        Isdisputeoccurred = c.Isdisputeoccurred,
                        Nominaldefendantaccident = c.Nominaldefendantaccident,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Subtype = c.Subtype,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Claimeventquestion();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimeventquestion();
            }

            return item;
        }

        public async Task<PaginatedList<Claimexception>> SearchClaimexception(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimexception> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimexceptions
                            orderby c.Id ascending
                            select new Claimexception
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Exchecktime = c.Exchecktime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Exchecktime":
                            query = query.Where(c => c.Exchecktime!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimexception>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimexception> GetClaimexception(string id)
        {
            Claimexception item = null!;
            try
            {
                var c = await _context.Claimexceptions.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimexception
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Exchecktime = c.Exchecktime,
                        Publicid = c.Publicid,
                    };
                }
                else
                {
                    item = new Claimexception();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimexception();
            }

            return item;
        }

        public async Task<PaginatedList<Claiminassociation>> SearchClaiminassociation(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claiminassociation> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claiminassociations
                            orderby c.Id ascending
                            select new Claiminassociation
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimassociationid = c.Claimassociationid,
                                Claiminfoid = c.Claiminfoid,
                                Primaryclaim = c.Primaryclaim,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimassociationid":
                            query = query.Where(c => c.Claimassociationid!.ToString()!.Contains(search));
                            break;
                        case "Claiminfoid":
                            query = query.Where(c => c.Claiminfoid!.ToString()!.Contains(search));
                            break;
                        case "Primaryclaim":
                            query = query.Where(c => c.Primaryclaim!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claiminassociation>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claiminassociation> GetClaiminassociation(string id)
        {
            Claiminassociation item = null!;
            try
            {
                var c = await _context.Claiminassociations.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claiminassociation
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimassociationid = c.Claimassociationid,
                        Claiminfoid = c.Claiminfoid,
                        Primaryclaim = c.Primaryclaim,
                        Publicid = c.Publicid,
                    };
                }
                else
                {
                    item = new Claiminassociation();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claiminassociation();
            }

            return item;
        }

        public async Task<PaginatedList<Claimindicator>> SearchClaimindicator(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimindicator> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimindicators
                            orderby c.Id ascending
                            select new Claimindicator
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Ison = c.Ison,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Subtype = c.Subtype,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimindicator>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimindicator> GetClaimindicator(string id)
        {
            Claimindicator item = null!;
            try
            {
                var c = await _context.Claimindicators.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimindicator
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Ison = c.Ison,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Subtype = c.Subtype,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Whenon = c.Whenon,
                    };
                }
                else
                {
                    item = new Claimindicator();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimindicator();
            }

            return item;
        }

        public async Task<PaginatedList<Claiminfo>> SearchClaiminfo(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claiminfo> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claiminfos
                            orderby c.Id ascending
                            select new Claiminfo
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Claimnumber = c.Claimnumber,
                                Coveragelinematchdatainfovalid = c.Coveragelinematchdatainfovalid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Donotdestroy = c.Donotdestroy,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Rootpublicid = c.Rootpublicid,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Claimnumber":
                            query = query.Where(c => c.Claimnumber!.Contains(search));
                            break;
                        case "Coveragelinematchdatainfovalid":
                            query = query.Where(c => c.Coveragelinematchdatainfovalid!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claiminfo>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claiminfo> GetClaiminfo(string id)
        {
            Claiminfo item = null!;
            try
            {
                var c = await _context.Claiminfos.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claiminfo
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Claimnumber = c.Claimnumber,
                        Coveragelinematchdatainfovalid = c.Coveragelinematchdatainfovalid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Donotdestroy = c.Donotdestroy,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Rootpublicid = c.Rootpublicid,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Claiminfo();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claiminfo();
            }

            return item;
        }

        public async Task<PaginatedList<Claimmetric>> SearchClaimmetric(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimmetric> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimmetrics
                            orderby c.Id ascending
                            select new Claimmetric
                            {
                                Id = c.Id,
                                Activityskipped = c.Activityskipped,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Claimmetriccategory = c.Claimmetriccategory,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Initialreserve = c.Initialreserve,
                                Integervalue = c.Integervalue,
                                Isopen = c.Isopen,
                                Nextoverduetime = c.Nextoverduetime,
                                Percentvalue = c.Percentvalue,
                                Publicid = c.Publicid,
                                Skipped = c.Skipped,
                                Starttime = c.Starttime,
                                Subtype = c.Subtype,
                                Totalreservechange = c.Totalreservechange,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Activityskipped":
                            query = query.Where(c => c.Activityskipped!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Claimmetriccategory":
                            query = query.Where(c => c.Claimmetriccategory!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimmetric>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimmetric> GetClaimmetric(string id)
        {
            Claimmetric item = null!;
            try
            {
                var c = await _context.Claimmetrics.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimmetric
                    {
                        Id = c.Id,
                        Activityskipped = c.Activityskipped,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Claimmetriccategory = c.Claimmetriccategory,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Initialreserve = c.Initialreserve,
                        Integervalue = c.Integervalue,
                        Isopen = c.Isopen,
                        Nextoverduetime = c.Nextoverduetime,
                        Percentvalue = c.Percentvalue,
                        Publicid = c.Publicid,
                        Skipped = c.Skipped,
                        Starttime = c.Starttime,
                        Subtype = c.Subtype,
                        Totalreservechange = c.Totalreservechange,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Claimmetric();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimmetric();
            }

            return item;
        }

        public async Task<PaginatedList<Claimmetricrecalctime>> SearchClaimmetricrecalctime(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimmetricrecalctime> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimmetricrecalctimes
                            orderby c.Id ascending
                            select new Claimmetricrecalctime
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Lockingcolumn = c.Lockingcolumn,
                                Metriclimitgeneration = c.Metriclimitgeneration,
                                Nextrecalculationtime = c.Nextrecalculationtime,
                                Publicid = c.Publicid,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimmetricrecalctime>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimmetricrecalctime> GetClaimmetricrecalctime(string id)
        {
            Claimmetricrecalctime item = null!;
            try
            {
                var c = await _context.Claimmetricrecalctimes.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimmetricrecalctime
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Lockingcolumn = c.Lockingcolumn,
                        Metriclimitgeneration = c.Metriclimitgeneration,
                        Nextrecalculationtime = c.Nextrecalculationtime,
                        Publicid = c.Publicid,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Claimmetricrecalctime();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimmetricrecalctime();
            }

            return item;
        }

        public async Task<PaginatedList<Claimrpt>> SearchClaimrpt(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimrpt> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimrpts
                            orderby c.Id ascending
                            select new Claimrpt
                            {
                                Id = c.Id,
                                Availablereserves = c.Availablereserves,
                                Availableresrvrprtng = c.Availableresrvrprtng,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Futurepayments = c.Futurepayments,
                                Futurepaymentsrprtng = c.Futurepaymentsrprtng,
                                Openrecoveryreserves = c.Openrecoveryreserves,
                                Openrecoveryresrprtng = c.Openrecoveryresrprtng,
                                Openreserves = c.Openreserves,
                                Openreservesrprtng = c.Openreservesrprtng,
                                Publicid = c.Publicid,
                                Remainingreserves = c.Remainingreserves,
                                Remainingresrvrprtng = c.Remainingresrvrprtng,
                                Retired = c.Retired,
                                Totalpayments = c.Totalpayments,
                                Totalpaymentsrprtng = c.Totalpaymentsrprtng,
                                Totalrecoveries = c.Totalrecoveries,
                                Totalrecoveriesrprtng = c.Totalrecoveriesrprtng,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Availablereserves":
                            query = query.Where(c => c.Availablereserves!.ToString()!.Contains(search));
                            break;
                        case "Availableresrvrprtng":
                            query = query.Where(c => c.Availableresrvrprtng!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimrpt>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimrpt> GetClaimrpt(string id)
        {
            Claimrpt item = null!;
            try
            {
                var c = await _context.Claimrpts.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimrpt
                    {
                        Id = c.Id,
                        Availablereserves = c.Availablereserves,
                        Availableresrvrprtng = c.Availableresrvrprtng,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Futurepayments = c.Futurepayments,
                        Futurepaymentsrprtng = c.Futurepaymentsrprtng,
                        Openrecoveryreserves = c.Openrecoveryreserves,
                        Openrecoveryresrprtng = c.Openrecoveryresrprtng,
                        Openreserves = c.Openreserves,
                        Openreservesrprtng = c.Openreservesrprtng,
                        Publicid = c.Publicid,
                        Remainingreserves = c.Remainingreserves,
                        Remainingresrvrprtng = c.Remainingresrvrprtng,
                        Retired = c.Retired,
                        Totalpayments = c.Totalpayments,
                        Totalpaymentsrprtng = c.Totalpaymentsrprtng,
                        Totalrecoveries = c.Totalrecoveries,
                        Totalrecoveriesrprtng = c.Totalrecoveriesrprtng,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Claimrpt();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimrpt();
            }

            return item;
        }

        public async Task<PaginatedList<Claimsignificantdate>> SearchClaimsignificantdate(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimsignificantdate> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimsignificantdates
                            orderby c.Id ascending
                            select new Claimsignificantdate
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Significantdate = c.Significantdate,
                                Significantdatetype = c.Significantdatetype,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimsignificantdate>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimsignificantdate> GetClaimsignificantdate(string id)
        {
            Claimsignificantdate item = null!;
            try
            {
                var c = await _context.Claimsignificantdates.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimsignificantdate
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Significantdate = c.Significantdate,
                        Significantdatetype = c.Significantdatetype,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Claimsignificantdate();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimsignificantdate();
            }

            return item;
        }

        public async Task<PaginatedList<Claimsnapshot>> SearchClaimsnapshot(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claimsnapshot> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimsnapshots
                            orderby c.Id ascending
                            select new Claimsnapshot
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimdata = c.Claimdata,
                                Claimid = c.Claimid,
                                Compressed = c.Compressed,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Encryptionversion = c.Encryptionversion,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Snapshotdate = c.Snapshotdate,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimdata":
                            query = query.Where(c => c.Claimdata!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Compressed":
                            query = query.Where(c => c.Compressed!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claimsnapshot>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimsnapshot> GetClaimsnapshot(string id)
        {
            Claimsnapshot item = null!;
            try
            {
                var c = await _context.Claimsnapshots.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Claimsnapshot
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimdata = c.Claimdata,
                        Claimid = c.Claimid,
                        Compressed = c.Compressed,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Encryptionversion = c.Encryptionversion,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Snapshotdate = c.Snapshotdate,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Claimsnapshot();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimsnapshot();
            }

            return item;
        }

        public async Task<PaginatedList<Complaint>> SearchComplaint(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Complaint> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Complaints
                            orderby c.Id ascending
                            select new Complaint
                            {
                                Id = c.Id,
                                Assignedbyuserid = c.Assignedbyuserid,
                                Assignedgroupid = c.Assignedgroupid,
                                Assigneduserid = c.Assigneduserid,
                                Assignmentdate = c.Assignmentdate,
                                Assignmentstatus = c.Assignmentstatus,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Complainantexpectationdesc = c.Complainantexpectationdesc,
                                ComplaintcategoryExtid = c.ComplaintcategoryExtid,
                                Complaintnumber = c.Complaintnumber,
                                Contactid = c.Contactid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Description = c.Description,
                                Extendedresolutiondate = c.Extendedresolutiondate,
                                Howreported = c.Howreported,
                                Incidentdate = c.Incidentdate,
                                Iscostforactualamount = c.Iscostforactualamount,
                                Mediadescription = c.Mediadescription,
                                Mediainvolvedflag = c.Mediainvolvedflag,
                                Previousgroupid = c.Previousgroupid,
                                Previoususerid = c.Previoususerid,
                                Publicid = c.Publicid,
                                Receiveddate = c.Receiveddate,
                                Resolutiondate = c.Resolutiondate,
                                Resolutiondescription = c.Resolutiondescription,
                                Retired = c.Retired,
                                Status = c.Status,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Complaintnumber":
                            query = query.Where(c => c.Complaintnumber!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "Incidentdate":
                            query = query.Where(c => c.Incidentdate!.ToString()!.Contains(search));
                            break;
                        case "Resolutiondescription":
                            query = query.Where(c => c.Resolutiondescription!.Contains(search));
                            break;

                    }
                }

                list = await PaginatedList<Complaint>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Complaint> GetComplaint(string id)
        {
            Complaint item = null!;
            try
            {
                var c = await _context.Complaints.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Complaint
                    {
                        Id = c.Id,
                        Assignedbyuserid = c.Assignedbyuserid,
                        Assignedgroupid = c.Assignedgroupid,
                        Assigneduserid = c.Assigneduserid,
                        Assignmentdate = c.Assignmentdate,
                        Assignmentstatus = c.Assignmentstatus,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Complainantexpectationdesc = c.Complainantexpectationdesc,
                        ComplaintcategoryExtid = c.ComplaintcategoryExtid,
                        Complaintnumber = c.Complaintnumber,
                        Contactid = c.Contactid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Description = c.Description,
                        Extendedresolutiondate = c.Extendedresolutiondate,
                        Howreported = c.Howreported,
                        Incidentdate = c.Incidentdate,
                        Iscostforactualamount = c.Iscostforactualamount,
                        Mediadescription = c.Mediadescription,
                        Mediainvolvedflag = c.Mediainvolvedflag,
                        Previousgroupid = c.Previousgroupid,
                        Previoususerid = c.Previoususerid,
                        Publicid = c.Publicid,
                        Receiveddate = c.Receiveddate,
                        Resolutiondate = c.Resolutiondate,
                        Resolutiondescription = c.Resolutiondescription,
                        Retired = c.Retired,
                        Status = c.Status,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Complaint();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Complaint();
            }

            return item;
        }

        public async Task<PaginatedList<Complaintcategory>> SearchComplaintcategory(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Complaintcategory> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Complaintcategories
                            orderby c.Id ascending
                            select new Complaintcategory
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Categorydescription = c.Categorydescription,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Isdisabled = c.Isdisabled,
                                Isinuse = c.Isinuse,
                                Policytype = c.Policytype,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Subcategorydescription = c.Subcategorydescription,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Categorydescription":
                            query = query.Where(c => c.Categorydescription!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Complaintcategory>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Complaintcategory> GetComplaintcategory(string id)
        {
            Complaintcategory item = null!;
            try
            {
                var c = await _context.Complaintcategories.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Complaintcategory
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Categorydescription = c.Categorydescription,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Isdisabled = c.Isdisabled,
                        Isinuse = c.Isinuse,
                        Policytype = c.Policytype,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Subcategorydescription = c.Subcategorydescription,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Complaintcategory();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Complaintcategory();
            }

            return item;
        }

        public async Task<PaginatedList<Complainthandler>> SearchComplainthandler(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Complainthandler> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Complainthandlers
                            orderby c.Id ascending
                            select new Complainthandler
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Complaintid = c.Complaintid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Complaintid":
                            query = query.Where(c => c.Complaintid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Complainthandler>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Complainthandler> GetComplainthandler(string id)
        {
            Complainthandler item = null!;
            try
            {
                var c = await _context.Complainthandlers.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Complainthandler
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Complaintid = c.Complaintid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Userid = c.Userid,
                    };
                }
                else
                {
                    item = new Complainthandler();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Complainthandler();
            }

            return item;
        }

        public async Task<PaginatedList<Complainthistory>> SearchComplainthistory(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Complainthistory> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Complainthistories
                            orderby c.Id ascending
                            select new Complainthistory
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                ComplaintcategoryExtid = c.ComplaintcategoryExtid,
                                Complaintid = c.Complaintid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Description = c.Description,
                                Extendedresolutiondate = c.Extendedresolutiondate,
                                Publicid = c.Publicid,
                                Receiveddate = c.Receiveddate,
                                Resolutiondate = c.Resolutiondate,
                                Resolutiondescription = c.Resolutiondescription,
                                Retired = c.Retired,
                                Status = c.Status,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "ComplaintcategoryExtid":
                            query = query.Where(c => c.ComplaintcategoryExtid!.ToString()!.Contains(search));
                            break;
                        case "Complaintid":
                            query = query.Where(c => c.Complaintid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Complainthistory>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Complainthistory> GetComplainthistory(string id)
        {
            Complainthistory item = null!;
            try
            {
                var c = await _context.Complainthistories.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Complainthistory
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        ComplaintcategoryExtid = c.ComplaintcategoryExtid,
                        Complaintid = c.Complaintid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Description = c.Description,
                        Extendedresolutiondate = c.Extendedresolutiondate,
                        Publicid = c.Publicid,
                        Receiveddate = c.Receiveddate,
                        Resolutiondate = c.Resolutiondate,
                        Resolutiondescription = c.Resolutiondescription,
                        Retired = c.Retired,
                        Status = c.Status,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Userid = c.Userid,
                    };
                }
                else
                {
                    item = new Complainthistory();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Complainthistory();
            }

            return item;
        }

        public async Task<PaginatedList<Complaintnote>> SearchComplaintnote(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Complaintnote> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Complaintnotes
                            orderby c.Id ascending
                            select new Complaintnote
                            {
                                Id = c.Id,
                                Adviceinstructions = c.Adviceinstructions,
                                Beanversion = c.Beanversion,
                                Complaintid = c.Complaintid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Isrepeatcall = c.Isrepeatcall,
                                Nextaction = c.Nextaction,
                                Noteid = c.Noteid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Adviceinstructions":
                            query = query.Where(c => c.Adviceinstructions!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Complaintid":
                            query = query.Where(c => c.Complaintid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Complaintnote>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Complaintnote> GetComplaintnote(string id)
        {
            Complaintnote item = null!;
            try
            {
                var c = await _context.Complaintnotes.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Complaintnote
                    {
                        Id = c.Id,
                        Adviceinstructions = c.Adviceinstructions,
                        Beanversion = c.Beanversion,
                        Complaintid = c.Complaintid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Isrepeatcall = c.Isrepeatcall,
                        Nextaction = c.Nextaction,
                        Noteid = c.Noteid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Complaintnote();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Complaintnote();
            }

            return item;
        }

        public async Task<PaginatedList<Complaintparty>> SearchComplaintparty(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Complaintparty> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Complaintparties
                            orderby c.Id ascending
                            select new Complaintparty
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Comments = c.Comments,
                                Complaintid = c.Complaintid,
                                Contactid = c.Contactid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Preferedcontactmethod = c.Preferedcontactmethod,
                                Preferedcontacttime = c.Preferedcontacttime,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Comments":
                            query = query.Where(c => c.Comments!.Contains(search));
                            break;
                        case "Complaintid":
                            query = query.Where(c => c.Complaintid!.ToString()!.Contains(search));
                            break;
                        case "Contactid":
                            query = query.Where(c => c.Contactid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Complaintparty>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Complaintparty> GetComplaintparty(string id)
        {
            Complaintparty item = null!;
            try
            {
                var c = await _context.Complaintparties.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Complaintparty
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Comments = c.Comments,
                        Complaintid = c.Complaintid,
                        Contactid = c.Contactid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Preferedcontactmethod = c.Preferedcontactmethod,
                        Preferedcontacttime = c.Preferedcontacttime,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Complaintparty();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Complaintparty();
            }

            return item;
        }

        public async Task<PaginatedList<Contact>> SearchContact(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Contact> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Contacts
                            orderby c.Id ascending
                            select new Contact
                            {
                                Id = c.Id,
                                Addressbookuid = c.Addressbookuid,
                                Afterhours = c.Afterhours,
                                Attorneylicense = c.Attorneylicense,
                                AutopaymentallowedExt = c.AutopaymentallowedExt,
                                Autosync = c.Autosync,
                                Beanversion = c.Beanversion,
                                Canmanageprojects = c.Canmanageprojects,
                                Cellphone = c.Cellphone,
                                Claimantidtype = c.Claimantidtype,
                                CommentsExt = c.CommentsExt,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Dateofbirth = c.Dateofbirth,
                                DayperiodExt = c.DayperiodExt,
                                Donotdestroy = c.Donotdestroy,
                                Emailaddress1 = c.Emailaddress1,
                                Emailaddress2 = c.Emailaddress2,
                                Employeenumber = c.Employeenumber,
                                Faxphone = c.Faxphone,
                                Firstname = c.Firstname,
                                Firstnamedenorm = c.Firstnamedenorm,
                                Formername = c.Formername,
                                Gender = c.Gender,
                                Homephone = c.Homephone,
                                IssensitiveExt = c.IssensitiveExt,
                                Lastname = c.Lastname,
                                Lastnamedenorm = c.Lastnamedenorm,
                                Loadrelatedcontacts = c.Loadrelatedcontacts,
                                LocationrepairtypeExt = c.LocationrepairtypeExt,
                                Makesafe = c.Makesafe,
                                Middlename = c.Middlename,
                                Name = c.Name,
                                Namedenorm = c.Namedenorm,
                                Obfuscatedinternal = c.Obfuscatedinternal,
                                Pendinglinkmessage = c.Pendinglinkmessage,
                                Postaladdress = c.Postaladdress,
                                Preferred = c.Preferred,
                                Prefix = c.Prefix,
                                Primaryaddressid = c.Primaryaddressid,
                                Primaryphone = c.Primaryphone,
                                Publicid = c.Publicid,
                                RepairerrelationshipExt = c.RepairerrelationshipExt,
                                Retired = c.Retired,
                                ScAcceptsawpclaims = c.ScAcceptsawpclaims,
                                ScAcceptsdriveable = c.ScAcceptsdriveable,
                                ScAcceptsnondriveable = c.ScAcceptsnondriveable,
                                ScAcceptssms = c.ScAcceptssms,
                                ScAcceptstpafclaims = c.ScAcceptstpafclaims,
                                ScAcceptstpvehicles = c.ScAcceptstpvehicles,
                                ScAcceptsume = c.ScAcceptsume,
                                ScAccidentsequencekey = c.ScAccidentsequencekey,
                                ScAccountname = c.ScAccountname,
                                ScAccountnumber = c.ScAccountnumber,
                                ScActivecontact = c.ScActivecontact,
                                ScActivepnetaccount = c.ScActivepnetaccount,
                                ScAuthparty = c.ScAuthparty,
                                ScB2bEnabled = c.ScB2bEnabled,
                                ScBankname = c.ScBankname,
                                ScBsb = c.ScBsb,
                                ScBulkpayments = c.ScBulkpayments,
                                ScBusinesstype = c.ScBusinesstype,
                                ScCellphone = c.ScCellphone,
                                ScCentralbillservice = c.ScCentralbillservice,
                                ScConsolvendor = c.ScConsolvendor,
                                ScContactpaymentaccountseq = c.ScContactpaymentaccountseq,
                                ScCorrespondencedelivery = c.ScCorrespondencedelivery,
                                ScDeceased = c.ScDeceased,
                                ScFormerfirstname = c.ScFormerfirstname,
                                ScFormermiddlename = c.ScFormermiddlename,
                                ScGstregistered = c.ScGstregistered,
                                ScHospitalname = c.ScHospitalname,
                                ScInterpreterreqd = c.ScInterpreterreqd,
                                ScLanguage = c.ScLanguage,
                                ScLanguagepref = c.ScLanguagepref,
                                ScLocationtype = c.ScLocationtype,
                                ScNodependantadults = c.ScNodependantadults,
                                ScNodependantchildren = c.ScNodependantchildren,
                                ScOpenfriday = c.ScOpenfriday,
                                ScOpenmonday = c.ScOpenmonday,
                                ScOpensaturday = c.ScOpensaturday,
                                ScOpensunday = c.ScOpensunday,
                                ScOpenthursday = c.ScOpenthursday,
                                ScOpentuesday = c.ScOpentuesday,
                                ScOpenwednesday = c.ScOpenwednesday,
                                ScOtherphone = c.ScOtherphone,
                                ScOtherphonedesc = c.ScOtherphonedesc,
                                ScPayable = c.ScPayable,
                                ScPaymentmethod = c.ScPaymentmethod,
                                ScPaymentname = c.ScPaymentname,
                                ScPaymentserviceackdate = c.ScPaymentserviceackdate,
                                ScPaymentservicecorrid = c.ScPaymentservicecorrid,
                                ScPaymentservicevendorid = c.ScPaymentservicevendorid,
                                ScPaymentterms = c.ScPaymentterms,
                                ScPaystartdate = c.ScPaystartdate,
                                ScPolicytype = c.ScPolicytype,
                                ScPortfoliocode = c.ScPortfoliocode,
                                ScProcesstypeexists = c.ScProcesstypeexists,
                                ScRecommended = c.ScRecommended,
                                ScRemittancedelivery = c.ScRemittancedelivery,
                                ScRemittancenotificationemail = c.ScRemittancenotificationemail,
                                ScSamenotificationemail = c.ScSamenotificationemail,
                                ScSamenotificationsms = c.ScSamenotificationsms,
                                ScServiceablepostcodenational = c.ScServiceablepostcodenational,
                                ScStaffnumber = c.ScStaffnumber,
                                ScSuspended = c.ScSuspended,
                                ScTradingname = c.ScTradingname,
                                ScVendorengagementtype = c.ScVendorengagementtype,
                                ScVendortype = c.ScVendortype,
                                Subtype = c.Subtype,
                                Suffix = c.Suffix,
                                Taxid = c.Taxid,
                                Taxstatus = c.Taxstatus,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,
                                Validationlevel = c.Validationlevel,
                                Vendortype = c.Vendortype,
                                W9received = c.W9received,
                                WatchlistproviderExt = c.WatchlistproviderExt,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Firstname":
                            query = query.Where(c => c.Firstname!.Contains(search));
                            break;
                        case "Lastname":
                            query = query.Where(c => c.Lastname!.Contains(search));
                            break;
                        case "Gender":
                            query = query.Where(c => c.Gender!.ToString()!.Contains(search));
                            break;
                        case "Dateofbirth":
                            query = query.Where(c => c.Dateofbirth!.ToString()!.Contains(search));
                            break;
                        case "Cellphone":
                            query = query.Where(c => c.Cellphone!.Contains(search));
                            break;
                        case "Emailaddress1":
                            query = query.Where(c => c.Emailaddress1!.Contains(search));
                            break;

                    }
                }

                list = await PaginatedList<Contact>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Contact> GetContact(string id)
        {
            Contact item = null!;
            try
            {
                var c = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Contact
                    {
                        Id = c.Id,
                        Addressbookuid = c.Addressbookuid,
                        Afterhours = c.Afterhours,
                        Attorneylicense = c.Attorneylicense,
                        AutopaymentallowedExt = c.AutopaymentallowedExt,
                        Autosync = c.Autosync,
                        Beanversion = c.Beanversion,
                        Canmanageprojects = c.Canmanageprojects,
                        Cellphone = c.Cellphone,
                        Claimantidtype = c.Claimantidtype,
                        CommentsExt = c.CommentsExt,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Dateofbirth = c.Dateofbirth,
                        DayperiodExt = c.DayperiodExt,
                        Donotdestroy = c.Donotdestroy,
                        Emailaddress1 = c.Emailaddress1,
                        Emailaddress2 = c.Emailaddress2,
                        Employeenumber = c.Employeenumber,
                        Faxphone = c.Faxphone,
                        Firstname = c.Firstname,
                        Firstnamedenorm = c.Firstnamedenorm,
                        Formername = c.Formername,
                        Gender = c.Gender,
                        Homephone = c.Homephone,
                        IssensitiveExt = c.IssensitiveExt,
                        Lastname = c.Lastname,
                        Lastnamedenorm = c.Lastnamedenorm,
                        Loadrelatedcontacts = c.Loadrelatedcontacts,
                        LocationrepairtypeExt = c.LocationrepairtypeExt,
                        Makesafe = c.Makesafe,
                        Middlename = c.Middlename,
                        Name = c.Name,
                        Namedenorm = c.Namedenorm,
                        Obfuscatedinternal = c.Obfuscatedinternal,
                        Pendinglinkmessage = c.Pendinglinkmessage,
                        Postaladdress = c.Postaladdress,
                        Preferred = c.Preferred,
                        Prefix = c.Prefix,
                        Primaryaddressid = c.Primaryaddressid,
                        Primaryphone = c.Primaryphone,
                        Publicid = c.Publicid,
                        RepairerrelationshipExt = c.RepairerrelationshipExt,
                        Retired = c.Retired,
                        ScAcceptsawpclaims = c.ScAcceptsawpclaims,
                        ScAcceptsdriveable = c.ScAcceptsdriveable,
                        ScAcceptsnondriveable = c.ScAcceptsnondriveable,
                        ScAcceptssms = c.ScAcceptssms,
                        ScAcceptstpafclaims = c.ScAcceptstpafclaims,
                        ScAcceptstpvehicles = c.ScAcceptstpvehicles,
                        ScAcceptsume = c.ScAcceptsume,
                        ScAccidentsequencekey = c.ScAccidentsequencekey,
                        ScAccountname = c.ScAccountname,
                        ScAccountnumber = c.ScAccountnumber,
                        ScActivecontact = c.ScActivecontact,
                        ScActivepnetaccount = c.ScActivepnetaccount,
                        ScAuthparty = c.ScAuthparty,
                        ScB2bEnabled = c.ScB2bEnabled,
                        ScBankname = c.ScBankname,
                        ScBsb = c.ScBsb,
                        ScBulkpayments = c.ScBulkpayments,
                        ScBusinesstype = c.ScBusinesstype,
                        ScCellphone = c.ScCellphone,
                        ScCentralbillservice = c.ScCentralbillservice,
                        ScConsolvendor = c.ScConsolvendor,
                        ScContactpaymentaccountseq = c.ScContactpaymentaccountseq,
                        ScCorrespondencedelivery = c.ScCorrespondencedelivery,
                        ScDeceased = c.ScDeceased,
                        ScFormerfirstname = c.ScFormerfirstname,
                        ScFormermiddlename = c.ScFormermiddlename,
                        ScGstregistered = c.ScGstregistered,
                        ScHospitalname = c.ScHospitalname,
                        ScInterpreterreqd = c.ScInterpreterreqd,
                        ScLanguage = c.ScLanguage,
                        ScLanguagepref = c.ScLanguagepref,
                        ScLocationtype = c.ScLocationtype,
                        ScNodependantadults = c.ScNodependantadults,
                        ScNodependantchildren = c.ScNodependantchildren,
                        ScOpenfriday = c.ScOpenfriday,
                        ScOpenmonday = c.ScOpenmonday,
                        ScOpensaturday = c.ScOpensaturday,
                        ScOpensunday = c.ScOpensunday,
                        ScOpenthursday = c.ScOpenthursday,
                        ScOpentuesday = c.ScOpentuesday,
                        ScOpenwednesday = c.ScOpenwednesday,
                        ScOtherphone = c.ScOtherphone,
                        ScOtherphonedesc = c.ScOtherphonedesc,
                        ScPayable = c.ScPayable,
                        ScPaymentmethod = c.ScPaymentmethod,
                        ScPaymentname = c.ScPaymentname,
                        ScPaymentserviceackdate = c.ScPaymentserviceackdate,
                        ScPaymentservicecorrid = c.ScPaymentservicecorrid,
                        ScPaymentservicevendorid = c.ScPaymentservicevendorid,
                        ScPaymentterms = c.ScPaymentterms,
                        ScPaystartdate = c.ScPaystartdate,
                        ScPolicytype = c.ScPolicytype,
                        ScPortfoliocode = c.ScPortfoliocode,
                        ScProcesstypeexists = c.ScProcesstypeexists,
                        ScRecommended = c.ScRecommended,
                        ScRemittancedelivery = c.ScRemittancedelivery,
                        ScRemittancenotificationemail = c.ScRemittancenotificationemail,
                        ScSamenotificationemail = c.ScSamenotificationemail,
                        ScSamenotificationsms = c.ScSamenotificationsms,
                        ScServiceablepostcodenational = c.ScServiceablepostcodenational,
                        ScStaffnumber = c.ScStaffnumber,
                        ScSuspended = c.ScSuspended,
                        ScTradingname = c.ScTradingname,
                        ScVendorengagementtype = c.ScVendorengagementtype,
                        ScVendortype = c.ScVendortype,
                        Subtype = c.Subtype,
                        Suffix = c.Suffix,
                        Taxid = c.Taxid,
                        Taxstatus = c.Taxstatus,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Validationlevel = c.Validationlevel,
                        Vendortype = c.Vendortype,
                        W9received = c.W9received,
                        WatchlistproviderExt = c.WatchlistproviderExt,
                        Workphone = c.Workphone,
                    };
                }
                else
                {
                    item = new Contact();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Contact();
            }

            return item;
        }

        public async Task<PaginatedList<Coverage>> SearchCoverage(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Coverage> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Coverages
                            orderby c.Id ascending
                            select new Coverage
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Currency = c.Currency,
                                Effectivedate = c.Effectivedate,
                                Expirationdate = c.Expirationdate,
                                OccupationExt = c.OccupationExt,
                                Policyid = c.Policyid,
                                PremiumstatusExt = c.PremiumstatusExt,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Riskunitid = c.Riskunitid,
                                ScCoveragesourcekey = c.ScCoveragesourcekey,
                                ScRawproduct = c.ScRawproduct,
                                ScStatus = c.ScStatus,
                                Subtype = c.Subtype,
                                TermenddateExt = c.TermenddateExt,
                                TermstartdateExt = c.TermstartdateExt,
                                Type = c.Type,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Policyid":
                            query = query.Where(c => c.Policyid!.ToString()!.Contains(search));
                            break;
                        case "Effectivedate":
                            query = query.Where(c => c.Effectivedate!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Expirationdate":
                            query = query.Where(c => c.Expirationdate!.ToString()!.Contains(search));
                            break;
                        case "Currency":
                            query = query.Where(c => c.Currency!.ToString()!.Contains(search));
                            break;
                        case "Riskunitid":
                            query = query.Where(c => c.Riskunitid!.ToString()!.Contains(search));
                            break;
                        case "Subtype":
                            query = query.Where(c => c.Subtype!.ToString()!.Contains(search));
                            break;
                        case "Type":
                            query = query.Where(c => c.Type!.ToString()!.Contains(search));
                            break;
                        case "Publicid":
                            query = query.Where(c => c.Publicid!.ToString()!.Contains(search));
                            break;
                    }
                }

                list = await PaginatedList<Coverage>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Coverage> GetCoverage(string id)
        {
            Coverage item = null!;
            try
            {
                var c = await _context.Coverages.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Coverage
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Currency = c.Currency,
                        Effectivedate = c.Effectivedate,
                        Expirationdate = c.Expirationdate,
                        OccupationExt = c.OccupationExt,
                        Policyid = c.Policyid,
                        PremiumstatusExt = c.PremiumstatusExt,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Riskunitid = c.Riskunitid,
                        ScCoveragesourcekey = c.ScCoveragesourcekey,
                        ScRawproduct = c.ScRawproduct,
                        ScStatus = c.ScStatus,
                        Subtype = c.Subtype,
                        TermenddateExt = c.TermenddateExt,
                        TermstartdateExt = c.TermstartdateExt,
                        Type = c.Type,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Coverage();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Coverage();
            }

            return item;
        }

        public async Task<PaginatedList<Credential>> SearchCredential(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Credential> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Credentials
                            orderby c.Id ascending
                            select new Credential
                            {
                                Id = c.Id,
                                Active = c.Active,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Failedattempts = c.Failedattempts,
                                Lockdate = c.Lockdate,
                                Obfuscatedinternal = c.Obfuscatedinternal,
                                Password = c.Password,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,
                                Username = c.Username,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Active":
                            query = query.Where(c => c.Active!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Credential>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Credential> GetCredential(string id)
        {
            Credential item = null!;
            try
            {
                var c = await _context.Credentials.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Credential
                    {
                        Id = c.Id,
                        Active = c.Active,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Failedattempts = c.Failedattempts,
                        Lockdate = c.Lockdate,
                        Obfuscatedinternal = c.Obfuscatedinternal,
                        Password = c.Password,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Username = c.Username,
                        Usernamedenorm = c.Usernamedenorm,
                    };
                }
                else
                {
                    item = new Credential();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Credential();
            }

            return item;
        }

        public async Task<PaginatedList<CsvdataFile>> SearchCsvdataFile(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<CsvdataFile> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.CsvdataFiles
                            orderby c.Id ascending
                            select new CsvdataFile
                            {
                                Id = c.Id,
                                FilePath = c.FilePath,
                                FileName = c.FileName,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "FilePath":
                            query = query.Where(c => c.FilePath!.Contains(search));
                            break;
                        case "FileName":
                            query = query.Where(c => c.FileName!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<CsvdataFile>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<CsvdataFile> GetCsvdataFile(string id)
        {
            CsvdataFile item = null!;
            try
            {
                var c = await _context.CsvdataFiles.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new CsvdataFile
                    {
                        Id = c.Id,
                        FilePath = c.FilePath,
                        FileName = c.FileName,
                        TableName = c.TableName,
                    };
                }
                else
                {
                    item = new CsvdataFile();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new CsvdataFile();
            }

            return item;
        }

        public async Task<PaginatedList<Document>> SearchDocument(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Document> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Documents
                            orderby c.Id ascending
                            select new Document
                            {
                                Id = c.Id,
                                Author = c.Author,
                                Authordenorm = c.Authordenorm,
                                Beanversion = c.Beanversion,
                                Claimcontactid = c.Claimcontactid,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Datemodified = c.Datemodified,
                                Description = c.Description,
                                Dms = c.Dms,
                                Docuid = c.Docuid,
                                Documentidentifier = c.Documentidentifier,
                                Documentidentifierdenorm = c.Documentidentifierdenorm,
                                ExposetocustomerExt = c.ExposetocustomerExt,
                                Exposureid = c.Exposureid,
                                Inbound = c.Inbound,
                                Mimetype = c.Mimetype,
                                Name = c.Name,
                                Namedenorm = c.Namedenorm,
                                Obsolete = c.Obsolete,
                                Publicid = c.Publicid,
                                Recipient = c.Recipient,
                                Retired = c.Retired,
                                ScActivitystatus = c.ScActivitystatus,
                                ScArchiveonly = c.ScArchiveonly,
                                ScBatchid = c.ScBatchid,
                                ScDisclosurestatus = c.ScDisclosurestatus,
                                ScDocsource = c.ScDocsource,
                                ScDocumentdate = c.ScDocumentdate,
                                ScDocumentsize = c.ScDocumentsize,
                                ScIsversion = c.ScIsversion,
                                Securitytype = c.Securitytype,
                                Status = c.Status,
                                Type = c.Type,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Docuid":
                            query = query.Where(c => c.Docuid!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "Mimetype":
                            query = query.Where(c => c.Mimetype!.Contains(search));
                            break;
                        case "Name":
                            query = query.Where(c => c.Name!.Contains(search));
                            break;
                        case "Publicid":
                            query = query.Where(c => c.Publicid!.ToString()!.Contains(search));
                            break;

                    }
                }

                list = await PaginatedList<Document>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Document> GetDocument(string id)
        {
            Document item = null!;
            try
            {
                var c = await _context.Documents.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Document
                    {
                        Id = c.Id,
                        Author = c.Author,
                        Authordenorm = c.Authordenorm,
                        Beanversion = c.Beanversion,
                        Claimcontactid = c.Claimcontactid,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Datemodified = c.Datemodified,
                        Description = c.Description,
                        Dms = c.Dms,
                        Docuid = c.Docuid,
                        Documentidentifier = c.Documentidentifier,
                        Documentidentifierdenorm = c.Documentidentifierdenorm,
                        ExposetocustomerExt = c.ExposetocustomerExt,
                        Exposureid = c.Exposureid,
                        Inbound = c.Inbound,
                        Mimetype = c.Mimetype,
                        Name = c.Name,
                        Namedenorm = c.Namedenorm,
                        Obsolete = c.Obsolete,
                        Publicid = c.Publicid,
                        Recipient = c.Recipient,
                        Retired = c.Retired,
                        ScActivitystatus = c.ScActivitystatus,
                        ScArchiveonly = c.ScArchiveonly,
                        ScBatchid = c.ScBatchid,
                        ScDisclosurestatus = c.ScDisclosurestatus,
                        ScDocsource = c.ScDocsource,
                        ScDocumentdate = c.ScDocumentdate,
                        ScDocumentsize = c.ScDocumentsize,
                        ScIsversion = c.ScIsversion,
                        Securitytype = c.Securitytype,
                        Status = c.Status,
                        Type = c.Type,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Document();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Document();
            }

            return item;
        }

        public async Task<PaginatedList<Empldatatoinjincident>> SearchEmpldatatoinjincident(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Empldatatoinjincident> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Empldatatoinjincidents
                            orderby c.Id ascending
                            select new Empldatatoinjincident
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Foreignentityid = c.Foreignentityid,
                                Ownerid = c.Ownerid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Foreignentityid":
                            query = query.Where(c => c.Foreignentityid!.ToString()!.Contains(search));
                            break;
                        case "Ownerid":
                            query = query.Where(c => c.Ownerid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Empldatatoinjincident>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Empldatatoinjincident> GetEmpldatatoinjincident(string id)
        {
            Empldatatoinjincident item = null!;
            try
            {
                var c = await _context.Empldatatoinjincidents.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Empldatatoinjincident
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Foreignentityid = c.Foreignentityid,
                        Ownerid = c.Ownerid,
                        Publicid = c.Publicid,
                    };
                }
                else
                {
                    item = new Empldatatoinjincident();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Empldatatoinjincident();
            }

            return item;
        }

        public async Task<PaginatedList<Employmentdatum>> SearchEmploymentdatum(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Employmentdatum> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Employmentdata
                            orderby c.Id ascending
                            select new Employmentdatum
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                ScWorkplacesize = c.ScWorkplacesize,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Employmentdatum>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Employmentdatum> GetEmploymentdatum(string id)
        {
            Employmentdatum item = null!;
            try
            {
                var c = await _context.Employmentdata.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Employmentdatum
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        ScWorkplacesize = c.ScWorkplacesize,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        WcworkweekSp = c.WcworkweekSp,
                    };
                }
                else
                {
                    item = new Employmentdatum();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Employmentdatum();
            }

            return item;
        }

        public async Task<PaginatedList<Evaluation>> SearchEvaluation(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Evaluation> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Evaluations
                            orderby c.Id ascending
                            select new Evaluation
                            {
                                Id = c.Id,
                                Amount = c.Amount,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Exposureid = c.Exposureid,
                                IsvupliftapplicableExt = c.IsvupliftapplicableExt,
                                Name = c.Name,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                ScCollectexcessind = c.ScCollectexcessind,
                                ScSettlingtpinsurance = c.ScSettlingtpinsurance,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Amount":
                            query = query.Where(c => c.Amount!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Evaluation>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Evaluation> GetEvaluation(string id)
        {
            Evaluation item = null!;
            try
            {
                var c = await _context.Evaluations.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Evaluation
                    {
                        Id = c.Id,
                        Amount = c.Amount,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Exposureid = c.Exposureid,
                        IsvupliftapplicableExt = c.IsvupliftapplicableExt,
                        Name = c.Name,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        ScCollectexcessind = c.ScCollectexcessind,
                        ScSettlingtpinsurance = c.ScSettlingtpinsurance,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Evaluation();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Evaluation();
            }

            return item;
        }

        public async Task<PaginatedList<Exposure>> SearchExposure(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Exposure> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Exposures
                            orderby c.Id ascending
                            select new Exposure
                            {
                                Id = c.Id,
                                Assignedbyuserid = c.Assignedbyuserid,
                                Assignedgroupid = c.Assignedgroupid,
                                Assigneduserid = c.Assigneduserid,
                                Assignmentdate = c.Assignmentdate,
                                Assignmentstatus = c.Assignmentstatus,
                                Beanversion = c.Beanversion,
                                Claimantdenormid = c.Claimantdenormid,
                                Claimanttype = c.Claimanttype,
                                Claimid = c.Claimid,
                                Claimorder = c.Claimorder,
                                Closedate = c.Closedate,
                                Closedoutcome = c.Closedoutcome,
                                Contactpermitted = c.Contactpermitted,
                                Coverageid = c.Coverageid,
                                Coveragesubtype = c.Coveragesubtype,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                DecisioncommentsExt = c.DecisioncommentsExt,
                                DecisionExt = c.DecisionExt,
                                ExposurereferencenumberExt = c.ExposurereferencenumberExt,
                                Exposuretier = c.Exposuretier,
                                Exposuretype = c.Exposuretype,
                                Incidentid = c.Incidentid,
                                Isostatus = c.Isostatus,
                                Jurisdictionstate = c.Jurisdictionstate,
                                LitigationstatusExt = c.LitigationstatusExt,
                                MaterialdamageExt = c.MaterialdamageExt,
                                Metriclimitgeneration = c.Metriclimitgeneration,
                                Previousgroupid = c.Previousgroupid,
                                Previoususerid = c.Previoususerid,
                                Primarycoverage = c.Primarycoverage,
                                Publicid = c.Publicid,
                                ReasonwithoutprejudiceExt = c.ReasonwithoutprejudiceExt,
                                Reopendate = c.Reopendate,
                                Reopenedreason = c.Reopenedreason,
                                Retired = c.Retired,
                                Rigroupsetexternally = c.Rigroupsetexternally,
                                Segment = c.Segment,
                                Settledate = c.Settledate,
                                State = c.State,
                                Strategy = c.Strategy,
                                Supplementalworkloadweight = c.Supplementalworkloadweight,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,
                                Validationlevel = c.Validationlevel,
                                Wcpreexdisblty = c.Wcpreexdisblty,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Assignedbyuserid":
                            query = query.Where(c => c.Assignedbyuserid!.ToString()!.Contains(search));
                            break;
                        case "Assignedgroupid":
                            query = query.Where(c => c.Assignedgroupid!.ToString()!.Contains(search));
                            break;
                        case "Assigneduserid":
                            query = query.Where(c => c.Assigneduserid!.ToString()!.Contains(search));
                            break;
                        case "Assignmentdate":
                            query = query.Where(c => c.Assignmentdate!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Exposure>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Exposure> GetExposure(string id)
        {
            Exposure item = null!;
            try
            {
                var c = await _context.Exposures.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Exposure
                    {
                        Id = c.Id,
                        Assignedbyuserid = c.Assignedbyuserid,
                        Assignedgroupid = c.Assignedgroupid,
                        Assigneduserid = c.Assigneduserid,
                        Assignmentdate = c.Assignmentdate,
                        Assignmentstatus = c.Assignmentstatus,
                        Beanversion = c.Beanversion,
                        Claimantdenormid = c.Claimantdenormid,
                        Claimanttype = c.Claimanttype,
                        Claimid = c.Claimid,
                        Claimorder = c.Claimorder,
                        Closedate = c.Closedate,
                        Closedoutcome = c.Closedoutcome,
                        Contactpermitted = c.Contactpermitted,
                        Coverageid = c.Coverageid,
                        Coveragesubtype = c.Coveragesubtype,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        DecisioncommentsExt = c.DecisioncommentsExt,
                        DecisionExt = c.DecisionExt,
                        ExposurereferencenumberExt = c.ExposurereferencenumberExt,
                        Exposuretier = c.Exposuretier,
                        Exposuretype = c.Exposuretype,
                        Incidentid = c.Incidentid,
                        Isostatus = c.Isostatus,
                        Jurisdictionstate = c.Jurisdictionstate,
                        LitigationstatusExt = c.LitigationstatusExt,
                        MaterialdamageExt = c.MaterialdamageExt,
                        Metriclimitgeneration = c.Metriclimitgeneration,
                        Previousgroupid = c.Previousgroupid,
                        Previoususerid = c.Previoususerid,
                        Primarycoverage = c.Primarycoverage,
                        Publicid = c.Publicid,
                        ReasonwithoutprejudiceExt = c.ReasonwithoutprejudiceExt,
                        Reopendate = c.Reopendate,
                        Reopenedreason = c.Reopenedreason,
                        Retired = c.Retired,
                        Rigroupsetexternally = c.Rigroupsetexternally,
                        Segment = c.Segment,
                        Settledate = c.Settledate,
                        State = c.State,
                        Strategy = c.Strategy,
                        Supplementalworkloadweight = c.Supplementalworkloadweight,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Validationlevel = c.Validationlevel,
                        Wcpreexdisblty = c.Wcpreexdisblty,
                        Workloadweight = c.Workloadweight,
                    };
                }
                else
                {
                    item = new Exposure();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Exposure();
            }

            return item;
        }

        public async Task<PaginatedList<Exposuremetric>> SearchExposuremetric(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Exposuremetric> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Exposuremetrics
                            orderby c.Id ascending
                            select new Exposuremetric
                            {
                                Id = c.Id,
                                Activityskipped = c.Activityskipped,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Exposureid = c.Exposureid,
                                Integervalue = c.Integervalue,
                                Isopen = c.Isopen,
                                Percentvalue = c.Percentvalue,
                                Publicid = c.Publicid,
                                Skipped = c.Skipped,
                                Starttime = c.Starttime,
                                Subtype = c.Subtype,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Activityskipped":
                            query = query.Where(c => c.Activityskipped!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Exposuremetric>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Exposuremetric> GetExposuremetric(string id)
        {
            Exposuremetric item = null!;
            try
            {
                var c = await _context.Exposuremetrics.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Exposuremetric
                    {
                        Id = c.Id,
                        Activityskipped = c.Activityskipped,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Exposureid = c.Exposureid,
                        Integervalue = c.Integervalue,
                        Isopen = c.Isopen,
                        Percentvalue = c.Percentvalue,
                        Publicid = c.Publicid,
                        Skipped = c.Skipped,
                        Starttime = c.Starttime,
                        Subtype = c.Subtype,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Exposuremetric();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Exposuremetric();
            }

            return item;
        }

        public async Task<PaginatedList<Exposurerpt>> SearchExposurerpt(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Exposurerpt> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Exposurerpts
                            orderby c.Id ascending
                            select new Exposurerpt
                            {
                                Id = c.Id,
                                Availablereserves = c.Availablereserves,
                                Availableresrvrprtng = c.Availableresrvrprtng,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Exposureid = c.Exposureid,
                                Futurepayments = c.Futurepayments,
                                Futurepaymentsrprtng = c.Futurepaymentsrprtng,
                                Openrecoveryreserves = c.Openrecoveryreserves,
                                Openrecoveryresrprtng = c.Openrecoveryresrprtng,
                                Openreserves = c.Openreserves,
                                Openreservesrprtng = c.Openreservesrprtng,
                                Publicid = c.Publicid,
                                Remainingreserves = c.Remainingreserves,
                                Remainingresrvrprtng = c.Remainingresrvrprtng,
                                Retired = c.Retired,
                                Totalpayments = c.Totalpayments,
                                Totalpaymentsrprtng = c.Totalpaymentsrprtng,
                                Totalrecoveries = c.Totalrecoveries,
                                Totalrecoveriesrprtng = c.Totalrecoveriesrprtng,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Availablereserves":
                            query = query.Where(c => c.Availablereserves!.ToString()!.Contains(search));
                            break;
                        case "Availableresrvrprtng":
                            query = query.Where(c => c.Availableresrvrprtng!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Exposurerpt>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Exposurerpt> GetExposurerpt(string id)
        {
            Exposurerpt item = null!;
            try
            {
                var c = await _context.Exposurerpts.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Exposurerpt
                    {
                        Id = c.Id,
                        Availablereserves = c.Availablereserves,
                        Availableresrvrprtng = c.Availableresrvrprtng,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Exposureid = c.Exposureid,
                        Futurepayments = c.Futurepayments,
                        Futurepaymentsrprtng = c.Futurepaymentsrprtng,
                        Openrecoveryreserves = c.Openrecoveryreserves,
                        Openrecoveryresrprtng = c.Openrecoveryresrprtng,
                        Openreserves = c.Openreserves,
                        Openreservesrprtng = c.Openreservesrprtng,
                        Publicid = c.Publicid,
                        Remainingreserves = c.Remainingreserves,
                        Remainingresrvrprtng = c.Remainingresrvrprtng,
                        Retired = c.Retired,
                        Totalpayments = c.Totalpayments,
                        Totalpaymentsrprtng = c.Totalpaymentsrprtng,
                        Totalrecoveries = c.Totalrecoveries,
                        Totalrecoveriesrprtng = c.Totalrecoveriesrprtng,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Exposurerpt();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Exposurerpt();
            }

            return item;
        }

        public async Task<PaginatedList<Fllog>> SearchFllog(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Fllog> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Fllogs
                            orderby c.Id ascending
                            select new Fllog
                            {
                                Id = c.Id,
                                Message = c.Message,
                                MessageTemplate = c.MessageTemplate,
                                Level = c.Level,
                                TimeStamp = c.TimeStamp,
                                Exception = c.Exception,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Message":
                            query = query.Where(c => c.Message!.Contains(search));
                            break;
                        case "MessageTemplate":
                            query = query.Where(c => c.MessageTemplate!.Contains(search));
                            break;
                        case "Level":
                            query = query.Where(c => c.Level!.Contains(search));
                            break;
                        case "TimeStamp":
                            query = query.Where(c => c.TimeStamp!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Fllog>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Fllog> GetFllog(string id)
        {
            Fllog item = null!;
            try
            {
                var c = await _context.Fllogs.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Fllog
                    {
                        Id = c.Id,
                        Message = c.Message,
                        MessageTemplate = c.MessageTemplate,
                        Level = c.Level,
                        TimeStamp = c.TimeStamp,
                        Exception = c.Exception,
                        Properties = c.Properties,
                    };
                }
                else
                {
                    item = new Fllog();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Fllog();
            }

            return item;
        }

        public async Task<PaginatedList<Group>> SearchGroup(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Group> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Groups
                            orderby c.Id ascending
                            select new Group
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Grouptype = c.Grouptype,
                                Loadfactor = c.Loadfactor,
                                Name = c.Name,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                ScGroupstrategy = c.ScGroupstrategy,
                                Securityzoneid = c.Securityzoneid,
                                Supervisorid = c.Supervisorid,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,
                                Validationlevel = c.Validationlevel,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;
                        case "Grouptype":
                            query = query.Where(c => c.Grouptype!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Group>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Group> GetGroup(string id)
        {
            Group item = null!;
            try
            {
                var c = await _context.Groups.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Group
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Grouptype = c.Grouptype,
                        Loadfactor = c.Loadfactor,
                        Name = c.Name,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        ScGroupstrategy = c.ScGroupstrategy,
                        Securityzoneid = c.Securityzoneid,
                        Supervisorid = c.Supervisorid,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Validationlevel = c.Validationlevel,
                        Worldvisible = c.Worldvisible,
                    };
                }
                else
                {
                    item = new Group();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Group();
            }

            return item;
        }

        public async Task<PaginatedList<History>> SearchHistory(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<History> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Histories
                            orderby c.Id ascending
                            select new History
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Customtype = c.Customtype,
                                Description = c.Description,
                                Eventtimestamp = c.Eventtimestamp,
                                Exposureid = c.Exposureid,
                                Matterid = c.Matterid,
                                Publicid = c.Publicid,
                                Subtype = c.Subtype,
                                Type = c.Type,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Eventtimestamp":
                            query = query.Where(c => c.Eventtimestamp!.ToString()!.Contains(search));
                            break;
                        case "Subtype":
                            query = query.Where(c => c.Subtype!.ToString()!.Contains(search));
                            break;
                        case "Publicid":
                            query = query.Where(c => c.Publicid!.ToString()!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<History>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<History> GetHistory(string id)
        {
            History item = null!;
            try
            {
                var c = await _context.Histories.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new History
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Customtype = c.Customtype,
                        Description = c.Description,
                        Eventtimestamp = c.Eventtimestamp,
                        Exposureid = c.Exposureid,
                        Matterid = c.Matterid,
                        Publicid = c.Publicid,
                        Subtype = c.Subtype,
                        Type = c.Type,
                        Userid = c.Userid,
                    };
                }
                else
                {
                    item = new History();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new History();
            }

            return item;
        }

        public async Task<PaginatedList<Incident>> SearchIncident(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Incident> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Incidents
                            orderby c.Id ascending
                            select new Incident
                            {
                                Id = c.Id,
                                Ambulanceused = c.Ambulanceused,
                                Beanversion = c.Beanversion,
                                ClaimanttypeExt = c.ClaimanttypeExt,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Description = c.Description,
                                Detailedinjurytype = c.Detailedinjurytype,
                                Employmentdataid = c.Employmentdataid,
                                FaultratingExt = c.FaultratingExt,
                                FirstnoticeindicatorExt = c.FirstnoticeindicatorExt,
                                Generalinjurytype = c.Generalinjurytype,
                                HowreportedExt = c.HowreportedExt,
                                LosscauseExt = c.LosscauseExt,
                                Lostwages = c.Lostwages,
                                PrimarybodyfunctionExt = c.PrimarybodyfunctionExt,
                                Publicid = c.Publicid,
                                RehabilitationreferralindExt = c.RehabilitationreferralindExt,
                                ReportedbytypeExt = c.ReportedbytypeExt,
                                ReporteddateExt = c.ReporteddateExt,
                                ReportonlyExt = c.ReportonlyExt,
                                ResultofinjuryExt = c.ResultofinjuryExt,
                                Retired = c.Retired,
                                ScClaimeventquestions = c.ScClaimeventquestions,
                                ScInjuryquestions = c.ScInjuryquestions,
                                Severity = c.Severity,
                                StatutorybenefitsExt = c.StatutorybenefitsExt,
                                StatutorycareExtid = c.StatutorycareExtid,
                                Subtype = c.Subtype,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "Detailedinjurytype":
                            query = query.Where(c => c.Detailedinjurytype!.ToString()!.Contains(search));
                            break;
                        case "Generalinjurytype":
                            query = query.Where(c => c.Generalinjurytype!.ToString()!.Contains(search));
                            break;
                        case "Subtype":
                            query = query.Where(c => c.Subtype!.ToString()!.Contains(search));
                            break;
                        case "Publicid":
                            query = query.Where(c => c.Publicid!.ToString()!.Contains(search));
                            break;

                    }
                }

                list = await PaginatedList<Incident>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Incident> GetIncident(string id)
        {
            Incident item = null!;
            try
            {
                var c = await _context.Incidents.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Incident
                    {
                        Id = c.Id,
                        Ambulanceused = c.Ambulanceused,
                        Beanversion = c.Beanversion,
                        ClaimanttypeExt = c.ClaimanttypeExt,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Description = c.Description,
                        Detailedinjurytype = c.Detailedinjurytype,
                        Employmentdataid = c.Employmentdataid,
                        FaultratingExt = c.FaultratingExt,
                        FirstnoticeindicatorExt = c.FirstnoticeindicatorExt,
                        Generalinjurytype = c.Generalinjurytype,
                        HowreportedExt = c.HowreportedExt,
                        LosscauseExt = c.LosscauseExt,
                        Lostwages = c.Lostwages,
                        PrimarybodyfunctionExt = c.PrimarybodyfunctionExt,
                        Publicid = c.Publicid,
                        RehabilitationreferralindExt = c.RehabilitationreferralindExt,
                        ReportedbytypeExt = c.ReportedbytypeExt,
                        ReporteddateExt = c.ReporteddateExt,
                        ReportonlyExt = c.ReportonlyExt,
                        ResultofinjuryExt = c.ResultofinjuryExt,
                        Retired = c.Retired,
                        ScClaimeventquestions = c.ScClaimeventquestions,
                        ScInjuryquestions = c.ScInjuryquestions,
                        Severity = c.Severity,
                        StatutorybenefitsExt = c.StatutorybenefitsExt,
                        StatutorycareExtid = c.StatutorycareExtid,
                        Subtype = c.Subtype,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Incident();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Incident();
            }

            return item;
        }

        public async Task<PaginatedList<Incidentaddress>> SearchIncidentaddress(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Incidentaddress> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Incidentaddresses
                            orderby c.Id ascending
                            select new Incidentaddress
                            {
                                Id = c.Id,
                                Address = c.Address,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Incidentid = c.Incidentid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Address":
                            query = query.Where(c => c.Address!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Incidentaddress>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Incidentaddress> GetIncidentaddress(string id)
        {
            Incidentaddress item = null!;
            try
            {
                var c = await _context.Incidentaddresses.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Incidentaddress
                    {
                        Id = c.Id,
                        Address = c.Address,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Incidentid = c.Incidentid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Incidentaddress();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Incidentaddress();
            }

            return item;
        }

        public async Task<PaginatedList<Incidentcontact>> SearchIncidentcontact(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Incidentcontact> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Incidentcontacts
                            orderby c.Id ascending
                            select new Incidentcontact
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Contact = c.Contact,
                                ContactroleExt = c.ContactroleExt,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Incidentid = c.Incidentid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Contact":
                            query = query.Where(c => c.Contact!.ToString()!.Contains(search));
                            break;
                        case "ContactroleExt":
                            query = query.Where(c => c.ContactroleExt!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Incidentcontact>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Incidentcontact> GetIncidentcontact(string id)
        {
            Incidentcontact item = null!;
            try
            {
                var c = await _context.Incidentcontacts.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Incidentcontact
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Contact = c.Contact,
                        ContactroleExt = c.ContactroleExt,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Incidentid = c.Incidentid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Incidentcontact();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Incidentcontact();
            }

            return item;
        }

        public async Task<PaginatedList<Injuryquestion>> SearchInjuryquestion(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Injuryquestion> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Injuryquestions
                            orderby c.Id ascending
                            select new Injuryquestion
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimantdied = c.Claimantdied,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Deathdate = c.Deathdate,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                ScRehabstatusid = c.ScRehabstatusid,
                                Subtype = c.Subtype,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimantdied":
                            query = query.Where(c => c.Claimantdied!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Injuryquestion>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Injuryquestion> GetInjuryquestion(string id)
        {
            Injuryquestion item = null!;
            try
            {
                var c = await _context.Injuryquestions.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Injuryquestion
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimantdied = c.Claimantdied,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Deathdate = c.Deathdate,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        ScRehabstatusid = c.ScRehabstatusid,
                        Subtype = c.Subtype,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Injuryquestion();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Injuryquestion();
            }

            return item;
        }

        public async Task<PaginatedList<Legacyclaimdetail>> SearchLegacyclaimdetail(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Legacyclaimdetail> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Legacyclaimdetails
                            orderby c.Id ascending
                            select new Legacyclaimdetail
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Legacyclaimcategory = c.Legacyclaimcategory,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Legacyclaimdetail>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Legacyclaimdetail> GetLegacyclaimdetail(string id)
        {
            Legacyclaimdetail item = null!;
            try
            {
                var c = await _context.Legacyclaimdetails.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Legacyclaimdetail
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Legacyclaimcategory = c.Legacyclaimcategory,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Legacyclaimdetail();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Legacyclaimdetail();
            }

            return item;
        }

        public async Task<PaginatedList<Legalengagement>> SearchLegalengagement(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Legalengagement> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Legalengagements
                            orderby c.Id ascending
                            select new Legalengagement
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Externalreference = c.Externalreference,
                                Publicid = c.Publicid,
                                Requeststatus = c.Requeststatus,
                                Retired = c.Retired,
                                Status = c.Status,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Legalengagement>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Legalengagement> GetLegalengagement(string id)
        {
            Legalengagement item = null!;
            try
            {
                var c = await _context.Legalengagements.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Legalengagement
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Externalreference = c.Externalreference,
                        Publicid = c.Publicid,
                        Requeststatus = c.Requeststatus,
                        Retired = c.Retired,
                        Status = c.Status,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Legalengagement();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Legalengagement();
            }

            return item;
        }

        public async Task<PaginatedList<Litstatustypeline>> SearchLitstatustypeline(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Litstatustypeline> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Litstatustypelines
                            orderby c.Id ascending
                            select new Litstatustypeline
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Completiondate = c.Completiondate,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Litigationstatus = c.Litigationstatus,
                                Matterid = c.Matterid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Startdate = c.Startdate,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Completiondate":
                            query = query.Where(c => c.Completiondate!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Litstatustypeline>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Litstatustypeline> GetLitstatustypeline(string id)
        {
            Litstatustypeline item = null!;
            try
            {
                var c = await _context.Litstatustypelines.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Litstatustypeline
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Completiondate = c.Completiondate,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Litigationstatus = c.Litigationstatus,
                        Matterid = c.Matterid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Startdate = c.Startdate,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Litstatustypeline();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Litstatustypeline();
            }

            return item;
        }

        public async Task<PaginatedList<Matter>> SearchMatter(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Matter> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Matters
                            orderby c.Id ascending
                            select new Matter
                            {
                                Id = c.Id,
                                Assignedbyuserid = c.Assignedbyuserid,
                                Assignedgroupid = c.Assignedgroupid,
                                Assigneduserid = c.Assigneduserid,
                                Assignmentdate = c.Assignmentdate,
                                Assignmentstatus = c.Assignmentstatus,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Closedate = c.Closedate,
                                Courttype = c.Courttype,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Legalspecialty = c.Legalspecialty,
                                Mattertype = c.Mattertype,
                                Name = c.Name,
                                Previousgroupid = c.Previousgroupid,
                                Previoususerid = c.Previoususerid,
                                Primarycause = c.Primarycause,
                                Publicid = c.Publicid,
                                Reopenedreason = c.Reopenedreason,
                                Resolution = c.Resolution,
                                Retired = c.Retired,
                                Subrorelated = c.Subrorelated,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Assignedbyuserid":
                            query = query.Where(c => c.Assignedbyuserid!.ToString()!.Contains(search));
                            break;
                        case "Assignedgroupid":
                            query = query.Where(c => c.Assignedgroupid!.ToString()!.Contains(search));
                            break;
                        case "Assigneduserid":
                            query = query.Where(c => c.Assigneduserid!.ToString()!.Contains(search));
                            break;
                        case "Assignmentdate":
                            query = query.Where(c => c.Assignmentdate!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Matter>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Matter> GetMatter(string id)
        {
            Matter item = null!;
            try
            {
                var c = await _context.Matters.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Matter
                    {
                        Id = c.Id,
                        Assignedbyuserid = c.Assignedbyuserid,
                        Assignedgroupid = c.Assignedgroupid,
                        Assigneduserid = c.Assigneduserid,
                        Assignmentdate = c.Assignmentdate,
                        Assignmentstatus = c.Assignmentstatus,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Closedate = c.Closedate,
                        Courttype = c.Courttype,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Legalspecialty = c.Legalspecialty,
                        Mattertype = c.Mattertype,
                        Name = c.Name,
                        Previousgroupid = c.Previousgroupid,
                        Previoususerid = c.Previoususerid,
                        Primarycause = c.Primarycause,
                        Publicid = c.Publicid,
                        Reopenedreason = c.Reopenedreason,
                        Resolution = c.Resolution,
                        Retired = c.Retired,
                        Subrorelated = c.Subrorelated,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Validationlevel = c.Validationlevel,
                    };
                }
                else
                {
                    item = new Matter();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Matter();
            }

            return item;
        }

        public async Task<PaginatedList<Matterexposure>> SearchMatterexposure(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Matterexposure> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Matterexposures
                            orderby c.Id ascending
                            select new Matterexposure
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Exposureid = c.Exposureid,
                                Matterid = c.Matterid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Exposureid":
                            query = query.Where(c => c.Exposureid!.ToString()!.Contains(search));
                            break;
                        case "Matterid":
                            query = query.Where(c => c.Matterid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Matterexposure>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Matterexposure> GetMatterexposure(string id)
        {
            Matterexposure item = null!;
            try
            {
                var c = await _context.Matterexposures.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Matterexposure
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Exposureid = c.Exposureid,
                        Matterid = c.Matterid,
                        Publicid = c.Publicid,
                    };
                }
                else
                {
                    item = new Matterexposure();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Matterexposure();
            }

            return item;
        }

        public async Task<PaginatedList<Note>> SearchNote(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Note> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Notes
                            orderby c.Id ascending
                            select new Note
                            {
                                Id = c.Id,
                                Activityid = c.Activityid,
                                Authorid = c.Authorid,
                                Authoringdate = c.Authoringdate,
                                Beanversion = c.Beanversion,
                                Body = c.Body,
                                Claimcontactid = c.Claimcontactid,
                                Claimid = c.Claimid,
                                Confidential = c.Confidential,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                ExpcustomernoteExt = c.ExpcustomernoteExt,
                                Exposureid = c.Exposureid,
                                ExptocustselfserviceExt = c.ExptocustselfserviceExt,
                                Language = c.Language,
                                Matterid = c.Matterid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                ScIsmanualnote = c.ScIsmanualnote,
                                Securitytype = c.Securitytype,
                                Subject = c.Subject,
                                Topic = c.Topic,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Subject":
                            query = query.Where(c => c.Subject!.Contains(search));
                            break;
                        case "Topic":
                            query = query.Where(c => c.Topic!.ToString()!.Contains(search));
                            break;
                        case "Body":
                            query = query.Where(c => c.Body!.ToString()!.Contains(search));
                            break;
                        case "Publicid":
                            query = query.Where(c => c.Publicid!.ToString()!.Contains(search));
                            break;
                        case "Retired":
                            query = query.Where(c => c.Retired!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Note>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Note> GetNote(string id)
        {
            Note item = null!;
            try
            {
                var c = await _context.Notes.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Note
                    {
                        Id = c.Id,
                        Activityid = c.Activityid,
                        Authorid = c.Authorid,
                        Authoringdate = c.Authoringdate,
                        Beanversion = c.Beanversion,
                        Body = c.Body,
                        Claimcontactid = c.Claimcontactid,
                        Claimid = c.Claimid,
                        Confidential = c.Confidential,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        ExpcustomernoteExt = c.ExpcustomernoteExt,
                        Exposureid = c.Exposureid,
                        ExptocustselfserviceExt = c.ExptocustselfserviceExt,
                        Language = c.Language,
                        Matterid = c.Matterid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        ScIsmanualnote = c.ScIsmanualnote,
                        Securitytype = c.Securitytype,
                        Subject = c.Subject,
                        Topic = c.Topic,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        ClaimnumberRefOnly = c.ClaimnumberRefOnly,
                    };
                }
                else
                {
                    item = new Note();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Note();
            }

            return item;
        }

        public async Task<PaginatedList<Policy>> SearchPolicy(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Policy> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Policies
                            orderby c.Id ascending
                            select new Policy
                            {
                                Id = c.Id,
                                Accountnumber = c.Accountnumber,
                                Beanversion = c.Beanversion,
                                Cancellationdate = c.Cancellationdate,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Currency = c.Currency,
                                Effectivedate = c.Effectivedate,
                                Expirationdate = c.Expirationdate,
                                Foreigncoverage = c.Foreigncoverage,
                                Origeffectivedate = c.Origeffectivedate,
                                Otherinsurance = c.Otherinsurance,
                                Policynumber = c.Policynumber,
                                Policytype = c.Policytype,
                                Producercode = c.Producercode,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Retroactivedate = c.Retroactivedate,
                                Returntoworkprgm = c.Returntoworkprgm,
                                ScBrand = c.ScBrand,
                                ScGstexempt = c.ScGstexempt,
                                ScGstregistered = c.ScGstregistered,
                                ScIntermedtype = c.ScIntermedtype,
                                ScStampdutyexempt = c.ScStampdutyexempt,
                                ScUnderwritingcompany = c.ScUnderwritingcompany,
                                Status = c.Status,
                                Totalproperties = c.Totalproperties,
                                Totalvehicles = c.Totalvehicles,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,
                                Validationlevel = c.Validationlevel,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Policynumber":
                            query = query.Where(c => c.Policynumber!.Contains(search));
                            break;
                        case "Publicid":
                            query = query.Where(c => c.Publicid!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Currency":
                            query = query.Where(c => c.Currency.ToString()!.Contains(search));
                            break;
                        case "Policytype":
                            query = query.Where(c => c.Policytype.ToString()!.Contains(search));
                            break;

                    }
                }

                list = await PaginatedList<Policy>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Policy> GetPolicy(string id)
        {
            Policy item = null!;
            try
            {
                var c = await _context.Policies.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Policy
                    {
                        Id = c.Id,
                        Accountnumber = c.Accountnumber,
                        Beanversion = c.Beanversion,
                        Cancellationdate = c.Cancellationdate,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Currency = c.Currency,
                        Effectivedate = c.Effectivedate,
                        Expirationdate = c.Expirationdate,
                        Foreigncoverage = c.Foreigncoverage,
                        Origeffectivedate = c.Origeffectivedate,
                        Otherinsurance = c.Otherinsurance,
                        Policynumber = c.Policynumber,
                        Policytype = c.Policytype,
                        Producercode = c.Producercode,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Retroactivedate = c.Retroactivedate,
                        Returntoworkprgm = c.Returntoworkprgm,
                        ScBrand = c.ScBrand,
                        ScGstexempt = c.ScGstexempt,
                        ScGstregistered = c.ScGstregistered,
                        ScIntermedtype = c.ScIntermedtype,
                        ScStampdutyexempt = c.ScStampdutyexempt,
                        ScUnderwritingcompany = c.ScUnderwritingcompany,
                        Status = c.Status,
                        Totalproperties = c.Totalproperties,
                        Totalvehicles = c.Totalvehicles,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Validationlevel = c.Validationlevel,
                        Verified = c.Verified,
                    };
                }
                else
                {
                    item = new Policy();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Policy();
            }

            return item;
        }

        public async Task<PaginatedList<Policylocation>> SearchPolicylocation(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Policylocation> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Policylocations
                            orderby c.Id ascending
                            select new Policylocation
                            {
                                Id = c.Id,
                                Addressid = c.Addressid,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Locationnumber = c.Locationnumber,
                                Policyid = c.Policyid,
                                Primarylocation = c.Primarylocation,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Addressid":
                            query = query.Where(c => c.Addressid!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Policylocation>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Policylocation> GetPolicylocation(string id)
        {
            Policylocation item = null!;
            try
            {
                var c = await _context.Policylocations.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Policylocation
                    {
                        Id = c.Id,
                        Addressid = c.Addressid,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Locationnumber = c.Locationnumber,
                        Policyid = c.Policyid,
                        Primarylocation = c.Primarylocation,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Policylocation();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Policylocation();
            }

            return item;
        }

        public async Task<PaginatedList<Riskunit>> SearchRiskunit(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Riskunit> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Riskunits
                            orderby c.Id ascending
                            select new Riskunit
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Policyid = c.Policyid,
                                Policylocationid = c.Policylocationid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Runumber = c.Runumber,
                                Subtype = c.Subtype,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;
                        case "Policyid":
                            query = query.Where(c => c.Policyid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Riskunit>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Riskunit> GetRiskunit(string id)
        {
            Riskunit item = null!;
            try
            {
                var c = await _context.Riskunits.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Riskunit
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Policyid = c.Policyid,
                        Policylocationid = c.Policylocationid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Runumber = c.Runumber,
                        Subtype = c.Subtype,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Riskunit();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Riskunit();
            }

            return item;
        }

        public async Task<PaginatedList<Scheduledevent>> SearchScheduledevent(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Scheduledevent> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Scheduledevents
                            orderby c.Id ascending
                            select new Scheduledevent
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Comments = c.Comments,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Eventname = c.Eventname,
                                Paramname1 = c.Paramname1,
                                Paramname2 = c.Paramname2,
                                Paramtype1 = c.Paramtype1,
                                Paramtype2 = c.Paramtype2,
                                Paramvalue1 = c.Paramvalue1,
                                Paramvalue2 = c.Paramvalue2,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Retrycount = c.Retrycount,
                                Scheduleddatetime = c.Scheduleddatetime,
                                Type = c.Type,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimid":
                            query = query.Where(c => c.Claimid!.ToString()!.Contains(search));
                            break;
                        case "Comments":
                            query = query.Where(c => c.Comments!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Scheduledevent>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Scheduledevent> GetScheduledevent(string id)
        {
            Scheduledevent item = null!;
            try
            {
                var c = await _context.Scheduledevents.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Scheduledevent
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Comments = c.Comments,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Eventname = c.Eventname,
                        Paramname1 = c.Paramname1,
                        Paramname2 = c.Paramname2,
                        Paramtype1 = c.Paramtype1,
                        Paramtype2 = c.Paramtype2,
                        Paramvalue1 = c.Paramvalue1,
                        Paramvalue2 = c.Paramvalue2,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Retrycount = c.Retrycount,
                        Scheduleddatetime = c.Scheduleddatetime,
                        Type = c.Type,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Scheduledevent();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Scheduledevent();
            }

            return item;
        }

        public async Task<PaginatedList<Securityzone>> SearchSecurityzone(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Securityzone> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Securityzones
                            orderby c.Id ascending
                            select new Securityzone
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Description = c.Description,
                                Name = c.Name,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Securityzone>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Securityzone> GetSecurityzone(string id)
        {
            Securityzone item = null!;
            try
            {
                var c = await _context.Securityzones.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Securityzone
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Description = c.Description,
                        Name = c.Name,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Securityzone();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Securityzone();
            }

            return item;
        }

        public async Task<PaginatedList<Specialneed>> SearchSpecialneed(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Specialneed> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Specialneeds
                            orderby c.Id ascending
                            select new Specialneed
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Claimfkid = c.Claimfkid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                ScSpecialneed = c.ScSpecialneed,
                                ScSpecialneedcomment = c.ScSpecialneedcomment,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Claimfkid":
                            query = query.Where(c => c.Claimfkid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Specialneed>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Specialneed> GetSpecialneed(string id)
        {
            Specialneed item = null!;
            try
            {
                var c = await _context.Specialneeds.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Specialneed
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Claimfkid = c.Claimfkid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        ScSpecialneed = c.ScSpecialneed,
                        ScSpecialneedcomment = c.ScSpecialneedcomment,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Specialneed();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Specialneed();
            }

            return item;
        }

        public async Task<PaginatedList<User>> SearchUser(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<User> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Users
                            orderby c.Id ascending
                            select new User
                            {
                                Id = c.Id,
                                Authorityprofileid = c.Authorityprofileid,
                                Beanversion = c.Beanversion,
                                Contactid = c.Contactid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Credentialid = c.Credentialid,
                                Defaultcountry = c.Defaultcountry,
                                Defaultphonecountry = c.Defaultphonecountry,
                                Department = c.Department,
                                Externaluser = c.Externaluser,
                                Jobtitle = c.Jobtitle,
                                Language = c.Language,
                                Locale = c.Locale,
                                Obfuscatedinternal = c.Obfuscatedinternal,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Systemusertype = c.Systemusertype,
                                Updatetime = c.Updatetime,
                                Updateuserid = c.Updateuserid,
                                Usersettingsid = c.Usersettingsid,
                                Vacationstatus = c.Vacationstatus,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Authorityprofileid":
                            query = query.Where(c => c.Authorityprofileid!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Contactid":
                            query = query.Where(c => c.Contactid!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<User>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<User> GetUser(string id)
        {
            User item = null!;
            try
            {
                var c = await _context.Users.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new User
                    {
                        Id = c.Id,
                        Authorityprofileid = c.Authorityprofileid,
                        Beanversion = c.Beanversion,
                        Contactid = c.Contactid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Credentialid = c.Credentialid,
                        Defaultcountry = c.Defaultcountry,
                        Defaultphonecountry = c.Defaultphonecountry,
                        Department = c.Department,
                        Externaluser = c.Externaluser,
                        Jobtitle = c.Jobtitle,
                        Language = c.Language,
                        Locale = c.Locale,
                        Obfuscatedinternal = c.Obfuscatedinternal,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Systemusertype = c.Systemusertype,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                        Usersettingsid = c.Usersettingsid,
                        Vacationstatus = c.Vacationstatus,
                        Validationlevel = c.Validationlevel,
                    };
                }
                else
                {
                    item = new User();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new User();
            }

            return item;
        }

        public async Task<PaginatedList<Userroleassign>> SearchUserroleassign(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Userroleassign> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Userroleassigns
                            orderby c.Id ascending
                            select new Userroleassign
                            {
                                Id = c.Id,
                                Active = c.Active,
                                Assignedgroupid = c.Assignedgroupid,
                                Assigneduserid = c.Assigneduserid,
                                Assignmentstatus = c.Assignmentstatus,
                                Beanversion = c.Beanversion,
                                Claimid = c.Claimid,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Role = c.Role,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Active":
                            query = query.Where(c => c.Active!.Contains(search));
                            break;
                        case "Assignedgroupid":
                            query = query.Where(c => c.Assignedgroupid!.ToString()!.Contains(search));
                            break;
                        case "Assigneduserid":
                            query = query.Where(c => c.Assigneduserid!.ToString()!.Contains(search));
                            break;
                        case "Assignmentstatus":
                            query = query.Where(c => c.Assignmentstatus!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Userroleassign>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Userroleassign> GetUserroleassign(string id)
        {
            Userroleassign item = null!;
            try
            {
                var c = await _context.Userroleassigns.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Userroleassign
                    {
                        Id = c.Id,
                        Active = c.Active,
                        Assignedgroupid = c.Assignedgroupid,
                        Assigneduserid = c.Assigneduserid,
                        Assignmentstatus = c.Assignmentstatus,
                        Beanversion = c.Beanversion,
                        Claimid = c.Claimid,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Role = c.Role,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Userroleassign();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Userroleassign();
            }

            return item;
        }

        public async Task<PaginatedList<Usersetting>> SearchUsersetting(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Usersetting> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Usersettings
                            orderby c.Id ascending
                            select new Usersetting
                            {
                                Id = c.Id,
                                Beanversion = c.Beanversion,
                                Createtime = c.Createtime,
                                Createuserid = c.Createuserid,
                                Lastnclaims = c.Lastnclaims,
                                Numopenclaims = c.Numopenclaims,
                                Publicid = c.Publicid,
                                Retired = c.Retired,
                                Startuppage = c.Startuppage,
                                Updatetime = c.Updatetime,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Id":
                            query = query.Where(c => c.Id!.ToString()!.Contains(search));
                            break;
                        case "Beanversion":
                            query = query.Where(c => c.Beanversion!.ToString()!.Contains(search));
                            break;
                        case "Createtime":
                            query = query.Where(c => c.Createtime!.ToString()!.Contains(search));
                            break;
                        case "Createuserid":
                            query = query.Where(c => c.Createuserid!.ToString()!.Contains(search));
                            break;
                        case "Lastnclaims":
                            query = query.Where(c => c.Lastnclaims!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Usersetting>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Usersetting> GetUsersetting(string id)
        {
            Usersetting item = null!;
            try
            {
                var c = await _context.Usersettings.FirstOrDefaultAsync(m => m.Id == Convert.ToDecimal(id));
                if (c != null)
                {
                    item = new Usersetting
                    {
                        Id = c.Id,
                        Beanversion = c.Beanversion,
                        Createtime = c.Createtime,
                        Createuserid = c.Createuserid,
                        Lastnclaims = c.Lastnclaims,
                        Numopenclaims = c.Numopenclaims,
                        Publicid = c.Publicid,
                        Retired = c.Retired,
                        Startuppage = c.Startuppage,
                        Updatetime = c.Updatetime,
                        Updateuserid = c.Updateuserid,
                    };
                }
                else
                {
                    item = new Usersetting();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Usersetting();
            }

            return item;
        }

        public async Task<List<Claim>> GetClaimList(string claimid)
        {
            List<Claim> claimslist = new List<Claim>();

            // get claimcontacts
            var claims = await SearchClaim("Id", claimid.ToString()!, 1, 10);

            foreach (var claim in claims)
            {
                claimslist.Add(claim);
            }

            return claimslist;
        }

        public async Task<List<AsteronModels.Activity>> GetClaimActivityList(string claimid)
        {
            List<AsteronModels.Activity> activities = new List<AsteronModels.Activity>();

            // get claimcontacts
            var claimactivities = await SearchActivity("Claimid", claimid.ToString()!, 1, 10);

            foreach (var activity in claimactivities)
            {
                activities.Add(activity);
            }

            return activities;
        }

        public async Task<List<Address>> GetClaimAddressList(string claimid)
        {
            List<Address> addresses = new List<Address>();

            // get claimcontacts
            var claimcontacts = await SearchClaimcontact("Claimid", claimid.ToString()!, 1, 10);

            foreach (var contact in claimcontacts)
            {
                var address = await SearchAddress("Contactid", contact.Contactid.ToString()!, 1, 10);
                foreach (var address2 in address)
                {
                    addresses.Add(address2);
                }
            }

            return addresses;
        }

        public async Task<List<Contact>> GetClaimContactsList(string claimid) 
        {
            List<Contact> contacts = new List<Contact>();

            // get claimcontacts
            var claimcontacts = await SearchClaimcontact("Claimid", claimid.ToString()!, 1, 10);

            foreach (var claimcontact in claimcontacts) 
            {
                var contact = await GetContact(claimcontact.Contactid.ToString()!);
                contacts.Add(contact);
            }

            return contacts;
        }

        public async Task<List<Document>> GetClaimDocumentsList(string claimid)
        {
            List<Document> documents = new List<Document>();

            // get claimcontacts
            var claimdocs = await SearchDocument("Claimid", claimid.ToString()!, 1, 10);

            foreach (var document in claimdocs)
            {
                documents.Add(document);
            }

            return documents;
        }

        public async Task<List<Incident>> GetClaimIncidentList(string claimid)
        {
            List<Incident> incidents = new List<Incident>();

            // get claimcontacts
            var claimincidents = await SearchIncident("Claimid", claimid.ToString()!, 1, 10);

            foreach (var incident in claimincidents)
            {
                incidents.Add(incident);
            }

            return incidents;
        }

        public async Task<List<Note>> GetClaimNotesList(string claimid)
        {
            List<Note> notes = new List<Note>();

            // get claimcontacts
            var claimnotes = await SearchNote("Claimid", claimid.ToString()!, 1, 10);

            foreach (var note in claimnotes)
            {
                notes.Add(note);
            }

            return notes;
        }

        public async Task<List<Policy>> GetClaimPolicyList(string claimid)
        {
            List<Policy> policylist = new List<Policy>();

            // get claimcontacts
            var claimlist = await GetClaimList(claimid);

            foreach (var claim in claimlist)
            {
                var policy = await GetPolicy(claim.Policyid!.ToString()!);
                policylist.Add(policy);
            }

            return policylist;
        }

        public async Task<ActivityLinks> GetActivityDetails(string activityid)
        {
            ActivityLinks link = new ActivityLinks();

            try
            {
                // get activity
                var activity = await GetActivity(activityid);
                string claimid = activity.Claimid.ToString()!;

                link.ActivityList = await GetClaimActivityList(claimid);
                link.ClaimList = await GetClaimList(claimid);
                link.PolicyList = await GetClaimPolicyList(claimid);
                link.ContactList = await GetClaimContactsList(claimid);
                link.DocumentList = await GetClaimDocumentsList(claimid);
                link.AddressList = await GetClaimAddressList(claimid);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return link;
        }

        public async Task<ActivityLinks> GetClaimDetails(string claimid)
        {
            ActivityLinks link = new ActivityLinks();

            try
            {
                link.ActivityList = await GetClaimActivityList(claimid);
                link.ClaimList = await GetClaimList(claimid);
                link.PolicyList = await GetClaimPolicyList(claimid);
                link.ContactList = await GetClaimContactsList(claimid);
                link.DocumentList = await GetClaimDocumentsList(claimid);
                link.AddressList = await GetClaimAddressList(claimid);
                link.NoteList = await GetClaimNotesList(claimid);
                link.IncidentList = await GetClaimIncidentList(claimid);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return link;
        }

        public async Task<ActivityLinks> GetNoteDetails(string noteid)
        {
            ActivityLinks link = new ActivityLinks();

            try
            {
                // get activity
                var note = await GetNote(noteid);
                string claimid = note.Claimid.ToString()!;

                link.ActivityList = await GetClaimActivityList(claimid);
                link.ClaimList = await GetClaimList(claimid);
                link.PolicyList = await GetClaimPolicyList(claimid);
                link.ContactList = await GetClaimContactsList(claimid);
                link.DocumentList = await GetClaimDocumentsList(claimid);
                link.AddressList = await GetClaimAddressList(claimid);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return link;
        }

    }
}

using AppCoreV1.Data;
using AppCoreV1.Interfaces;
using AppCoreV1.Repositories;
using CsvHelper;
using CsvHelper.Configuration;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Text;

namespace AppCoreV1.Helper
{
    public class ABLEExport : IABLEExport, IDisposable
    {
        private readonly AbleDBContext _context;
        private readonly ILogger<ABLEExport> _logger;

        public ABLEExport(AbleDBContext context, ILogger<ABLEExport> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool CreateTablesFile(List<string> items, string fileName)
        {
            try
            {
                // check file exists
                if (File.Exists(fileName))
                {
                    var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true
                    };

                    using (var stream = File.Open(fileName, FileMode.Create))
                    using (var writer = new StreamWriter(stream))
                    using (var csv = new CsvWriter(writer, configPersons))
                    {
                        csv.WriteRecords(items);
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool CreateColumnsFile(List<string> items, string fileName)
        {
            try
            {
                // check file exists
                if (File.Exists(fileName))
                {
                    var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true
                    };

                    using (var stream = File.Open(fileName, FileMode.Create))
                    using (var writer = new StreamWriter(stream))
                    using (var csv = new CsvWriter(writer, configPersons))
                    {
                        csv.WriteRecords(items);
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool CreateDocItemsFile(List<string> items, string fileName)
        {
            try
            {
                // check file exists
                if (File.Exists(fileName))
                {
                    var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true
                    };

                    using (var stream = File.Open(fileName, FileMode.Create))
                    using (var writer = new StreamWriter(stream))
                    using (var csv = new CsvWriter(writer, configPersons))
                    {
                        csv.WriteRecords(items);
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool CreateTableFile()
        {
            try
            {
                string datafileName = @"D:\Temp\FSF071_Pipe_Export.txt";
                string csvfileName = @"D:\Temp\FSF071_Pipe_ExportCSV.csv"; ;

                using var sr = new StreamReader(datafileName);
                string? line;
                StringBuilder sb = new StringBuilder();

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Replace(",", "");
                    line = line.Replace("|", ",");
                    sb.AppendLine(line);
                    //Console.WriteLine(line);
                }

                CreateTextFile(csvfileName);

                // check file exists
                if (File.Exists(csvfileName))
                {
                    var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true
                    };

                    using (var stream = File.Open(csvfileName, FileMode.Create))
                    using (var writer = new StreamWriter(stream))
                        writer.Write(sb.ToString());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public void CreateTextFile(string fileName)
        {
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (StreamWriter sr = File.CreateText(fileName))
                {
                    // Add some text to file    
                    //sr.WriteLine("");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public async Task<bool> CreateCSVFile_Old(string filePath, string strReport, string id)
        {
            var con = (SqlConnection)_context.Database.GetDbConnection();
            string strSql = "";
            int _count = 0;
            bool result = false;

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                var cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                strSql = "Select Count(*) From " + strReport + ";";
                cmd.CommandText = strSql;
                var obj = await cmd.ExecuteScalarAsync();
                _count = Convert.ToInt32(obj);

                int counter = 0;
                int increment = 10000;
                int rowscount = _count + 10;

                for (counter = 0; counter < rowscount; counter += increment)
                {
                    strSql = "Select * From " + strReport + " Order By [" + id + "] offset " + counter.ToString() + " rows fetch next " + increment.ToString() + " rows only;";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = strSql;

                    _logger.LogError("Fetching :" + strSql);
                    SqlDataReader reader = null!;
                    reader = await cmd.ExecuteReaderAsync();

                    using (StreamWriter writer = System.IO.File.AppendText(filePath))
                    {
                        if (counter == 0)
                        {
                            await writer.WriteLineAsync(string.Join(",", Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList()));
                        }

                        while (reader.Read())
                        {
                            await writer.WriteLineAsync(string.Join(",", Enumerable.Range(0, reader.FieldCount).Select(reader.GetValue).ToList()));
                        }

                        writer.Flush();
                    }

                    await reader.CloseAsync();
                }

                result = true;
            }
            catch(Exception ex) 
            {
                // log error
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> CreateCSVFile(string filePath, string strReport, string id)
        {
            var con = (SqlConnection)_context.Database.GetDbConnection();
            string strSql = "";
            int counter = 0;
            bool result = false;

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                var cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                strSql = "Select * From " + strReport + ";";
                cmd.CommandText = strSql;

                _logger.LogError("Fetching :" + strSql);
                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                using (StreamWriter writer = System.IO.File.AppendText(filePath))
                {
                    if (counter == 0)
                    {
                        await writer.WriteLineAsync(string.Join(",", Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList()));
                    }

                    while (reader.Read())
                    {
                        await writer.WriteLineAsync(string.Join(",", Enumerable.Range(0, reader.FieldCount).Select(reader.GetValue).ToList()));
                    }

                    counter++;
                    if (counter % 100 == 0)
                    {
                        writer.Flush();
                    }
                }

                await reader.CloseAsync();

                result = true;
            }
            catch (Exception ex)
            {
                // log error
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> CreateCSV(IDataReader reader, string filePath)
        {
            bool result = false;
            try
            {

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    await writer.WriteLineAsync(string.Join(",", Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList()));
                    int count = 0;

                    while (reader.Read())
                    {
                        await writer.WriteLineAsync(string.Join(",", Enumerable.Range(0, reader.FieldCount).Select(reader.GetValue).ToList()));
                        if (++count % 100 == 0)
                        {
                            writer.Flush();
                        }
                    }
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> RptAbleUser()
        {
            string filename = @"AbleUser";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_ABLEUSERS", "Claim User ID");
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptAbleUserRole()
        {
            string filename = @"AbleUserRole";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_ABLEUSERSALLROLES", "Claim User ID");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptActionService()
        {
            string filename = @"ActionService";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_ACTIONSSERVICES", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptCaseAction()
        {
            string filename = @"CaseAction";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CASEACTIONS", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptClaimBenefit()
        {
            string filename = @"ClaimBenefit";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "CLAIMBENEFITMV", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptClaimBenefitActuarialRec()
        {
            string filename = @"RptClaimBenefitActuarialRec";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CLAIMBENEFITACTUARIALREC", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptClaimBenefitGroup()
        {
            string filename = @"RptClaimBenefitGroup";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CLAIMBENEFITGROUP", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptClaimBenefitReinsurance()
        {
            string filename = @"RptClaimBenefitReinsurance";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CLAIMBENEFITREINSURANCE", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptClaimBenefitWS()
        {
            string filename = @"RptClaimBenefitWS";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CLAIMBENEFITWS", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptClaimCaseDecipha()
        {
            string filename = @"RptClaimCaseDecipha";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CLAIMCASEDECIPHA", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptClaimExpense()
        {
            string filename = @"RptClaimExpense";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CLAIMEXPENSES", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptClaimParticipant()
        {
            string filename = @"RptClaimParticipant";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CLAIMPARTICIPANT", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptClosedTaskReport()
        {
            string filename = @"RptClosedTaskReport";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CLOSEDTASKREPORT", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptCMPActions()
        {
            string filename = @"RptCMPActions";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CMPACTIONS", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptCMPGDMovements()
        {
            string filename = @"RptCMPGDMovements";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CMPGOALDATEMOVEMENTS", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptCMPPlanStatus()
        {
            string filename = @"RptCMPPlanStatus";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CMPPLANSTATUS", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptCMPService()
        {
            string filename = @"RptCMPService";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_CMPSERVICES", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptComplaints()
        {
            string filename = @"RptComplaints";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_COMPLIANTS", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptDocumentReport()
        {
            string filename = @"RptDocumentReport";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_DOCUMENTREPORT", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptEnquiryCaseReport()
        {
            string filename = @"RptEnquiryCaseReport";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_ENQUIRYCASEREPORT", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptHCRCompletedNotes()
        {
            string filename = @"RptHCRCompletedNotes";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_HCRCOMPLETEDNOTES", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptOpenTask()
        {
            string filename = @"RptOpenTask";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_OPENTASK", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptOverrideRiskReport()
        {
            string filename = @"RptOverrideRiskReport";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_OVERRIDERISKREPORT", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptPaymentSummary()
        {
            string filename = @"RptPaymentSummary";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "PAYMENTSUMMARYMV", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptPaymentSummaryLS()
        {
            string filename = @"RptPaymentSummaryLS";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_PAYMENTSUMMARYLS", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptPhoneEnquiry()
        {
            string filename = @"RptPhoneEnquiry";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_PHONEENQUIRY", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptRecoveryRehabNote()
        {
            string filename = @"RptRecoveryRehabNote";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_RECOVERYREHABNOTES", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptTaskReport()
        {
            string filename = @"RptTaskReport";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "TASKMV", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptTaskReportGroup()
        {
            string filename = @"RptTaskReportGroup";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_TASKREPORTGROUP", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }

        public async Task<bool> RptTaskReportReinsurance()
        {
            string filename = @"RptTaskReportReinsurance";
            string extension = "txt";
            string path = @"\\wlife.com.au\apps\ClaimsCentral\Figtree Reports\Actuarial\";
            bool result;

            try
            {
                result = false;
                // create fileName
                var filePath = System.IO.Path.Combine(string.IsNullOrEmpty(path) ? System.IO.Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));

                // create text file
                CreateTextFile(filePath);

                // get data reader
                result = await CreateCSVFile(filePath, "RPT_TASKREPORTREINSURANCE", "Id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result = false;
            }

            return result;
        }
    }
}

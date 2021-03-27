using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using VPNHelperCommon.Clients;
using VPNHelperCommon.Models;
using VPNHelperLibrary.Models;

namespace VPNHelperService.Services
{
    public class NordVPNService : INordVPNService
    {
        private INordVPNApiClient ApiClient { get; }

        public NordVPNService(INordVPNApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        public async Task<bool> GetServers(CountryModel country)
        {
            try
            {
                var apiUrl = ApiClient.GetApiUrl("server");
                var response = await ApiClient.GetAsync<List<Server>>(apiUrl);

                if (response.Content != null && response.Content.Any())
                {
                    if (response.Content.Any(x => x.Domain.StartsWith(country.Abrv, StringComparison.InvariantCultureIgnoreCase) && x.Load < 50))
                    {
                        var servers = response.Content.Where(x => x.Domain.StartsWith(country.Abrv, StringComparison.InvariantCultureIgnoreCase)).OrderBy(x => x.Load);
                        await GenerateServerExcelFile(servers, country);

                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task GenerateServerExcelFile(IEnumerable<Server> servers, CountryModel country)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo($"D:\\Servers\\Servers-{country.Name}-{DateTime.Now:dd-MM-yyyy-HH-mm-ss}.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet 1");

                var row = 1;

                worksheet.Cells[row, 1].Value = "Server";
                worksheet.Cells[row, 2].Value = "Load";
                worksheet.Cells[row, 3].Value = "IP";
                worksheet.Cells[row, 4].Value = "Ping";

                row++;

                Ping p = new Ping();

                foreach (var server in servers.Where(x => x.Load < 50).Take(1000))
                {
                    var ping = string.Empty;
                    try
                    {
                        long total = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            PingReply reply = p.Send(server.IPAddress, 1000);
                            if (reply != null)
                            {
                                total += reply.RoundtripTime;
                            }
                        }
                        if (total > 0)
                        {
                            ping = $"{total / 5}ms";
                        }
                        else
                        {
                            ping = "Couldn't connect.";
                        }
                    }
                    catch
                    {
                        ping = "Couldn't connect.";
                    }

                    var column = 1;
                    worksheet.Cells[row, column].Value = server.Domain;
                    column++;
                    worksheet.Cells[row, column].Value = $"{server.Load}%";
                    column++;
                    worksheet.Cells[row, column].Value = String.Format("{0} {1}", server.IPAddress, server.Features.OpenVPNTcp ? "443" : "1194");
                    column++;
                    worksheet.Cells[row, column].Value = ping;

                    row++;
                }

                p.Dispose();

                await package.SaveAsync();
            }
        }
    }
}

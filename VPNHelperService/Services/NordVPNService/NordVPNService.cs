using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPNHelperCommon.Clients;
using VPNHelperCommon.Models;

namespace VPNHelperService.Services
{
    public class NordVPNService : INordVPNService
    {
        private INordVPNApiClient ApiClient { get; }

        public NordVPNService(INordVPNApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        public async Task<IEnumerable<IResult>> GetServers(string country)
        {
            try
            {
                var apiUrl = ApiClient.GetApiUrl("server");
                var response = await ApiClient.GetAsync<List<Server>>(apiUrl);

                if (response.Content != null && response.Content.Any())
                {
                    if (response.Content.Any(x => x.Domain.StartsWith(country, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        var servers = response.Content.Where(x => x.Domain.StartsWith(country, StringComparison.InvariantCultureIgnoreCase)).OrderBy(x => x.Load);
                        await GenerateServerExcelFile(servers);

                        return servers.Take(10).Select(x => new Result
                        {
                            Server = x.Domain,
                            Load = $"{x.Load}%"
                        });
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task GenerateServerExcelFile(IEnumerable<Server> servers)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo($"D:\\Servers\\Servers-{DateTime.Now:dd-MM-yyyy-HH-mm}.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet 1");

                var row = 1;

                worksheet.Cells[row, 1].Value = "Server";
                worksheet.Cells[row, 2].Value = "Load";
                worksheet.Cells[row, 3].Value = "IP";

                row++;

                foreach (var server in servers.Take(100))
                {
                    var column = 1;
                    worksheet.Cells[row, column].Value = server.Domain;
                    column++;
                    worksheet.Cells[row, column].Value = $"{server.Load}%";
                    column++;
                    worksheet.Cells[row, column].Value = String.Format("{0} {1}", server.IPAddress, server.Features.OpenVPNTcp ? "443" : "1194");
                    column++;
                    worksheet.Cells[row, column].Value = server.Features.OpenVPNTcp ? "TCP" : "UDP";

                    row++;
                }

                await package.SaveAsync();
            }
        }
    }
}

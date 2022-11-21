﻿using Gehtsoft.PDFFlow.Builder;
using Gehtsoft.PDFFlow.Models.Enumerations;
using IntegrationLibrary.Core.Enums;
using IntegrationLibrary.Features.BloodBankReports.DTO;
using IntegrationLibrary.Features.BloodBankReports.Mapper;
using IntegrationLibrary.Features.BloodBankReports.Model;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.HospitalRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.BloodBankReports.Service
{
    public class BBReportsService : IBBReportsService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private readonly IHospitalRepository _hospitalRepository;


        public BBReportsService(IHospitalRepository hospitalRepository)
        {
            this._hospitalRepository = hospitalRepository;
        }

        public String GenerateReport(List<BloodUsageEvidency> evidencies, int days)
        {
            double totalAPlus = 0, totalAMinus = 0, totalBPlus = 0, totalBMinus = 0, totalABPlus = 0, totalABMinus = 0, totalOPlus = 0, totalOMinus = 0;
            var folderPath = Environment.CurrentDirectory + "/PDFs";
            var filePath = Path.Combine(folderPath, "Report" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString()
                + "-" + DateTime.Now.Year.ToString() + "-" +
                DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + ".pdf");

            var myStream = new FileStream(filePath, FileMode.Create);

            DocumentBuilder builder = DocumentBuilder.New();
            var section = builder.AddSection();
            section.AddParagraph("Report for the past " + days.ToString() + " days").SetFontSize(20).SetAlignment(HorizontalAlignment.Center).ToDocument();

            foreach (BloodUsageEvidency evidency in evidencies)
            {
                section.AddParagraph("On the day of " + evidency.DateOfUsage.ToShortDateString().ToString() + ", " + evidency.QuantityUsedInMililiters + "ml of blood type " + evidency.BloodType.ToString() + " was used.").SetFontSize(14).SetMarginTop(10).ToDocument();
                switch (evidency.BloodType)
                {
                    case BloodType.A_PLUS:
                        {
                            totalAPlus += evidency.QuantityUsedInMililiters;
                            break;
                        }
                    case BloodType.A_MINUS:
                        {
                            totalAMinus += evidency.QuantityUsedInMililiters;
                            break;
                        }
                    case BloodType.B_PLUS:
                        {
                            totalBPlus += evidency.QuantityUsedInMililiters;
                            break;
                        }
                    case BloodType.B_MINUS:
                        {
                            totalBMinus += evidency.QuantityUsedInMililiters;
                            break;
                        }
                    case BloodType.AB_MINUS:
                        {
                            totalABMinus += evidency.QuantityUsedInMililiters;
                            break;
                        }
                    case BloodType.AB_PLUS:
                        {
                            totalABPlus += evidency.QuantityUsedInMililiters;
                            break;
                        }
                    case BloodType.O_MINUS:
                        {
                            totalOMinus += evidency.QuantityUsedInMililiters;
                            break;
                        }
                    case BloodType.O_PLUS:
                        {
                            totalOPlus += evidency.QuantityUsedInMililiters;
                            break;
                        }
                    default:
                        break;
                }
            }
            section.AddLine().ToDocument();
            section.AddParagraph("Total blood of type A positive spent: " + totalAPlus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type A negative spent: " + totalAMinus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type B positive spent: " + totalBPlus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type B negative spent: " + totalBMinus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type AB positive spent: " + totalABPlus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type AB negative spent: " + totalABMinus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type O positive spent: " + totalOPlus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type O negative spent: " + totalOMinus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            builder.Build(myStream);
            myStream.Close();
            return filePath;
        }

        public async void SendReportInRequest(String filePath)
        {
            var url = "http://localhost:6555/api/blood-use-report";

            using var requestContent = new MultipartFormDataContent();
            using var fileStream = File.OpenRead(filePath);
            requestContent.Add(new StreamContent(fileStream), "file", filePath);
            await _httpClient.PostAsync(url,requestContent);
        }

        public List<BloodUsageEvidency> GetEvidencies(int days)
        {
            List<BloodUsageEvidency> allEvidency = _hospitalRepository.GetAllEvidency().Result;
            List<BloodUsageEvidency> ret = new List<BloodUsageEvidency>();
            DateTime minDate = DateTime.Now.AddDays(-days);

            foreach (BloodUsageEvidency evidency in allEvidency)
            {
                if (evidency.DateOfUsage >= minDate)
                {
                    ret.Add(evidency);
                }
            }
            return ret;
        }

        public  void SendReport(int days)
        {
            List<BloodUsageEvidency> desiredEvidency = GetEvidencies(days);
            String filePath = GenerateReport(desiredEvidency, days);
            SendReportInRequest(filePath);
            //TO DO: Dodati da se generisani pdf-ovi salju
        }
    }
}

using Aspose.Cells;
using Aspose.Cells.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Net;

namespace FemiHealthArabForum.Models
{
    public class AtendeeLogic
    {
        public static List<Atendee> attendees = new List<Atendee>();

        public string AddAttendee(Atendee atendee, string path)
        {
            FillArray(path);

            var attendeeCount = attendees.Count + 1;
            var attendeeID = WebConfigurationManager.AppSettings["IDStartValue"] + attendeeCount;

            attendees.Add(new Atendee()
            {
                Name = atendee.Name,
                Email = atendee.Email,
                ID = attendeeID,
                Phone = atendee.Phone,

            });


            string json = JsonConvert.SerializeObject(attendees.ToArray());

            //write string to file
            System.IO.File.WriteAllText(path, json);
            return attendeeID;
        }
        public void FillArray(string path)
        {
            if (attendees.Count == 0)
            {
                string jsonInput = File.ReadAllText(path);
                if (!string.IsNullOrEmpty(jsonInput))
                {
                    attendees = JsonConvert.DeserializeObject<List<Atendee>>(jsonInput);
                }
            }
        }
        public void Delete(string id, string path)
        {
            var toBeDel = AtendeeLogic.attendees.Where(at => at.ID == id).FirstOrDefault();
            if (toBeDel != null)
            {
                AtendeeLogic.attendees.Remove(toBeDel);

                string json = JsonConvert.SerializeObject(attendees.ToArray());

                //write string to file
                System.IO.File.WriteAllText(path, json);
            }
        }
        public void ExportToExcel(string jsonPath, string excelPath)
        {
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            // Read JSON File
            string jsonInput = File.ReadAllText(jsonPath);

            // Set Styles
            CellsFactory factory = new CellsFactory();
            Style style = factory.CreateStyle();
            style.HorizontalAlignment = TextAlignmentType.Center;
            style.Font.Color = System.Drawing.Color.BlueViolet;
            style.Font.IsBold = true;

            // Set JsonLayoutOptions
            JsonLayoutOptions options = new JsonLayoutOptions();
            options.TitleStyle = style;
            options.ArrayAsTable = true;

            // Import JSON Data
            JsonUtility.ImportData(jsonInput, worksheet.Cells, 0, 0, options);

            // Save Excel file
            workbook.Save(excelPath);
        }


    }
}
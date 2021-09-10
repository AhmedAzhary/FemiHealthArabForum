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

namespace FemiHealthArabForum.Models
{
    public class AtendeeLogic
    {
        public static List<Atendee> attendees = new List<Atendee>();

        public void AddAttendee(Atendee atendee) {
            var attendeeCount = attendees.Count + 1;
            var attendeeID = WebConfigurationManager.AppSettings["IDStartValue"] + attendeeCount;

            attendees.Add(new Atendee()
            {
                Name = atendee.Name,
                Email = atendee.Email,
                 ID= attendeeID,
                Phone = atendee.Phone,
                
            });

            string json = JsonConvert.SerializeObject(attendees.ToArray());

            //write string to file
            System.IO.File.WriteAllText(@"D:\AttendeesJson.json", json);
        }

        public void ExportToExcel() {
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            // Read JSON File
            string jsonInput = File.ReadAllText(@"D:\AttendeesJson.json");

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
            workbook.Save(@"D:\Attendee-Excel.xlsx");
        }
        

}
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace NYSS__Lab2.Models
{
   public class ExcelParser
   {
       public static IEnumerable<Data> GetFullData(string path)
       {
           using (IXLWorkbook workbook = new XLWorkbook(path))
           {
               IXLWorksheet worksheet = workbook.Worksheets.Worksheet(1);
               for (int row = 3; !string.IsNullOrEmpty(worksheet.Cell(row, 1).GetString()); ++row)
               {
                   Data newData = new Data
                   {
                       Id = worksheet.Cell(row, 1).GetValue<int>(),
                       Name = worksheet.Cell(row, 2).GetValue<string>(),
                       Description = worksheet.Cell(row, 3).GetValue<string>(),
                       Source = worksheet.Cell(row, 4).GetValue<string>(),
                       Target = worksheet.Cell(row, 5).GetValue<string>(),
                       ConfidentialityOffense = worksheet.Cell(row, 6).GetValue<string>() == "1" ? "да" : "нет",
                       ContinuityOffense = worksheet.Cell(row, 7).GetValue<string>() == "1" ? "да" : "нет",
                       AvailabilityOffense = worksheet.Cell(row, 8).GetValue<string>() == "1" ? "да" : "нет"
                   };
                   yield return newData;
               }
           }
       }

       public static IEnumerable<ShortData> GetShortData(ObservableCollection<Data> data)
       {
           foreach (var dataitem in data)
           {
               ShortData shortData = new ShortData
               {
                   Id = dataitem.Id.ToString(),
                   Name = dataitem.Name
               };
               yield return shortData;
           }
       }

       private static string ShortDataId(string id)
       {
           switch (id.Length)
           {
               case 3:
                   return "УБИ." + id;
               case 2:
                   return "УБИ.0" + id;
               case 1:
                   return "УБИ.00" + id;
           }
           return string.Empty;
       }

    }
}

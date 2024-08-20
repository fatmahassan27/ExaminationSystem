using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL
{
    public static class UploadImage
    {
  

         public static string Upload(string folderName, IFormFile file)
           {
              try
              {
                      string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
                      string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                      string finalPath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(finalPath, FileMode.Create))
                     {
                         file.CopyTo(stream);
                     }

                       return fileName;
              }
              catch (Exception ex)
              {
                  return ex.Message;
              }
    }

    }
}

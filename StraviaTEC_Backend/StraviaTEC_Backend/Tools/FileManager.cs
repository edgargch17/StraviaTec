using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Tools
{
    public static class FileManager
    {
        public static string findExtension(string filename)
        {
            int pointIndex = filename.IndexOf('.');
            string extension = filename.Substring(pointIndex);
            return extension;
        }

        public static string saveFile(UploadFile file, string token)
        {
            string fileName = file.file.FileName;
            string destination = AppDomain.CurrentDomain.BaseDirectory + "/Database";


            switch (findExtension(fileName))
            {
                case ".jpg":
                    destination += "/photos/";
                    break;
                case ".jpeg":
                    destination += "/photos/";
                    break;
                case ".png":
                    destination += "/photos/";
                    break;
                case ".gpx":
                    destination += "/gpxs/";
                    break;
                default:
                    return null;
            }

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            string fullPath = destination + "/" + file.file.FileName;

            bool dbApproved = Connector.savePhoto(token, fullPath);

            if (dbApproved)
            {

                using (FileStream fileStream = System.IO.File.Create(fullPath))
                {
                    file.file.CopyTo(fileStream);
                    fileStream.Flush();
                    return destination + "/" + file.file.FileName;
                }

            }

            return null;
        }

        public static FileStream getUserPhoto(string token)
        {
            FileStream picture = File.OpenRead(Connector.getPhotoPath(token));

            if (picture != null)
            {
                return picture;
            }

            return null;
        }
    }
}

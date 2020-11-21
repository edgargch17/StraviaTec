﻿using System;
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
            return extension.ToLower();
        }

        public static string saveFile(FileUPloadAPI file, string username)
        {
            string fileName = file.files.FileName;
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

            string fullPath = destination + "/" + file.files.FileName;
            Connector connector = new Connector();
            bool dbApproved = connector.savePhoto(username, fullPath);
            //bool dbApproved = Connector.savePhoto(fullPath);

            if (dbApproved)
            {
                using (FileStream fileStream = System.IO.File.Create(fullPath))
                {
                    file.files.CopyTo(fileStream);
                    fileStream.Flush();
                    return destination + "/" + file.files.FileName;
                }

            }

            return null;
        }

        /*public static FileStream getUserPhoto(string token)
        {
            FileStream picture = File.OpenRead(Connector.getPhotoPath(token));

            if (picture != null)
            {
                return picture;
            }

            return null;
        }*/
    }
}

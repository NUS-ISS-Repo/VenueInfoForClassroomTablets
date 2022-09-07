using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Collections;
using System.Configuration;

namespace ClassVenueInfo.Controllers
{
    public class LogCreation
    {
        private string strLogFile;
        private string strLogFolder;
        string dirName = "";
        
        // property to get and set the course name
        public string StrLogFile
        {   
            get
            {               
                return strLogFile;
            }  // end get 
            set
            {    
                strLogFile = value; 
            }  // end set 
        }

        public string StrLogFolder
        {
            get
            {
                strLogFolder = ConfigurationManager.AppSettings["LOG"].ToString();
                return strLogFolder;
            }  // end get 
          
        }

        public void Init()
        {
            DateTime now = DateTime.Now;
            StrLogFile = ConfigurationManager.AppSettings["LOG_FILENAME"].ToString();
            StrLogFile = (dirName.Length > 0 ? (dirName + "\\" + StrLogFolder  + StrLogFile + " " + now.ToString("yyyy") + ".txt") : StrLogFolder  + StrLogFile +  " " + now.ToString("yyyy") + ".txt");
                             
        }
        
        public void writeToLogFile(string logMessage)
        {            
            string strLogMessage = string.Empty;           

            strLogMessage = string.Format("{0}: {1}", DateTime.Now, logMessage);

            if (string.IsNullOrEmpty(StrLogFile))
            {
                Init();
            }

            if (!Directory.Exists(Path.GetDirectoryName(StrLogFolder)))
            {
                Directory.CreateDirectory(StrLogFolder);
            }

            if (!Directory.Exists(Path.GetDirectoryName(StrLogFolder)))
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(Path.Combine(StrLogFolder, StrLogFile), false, Encoding.UTF8))
            {
                sw.WriteLine(strLogMessage);
            }

            if (!File.Exists(Path.Combine(StrLogFolder, StrLogFile)))
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(StrLogFolder, StrLogFile), false))
                {
                    sw.WriteLine(strLogMessage);
                }
            }
            else
            {
                using (FileStream fs = new FileStream(Path.Combine(StrLogFolder, StrLogFile), FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(strLogMessage);
                }
            }

        }

      
    }
}


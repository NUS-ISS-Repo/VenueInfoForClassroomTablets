using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;

namespace ClassVenueInfo.Controllers
{
    class Program
    {
        private static string returnMessage;

        static void Main(string[] args)
        {
            LogCreation objLogFile = new LogCreation();
            Genfunction objGenfunction = new Genfunction(objLogFile);

            string RETRIEVE_JSON_SP_NAME = string.Empty;
            string ls_dummy = "";
            string returnMessage = string.Empty;
            DataSet retDataSet = new DataSet();
            DateTime now = DateTime.Now;

            objLogFile.writeToLogFile("Start Processing.");
            string SP_Name = ConfigurationManager.AppSettings["RETRIEVE_JSON_SP_NAME"].ToString();

            object[] objParameters = null;
            objLogFile.writeToLogFile("Start writing Json from database to the file.");
            if (objGenfunction.GetData(ref retDataSet, ref ls_dummy, SP_Name, objParameters, ref returnMessage) == true)
            {
                string retJsonFromDB = retDataSet.Tables[0].Rows[0]["Column1"].ToString();
                objGenfunction.writeToFile(retJsonFromDB);
            }
            objLogFile.writeToLogFile("End writing file.");
        }

    }
}

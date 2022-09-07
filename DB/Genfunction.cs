using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.IO;
using System.Net.Mail;
using Newtonsoft.Json;
using System.Web.Script.Serialization;


using System.Data.SqlClient;

namespace ClassVenueInfo.Controllers
{
    class Genfunction
    {
        LogCreation objLogFile;

        // protected Microsoft.Practices.EnterpriseLibrary.Data.Database objDB;
        protected SqlConnection objDB;
        public Genfunction(LogCreation objLogFile)
        {
            
            DBGateway objDBGateway = new DBGateway();
            objDB = objDBGateway.IsDBConnected();
            this.objLogFile = objLogFile;

        }

        public Genfunction(ref SqlConnection objDatabase)
        {
            objDB = objDatabase;
        }


        private enum ExecuteType
        {
            NonQuery,
            Scalar,
            Reader,
            DataRow,
            DataTable,
            DataSet
        }

        public bool GetData(ref DataSet ds, ref string ScalarValue, string storedProcedureName, string parameters, ref string errorMessage)
        {

            bool isSuccess = false;
            try
            {
                string returnValue = string.Empty;
                isSuccess = Execute(ref ds, ref ScalarValue, storedProcedureName, parameters, ExecuteType.DataSet, ref errorMessage);

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                objLogFile.writeToLogFile("Error :" + ex.Message.ToString());
            }
            finally
            {
                objDB.Close();
            }
            return isSuccess;
        }

        private bool Execute(ref  DataSet returnDsValue,ref string returnScalarValue, string storedProcedureName, string parameters, ExecuteType executeType, ref string returnMessage)
        {
            returnDsValue = null;
            bool isSuccess = false;
            try
            {

                switch (executeType)
                {
                    case ExecuteType.NonQuery:
                        using (SqlCommand command = new SqlCommand(storedProcedureName, objDB))
                        {
                            command.CommandType = CommandType.Text;

                            returnScalarValue = (string)command.ExecuteScalar();
                            isSuccess = true;
                        }
                        break;
                    case ExecuteType.DataSet:               
                        SqlCommand storeProc = new SqlCommand();
                        storeProc.Connection = objDB;
                        storeProc.CommandType = CommandType.StoredProcedure;
                        storeProc.CommandText = storedProcedureName;
                        storeProc.Parameters.Add("@RoomID", SqlDbType.Int, 50).Value = parameters;
    
                        DataSet ds = new DataSet();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(storeProc);
                        dataAdapter.Fill(ds);


                        returnDsValue = ds;
                        isSuccess = true;
                        break;
                    case ExecuteType.Scalar:

                        break;

                    case ExecuteType.Reader:

                        break;

                    case ExecuteType.DataRow:


                        break;

                    case ExecuteType.DataTable:

                        break;


                }

            }

            catch (Exception exception)
            {

                returnMessage = exception.ToString();
                objLogFile.writeToLogFile("Error :" + exception.Message.ToString());
            }

            return isSuccess;
        }

        public void writeToFile(string ds)
        {
           
            DateTime now = DateTime.Now;
            string FileName = ConfigurationManager.AppSettings["JSON_FILE_FOR_SIGNAGE_DISPLAY"].ToString();
            string CurrentFileDirectory = ConfigurationManager.AppSettings["FOLDER_FOR_CLASS_VENUE_FILES"].ToString();
 
            if (!Directory.Exists(Path.GetDirectoryName(CurrentFileDirectory)))
            {
                Directory.CreateDirectory(CurrentFileDirectory);
            }

            using (StreamWriter sw = new StreamWriter(Path.Combine(CurrentFileDirectory, FileName), false, Encoding.UTF8))
            {
                sw.WriteLine(ds);
            }

        }
    }
    
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Xml.Linq;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using System.Data.SqlClient;

namespace ClassVenueInfo.Controllers
{
    public class DBGateway
    {
        LogCreation log = new LogCreation();
        public bool ConnectToDB(ref Database objDB, ref string returnMessage)
        {
            bool ret = false;
            try
            {
                objDB = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase();
                ret = true;
            }

            catch (Exception ex)
            {
                returnMessage = ex.Message.ToString();
                ret = false;
            }


            return ret;
        }

       public SqlConnection IsDBConnected()
        {
            //System.Configuration.ConfigurationManager.AppSettings["filepath"];
            string msSqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["msSqlConnection"].ToString();
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(msSqlConnection);
                objDB.Open();
                return objDB;
            }
            catch (Exception ex)
            {
                log.writeToLogFile(ex.Message);
                throw ex;
            }
        }



    }

}

using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Data.SqlClient;

namespace library1
{
    public class SQLHelper
    {
        public SqlConnection conCollection;
        public SqlCommand cmdCollection = new SqlCommand();
        public SqlDataAdapter adpCollection = new SqlDataAdapter();
        public SqlDataReader drdCollection;
        public SqlTransaction objTransaction;
        public SqlParameter spOutpuPrm = new SqlParameter("@nCount", SqlDbType.Int);
        public IFormatProvider objCulture = new System.Globalization.CultureInfo("en-GB", true);



        public SQLHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public void CreateConnection(string sDistrict)
        {



            string sConnStr = string.Empty;




            if (sDistrict == "Name")
            {
                sConnStr = "Sample";
            }
            else
            {
                sConnStr = "Connect";
            }



            conCollection = new SqlConnection(ConfigurationSettings.AppSettings[sConnStr]);
        }



        public Boolean SqlCommandExcuteNonQuery(ref string sError, string sQuery)
        {
            try
            {
                cmdCollection = new SqlCommand(sQuery, conCollection);
                cmdCollection.CommandType = CommandType.Text;
                cmdCollection.CommandTimeout = 10000;



                if (conCollection.State == ConnectionState.Closed)
                {
                    conCollection.Open();
                }



                cmdCollection.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sError = ex.Message.Replace("'", "").Replace("\r", "").Replace("\n", "");
                return false;
            }
            finally
            {
                conCollection.Close();
            }



            return true;
        }



        public Boolean SqlCommandExcuteReader(ref string sRowCount, ref string sError, string sQuery)
        {
            try
            {
                cmdCollection = new SqlCommand(sQuery, conCollection);
                cmdCollection.CommandType = CommandType.Text;
                cmdCollection.CommandTimeout = 10000;
                if (conCollection.State == ConnectionState.Closed)
                {
                    conCollection.Open();
                }
                drdCollection = cmdCollection.ExecuteReader();
                if (drdCollection.HasRows)
                {
                    drdCollection.Read();
                    sRowCount = drdCollection[0].ToString();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message.Replace("'", "").Replace("\r", "").Replace("\n", "");
                return false;
            }
            finally
            {
                conCollection.Close();
            }



            return true;
        }



        public Boolean SqlCommandExcuteReaderRights(ref string sRowCount, ref string sError, string sQuery)
        {
            try
            {
                cmdCollection = new SqlCommand(sQuery, conCollection);
                cmdCollection.CommandType = CommandType.Text;
                cmdCollection.CommandTimeout = 10000;



                if (conCollection.State == ConnectionState.Closed)
                {
                    conCollection.Open();
                }



                drdCollection = cmdCollection.ExecuteReader();



                if (drdCollection.HasRows)
                {
                    drdCollection.Read();
                    sRowCount = drdCollection[0].ToString();
                }
                else
                {
                    sRowCount = "0";
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message.Replace("'", "").Replace("\r", "").Replace("\n", "");
                return false;
            }
            finally
            {
                conCollection.Close();
            }



            return true;
        }



        public Boolean FillDataTableByQueryString(ref DataTable dtblCollection, ref string sError, string sQuery)
        {
            try
            {
                adpCollection = new SqlDataAdapter(sQuery, conCollection);
                adpCollection.SelectCommand.CommandType = CommandType.Text;
                adpCollection.SelectCommand.CommandTimeout = 10000;
                adpCollection.Fill(dtblCollection);



                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message.Replace("'", "").Replace("\r", "").Replace("\n", "");



                return false;
            }
        }



        public Boolean FillDataSetByQueryString(ref DataSet dstCollection, ref string sError, string sQuery, string sTableName)
        {
            try
            {
                adpCollection = new SqlDataAdapter(sQuery, conCollection);
                adpCollection.SelectCommand.CommandType = CommandType.Text;
                adpCollection.SelectCommand.CommandTimeout = 150000;
                adpCollection.Fill(dstCollection, sTableName);



                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message.Replace("'", "").Replace("\r", "").Replace("\n", "");



                return false;
            }
        }



        public Boolean GetNumberToWords(ref string sNumberToWords, ref string sError, string nNumber)
        {
            try
            {
                cmdCollection = new SqlCommand("NumbersToWords", conCollection);
                cmdCollection.CommandType = CommandType.StoredProcedure;
                cmdCollection.CommandTimeout = 10000;
                cmdCollection.Parameters.Add("@Number", SqlDbType.Decimal).Value = nNumber;



                if (conCollection.State == ConnectionState.Closed)
                {
                    conCollection.Open();
                }



                drdCollection = cmdCollection.ExecuteReader();



                if (drdCollection.HasRows)
                {
                    drdCollection.Read();
                    sNumberToWords = drdCollection[0].ToString();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message.Replace("'", "").Replace("\r", "").Replace("\n", "");
                return false;
            }
            finally
            {
                conCollection.Close();
            }



            return true;
        }



    }
}

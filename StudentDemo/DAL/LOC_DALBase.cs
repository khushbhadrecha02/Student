using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace StudentDemo.DAL
{
    public class LOC_DALBase
    {
        
        #region dbo.PR_Country_SelectAll
            public DataTable PR_Country_SelectAll(string conn)
            {
                try
                {
                    SqlDatabase db = new SqlDatabase(conn);
                    DbCommand dbCMD = db.GetStoredProcCommand("PR_Country_SelectAll");
                    //db.AddInParameter(dbCMD,"CountryName",SqlDbType.VarChar,countryname);
                    DataTable dt = new DataTable();
                    dt.Columns.Add();
                    using(IDataReader dr = db.ExecuteReader(dbCMD))
                    {
                        dt.Load(dr);
                    }
                    return dt;
                }
                catch(Exception ex)  
                {
                    return null;
                }
            }
        #endregion

        #region dbo.PR_State_SelectAll
        public DataTable PR_State_SelectAll(string conn)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_State_SelectAll");
                //db.AddInParameter(dbCMD,"CountryName",SqlDbType.VarChar,countryname);
                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region dbo.PR_City_SelectAll
        public DataTable PR_City_SelectAll(string conn)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_City_SelectAll");
                //db.AddInParameter(dbCMD,"CountryName",SqlDbType.VarChar,countryname);
                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_Country_DeleteByPK
        public void PR_Country_DeleteByPK(string conn,int CountryID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Country_DeleteByPK");
                db.AddInParameter(dbCMD,"CountryID",SqlDbType.Int,CountryID);
                db.ExecuteNonQuery(dbCMD);
                
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion

        #region PR_Country_SelectByPK
        public DataTable PR_Country_SelectByPK(string conn,int? CountryID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Country_SelectByPK");
                db.AddInParameter(dbCMD,"CountryID",SqlDbType.Int,CountryID);
                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_Country_Insert
        public void PR_Country_Insert(string conn,string CountryName,string CountryCode)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Country_Insert");
                db.AddInParameter(dbCMD, "CountryName", SqlDbType.VarChar, CountryName);
                db.AddInParameter(dbCMD, "CountryCode", SqlDbType.VarChar, CountryCode);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region PR_Country_UpdateByPK
        public void PR_Country_UpdateByPK(string conn, int CountryID,string CountryName,string CountryCode)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Country_UpdateByPK");
                db.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                db.AddInParameter(dbCMD, "CountryName", SqlDbType.VarChar, CountryName);
                db.AddInParameter(dbCMD, "CountryCode", SqlDbType.VarChar, CountryCode);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region PR_State_DeleteByPK
        public void PR_State_DeleteByPK(string conn, int StateID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_State_DeleteByPK");
                db.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region dbo.PR_Country_SelectByComboBox
        public DataTable PR_Country_SelectByComboBox(string conn)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Country_SelectByComboBox");

                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_State_Insert
        public void PR_State_Insert(string conn,int CountryID, string StateName, string StateCode)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_State_Insert");
                db.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                db.AddInParameter(dbCMD, "StateName", SqlDbType.VarChar, StateName);
                db.AddInParameter(dbCMD, "StateCode", SqlDbType.VarChar, StateCode);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region PR_State_UpdateByPK
        public void PR_State_UpdateByPK(string conn,int StateID, int CountryID, string StateName, string StateCode)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_State_UpdateByPK");
                db.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);
                db.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                db.AddInParameter(dbCMD, "StateName", SqlDbType.VarChar, StateName);
                db.AddInParameter(dbCMD, "StateCode", SqlDbType.VarChar, StateCode);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region PR_State_SelectByPK
        public DataTable PR_State_SelectByPK(string conn, int? StateID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_State_SelectByPK");
                db.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);
                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_City_DeleteByPK
        public void PR_City_DeleteByPK(string conn, int CityID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_City_DeleteByPK");
                db.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region dbo.PR_State_SelectByComboBox
        public DataTable PR_State_SelectByComboBox(string conn,int CountryID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_State_SelectByComboBox");
                db.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);


                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_City_SelectByPK
        public DataTable PR_City_SelectByPK(string conn, int? CityID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_City_SelectByPK");
                db.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);
                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_City_UpdateByPK
        public void PR_City_UpdateByPK(string conn,int CityID, int StateID, int CountryID, string CityName, string CityCode)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_City_UpdateByPK");
                db.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);
                db.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                db.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);
                db.AddInParameter(dbCMD, "CityName", SqlDbType.VarChar, CityName);
                db.AddInParameter(dbCMD, "CityCode", SqlDbType.VarChar, CityCode);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region PR_City_Insert
        public void PR_City_Insert(string conn, int CountryID,int StateID, string CityName, string CityCode)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_City_Insert");
                db.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                db.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);
                
                db.AddInParameter(dbCMD, "CityName", SqlDbType.VarChar, CityName);
                db.AddInParameter(dbCMD, "CityCode", SqlDbType.VarChar, CityCode);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region dbo.PR_Country_SelectByPage
        public DataTable PR_Country_SelectByPage(string conn, string? CountryName,string? CountryCode)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Country_SelectByPage");
                db.AddInParameter(dbCMD, "CountryName", SqlDbType.VarChar, CountryName);
                db.AddInParameter(dbCMD, "CountryCode", SqlDbType.VarChar, CountryCode);


                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_Country_SelectByPage
        public DataTable PR_State_SelectByPage(string conn,int? CountryID, string? StateName, string? StateCode)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_State_SelectByPage");
                db.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                db.AddInParameter(dbCMD, "StateName", SqlDbType.VarChar, StateName);
                db.AddInParameter(dbCMD, "StateCode", SqlDbType.VarChar, StateCode);


                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region dbo.PR_City_SelectByPage
        public DataTable PR_City_SelectByPage(string conn, int? CountryID,int? StateID, string? CityName, string? CityCode)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_City_SelectByPage");
                db.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                db.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);
                db.AddInParameter(dbCMD, "CityName", SqlDbType.VarChar, CityName);
                db.AddInParameter(dbCMD, "CityCode", SqlDbType.VarChar, CityCode);


                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region PR_State_SelectByCountryID
        public DataTable PR_State_SelectByCountryID(string conn, int? CountryID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_State_SelectByCountryID");
                db.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region PR_City_SelectByCountryID
        public DataTable PR_City_SelectByCountryID(string conn, int? CountryID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_City_SelectByCountryID");
                db.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region PR_City_SelectByStateID
        public DataTable PR_City_SelectByStateID(string conn, int? StateID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_City_SelectByStateID");
                db.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);
                DataTable dt = new DataTable();
                dt.Columns.Add();
                using (IDataReader dr = db.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion



    }
}

using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace StudentDemo.DAL
{
    public class MST_DALBase
    {
        #region dbo.PR_Branch_SelectAll
        public DataTable PR_Branch_SelectAll(string conn)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Branch_SelectAll");
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

        #region PR_Branch_SelectByPK
        public DataTable PR_Branch_SelectByPK(string conn, int? BranchID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Branch_SelectByPK");
                db.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, BranchID);
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

        #region PR_Branch_DeleteByPK
        public void PR_Branch_DeleteByPK(string conn, int BranchID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Branch_DeleteByPK");
                db.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, BranchID);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region PR_Branch_Insert
        public void PR_Branch_Insert(string conn, string BranchName, string BranchCode)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Branch_Insert");
                db.AddInParameter(dbCMD, "BranchName", SqlDbType.VarChar, BranchName);
                db.AddInParameter(dbCMD, "BranchCode", SqlDbType.VarChar, BranchCode);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region PR_Branch_UpdateByPK
        public void PR_Country_UpdateByPK(string conn, int BranchID, string BranchName, string BranchCode)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Branch_UpdateByPK");
                db.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, BranchID);
                db.AddInParameter(dbCMD, "BranchName", SqlDbType.VarChar, BranchName);
                db.AddInParameter(dbCMD, "BranchCode", SqlDbType.VarChar, BranchCode);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region dbo.PR_Student_SelectAll
        public DataTable PR_Student_SelectAll(string conn)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Student_SelectAll");
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

        #region dbo.PR_City_SelectByComboBox
        public DataTable PR_City_SelectByComboBox(string conn)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_City_SelectByComboBox");

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

        #region dbo.PR_Branch_SelectByComboBox
        public DataTable PR_Branch_SelectByComboBox(string conn)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Branch_SelectByComboBox");

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

        #region PR_Student_DeleteByPK
        public void PR_Student_DeleteByPK(string conn, int StudentID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Student_DeleteByPK");
                db.AddInParameter(dbCMD, "StudentID", SqlDbType.Int, StudentID);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region PR_Branch_SelectByPK
        public DataTable PR_Student_SelectByPK(string conn, int? StudentID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Student_SelectByPK");
                db.AddInParameter(dbCMD, "StudentID", SqlDbType.Int, StudentID);
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

        #region PR_Student_Insert
        public void PR_Student_Insert(string conn,string StudentName,int BranchID,int CityID,string MobileNoStudent,string MobileNoFather,string Address,string Email,string Gender,string ISActive,int Age,DateTime BirthDate,string PhotoPath,string Password)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Student_Insert");
                db.AddInParameter(dbCMD, "StudentName", SqlDbType.VarChar, StudentName);
                db.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, BranchID);
                db.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);
                db.AddInParameter(dbCMD, "Age", SqlDbType.Int, Age);
                db.AddInParameter(dbCMD, "MobileNoStudent", SqlDbType.VarChar, MobileNoStudent);
                db.AddInParameter(dbCMD, "MobileNoFather", SqlDbType.VarChar, MobileNoFather);
                db.AddInParameter(dbCMD, "Address", SqlDbType.VarChar, Address);
                db.AddInParameter(dbCMD, "Email", SqlDbType.VarChar, Email);
                db.AddInParameter(dbCMD, "Gender", SqlDbType.VarChar, Gender);
                db.AddInParameter(dbCMD, "ISActive", SqlDbType.VarChar, ISActive);
                db.AddInParameter(dbCMD, "BirthDate", SqlDbType.DateTime, BirthDate);
                db.AddInParameter(dbCMD, "PhotoPath", SqlDbType.VarChar, PhotoPath);
                db.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region PR_Student_UpdateBYPK
        public void PR_Student_UpdateByPK(string conn, int StudentID, string StudentName, int BranchID, int CityID, string MobileNoStudent, string MobileNoFather, string Address, string Email, string Gender, string ISActive, int Age, DateTime BirthDate, string PhotoPath, string Password)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conn);
                DbCommand dbCMD = db.GetStoredProcCommand("PR_Student_UpdateByPK");
                db.AddInParameter(dbCMD, "StudentName", SqlDbType.VarChar, StudentName);
                db.AddInParameter(dbCMD, "StudentID", SqlDbType.Int, StudentID);
                db.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, BranchID);
                db.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);
                db.AddInParameter(dbCMD, "Age", SqlDbType.Int, Age);
                db.AddInParameter(dbCMD, "MobileNoStudent", SqlDbType.VarChar, MobileNoStudent);
                db.AddInParameter(dbCMD, "MobileNoFather", SqlDbType.VarChar, MobileNoFather);
                db.AddInParameter(dbCMD, "Address", SqlDbType.VarChar, Address);
                db.AddInParameter(dbCMD, "Email", SqlDbType.VarChar, Email);
                db.AddInParameter(dbCMD, "Gender", SqlDbType.VarChar, Gender);
                db.AddInParameter(dbCMD, "ISActive", SqlDbType.VarChar, ISActive);
                db.AddInParameter(dbCMD, "BirthDate", SqlDbType.DateTime, BirthDate);
                db.AddInParameter(dbCMD, "PhotoPath", SqlDbType.VarChar, PhotoPath);
                db.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);
                db.ExecuteNonQuery(dbCMD);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}

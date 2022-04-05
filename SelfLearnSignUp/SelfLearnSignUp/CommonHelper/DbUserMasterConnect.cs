using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using SelfLearnSignUp.Models;
using System.Data;

namespace SelfLearnSignUp.CommonHelper
{
    public class DbUserMasterConnect
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public DbUserMasterConnect()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            con.Open();
        }

        public int InsertUserData(UserAccount U)
        {
            if (U.Id == 0)//insert
            {
                using (con)
                {
                    cmd = new SqlCommand("CreateNewAccount1_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = U.Id;
                    cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = U.FirstName;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = U.LastName;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = U.ContactNo;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = U.EmailId;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = U.Password;
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.Char).Value = U.Gender;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = U.Status;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                using (con)//update
                {
                    cmd = new SqlCommand("CreateNewAccount1_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = U.Id;
                    cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = U.FirstName;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = U.LastName;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = U.ContactNo;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = U.EmailId;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.Char).Value = U.Gender;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = 'X';
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;
        }

        public List<UserAccount> GetUserData(string orderby, string whereclause)
        {
            List<UserAccount> UList = new List<UserAccount>();
            using (con)
            {
                cmd = new SqlCommand("GetUserRecords1", con);
                cmd.Parameters.AddWithValue("orderby", SqlDbType.VarChar).Value = orderby;
                cmd.Parameters.AddWithValue("whereclause", SqlDbType.VarChar).Value = whereclause;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserAccount U = new UserAccount();
                    U.SetId(Convert.ToInt32(rdr["Id"]));
                    U.SetFirstName(Convert.ToString(rdr["FirstName"]));
                    U.SetLastName(Convert.ToString(rdr["LastNAME"]));
                    U.SetEmailId(Convert.ToString(rdr["EmailId"]));
                    U.SetContactNo(Convert.ToString(rdr["ContactNo"]));
                    U.SetGender(Convert.ToChar(rdr["Gender"]));
                    U.SetStatus(Convert.ToChar(rdr["Status"]));
                    U.SetCreatedAt(Convert.ToString(rdr["CreatedAt"]));
                    U.SetEditedAt(Convert.ToString(rdr["EditedAt"]));
                    U.SetDeletedAt(Convert.ToString(rdr["DeletedAt"]));
                    UList.Add(U);
                }

            }

            return UList;
        }

        public List<UserChartResponseModel> GetUserChartData(string SelectAsLabel, string GroupBy)
        {
            List<UserChartResponseModel> ULst = new List<UserChartResponseModel>();
            using (con)
            {
                cmd = new SqlCommand("GetUserRecordsChart", con);
                cmd.Parameters.AddWithValue("@SelectAsLabel", SqlDbType.VarChar).Value = SelectAsLabel;
                cmd.Parameters.AddWithValue("@GroupBy", SqlDbType.VarChar).Value = GroupBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserChartResponseModel U = new UserChartResponseModel();
                    U.setLabel(Convert.ToString(rdr["label"]));
                    U.setValue(Convert.ToInt32(rdr["value"]));
                    ULst.Add(U);
                }
            }
            return ULst;
        }
        public int UpdateUserStatus(UserAccount U)
        {
            if (U.Id != 0)
            {
                using (con)
                {
                    cmd = new SqlCommand("UpdateUserStatus1_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = U.Id;
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MMM/YYYY | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = U.Status;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;
        }
    }

   
}
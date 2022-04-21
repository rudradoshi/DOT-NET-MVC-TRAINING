using MVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC.CommonHelper
{
    public class DbUserConnectMaster

    {
      
         IConfiguration _configuration;

        public DbUserConnectMaster()
        {
            
        }
        SqlConnection con = null;
        SqlCommand cmd = null;
        public DbUserConnectMaster(IConfiguration configuration)
        {
            _configuration = configuration;
            con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
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

            return 1;
        }

    }
}
    


using System.Data;
using System.Data.SqlClient;

namespace DOTNETCoreMVC_ADODOTNET.Models
{
    public class StudentDataAccessLayer
    {
        string connectionString = "Server=192.168.1.250\\SQL2019INT;Database=Rudra_Doshi;User id = rudra; password=rudra;Trusted_Connection=false;MultipleActiveResultSets=true";
        public IEnumerable< Student> GetAllCustomers()
        {
            List<Student> lstStudent = new List<Student>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Student Student = new Student();

                    Student.Id = Convert.ToInt32(sdr["Id"]);
                    Student.Name = sdr["Name"].ToString();
                    Student.Address = sdr["Address"].ToString();
                    Student.Gender = sdr["Gender"].ToString();
                    Student.Country = sdr["Country"].ToString();
                    Student.City = sdr["City"].ToString();
                    Student.Mobile = sdr["MobileNo"].ToString();
                    Student.Email = sdr["MailId"].ToString();

                    lstStudent.Add(Student);
                }
                con.Close();
            }
            return lstStudent;
        }

        //To Add new Student record      
        public void AddCustomer(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Country", student.Country);
                cmd.Parameters.AddWithValue("@City", student.City);
                cmd.Parameters.AddWithValue("@MobileNo", student.Mobile);
                cmd.Parameters.AddWithValue("@MailId", student.Email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar Customer    
        public void UpdateCustomer(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Country", student.Country);
                cmd.Parameters.AddWithValue("@City", student.City);
                cmd.Parameters.AddWithValue("@MobileNo", student.Mobile);
                cmd.Parameters.AddWithValue("@MailId", student.Email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular Customer    
        public Student GetCustomerData(int? Id)
        {
            Student student = new Student();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("sp_GetStudentById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    student.Id = Convert.ToInt32(sdr["Id"]);
                    student.Name = sdr["Name"].ToString();
                    student.Address = sdr["Address"].ToString();
                    student.Gender = sdr["Gender"].ToString();
                    student.Country = sdr["Country"].ToString();
                    student.City = sdr["City"].ToString();
                    student.Mobile = sdr["MobileNo"].ToString();
                    student.Email = sdr["MailId"].ToString();
                }
            }
            return student;
        }

        //To Delete the record on a particular Customer    
        public void DeleteCustomer(int? Id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}


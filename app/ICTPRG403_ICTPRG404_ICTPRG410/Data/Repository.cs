using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ICTPRG403_ICTPRG404_ICTPRG410.Data
{
    /// <summary>
    /// Repository class is responsible for connecting to the database and implementing changes to the database
    /// </summary>
    public class Repository
    {
        readonly private string  _connectionString;

        /// <summary>
        /// I have initialised and assigned the correct value for the _connectionString field here using ConfigurationManager. 
        /// Connects to the SQL Database.
        /// </summary>
        public Repository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ICTPRG403_ICTPRG404_ICTPRG410"].ConnectionString;
        }

        /// <summary>
        /// Reads the database, gets the information regarding every person in the database and puts it into IEnumerable Person
        /// Afterwards disposes of the SqlConnection and SqlCommand to save resources
        /// </summary>
        /// <returns>Information regarding every person inside the database.</returns>
        public IEnumerable<Person> GetPeople()
        {
            var people = new List<Person>();
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("select * from dbo.People", conn);
            conn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Person output = new Person
                    {
                        Id = dataReader.GetInt32(0),
                        FirstName = dataReader.GetString(1),
                        LastName = dataReader.GetString(2),
                        Height = dataReader.GetDouble(3),
                        Weight = dataReader.GetDouble(4)
                    };
                    people.Add(output);
                }
            }
            conn.Dispose();
            cmd.Dispose();
            return people;
        }

        /// <summary>
        /// InsertPerson() method adds a Person (object) to the SQL database.
        /// Additionally, it records how many lines have been affected.
        /// Afterwards disposes of the SqlConnection and SqlCommand to save resources.
        /// </summary>
        /// <param name="p">The person that is to be added to the database</param>
        /// <returns>The number of rows affected by InsertPerson()</returns>

        public int InsertPerson(Person p)
        {
            int result;
            SqlConnection conn = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand
                ("Insert into dbo.People values(@First,@Last,@Height,@Weight)", conn);
            cmd.Parameters.AddWithValue("@First", p.FirstName);
            cmd.Parameters.AddWithValue("@Last", p.LastName);
            cmd.Parameters.AddWithValue("@Height", p.Height);
            cmd.Parameters.AddWithValue("@Weight", p.Weight);

            //Execute query
            conn.Open();
            result = cmd.ExecuteNonQuery();

            conn.Dispose();
            cmd.Dispose();
            return result;
        }


        /// <summary>
        /// UpdatePerson() method updates the Person's information inside the database.
        /// Essentially, it retrieves the ID from Person object and then replaces a(another) person in the database with the same ID.
        /// Additionally, it records how many lines have been affected by it.
        /// Afterwards disposes of the SqlConnection and SqlCommand to save resources
        /// </summary>
        /// <param name="p">The person whose information is to be updated in the database</param>
        /// <returns>The number of rows affected by UpdatePerson()</returns>

        public int UpdatePerson(Person p)
        {
            int result;
            SqlConnection conn = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand
                ("Update dbo.People SET " +
 "					FirstName=@First," +
 "					LastName=@Last," +
     "				Height=@Height," +
    "               Weight=@Weight" +
 "					Where ID=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", p.Id);
            cmd.Parameters.AddWithValue("@First", p.FirstName);
            cmd.Parameters.AddWithValue("@Last", p.LastName);
            cmd.Parameters.AddWithValue("@Height", p.Height);
            cmd.Parameters.AddWithValue("@Weight", p.Weight);

            //Execute query
            conn.Open();
            result = cmd.ExecuteNonQuery();

            conn.Dispose();
            cmd.Dispose();

            return result;
        }



        /// <summary>
        /// DeletePerson() method removes the Person's information inside the database.
        /// Essentially, it retrieves the ID from Person object and then deletes a database record with the same ID.
        /// Additionally, it records how many lines have been affected by it.
        /// Afterwards disposes of the SqlConnection and SqlCommand to save resources
        /// </summary>
        /// <param name="p">The person whose information is to be deleted in the database</param>
        /// <returns>The number of rows affected by DeletePerson()</returns>
        public int DeletePerson(Person p)
        {
            int result;

            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("Delete from dbo.People where ID=" + p.Id, conn);
            //Execute query
            conn.Open();
            result = cmd.ExecuteNonQuery();

            conn.Dispose();
            cmd.Dispose();

            return result;
        }
    }
}

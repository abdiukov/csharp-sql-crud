using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTPRG403_ICTPRG404_ICTPRG410.Data
{
    /// <summary>
    /// Person class is used to create Person objects.
    /// These objects will then get transferred into a database.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The database unique identifier (ID) of the Person.
        /// </summary>
        public int Id { get; set; }
        
        
        /// <summary>
        /// The First Name of the Person.
        /// </summary>
        public string FirstName { get; set; }


        /// <summary>
        /// The Last Name of the Person.
        /// </summary>
        public string LastName { get; set; }


        /// <summary>
        /// The Weight of the Person.
        /// </summary>
        public double Weight { get; set; }


        /// <summary>
        /// The Height of the Person.
        /// </summary>
        public double Height { get; set; }
    }
}

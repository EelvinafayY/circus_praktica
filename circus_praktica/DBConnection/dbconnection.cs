using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circus_praktica.DBConnection
{
    class dbconnection
    {
        public static Circus_FayzullinaEntities Circus = new Circus_FayzullinaEntities();
        public static Admins loginedAdmin;
        public static Artist loginedArtist;
        public static Staff loginedStaff;
        public static Animal_trainer loginedAnimal_trainer;
    }
}

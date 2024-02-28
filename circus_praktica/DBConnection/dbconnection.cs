using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circus_praktica.DBConnection
{
    class dbconnection
    {
        public static Circus_FayEntities Circus = new Circus_FayEntities();
        public static Admin loginedAdmin;
        public static Artist loginedArtist;
        public static Worker loginedStaff;
        public static AnimalTrainer loginedAnimal_trainer;
    }
}

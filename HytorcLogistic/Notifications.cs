using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HytorcLogistic
{
    class Notifications
    {
        private static Notifications instance = null;

        private Notifications() { }

        public static Notifications GetInstance()
        {
            if (instance == null)
                instance = new Notifications();

            return instance;
        }
    }
}

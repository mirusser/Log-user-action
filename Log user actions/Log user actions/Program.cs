using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_user_actions
{
    interface ILogger
    {
        void Log(object whatToLog);
    }

    class dbLogger : ILogger
    {
        public void Log(object whatToLog)
        {
            /* Log into database */
        }
    }
    class FileLogger : ILogger
    {
        public void Log(object whatToLog)
        {
            /* log into file */
        }
    }
    abstract class CompositeLogger : ILogger
    {
        #region Types of log
        dbLogger dblogger;
        FileLogger filelogger;
        //declare other Logs here
        #endregion
        public CompositeLogger()
        {
            dblogger = new dbLogger();
            filelogger = new FileLogger();
            //define other Logs here
        }
        public virtual void Log(object whatToLog)
        {
            dblogger.Log(whatToLog);
            filelogger.Log(whatToLog);
            //claim other Log methods here
        }
    }

    class User : CompositeLogger
    {
        public override void Log(object whatToLog)
        {
            base.Log(whatToLog);
        }

        /*here goes other stuff that user can do*/
    }

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Log("An action");
            //A parameter in  fuction "Log()" can be different, this is only an example.
        }
    }
}

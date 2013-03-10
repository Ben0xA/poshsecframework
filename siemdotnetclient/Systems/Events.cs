using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace siemdotnetclient.Systems
{
    class Events
    {
        #region Private Variables
        EventLog evt = new EventLog();
        #endregion

        #region Initialize
        public void Event()
        { 
            //New Event Class
        }
        #endregion

        #region Private Events

        #region Application Log
        private EventLogEntryCollection getApplication()
        {
            EventLogEntryCollection rtn = null;
            evt.Log = "Application";
            rtn = evt.Entries;
            return rtn;
        }
        #endregion

        #endregion

        #region Public Events
        public List<EventLogEntry> ApplicationLogs()
        {
            EventLogEntryCollection events = getApplication();
            List<EventLogEntry> rtn = new List<EventLogEntry>();
            foreach(EventLogEntry evnt in events)
            {
                if (evnt.EntryType ==  EventLogEntryType.Warning || evnt.EntryType == EventLogEntryType.Error)
                {
                    rtn.Add(evnt);
                }                
            }
            return rtn;
        }
        #endregion
    }
}

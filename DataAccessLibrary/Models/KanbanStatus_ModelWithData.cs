using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class KanbanStatus_ModelWithData
    {
        public int StatusID { get; set; }
        public string StatusDescription { get; set; }
    }

    public class KanbanStatusData
    {
        public List<KanbanStatus_ModelWithData> StatusData
        {
            get { return statusData; }
            set { statusData = value; }
        }

        private List<KanbanStatus_ModelWithData> statusData = new List<KanbanStatus_ModelWithData> {
            new KanbanStatus_ModelWithData() { StatusID = 1, StatusDescription = "WAITING"},
            new KanbanStatus_ModelWithData() { StatusID = 2, StatusDescription = "TRANSPORTATION" },
            new KanbanStatus_ModelWithData() { StatusID = 3, StatusDescription = "DELIVERED" },
            new KanbanStatus_ModelWithData() { StatusID = 4, StatusDescription = "CONFIRMED" },
        };
    }


}

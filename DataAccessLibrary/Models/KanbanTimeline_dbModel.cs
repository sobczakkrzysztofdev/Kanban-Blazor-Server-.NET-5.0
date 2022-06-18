using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class KanbanTimeline_dbModel
    {
        public int KANBAN_TL_ID { get; set; }
        public int KANBAN_ID { get; set; }
        public int KANBAN_TL_STATUS { get; set; }
        public string KANBAN_TL_COMMENT { get; set; }
        public string KANBAN_TL_USER_NAME { get; set; }
        public DateTime KANBAN_TL_DATETIME { get; set; }
    }
}

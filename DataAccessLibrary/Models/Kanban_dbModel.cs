using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class Kanban_dbModel
    {
        public int KANBAN_ID { get; set; }
        public int KANBAN_STATUS { get; set; }
        public int KANBAN_DESTINATION { get; set; }
        public int KANBAN_PACKAGING_ID { get; set; }
        public int KANBAN_PRODUCT_ID { get; set; }
        public string KANBAN_COMMENT { get; set; }
        public string KANBAN_USER_NAME { get; set; }
        public DateTime KANBAN_DATETIME { get; set; }
        public DateTime KANBAN_START_DATETIME { get; set; }


        //ADDITIONAL
        //public string AREA_NAME { get; set; }
        //public string PRODUCT_TYPE { get; set; }
        //public string PRODUCT_NAME { get; set; }
        //public string PRODUCT_NUMBER { get; set; }

        //public string PROD_CELL_NAME { get; set; }
        //public int KANBAN_PACKAGING_ID { get; set; }
    }
}

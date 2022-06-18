using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class Area_ModelWithData
    {
        public int AREA_ID { get; set; }
        public int AREA_PLANT_ID { get; set; }
        public string AREA_NAME { get; set; }
        public DateTime AREA_DATETIME { get; set; }
        public string AREA_USER_ID { get; set; }
        public int AREA_ACTIVATED { get; set; }


        //added
        public string AREA_USER_NAME { get; set; }
    }

    public class AreaData
    {
        public List<Area_ModelWithData> Data
        {
            get { return data; }
            set { data = value; }
        }

        private List<Area_ModelWithData> data = new List<Area_ModelWithData> {
            new Area_ModelWithData() { AREA_ID = 1, AREA_NAME = "Hartownia"},
            new Area_ModelWithData() { AREA_ID = 2, AREA_NAME = "Malarnia" },
            new Area_ModelWithData() { AREA_ID = 3, AREA_NAME = "Montaż Mercedes" },
            new Area_ModelWithData() { AREA_ID = 4, AREA_NAME = "Montaż Volvo" },
            new Area_ModelWithData() { AREA_ID = 5, AREA_NAME = "Montaż VW" },
        };
    }
}

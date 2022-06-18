using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLibrary.Models;
using System.Threading.Tasks;
using System.Linq;


namespace DataAccessLibrary.Other
{
    public class DataAccess : IDataAccess
    {
        private readonly ISqlDataAccess _db;

        public DataAccess(ISqlDataAccess db)
        {
            _db = db;
        }
        



        //----------------------------------------------------------------------------------------------------------------------------
        //      AREA
        //----------------------------------------------------------------------------------------------------------------------------
        public Task<List<Area_ModelWithData>> Get_Areas()
        {
            string sql = @"select area.AREA_ID, area.AREA_NAME, area.AREA_DATETIME, area.AREA_USER_ID, area.AREA_ACTIVATED, area.AREA_PLANT_ID 
                            from dbo.table_AREA area";
            return _db.LoadData<Area_ModelWithData, dynamic>(sql, new { });
        }

        public Task Insert_Area(Area_ModelWithData model)
        {
            string sql = @"insert into dbo.table_AREA (AREA_NAME, AREA_DATETIME, AREA_USER_ID, AREA_ACTIVATED, AREA_PLANT_ID)
                                           values (@AREA_NAME, @AREA_DATETIME, @AREA_USER_ID, @AREA_ACTIVATED, @AREA_PLANT_ID);";
            return _db.SaveData(sql, model);
        }

        public Task Update_Area(Area_ModelWithData model)
        {
            string sql = @"update dbo.table_AREA
                        SET AREA_NAME=@AREA_NAME, AREA_DATETIME=@AREA_DATETIME, AREA_USER_ID=@AREA_USER_ID, AREA_ACTIVATED=@AREA_ACTIVATED, AREA_PLANT_ID=@AREA_PLANT_ID 
                        WHERE AREA_ID=@AREA_ID;";
            return _db.SaveData(sql, model);
        }

        public Task Update_Activation_Area(Area_ModelWithData model)
        {
            string sql = @"update dbo.table_AREA
                        SET AREA_ACTIVATED=@AREA_ACTIVATED, AREA_USER_ID=@AREA_USER_ID 
                        WHERE AREA_ID=@AREA_ID;";
            return _db.SaveData(sql, model);
        }





        //----------------------------------------------------------------------------------------------------------------------------
        //      KANBAN
        //----------------------------------------------------------------------------------------------------------------------------
        public Task<List<Kanban_dbModel>> Get_Kanban()
        {
            string sql = "select k.KANBAN_ID, k.KANBAN_STATUS, k.KANBAN_DESTINATION, k.KANBAN_PACKAGING_ID, k.KANBAN_PRODUCT_ID, k.KANBAN_COMMENT, k.KANBAN_USER_NAME, k.KANBAN_DATETIME, k.KANBAN_START_DATETIME " +
                            "from dbo.table_KANBAN k " +
                            "WHERE k.KANBAN_STATUS < 4";
            return _db.LoadData<Kanban_dbModel, dynamic>(sql, new { });
        }

        public int Insert_Kanban(Kanban_dbModel model)
        {
            //ISSUE
            //https://stackoverflow.com/questions/13198476/cannot-use-update-with-output-clause-when-a-trigger-is-on-the-table
            //ISSUE RESOLVED
            string sql = @"DECLARE @insertedID TABLE (KANBAN_ID INT) 
                            INSERT into dbo.table_KANBAN (KANBAN_STATUS, KANBAN_DESTINATION, KANBAN_PACKAGING_ID, KANBAN_PRODUCT_ID, KANBAN_COMMENT, KANBAN_USER_NAME, KANBAN_DATETIME, KANBAN_START_DATETIME) 
                                                        OUTPUT INSERTED.KANBAN_ID INTO @insertedID(KANBAN_ID) 
                                                        VALUES (@KANBAN_STATUS, @KANBAN_DESTINATION, @KANBAN_PACKAGING_ID, @KANBAN_PRODUCT_ID, @KANBAN_COMMENT, @KANBAN_USER_NAME, @KANBAN_DATETIME, @KANBAN_START_DATETIME) 
                                                        SELECT KANBAN_ID FROM @insertedID;";
            return _db.SaveDataAndReturnIdentity(sql, model);

        }

        public Task Insert_KanbanTimeline(KanbanTimeline_dbModel model)
        {
            string sql = @"insert into dbo.table_KANBAN_TIMELINE (KANBAN_ID, KANBAN_TL_STATUS, KANBAN_TL_COMMENT, KANBAN_TL_USER_NAME, KANBAN_TL_DATETIME)
                                                        values (@KANBAN_ID, @KANBAN_TL_STATUS, @KANBAN_TL_COMMENT, @KANBAN_TL_USER_NAME, @KANBAN_TL_DATETIME);";
            return _db.SaveData(sql, model);
        }

        public Task Update_Kanban(Kanban_dbModel model)
        {
            string sql = @"update dbo.table_KANBAN 
                        SET KANBAN_STATUS=@KANBAN_STATUS, KANBAN_COMMENT=@KANBAN_COMMENT, KANBAN_USER_NAME=@KANBAN_USER_NAME, KANBAN_DATETIME=@KANBAN_DATETIME 
                        WHERE KANBAN_ID=@KANBAN_ID;";
            return _db.SaveData(sql, model);
        }




    }
}

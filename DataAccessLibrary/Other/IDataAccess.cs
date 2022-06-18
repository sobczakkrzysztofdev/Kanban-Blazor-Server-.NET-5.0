using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Other
{
    public interface IDataAccess
    {
        //----------------------------------------------------------------------------------------------------------------------------
        //      AREA
        //----------------------------------------------------------------------------------------------------------------------------
        Task<List<Area_ModelWithData>> Get_Areas();
        Task Insert_Area(Area_ModelWithData model);
        Task Update_Area(Area_ModelWithData model);
        Task Update_Activation_Area(Area_ModelWithData model);



        //----------------------------------------------------------------------------------------------------------------------------
        //      KANBAN
        //----------------------------------------------------------------------------------------------------------------------------
        Task<List<Kanban_dbModel>> Get_Kanban();
        int Insert_Kanban(Kanban_dbModel model);
        Task Insert_KanbanTimeline(KanbanTimeline_dbModel model);
        Task Update_Kanban(Kanban_dbModel model);

    }
}

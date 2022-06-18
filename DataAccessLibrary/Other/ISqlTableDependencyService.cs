using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLibrary.Models;


namespace DataAccessLibrary.Other
{
    public interface ISqlTableDependencyService : IDisposable
    {
        event KanbanChangeDelegate OnKanbanChanged;

        void Dispose();
    }


    public delegate void KanbanChangeDelegate(object sender, KanbanChangeEventArgs args);


    public class KanbanChangeEventArgs : EventArgs
    {
        public Kanban_dbModel KanbanNewValue { get; }
        public Kanban_dbModel KanbanOldValue { get; }

        public KanbanChangeEventArgs(Kanban_dbModel kanbanNewValue, Kanban_dbModel kanbanOldValue)
        {
            this.KanbanNewValue = kanbanNewValue;
            this.KanbanOldValue = kanbanOldValue;
        }
    }
}

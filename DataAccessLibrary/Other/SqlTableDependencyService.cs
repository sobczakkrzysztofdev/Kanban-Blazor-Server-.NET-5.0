using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
using DataAccessLibrary.Models;
using DataAccessLibrary.Other;

namespace DataAccessLibrary.Other
{
    public class SqlTableDependencyService : ISqlTableDependencyService
    {
        //FIRST ATTEMPT
        public string ConnectionStringName { get; set; } = "DefaultConnection";


        //KANBAN
        private const string tableKanban = "table_KANBAN";
        private SqlTableDependency<Kanban_dbModel> _kanban_notifier;
        public event KanbanChangeDelegate OnKanbanChanged;

        //private IDataAccess _db;
        private IConfiguration _configuration;

        public SqlTableDependencyService(IConfiguration configuration)
        {
            _configuration = configuration;

            // SqlTableDependency will trigger an event 
            // for any record change on monitored table  

            //KANBAN TABLE
            _kanban_notifier = new SqlTableDependency<Kanban_dbModel>(
                _configuration.GetConnectionString(ConnectionStringName),
                tableKanban);
            _kanban_notifier.OnChanged += this.TableKanbanDependency_Changed;
            _kanban_notifier.Start();

        }

        public void Dispose()
        {
            _kanban_notifier.Stop();
            _kanban_notifier.Dispose();
        }


        // This method will notify the Blazor component about the change
        private void TableKanbanDependency_Changed(object sender, RecordChangedEventArgs<Kanban_dbModel> k)
        {
            OnKanbanChanged(this, new KanbanChangeEventArgs(k.Entity, k.EntityOldValues));
        }

    }
}

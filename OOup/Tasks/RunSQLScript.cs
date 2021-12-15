using OOup.DataObjects;

namespace OOup.Tasks
{
    public class RunSQLScript : RunSQL
    {
        public RunSQLScript(string fileName, string databaseConnection) : base(databaseConnection)
        {
            Script = fileName;
        }
        public RunSQLScript(string fileName, DatabaseConnection databaseConnection) : base(databaseConnection)
        {
            Script = fileName;
        }

        public string Script { get; }

        public override void SetSQL()
        {
            SQL = Script;
        }
    }
}

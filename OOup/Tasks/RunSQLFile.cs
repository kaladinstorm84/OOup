using OOup.DataObjects;

namespace OOup.Tasks
{
    public class RunSQLFile : RunSQL
    {
        string FileName { get; set; }
        public RunSQLFile(string fileName, string databaseConnection) : base(databaseConnection)
        {
            FileName = fileName;
        }
        public RunSQLFile(string fileName,DatabaseConnection databaseConnection) : base(databaseConnection)
        {
            FileName = fileName;
        }
        public override void SetSQL()
        {
            SQL = File.ReadAllText(FileName);
        }
    }
}

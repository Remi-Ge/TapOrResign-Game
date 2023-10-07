using System.IO;

namespace Code.SavesData
{
    public static class SaveLoadData
    {
        public static void CreateEmptySqliteFile(string sqliteFilePath)
        {
            File.WriteAllText(sqliteFilePath, "");
        }
    }
}
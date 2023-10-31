using System.IO;
using UnityEngine.Device;

namespace Code.SavesData
{
    public static class DataStorage
    {
        public static readonly string SavingDirectory = Path.Combine(Application.persistentDataPath, "savedData");
        
    }
}
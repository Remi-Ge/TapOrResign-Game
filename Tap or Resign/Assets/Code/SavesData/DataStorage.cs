using System.IO;
using UnityEngine.Device;

namespace Code.SavesData
{
    public static class DataStorage
    {
        private static string _savingDirectory = Path.Combine(Application.persistentDataPath, "savedData");
    }
}
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Code.SavesData
{
    public static class SaveLoadData
    {
        public static T LoadData<T>(string relativeFilePath)
        {
            string fullFilePath = Path.Combine(DataStorage.SavingDirectory, relativeFilePath);
            //create an instance of binaryFormatter to Serialize binary files
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //return null if the file doesn't exists
            if (!File.Exists(fullFilePath))
            {
                throw new FileNotFoundException($"The file at {fullFilePath} doesn't exists");
            }
            //open the file with FileStream
            FileStream savedFile = File.Open(fullFilePath, FileMode.Open);
            //Deserialize the binary file
            T loadedData = (T)binaryFormatter.Deserialize(savedFile);
            //close the fileStream
            savedFile.Close();
            //return the result
            return loadedData;
        }
        
        public static void Save(string relativeFilePath, object objectToSave)
        {
            string fullFilePath = Path.Combine(DataStorage.SavingDirectory, relativeFilePath);
            //create the directory if it doesn't exist
            string directoryPath = Path.GetDirectoryName(relativeFilePath);
            //create directories needed
            if (!Directory.Exists(directoryPath))
            {
                if (directoryPath == null)
                {
                    throw new DirectoryNotFoundException("The directory of the File is null");
                }
                Directory.CreateDirectory(directoryPath);
            }
            //create an instance of BinaryFormatter to serialize a class
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //create FileStream to write the file
            FileStream saveFile = File.Create(fullFilePath);
            //turn the class into binary file
            binaryFormatter.Serialize(saveFile, objectToSave);
            //close the FileStream
            saveFile.Close();
        }
    }
}
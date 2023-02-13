using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Player Progress Baru",
    menuName = "Game Kuis/Player Progress")]
public class PlayerProgress : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int koin;
        public Dictionary<string, int> progresLevel;
    }

    public string fileName = "contoh.txt";
    public MainData progresData = new MainData();

    public void SimpanProgres()
    {
        // Sampel Data
        progresData.koin = 200;
        if (progresData.progresLevel == null)
            progresData.progresLevel = new();
        progresData.progresLevel.Add("Level Pack 1", 3);
        progresData.progresLevel.Add("Level Pack 3", 5);

        // Informasi penyimpanan data
        string directory = Application.dataPath + "/Temporary/";
        string path = directory + fileName;

        // Membuat Directory Temporary jika belum ada
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been Created: " + directory);
        }

        // Membuat file baru
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File created: " + path);
        }

        // Menyimpan data ke dalam file menggunakan binari formatter
        var fileStream = File.Open(path, FileMode.Open);
        var formatter = new BinaryFormatter();

        fileStream.Flush();
        formatter.Serialize(fileStream, progresData);

        //// Menyimpan data ke dalam file menggunakan binari writer
        //var fileStream = File.Open(path, FileMode.Open);
        //var writer = new BinaryWriter(fileStream);

        //fileStream.Flush();
        //writer.Write(progresData.koin);
        //foreach (var i in progresData.progresLevel)
        //{
        //    writer.Write(i.Key);
        //    writer.Write(i.Value);
        //}
        //writer.Dispose();

        // Putuskan aliran memori dengan File
        fileStream.Dispose();

        Debug.Log("Data saved to file: " + path);
    }

    public bool MuatProgres()
    {
        // Informasi untuk memuat data
        string directory = Application.dataPath + "/Temporary/";
        string path = directory + fileName;

        // Membuat Directory Temporary jika belum ada
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been Created: " + directory);
        }

        // Buka file dengan Filestream
        var fileStream = File.Open(path, FileMode.OpenOrCreate);

        try
        {
            // Memuat data dari file menggunakan binari formatter
            var formatter = new BinaryFormatter();

            progresData = (MainData)formatter.Deserialize(fileStream);

            //// Memuat data dari file menggunakan binari reader
            //var reader = new BinaryReader(fileStream);

            //try
            //{
            //    if (reader.PeekChar() != -1)
            //        progresData.koin = reader.ReadInt32();
            //    if (progresData.progresLevel == null)
            //        progresData.progresLevel = new();
            //    while (reader.PeekChar() != -1)
            //    {
            //        var namaLevelPack = reader.ReadString();
            //        var levelKe = reader.ReadInt32();
            //        progresData.progresLevel.Add(namaLevelPack, levelKe);
            //        Debug.Log($"{namaLevelPack}:{levelKe}");
            //    }

            //    // Putuskan aliran memori dengan File
            //    reader.Dispose();
            //}
            //catch (System.Exception e)
            //{
            //    Debug.Log($"ERROR: Terjadi kesalahan saat memuat progres binari.\n{e.Message}");

            //    // Putuskan aliran memori dengan File
            //    reader.Dispose();
            //}

            // Putuskan aliran memori dengan File
            fileStream.Dispose();

            Debug.Log($"{progresData.koin}; {progresData.progresLevel.Count}");

            return true;
        }
        catch (System.Exception e)
        {
            Debug.Log($"ERROR: Terjadi kesalahan saat memuat progres\n{e.Message}");

            // Putuskan aliran memori dengan File
            fileStream.Dispose();

            return false;
        }
    }
}

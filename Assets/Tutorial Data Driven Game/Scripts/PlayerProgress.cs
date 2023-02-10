using System.Collections.Generic;
using System.IO;
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
        string fileName = "contoh.txt";
        string directory = Application.dataPath + "/Temporary/";
        string path = directory + fileName;

        // Membuat Directory Temporary
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

        // Menyimpan data ke dalam file
        string kontenData = $"{progresData.koin}\n";
        int hitungPack = 0;
        foreach (var i in progresData.progresLevel)
        {
            kontenData += $"{i.Key}-{i.Value}";
            kontenData += hitungPack >= progresData.progresLevel.Count ? string.Empty : ";";
            hitungPack++;
        }
        File.WriteAllText(path, kontenData);

        Debug.Log("Data saved to file: " + path);
    }

    public void MuatProgres()
    {
        // TODO: Prosedur untuk muat data
    }
}

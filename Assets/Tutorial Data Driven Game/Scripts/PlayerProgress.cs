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
        string fileName = "contoh.txt";
        string path = Application.dataPath + "/" + fileName;

        // Membuat file baru
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File created: " + path);
        }

        // Menyimpan data ke dalam file
        string kontenData = "Ini adalah data yang disimpan dalam file";
        File.WriteAllText(path, kontenData);

        Debug.Log("Data saved to file: " + path);
    }

    public void MuatProgres()
    {
        // TODO: Prosedur untuk muat data
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;
    public int m_Points;

    public string BestPlayer;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public string BestPlayer = "Name";  
        public int BestSocre = 0;

    }
    public void SaveBestScore()
    {
        if (BestScore < m_Points)
        {
            SaveData data = new SaveData();
            data.BestPlayer = PlayerName;
            data.BestSocre = m_Points;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestPlayer= data.BestPlayer;
            BestScore = data.BestSocre;
        }

    }

}

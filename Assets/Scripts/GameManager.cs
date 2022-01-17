using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string recordKeeper;
        public int highScore;
    }

    public static GameManager Instance;
    public string recordKeeper;
    public int highScore;
    private string m_username = "";
    public string username
    {
        get { return m_username; }
        set
        {
            m_username = value;
        }
    }

    private int m_score;
    public int score
    {
        get { return m_score; }
        set
        {
            if(value <= 0)
            {
                m_score = 0;
            }
            else
            {
                m_score = value;
            }
        }
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void SaveScore()
    {
        string filepath = Application.persistentDataPath + "/highScore.json";
        SaveData saveData = new SaveData();

        recordKeeper = saveData.recordKeeper = m_username;
        highScore = saveData.highScore = m_score;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(filepath, json);
    }

    public void LoadScore()
    {
        string filepath = Application.persistentDataPath + "/highScore.json";

        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            recordKeeper = saveData.recordKeeper;
            highScore = saveData.highScore;
        }
    }
}

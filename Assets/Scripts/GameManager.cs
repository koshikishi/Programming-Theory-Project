using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Serializable] public class RecordEntry
    {
        public string name;
        public float time;
    }

    [Serializable] class SaveData
    {
        public string lastPlayer;
        public RecordEntry bestRecord;
    }

    // ENCAPSULATION
    string _CurrentPlayer;
    public string CurrentPlayer
    {
        get { return _CurrentPlayer; }
        set
        {
            if (value == "")
            {
                Debug.LogError("Name cannot be empty!");
            }
            else
            {
                _CurrentPlayer = value;
            }
        }
    }

    public RecordEntry bestRecord { get; private set; }
    public bool isGameOver = false;
    public bool isGamePaused = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadRecord();
    }

    // ABSTRACTION
    // Update the saved time record
    public void UpdateRecord(float time)
    {
        bestRecord = new RecordEntry
        {
            name = _CurrentPlayer,
            time = time
        };
    }

    // ABSTRACTION
    // Save the data to the file
    public void SaveRecord()
    {
        SaveData data = new SaveData
        {
            lastPlayer = _CurrentPlayer,
            bestRecord = bestRecord
        };
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // ABSTRACTION
    // Load the data from the file
    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            _CurrentPlayer = data.lastPlayer;
            bestRecord = data.bestRecord;
        }
    }
}

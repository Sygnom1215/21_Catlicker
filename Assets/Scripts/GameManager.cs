using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Monosingleton<GameManager>
{
    [SerializeField]
    private User user = null;

    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";
    private void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Save";
        // Application.persistentDataPath
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
    }
    private void Start()
    {
        LoadFromJson();
        InvokeRepeating("SaveToJson", 1f, 60f);
    }
    private void LoadFromJson()
    {
        if(File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            string json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
    }
    private void SaveToJson()
    {
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }

}

using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    string path;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            path = Application.persistentDataPath + "/save.json";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(int level, int lives, float music, float sfx)
    {
        SaveData data = new SaveData();

        data.currentLevel = level;
        data.lives = lives;
        data.musicVolume = music;
        data.sfxVolume = sfx;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, json);

        Debug.Log("Game Saved");
    }

    public SaveData LoadGame()
    {
        if (!File.Exists(path))
            return null;

        string json = File.ReadAllText(path);

        return JsonUtility.FromJson<SaveData>(json);
    }
}
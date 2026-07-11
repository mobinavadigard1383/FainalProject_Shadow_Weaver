using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public static class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/save.json";

    public static void SaveGame(int lives, float timer, Vector3 playerPosition)
    {
        GameData data = new GameData();

        data.currentLevel = SceneManager.GetActiveScene().buildIndex;
        data.lives = lives;
        data.timer = timer;
        data.playerX = playerPosition.x;
        data.playerY = playerPosition.y;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);

        Debug.Log("Game Saved Successfully");
        Debug.Log(savePath);
    }

    public static GameData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);

            GameData data = JsonUtility.FromJson<GameData>(json);

            Debug.Log("Game Loaded Successfully");

            return data;
        }

        Debug.Log("No Save File Found");
        return null;
    }

    public static void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Save Deleted");
        }
    }
}
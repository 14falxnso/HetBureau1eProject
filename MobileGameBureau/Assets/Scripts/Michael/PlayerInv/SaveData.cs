using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    private string filePath;


    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "UserData");
        LoadData();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(playerStats, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Data Saved" + json);

        //if (GameManager.instance.questActive)
        //{
        //    StartCoroutine(InGameMessage("Data Saved!"));
        //}
        //else
        //{
        //    StartCoroutine(OutGameMessage("Data Saved!"));
        //}
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, playerStats);
            Debug.Log("Laad de shit");
        }

        //if (GameManager.instance.questActive)
        //{
        //    StartCoroutine(InGameMessage("Loading Completed!"));
        //}
        //else
        //{
        //    StartCoroutine(OutGameMessage("Loading Completed!"));
        //}
    }

    public void ResetData()
    {
        PlayerStats resetData = new PlayerStats();
        //resetData.moneyAmount = 0;
        //resetData.experience = 0;
        //resetData.experienceLevel = 1;
        //resetData.tasksCompleted = 0;

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        //if (GameManager.instance.questActive)
        //{
        //    StartCoroutine(InGameMessage("Data Deleted!"));
        //}
        //else
        //{
        //    StartCoroutine(OutGameMessage("Data Deleted!"));
        //}
    }
}

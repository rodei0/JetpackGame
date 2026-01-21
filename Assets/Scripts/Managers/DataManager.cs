using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    
    public static DataManager Instance { get; private set; }

    [Header("Player Data")]

    public int money = 0;
    public int highScore = 0;
    public List<string> unlockedSkins = new List<string>();
    public string selectedSkin = "0";



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int coins)
    {
        money += coins;
        SaveData();
    }


    public void SaveData()
    {
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetString("SelectedSkin", selectedSkin);
        PlayerPrefs.SetString("UnlockedSkins", string.Join(",", unlockedSkins));
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        selectedSkin = PlayerPrefs.GetString("SelectedSkin", "0");
        string unlockedSkinsString = PlayerPrefs.GetString("UnlockedSkins", "0");
        unlockedSkins = new List<string>(unlockedSkinsString.Split(','));
        if (!unlockedSkins.Contains("0"))
        {
            unlockedSkins.Add("0");
            SaveData();
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        money = 0;
        highScore = 0;
        selectedSkin = "0";
        unlockedSkins = new List<string> { "0" };
        Debug.Log("Datos reseteados");
    }
}

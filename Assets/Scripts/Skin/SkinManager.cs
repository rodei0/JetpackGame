using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance { get; private set; }
    [SerializeField] private List<Skin> skins;
    [SerializeField] private TMPro.TextMeshProUGUI coinText;
    private Skin currentSkin;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    private void Start()
    {
        //coinText = GameObject.Find("CoinText").GetComponent<TMPro.TextMeshProUGUI>();
        //ChangeCoinText();
        //LoadSelectedSkin();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject coinTextObj = GameObject.FindWithTag("CoinText");

        if (coinTextObj != null)
        {
            coinText = coinTextObj.GetComponent<TMPro.TextMeshProUGUI>();
            ChangeCoinText();
            LoadSelectedSkin();
        }
    }

    private void LoadSelectedSkin()
    {
        currentSkin = skins.Find(skin => skin.skinId == DataManager.Instance.selectedSkin);
        Debug.Log("Skin cargada: " + currentSkin.skinName);
    }


    public void UnlockSkin(Skin skin)
    {
        if (!DataManager.Instance.unlockedSkins.Contains(skin.skinId) && DataManager.Instance.money >= skin.unlockCost)
        {
            DataManager.Instance.money -= skin.unlockCost;
            ChangeCoinText();
            DataManager.Instance.unlockedSkins.Add(skin.skinId);
            skin.isUnlocked = true;
            DataManager.Instance.SaveData();
            Debug.Log("Skin desbloqueada");
        }
        else if (skin.isUnlocked)
        {
            currentSkin = skin;
            DataManager.Instance.selectedSkin = skin.skinId;
            DataManager.Instance.SaveData();
            Debug.Log("Skin seleccionada");
        }
    }

    public Skin GetCurentSkin()
    {
        if (currentSkin == null)
        {
            currentSkin = skins.Find(skin => skin.skinId == "0");
        }
        Debug.Log("Skin actual: " + currentSkin.skinName);
        return currentSkin;
    }


    public void ChangeCoinText()
    {
        coinText.text = DataManager.Instance.money.ToString();
    }

    public void ResetIsUnlockedSkins()
    {
        foreach (var skin in skins)
        {
            skin.isUnlocked = false;
        }
    }
}

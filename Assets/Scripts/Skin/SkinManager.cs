using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance { get; private set; }
    [SerializeField] private List<Skin> skins;
    private Skin currentSkin;

    private void Awake()
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
    }

    private void Start()
    {
        LoadSelectedSkin();
    }

    private void LoadSelectedSkin()
    {
        currentSkin = skins.Find(skin => skin.skinId == DataManager.Instance.selectedSkin);
    }


    public void UnlockSkin(Skin skin)
    {
        if (!DataManager.Instance.unlockedSkins.Contains(skin.skinId))
        {
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
        return currentSkin;
    }
}

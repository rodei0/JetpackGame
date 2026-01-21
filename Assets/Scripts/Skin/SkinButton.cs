using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private Skin skin;
    [SerializeField] private Image skinImage;
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite LockedSprite;
    [SerializeField] private Sprite equippedSprite;
    [SerializeField] private Sprite equipSprite;
    [SerializeField] private Sprite unlockSprite;

    private void Start()
    {
        UpdateButtonImage();
        UpdateSkinImage();
    }

    public void OnButtonPressed()
    {
        if (skin == null) return;
        SkinManager.Instance.UnlockSkin(skin);

        UpdateSkinImage();

        // Actualiza todos los botones de skins
        SkinButton[] allButtons = FindObjectsByType<SkinButton>(FindObjectsSortMode.None);
        foreach (SkinButton button in allButtons)
        {
            button.UpdateButtonImage();
        }
    }

    public void UpdateButtonImage()
    {
        if (skin == null) return;

        if (DataManager.Instance.selectedSkin == skin.skinId)
        {
            buttonImage.sprite = equippedSprite;
        }
        else if (DataManager.Instance.unlockedSkins.Contains(skin.skinId))
        {
            buttonImage.sprite = equipSprite;
        }
        else
        {
            buttonImage.sprite = unlockSprite;
        }
    }

    public void UpdateSkinImage()
    {
        if (skin == null) return;
        if (DataManager.Instance.unlockedSkins.Contains(skin.skinId))
        {
            skinImage.sprite = skin.skinSprite;
            skinImage.color = Color.white;
        } else
        {
            skinImage.sprite = LockedSprite;
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkin", menuName = "Skin/Create New Skin")]
[System.Serializable]
public class Skin : ScriptableObject
{
        public string skinId;
        public string skinName;
        public Sprite skinSprite;
        public RuntimeAnimatorController animatorController;
        public int unlockCost;
        public bool isUnlocked;
}

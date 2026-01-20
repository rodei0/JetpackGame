using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject shopPanel;
    public void StartGame()
    {
        SceneManager.LoadScene(0);  
    }

    public void OpenShop() 
    {
        mainMenuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void CloseShop() 
    {
        shopPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}

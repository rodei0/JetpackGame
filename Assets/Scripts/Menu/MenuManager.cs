using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MenuManager : MonoBehaviour
{
    
    public static MenuManager Instance { get; private set; }

    [Header("Menu Panels")]
    [SerializeField] public GameObject PausePanel;
    [SerializeField] public GameObject DeathPanel;
    [SerializeField] public GameObject WinPanel; //?¿ no necesario?

    public bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public void ShowPauseMenu()
    {
        if (GameManager.Instance.gameover) return;
        PausePanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f; // Pausa el juego
    }

    public void Resume()
    {
        if (GameManager.Instance.gameover) return;
        PausePanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f; // Reanuda el juego
    }


    public void ExitMenu()
    {
        Time.timeScale = 1f; // Reanudar el juego
        isPaused = false;
        SceneManager.LoadScene(1);
        DeathPanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reanudar el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DeathPanel.SetActive(false);
    }
    public void ShowDeathMenu()
    {
        DeathPanel.SetActive(true);
    }

}

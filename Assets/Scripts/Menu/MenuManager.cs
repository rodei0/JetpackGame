using UnityEngine;

public class MenuManager : MonoBehaviour
{
    
    public static MenuManager Instance { get; private set; }

    [Header("Menu Panels")]
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject DeathPanel;
    [SerializeField] private GameObject WinPanel; //?¿ no necesario?

    public bool isPaused = false;

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

    public void ShowPauseMenu()
    {
        PausePanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f; // Pausa el juego
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f; // Reanuda el juego
    }

    public void ShowDeathMenu()
    {
        DeathPanel.SetActive(true);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Velocidad")]
    [SerializeField] private float incrementoPorPuntos = 0.01f;
    [SerializeField] private float velocidadMax;
    public float velocidadActual { get; private set; }

    [Header("Score")]
    public float score = 0f;
    private int coinThisRun = 0;
    private float timePassed = 0f;

    [Header("UI")]
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    [Header("Debug")]
    [SerializeField] private bool startWith1kScore = false;

    public bool gameover = false;


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

    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void Update()
    {
        if (!gameover)
        {
        Debug1kStart();
        UpdateUI();
        }
        if (gameover && (Input.GetKeyDown(KeyCode.Space)))
        {
        MenuManager.Instance.RestartGame();
        }
    }


    private void UpdateVelocidad()
    {
        float nuevaVelocidad = incrementoPorPuntos * score;
        velocidadActual = Mathf.Min(nuevaVelocidad, velocidadMax);
    }

    private void Debug1kStart()
    {
        if (!startWith1kScore)
        {
            timePassed += Time.deltaTime;
            score = timePassed * 10; // 10 puntos por segundo
            UpdateVelocidad();
        }
        else
        {
            score = 1000 + timePassed * 10;
            timePassed += Time.deltaTime;
            UpdateVelocidad();
        }
    }

    public void UpdateUI()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void AddCoin()
    {
        coinThisRun++;
    }
    public void OnPlayerDead()
    {
        if (gameover) return;
        Time.timeScale = 0f; // Pausar el juego
        gameover = true;
        DataManager.Instance.AddMoney(coinThisRun);

        if (score > DataManager.Instance.highScore)
        {
            DataManager.Instance.highScore = Mathf.FloorToInt(score);
            DataManager.Instance.SaveData();
        }

        MenuManager.Instance.ShowDeathMenu();

    }



}

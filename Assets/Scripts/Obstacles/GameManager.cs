using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Velocidad")]
    [SerializeField] private float incrementoPorPuntos = 0.01f;
    [SerializeField] private float velocidadMax;
    public float score = 0f;
    public float velocidadActual { get; private set; }

    private float timePassed = 0f;
    [SerializeField] private bool startWith1kScore = false;

    [Header("UI")]
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;


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

    private void UpdateVelocidad()
    {
        float nuevaVelocidad = incrementoPorPuntos * score;
        velocidadActual = Mathf.Min(nuevaVelocidad, velocidadMax);
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    private void Update()
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
}

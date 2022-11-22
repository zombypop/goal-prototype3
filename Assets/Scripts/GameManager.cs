using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text texto;
    [SerializeField] public float tiempo = 8;
    public GameObject player;
    [SerializeField] private GoalKeeper goalKeeper;
    [SerializeField] private Ball ball;
    private bool tieneElBalon;
    private int intentos = 0;
    private int goles = 0;

    [SerializeField] Text textoIntentos;
    [SerializeField] Text textoGoles;
    [SerializeField] Text textoGolesFinal;
    [SerializeField] Text textoIntentosFinal;
    [SerializeField] Text textoEfectividad;
    [SerializeField] GameObject resumen;

    private void Awake()
    {
        ball.isStick += Ball_isStick;
    }
    private void Start()
    {
        textoIntentos.text = ScoreManager.Instance.intentos.ToString();
        textoGoles.text = ScoreManager.Instance.goles.ToString();

    }

    private void Ball_isStick(object sender, System.EventArgs e)
    {
        tieneElBalon = true;
    }

    private void Update()
    {
        if (tieneElBalon)
        {
            texto.text = $"Tiempo: {(tiempo -= Time.deltaTime).ToString("#,##")}";
            if ((tiempo) <= 0)
            {
                ScoreManager.Instance.intentos++;
                SceneManager.LoadScene(0);
            }
        }

        if (ScoreManager.Instance.intentos >= 5)
        {
            resumen.SetActive(true); 
            textoGolesFinal.text = ScoreManager.Instance.intentos.ToString();
            textoIntentosFinal.text = ScoreManager.Instance.goles.ToString();
            textoEfectividad.text = (ScoreManager.Instance.goles*1f/ScoreManager.Instance.intentos).ToString("P2");
        }

    }

    public void ResetScore()
    {
        ScoreManager.Instance.intentos = 0;
        ScoreManager.Instance.goles = 0;
        SceneManager.LoadScene(0);
    }
}

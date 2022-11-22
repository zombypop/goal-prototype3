using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlowMotion : MonoBehaviour
{
    public float slowMotionTimeScale = 0.1f;
    private float startTimeScale;
    private float startFixedDeltaTime;
    [SerializeField] Text text;

    private void Start()
    {
        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime * slowMotionTimeScale;
        text.text = "Golazo!";
        ScoreManager.Instance.intentos++;
        ScoreManager.Instance.goles++;
        StartCoroutine(StopSlowMotion());
    }

    IEnumerator StopSlowMotion()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            Time.timeScale = startTimeScale;
            Time.fixedDeltaTime = startFixedDeltaTime;
            SceneManager.LoadScene(0);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScoreUIScript : MonoBehaviour
{
    public Text timerText;
    private float timer;
    private int seconds;

    public Text scoreText;
    public int score;

    private GameObject gameManager;
    private Data data;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("DataOBJ");
        data = gameManager.GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        score = data.GetScore();
        scoreText.text = score.ToString();

        if(!data.GetClearFlag())
        {
            timer += Time.deltaTime;
            seconds = (int)timer;
            timerText.text = seconds.ToString() + "秒";
        }

        Data.poolTime = seconds;
        Data.poolScore = score;

    }

    public int GetTimer()
    {
        return seconds;
    }

    public int GetScore()
    {
        return score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    public Text score;
    public Text time;

    private int scoreNum;
    private int timeNum;


    // Start is called before the first frame update
    void Start()
    {
        scoreNum = Data.poolScore;
        timeNum = Data.poolTime;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "獲った魚のスコア:" + scoreNum.ToString();
        time.text = "クリアタイム:" + timeNum.ToString() + " 0秒";
    }
}

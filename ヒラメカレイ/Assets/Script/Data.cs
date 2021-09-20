using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{

    private bool stageDirection = false;

    private bool stageChangeFlag = false;

    private bool clearFlag = false;
    private bool isDeadFlag = false;

    private GameObject player;
    private PlayerControl playerControl;

    private bool stageMoveFlag = false;

    private int score;

    public static int poolTime;
    public static int poolScore;


    private GameObject timeUI;
    private TimerScoreUIScript uIScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
        if(SceneManager.GetActiveScene().name == "GamePlay")
        {
            timeUI = GameObject.Find("TimerScoreUI");
            uIScript = timeUI.GetComponent<TimerScoreUIScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = playerControl.GetScore();
        poolScore = score;
        //プレイヤーが死んでるかチェック
        if (playerControl.GetDeadFlag())
        {
            isDeadFlag = true;
        }

        //プレイヤーがゴールについたかチェック
        if (playerControl.GetClearFlag())//後でプレイヤーからもらう
        {
            clearFlag = true;
        }

        //Debug.Log(stageChangeFlag);

    }

    public bool GetClearFlag()
    {
        return clearFlag;
    }


    public bool GetIsDeadFlag()
    {
        return isDeadFlag;
    }

    
    public bool GetStageDire()
    {
        return stageDirection;
    }


    /// <summary>
    /// falseでカレイ、trueでヒラメ
    /// </summary>
    /// <returns></returns>
    public bool GetStageChange()
    {
        return stageChangeFlag;
    }
    public void SetStageChangeFlag(bool fl)
    {
        stageChangeFlag = fl;
    }

    public void SetStageMoveFlag(bool fl)
    {
        stageMoveFlag = fl;
    }

    /// <summary>
    /// ステージが回転しているときにtrue、止まってる時にfalse
    /// </summary>
    /// <returns></returns>
    public bool GetStageMoveFlag()
    {
        return stageMoveFlag;
    }

    public int GetScore()
    {
        return score;
    }

    

}

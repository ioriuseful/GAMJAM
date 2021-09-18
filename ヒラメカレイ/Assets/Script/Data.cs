using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{

    private bool stageDirection = false;

    private bool stageChangeFlag = false;

    private bool clearFlag = false;
    private bool isDeadFlag = false;

    private GameObject player;
    private PlayerControl playerControl;

    private bool stageMoveFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが死んでるかチェック
        if (playerControl.GetDeadFlag())
        {
            isDeadFlag = true;
        }

        //プレイヤーがゴールについたかチェック
        if (clearFlag)//後でプレイヤーからもらう
        {
            clearFlag = true;
        }

        //Debug.Log(stageChangeFlag);

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

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{

    private bool stageDirection = false;

    private bool stageChange = false;

    private bool clearFlag = false;
    private bool isDeadFlag = false;

    private GameObject player;
    private PlayerControl playerControl;

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
        //if(isDeadFlag)//後でプレイヤーからもらう
        //{
        //    isDeadFlag = true;
        //}

        //プレイヤーがゴールについたかチェック
        //if(clearFlag))//後でプレイヤーからもらう
        //{
        //    clearFlag = true;
        //}

    }


    public bool GetIsDeadFlag()
    {
        return isDeadFlag;
    }

    /// <summary>
    /// falseで右スクロール、trueで左スクロール
    /// </summary>
    /// <returns></returns>
    public bool GetStageDire()
    {
        return stageDirection;
    }

    public bool GetStageChange()
    {
        return stageChange;
    }

    

}

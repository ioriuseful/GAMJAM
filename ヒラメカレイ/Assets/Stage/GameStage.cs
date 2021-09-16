﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage : MonoBehaviour
{
    int StageSize = 20;
    int StageIndex;

    public Transform Target;
    public GameObject[] stagenum;
    public int FirstStageIndex;
    public int aheadStage;
    public List<GameObject> StageList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        StageIndex = FirstStageIndex - 1;
        StageManager(aheadStage);
    }

    // Update is called once per frame
    void Update()
    {
        int targetPosIndex = (int)(Target.position.z / StageSize);

        if (targetPosIndex + aheadStage > StageIndex)

        {
            StageManager(targetPosIndex + aheadStage);
        }
    }

    void StageManager(int maps)
    {
        if(maps <= StageIndex)
        {
            return;
        }

        for(int i=StageIndex+1;i<maps;i++)//指定したステージまで作成する
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
        }

        while(StageList.Count > aheadStage+1)//古いステージを削除する
        {
            DestroyStage();
        }

        StageIndex = maps;
    }

    GameObject MakeStage(int index)
    {
        int nextStage = Random.Range(0, stagenum.Length);

        GameObject stageObject = (GameObject)Instantiate(stagenum[nextStage], new Vector3(0, 0, index * StageSize), Quaternion.identity);

        return stageObject;
    }

    void DestroyStage()
    {
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        Destroy(oldStage);
    }
}

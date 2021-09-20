using System.Collections;
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

    /// <summary>
    /// 下三つ実験用クリアステージ作成
    /// </summary>
    public float ClearFrag = 20;
    public float ClearCount = 0;
    public GameObject goalStage;
    public bool End = false;


    // Start is called before the first frame update
    void Start()
    {
        StageIndex = FirstStageIndex - 1;
        StageManager(aheadStage);
    }

    // Update is called once per frame
    void Update()
    {
        int targetPosIndex = (int)(Target.position.x / StageSize);

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

        for(int i=StageIndex+1;i<=maps;i++)//指定したステージまで作成する
        {
            if (End)
            {
                return;
            }
            GameObject stage = MakeStage(i);
                StageList.Add(stage);
                
        }

        while (StageList.Count > aheadStage + 1)//古いステージを削除する
        {
            DestroyStage();
        }

        StageIndex = maps;
    }

    GameObject MakeStage(int index)
    {
  
        int nextStage = Random.Range(0, stagenum.Length);
        GameObject stageObject;
        if (ClearCount > ClearFrag)
        {
            stageObject = (GameObject)Instantiate(goalStage, new Vector3(index * StageSize, 0, 0), Quaternion.identity);
            End = true;
        }
        else
        {
            stageObject = (GameObject)Instantiate(stagenum[nextStage], new Vector3(index * StageSize, 0, 0), Quaternion.identity);
            ClearCount++;
        }

        return stageObject;
    }

    void DestroyStage()
    {
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        Destroy(oldStage);
    }
}

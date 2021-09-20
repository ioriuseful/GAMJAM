﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update

    private string sceneName = "";
    //private bool clearFlag = false;

    public GameObject fade;
    private bool oneFadeFlag = false;
    private GameObject gameManager;
    private Data data;

    public enum SceneNames
    {
        TitleScene,
        GameScene,
        ClearScene,
        GameOverScene,
    }

    
    void Start()
    {
        Application.targetFrameRate = 60;
        sceneName = SceneManager.GetActiveScene().name;

        if(sceneName == SceneNames.GameScene.ToString())
        {
            gameManager = GameObject.Find("DataOBJ");
            data = gameManager.GetComponent<Data>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!oneFadeFlag && fade != null)
        {
            fade.GetComponent<FadeStart>().FadeInA();
            oneFadeFlag = true;
        }

        if (sceneName == SceneNames.TitleScene.ToString())
        {
            //Debug.Log("タイトルだよ");
        }
        else if (sceneName == SceneNames.GameScene.ToString())
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || data.GetClearFlag())
            {
                fade.GetComponent<FadeStart>().FadeOutNextScene(SceneNames.ClearScene.ToString());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || data.GetIsDeadFlag())
            {
                fade.GetComponent<FadeStart>().FadeOutNextScene(SceneNames.GameOverScene.ToString());
            }
        }
        else if (sceneName == SceneNames.ClearScene.ToString())
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                fade.GetComponent<FadeStart>().FadeOutNextScene(SceneNames.TitleScene.ToString());
            }
        }
        else if (sceneName == SceneNames.GameOverScene.ToString())
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                fade.GetComponent<FadeStart>().FadeOutNextScene(SceneNames.TitleScene.ToString());
            }
        }
    }

    public void OnClickTitle()
    {
        //SceneManager.LoadScene(SceneNames.TitleScene.ToString());
        fade.GetComponent<FadeStart>().FadeOutNextScene(SceneNames.TitleScene.ToString());
    }

    public void OnClickGameScene()
    {
        //SceneManager.LoadScene(SceneNames.GameScene.ToString());
        fade.GetComponent<FadeStart>().FadeOutNextScene(SceneNames.GameScene.ToString());
    }

    public void OnClickEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;   // UnityEditorの実行を停止する処理
#else
        Application.Quit();                                // ゲームを終了する処理
#endif
    }


}

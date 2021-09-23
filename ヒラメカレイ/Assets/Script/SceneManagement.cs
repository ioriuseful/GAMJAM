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

    public AudioSource audioSource;
    public AudioClip bgm;
    bool oneFlag = false;

    public enum SceneNames
    {
        TitleScene,
        GameScene,
        ClearScene,
        GameOverScene,
    }

    
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        Application.targetFrameRate = 60;
        sceneName = SceneManager.GetActiveScene().name;

        if(sceneName == SceneNames.GameScene.ToString())
        {
            gameManager = GameObject.Find("DataOBJ");
            data = gameManager.GetComponent<Data>();
        }

        if(audioSource != null)
        {
            audioSource.volume = 0.5f;
            audioSource.clip = bgm;
            audioSource.Play();
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
            if ( data.GetClearFlag()  )
            {
                if(!oneFlag) fade.GetComponent<FadeStart>().FadeOutNextScene(SceneNames.ClearScene.ToString());

                if (audioSource != null)
                {
                    audioSource.Stop();
                }
                oneFlag = true;

            }
            else if ( data.GetIsDeadFlag())
            {
                if (!oneFlag) fade.GetComponent<FadeStart>().FadeOutNextScene(SceneNames.GameOverScene.ToString(),2.5f);
                if (audioSource != null)
                {
                    audioSource.Stop();
                }
                oneFlag = true;
            }
        }
        else if (sceneName == SceneNames.ClearScene.ToString())
        {
            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    fade.GetComponent<FadeStart>().FadeOutNextScene(SceneNames.TitleScene.ToString());
            //}
        }
        else if (sceneName == SceneNames.GameOverScene.ToString())
        {
            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    fade.GetComponent<FadeStart>().FadeOutNextScene(SceneNames.TitleScene.ToString());
            //}
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YazirusiUI : MonoBehaviour
{

    private GameObject gameManager;
    private Data data;
    public Image img;

    public Sprite right;
    public Sprite left;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("DataOBJ");
        data = gameManager.GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        if(data.GetStageChange())
        {
            
            img.sprite = right;
        }
        else
        {
            
            img.sprite = left;
        }
    }
}

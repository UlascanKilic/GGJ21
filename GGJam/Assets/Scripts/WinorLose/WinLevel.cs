using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WinLevel : MonoBehaviour
{
    [SerializeField]
    public Transform wonCanvas;

    [SerializeField]
    public Image[] starList;

    [SerializeField]
    public Countdown countdown;

    public int reachedLevel;

    public int nextSceneLoad;

    public bool winLevel;
    void Start()
    {
        winLevel = false;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    public void LevelWon()
    {

        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }

        Debug.Log("unlocked level : " + nextSceneLoad);


        float yetmis, kirk;
        yetmis = (countdown.maxCount * 70) / 100;
        kirk = (countdown.maxCount * 40) / 100;

        if (countdown.countdown >= yetmis)
        {
            Debug.Log("3 yildiz");
            starList[0].color = Color.green;
            starList[1].color = Color.green;
            starList[2].color = Color.green;
        }
        if(countdown.countdown > kirk && countdown.countdown< yetmis)
        {
            Debug.Log("2 yildiz");
            starList[0].color = Color.green;
            starList[1].color = Color.green;
            starList[2].color = Color.red;
        }
        if (countdown.countdown < kirk)
        {
            Debug.Log("1 yildiz");
            starList[0].color = Color.green;
            starList[1].color = Color.red;
            starList[2].color = Color.red;
        }

        Debug.Log("Level won!");
        
        winLevel = true;
        wonCanvas.gameObject.SetActive(true);

        
        
    }
}

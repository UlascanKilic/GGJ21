using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel : MonoBehaviour
{
    [SerializeField]
    public Canvas wonCanvas;

    [SerializeField]
    public Countdown countdown;

    public int reachedLevel; 

    private bool winLevel;
    void Start()
    {
        winLevel = false;
    }

    // Update is called once per frame
    public void LevelWon()
    {
        float yetmis, kirk;
        yetmis = (countdown.maxCount * 70) / 100;
        kirk = (countdown.maxCount * 40) / 100;

        if (countdown.countdown >= yetmis)
        {
            Debug.Log("3 yildiz");
        }
        if(countdown.countdown > kirk && countdown.countdown< yetmis)
        {
            Debug.Log("2 yildiz");
        }
        if (countdown.countdown < kirk)
        {
            Debug.Log("1 yildiz");
        }

        Debug.Log("Level won!");
        
        winLevel = true;
        wonCanvas.gameObject.SetActive(true);
            
        PlayerPrefs.SetInt("ReachedLevel", reachedLevel);

        Debug.Log("unlocked level : " + reachedLevel);
        
    }
}

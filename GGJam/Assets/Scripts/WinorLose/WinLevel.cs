using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel : MonoBehaviour
{
    [SerializeField]
    public Canvas wonCanvas;

    private bool winLevel;
    void Start()
    {
        winLevel = false;
    }

    // Update is called once per frame
    public void LevelWon()
    {
        Debug.Log("Level won!");
        winLevel = true;
        wonCanvas.gameObject.SetActive(true);
        
    }
}

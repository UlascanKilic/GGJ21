using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLevel : MonoBehaviour
{
    [SerializeField]
    public Canvas loseCanvas;

    public bool levelLose;
    void Start()
    {
        levelLose = false;
    }

    // Update is called once per frame
    public void Lose()
    {
        Debug.Log("Lose Level!");
        levelLose = true;
        loseCanvas.gameObject.SetActive(true);


    }
}

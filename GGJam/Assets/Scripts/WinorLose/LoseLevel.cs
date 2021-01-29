using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLevel : MonoBehaviour
{
    [SerializeField]
    public Transform loseCanvas;

    [SerializeField]
    public GameObject soundManager;

    public bool levelLose;
    void Start()
    {
        soundManager = GameObject.Find("SoundController");
        levelLose = false;
    }

    // Update is called once per frame
    public void Lose()
    {
        Debug.Log("Lose Level!");
        levelLose = true;
        loseCanvas.gameObject.SetActive(true);
        soundManager.transform.GetChild(4).GetComponent<AudioSource>().Play();


    }
}

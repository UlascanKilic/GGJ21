using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    public int dnm;
    void Start()
    {
        PlayerPrefs.SetInt("deneme", dnm);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(PlayerPrefs.GetInt("deneme"));
    }
}

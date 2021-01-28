using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Countdown : MonoBehaviour
{
    [SerializeField]
    public float countdown;

    [SerializeField]
    public Text countdownText;

    [SerializeField]
    public LoseLevel lose;

    [HideInInspector]
    public float maxCount;

    public float minusPerSecond;

    private void Start()
    {
        maxCount = countdown;
    }

    void Update()
    {
        if(Mathf.Round(countdown) > 0 && Mathf.Round(countdown) != 0)
        {

            countdown -= minusPerSecond * Time.deltaTime;
            countdownText.text = Mathf.Round(countdown).ToString();

            if (countdown > 20)
            {
                //
            }

            else if (countdown < 20)
            {
                //
            }
        }
        else
        {
            //öldün çıq
            if(lose.levelLose !=true)
            {
                countdown = 0;
                lose.Lose();
                minusPerSecond = 0;
            }
            
        }     
    }
}

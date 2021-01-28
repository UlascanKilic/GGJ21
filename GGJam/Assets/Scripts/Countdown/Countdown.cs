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

    public float minusPerSecond;
    
    void Update()
    {
        if(Mathf.Round(countdown) != 0)
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
        }
       

    }
}

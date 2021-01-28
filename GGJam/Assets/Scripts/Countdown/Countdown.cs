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
    CameraShake cameraShake;

    public float minusPerSecond;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Round(countdown) != 0)
        {

            countdown -= minusPerSecond * Time.deltaTime;
            countdownText.text = Mathf.Round(countdown).ToString();

            if (countdown > 20)
            {
                cameraShake.RemoveShake();
            }

            else if (countdown < 20)
            {
                cameraShake.DoShake();
            }
        }
        else
        {
            //öldün çıq
        }
       

    }
}

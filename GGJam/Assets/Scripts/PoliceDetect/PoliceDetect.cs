using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceDetect : MonoBehaviour
{
    [SerializeField]
    public Countdown countDown;

    [SerializeField]
    public float minusAmount;

    [SerializeField]
    public float toleranceTime;

    private bool isInTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isInTrigger = true;
            StartCoroutine(EnterArea(toleranceTime));            
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInTrigger = false;
            countDown.minusPerSecond = 1;
            countDown.countdownText.color = Color.white;

        }
    }

    IEnumerator EnterArea(float toleranceTime)
    {      
        yield return new WaitForSeconds(toleranceTime);
        if (isInTrigger)
        {
            countDown.minusPerSecond = minusAmount;
            countDown.countdownText.color = Color.red;
        }
       
    }
}

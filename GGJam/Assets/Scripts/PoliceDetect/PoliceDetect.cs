using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PoliceDetect : MonoBehaviour
{
    [SerializeField]
    public Countdown countDown;

 

    [SerializeField]
    public float minusAmount;

    [SerializeField]
    public float toleranceTime;

    [SerializeField]
    public float duration;

    private bool isInTrigger = false;
	public GameObject manp;
    
    private Vector3 turnRight,turnLeft;

    private void Start()
    {
        turnRight = new Vector3();
        turnLeft = new Vector3();
    }

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
            Debug.Log("trigger");

        }
        

    }
}

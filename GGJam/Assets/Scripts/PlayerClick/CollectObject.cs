using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectObject : MonoBehaviour
{
    [SerializeField]
    public float delay;

    [SerializeField]
    public Image holdImage;

    public Spawner spawner;

    public Transform panel;

    private float timeLeft;
    private bool is_clicking = true;
    private bool trueLayer= false;

    private GameObject canvas;
    // Update is called once per frame

    private void Start()
    {       
        timeLeft = delay;
    }
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {            
            string clickedObject;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {              
                clickedObject = hit.transform.gameObject.name;
                Debug.Log(clickedObject);
                if (spawner.collectibleNames.Contains(clickedObject))
                {
                    trueLayer = true;
                    if (Input.GetMouseButton(0))
                    {
                        FillOutBar();
                        StartCoroutine(CollectItemWithDelay(delay, clickedObject));
                    }                                      
                }
                else
                {
                    trueLayer = false;
                    //Debug.Log("object");
                }
            }
        }       
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && holdImage.fillAmount != 0 && is_clicking)
        {
            holdImage.gameObject.SetActive(true);
            FillOutBar();
            if (holdImage.fillAmount == 0)
            {
                is_clicking = false;
                holdImage.gameObject.SetActive(false);
                holdImage.fillAmount = 1;
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            is_clicking = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            is_clicking = false;
            holdImage.gameObject.SetActive(false);
            holdImage.fillAmount = 1;
        }

    }
    private void FillOutBar()
    {      
        holdImage.fillAmount -= 1.0f / delay * Time.deltaTime;           
    }
    IEnumerator CollectItemWithDelay(float delay,string clickedObject)
    {
        yield return new WaitForSeconds(delay);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {                
                
                if (hit.transform.gameObject.name == clickedObject)
                
                Destroy(hit.transform.gameObject);

                foreach (Transform child in panel)
                {
                    if (child.gameObject.name == clickedObject)
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }
            
        }       
    }
}

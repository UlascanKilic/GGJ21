using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LateExe;
public class CollectObject : MonoBehaviour
{
    [SerializeField]
    public float delay,punishSecond;

    [SerializeField]
    public Countdown countdown;

    [SerializeField]
    public CameraShake cameraShake;

    [SerializeField]
    public ParticleSystem collectibleParticle, obstacleParticle;

    [SerializeField]
    public Image holdImage;

    [SerializeField]
    public WinLevel winLevel;

    [SerializeField]
    public LoseLevel loseLevel;

    public Spawner spawner;

    public Transform panel;

    [HideInInspector]
    public int collectibleCount;
    private Vector3 targetPos;
    private bool is_clicking = false;

    private void Start()
    {
        collectibleCount = panel.childCount;
    }

    void Update()
    {      
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("asdadas");
            string clickedObject;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {              
                clickedObject = hit.transform.gameObject.name;
                //Debug.Log(clickedObject);
                if (spawner.collectibleNames.Contains(clickedObject))
                {                
                    if (Input.GetMouseButton(0))
                    {
                        targetPos = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                        Debug.Log(collectibleCount);
                        is_clicking = true;
                        holdImage.gameObject.SetActive(true);
                        StartCoroutine(CollectItemWithDelay(delay, clickedObject));                       
                    }                  
                }
                else
                {

                    if (spawner.obstacleNames.Contains(clickedObject))
                    {
                        targetPos = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                        is_clicking = true;
                        holdImage.gameObject.SetActive(true);
                        StartCoroutine(CollectObstacle(hit.transform.gameObject.tag));
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            is_clicking = false;
            holdImage.gameObject.SetActive(false);

            StopAllCoroutines();
        }
        
    }
    private void FixedUpdate()
    {
        if (is_clicking)
        {
            FillOutBar();
        }       
        else
        {
            holdImage.fillAmount = 1f;
        }
        if (holdImage.fillAmount == 0)
        {
            holdImage.gameObject.SetActive(false);

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
                {
                    Instantiate(collectibleParticle, targetPos, Quaternion.identity);
                    Destroy(hit.transform.gameObject);

                    foreach (Transform child in panel)
                    {
                        if (child.gameObject.name == clickedObject)
                        {
                            child.gameObject.SetActive(false);
                            collectibleCount--;

                            if(collectibleCount == 0)
                            {
                                winLevel.LevelWon();
                            }
                            
                        }
                    }
                }                               
            }           
        }        
    }
    IEnumerator CollectObstacle(string clickedObject)
    {
        yield return new WaitForSeconds(delay);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == clickedObject)
                {
                    
                    countdown.countdown -= punishSecond;
                    CameraEffects.ShakeOnce(0.8f,1);
                    Instantiate(obstacleParticle, targetPos, Quaternion.identity);

                    Debug.Log("Obstacle almaya calistin!");
                   
                }
            }
        }

    }
    private void Collect(RaycastHit hit)
    {
        Destroy(hit.transform.gameObject);
    }
}

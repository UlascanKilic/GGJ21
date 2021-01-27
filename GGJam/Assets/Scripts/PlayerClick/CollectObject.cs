using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectObject : MonoBehaviour
{
    public Spawner spawner;

    public Transform panel;

    // Update is called once per frame
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
                if (spawner.collectibleNames.Contains(clickedObject))
                {
                    Debug.Log(clickedObject);
                    Destroy(hit.transform.gameObject);

                    foreach(Transform child in panel)
                    {
                        if (child.gameObject.name == clickedObject)
                        {
                            child.gameObject.active = false;
                        }
                    }
                    
                }
                else
                {
                    Debug.Log("object");
                }
            }
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPatrol : MonoBehaviour
{
    [SerializeField]
    public GameObject gameAmca;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, gameAmca.transform.position, Time.time);
    }
}

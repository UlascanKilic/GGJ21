using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPatrol : MonoBehaviour
{
    [SerializeField]
    public GameObject gameAmca;
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxdistance;

	private Transform myTransform;

    void Start()
    {
		myTransform = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, gameAmca.transform.position, Time.time);


    }

	void Update(){


		Debug.DrawLine(target.position, myTransform.position, Color.red); 

		GameObject go = GameObject.FindGameObjectWithTag("MainCamera");

		target = go.transform;

//		maxdistance = 20;

		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

//		if(Vector3.Distance(target.position, myTransform.position) > maxdistance){
//
//			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
//
//		}
	}
}

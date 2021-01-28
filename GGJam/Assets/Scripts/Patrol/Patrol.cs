using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Patrol : MonoBehaviour
{
    public List<GameObject> patrolPoints;

    public float patrolTime;
    public float walkTime;
    public float speed;

    private Vector3 targetPoint;
    private Collider targetCollider;
    private int previousPatrolIndex = -1;

    private bool shouldLerp = false;
    void Start()
    {      
        StartCoroutine(ChangeStatus(patrolTime));
    }
    void FixedUpdate()
    {
        if (shouldLerp)
        {
            int random = Random.Range(0, patrolPoints.Count);

            if (previousPatrolIndex != random)
            {               
                targetCollider = patrolPoints[random].GetComponent<Collider>();
                targetPoint = targetCollider.bounds.center;

                transform.DOLocalMove(targetPoint, speed * Time.deltaTime);
                //transform.position = targetPoint;
                previousPatrolIndex = random;
                StartCoroutine(ChangeStatus(patrolTime));
            }
        }
    }
 
    IEnumerator ChangeStatus(float patrolTime)
    {
        shouldLerp = false;
        yield return new WaitForSeconds(patrolTime);
        shouldLerp = true;

    }
}

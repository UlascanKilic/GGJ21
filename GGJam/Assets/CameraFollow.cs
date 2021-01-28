using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public float cameraLerpDuration;

    private bool isLerping = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveCamera(float offset,float duration)
    {
        StartCoroutine(ChangeStatus());

        Vector3 targetPoint = transform.position;
        targetPoint.x += offset;

        transform.DOLocalMoveX(targetPoint.x, duration);

       
    }
    public bool IsLerping()
    {
        return isLerping;
    }
    IEnumerator ChangeStatus()
    {
        isLerping = true;
        yield return new WaitForSeconds(cameraLerpDuration);
        isLerping = false;
    }
}

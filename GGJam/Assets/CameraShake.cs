using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraShake : MonoBehaviour
{
   [SerializeField]
   public Camera camera;


    

    [SerializeField]
    public float duration, strenght, randomness,offset;
    public int vibRatio;
    public bool fadeOut;

    private Vector3 linear;

   
    public void DoShake()
    {

        camera.DOShakeRotation(duration, strenght, vibRatio, randomness, fadeOut);
    }
    public void RemoveShake()
    {
        camera.DOShakeRotation(0, 0, 0, 0, false);
    }  
    public void CustomizedShake(float duration,float strenght,int vibRatio, float randomness, bool fadeOut)
    {
        camera.DOShakeRotation(duration, strenght, vibRatio, randomness, fadeOut);
    }
}

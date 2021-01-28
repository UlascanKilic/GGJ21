using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    public Transform shelfs;

    [SerializeField]
    public CameraFollow camera;

    

    [SerializeField]
    public Text shelfText;

    public float offset = 7f;

    private int currentShelf;
    private int shelfCount;

    

    void Start()
    {
        currentShelf = 1;
        shelfCount = shelfs.childCount;
    }

    public void LeftClick()
    {
        if(currentShelf != 1)
        {
            Debug.Log("left");
            if (!camera.IsLerping())
            {
                UpdateText(-1);
                camera.MoveCamera(-offset, camera.cameraLerpDuration);
            }
            
        }
    }
    public void RightClick()
    {
        if (currentShelf != shelfCount)
        {
            Debug.Log("right");
            if (!camera.IsLerping())
            {
                UpdateText(1);
                camera.MoveCamera(offset, camera.cameraLerpDuration);
            }
           
        }
    }

    private void UpdateText(int amount)
    {
        currentShelf += amount;
        shelfText.text = currentShelf + "/" + shelfCount;
    }
}

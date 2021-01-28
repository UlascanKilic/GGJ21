using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class LevelSelector : MonoBehaviour
{

    public Button[] levelButtons;

    private void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
    }
    public void Select(string levelName)
    {
        SceneManager.LoadScene(int.Parse(levelName));      
    }
}

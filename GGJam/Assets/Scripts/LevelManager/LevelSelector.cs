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

       int levelReached = PlayerPrefs.GetInt("ReachedLevel",1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
            
        }
    }
    public void Select(string levelName)
    {
        SceneManager.LoadScene(int.Parse(levelName)+1);      
    }
    public void GetName()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        Select(name);
    }
}

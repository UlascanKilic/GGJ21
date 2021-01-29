using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class LevelSelector : MonoBehaviour
{

    public Button[] lvlButtons;

    public int dnm;

    // Start is called before the first frame update
    void Start()
    {      
        int levelAt = PlayerPrefs.GetInt("levelAt", 1); /* < Change this int value to whatever your
                                                             level selection build index is on your                                                          build settings */

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }
    public void Select(string levelName)
    {
        SceneManager.LoadScene(int.Parse(levelName));      
    }
    public void GetName()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        Select(name);
    }
}

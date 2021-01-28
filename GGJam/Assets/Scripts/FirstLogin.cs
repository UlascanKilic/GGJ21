using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstLogin : MonoBehaviour
{

	public string name;
	public InputField nameinput;
	private int firstint;
	public GameObject FirstObject;
	public bool Delete;
	public Text wanted;
	public GameObject pbutton;
	private float timer;
	private bool animtrue;

	void Awake(){
		
		if(Delete){
			PlayerPrefs.DeleteAll();
		}

		firstint = PlayerPrefs.GetInt("firstint");

		if(firstint==0){
			FirstObject.SetActive(true);
		}
		else
		{
			FirstObject.SetActive(false);
		}
	}

    // Start is called before the first frame update
    void Start()
    {
		if(firstint==1){
			name = PlayerPrefs.GetString("name");
		}

		if(Delete){
			PlayerPrefs.DeleteAll();
		}

		timer = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
		if(firstint==0){
		name = nameinput.text;
		}
		wanted.text = name;

		if(animtrue){
			timer -= Time.deltaTime*1;
		}

		if(timer <= 0){
			SceneManager.LoadScene("feriha");
		}

    }

	public void LetsGo(){
		firstint=1;
		PlayerPrefs.SetInt("firstint",firstint);
		name = nameinput.text;
		PlayerPrefs.SetString("name",name);
		FirstObject.SetActive(false);
	}

	public void Close(){
		name = "";
		PlayerPrefs.SetString("name",name);
		firstint=1;
		PlayerPrefs.SetInt("firstint",firstint);
		FirstObject.SetActive(false);

	}

	public void Play(){
		GetComponent<Animator>().enabled=true;
		pbutton.SetActive(false);
		animtrue = true;

	}

}

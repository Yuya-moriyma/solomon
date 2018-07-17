using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class MenuView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject menuArea = (GameObject) GameObject.Find ("MenuArea");
		
		GameObject ready = (GameObject) Resources.Load ("Prefabs/Button/LargeButton");
		ready.GetComponent<Text>().text = Message.MENU_BUTTON_READY;
		ready.GetComponent<Text>().color = Color.white;
		ready = Prefab.instantiate(ready, 360, 125) as GameObject;
		ready.transform.SetParent (menuArea.transform);

		GameObject edit = (GameObject) Resources.Load ("Prefabs/Button/LargeButton");
		edit.GetComponent<Text>().text = Message.MENU_BUTTON_EDIT;
		edit.GetComponent<Text>().color = Color.white;
		edit = Prefab.instantiate(edit, 360, 50) as GameObject;
		edit.transform.SetParent (menuArea.transform);

		GameObject summon = (GameObject) Resources.Load ("Prefabs/Button/LargeButton");
		summon.GetComponent<Text>().text = Message.MENU_BUTTON_SUMMON;
		summon.GetComponent<Text>().color = Color.white;
		summon = Prefab.instantiate(summon, 360, -25) as GameObject;
		summon.transform.SetParent (menuArea.transform);

		GameObject shop = (GameObject) Resources.Load ("Prefabs/Button/LargeButton");
		shop.GetComponent<Text>().text = Message.MENU_BUTTON_SHOP;
		shop.GetComponent<Text>().color = Color.white;
		shop = Prefab.instantiate(shop, 360, -100) as GameObject;
		shop.transform.SetParent (menuArea.transform);

		GameObject exit = (GameObject) Resources.Load ("Prefabs/Button/LargeButton");
		exit.GetComponent<Text>().text = Message.MENU_BUTTON_EXIT;
		exit.GetComponent<Text>().color = Color.white;
		exit = Prefab.instantiate(exit, 360, -175) as GameObject;
		exit.transform.SetParent (menuArea.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

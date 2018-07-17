using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class TitleView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject backGround = (GameObject) GameObject.Find ("BackGround");

		GameObject _newGame = (GameObject) Resources.Load ("Prefabs/Button/LargeButton");
		_newGame.GetComponent<Text> ().text = Message.TITLE_BUTTON_NEWGAME;
		_newGame = Prefab.instantiate (_newGame, 0, -75) as GameObject;
		_newGame.transform.SetParent (backGround.transform);

		GameObject _continue = (GameObject) Resources.Load ("Prefabs/Button/LargeButton");
		_continue.GetComponent<Text> ().text = Message.TITLE_BUTTON_CONTINUE;
		_continue = Prefab.instantiate (_continue, 0, -150) as GameObject;
		_continue.transform.SetParent (backGround.transform);
	}

	// Update is called once per frame
	void Update () {

	}
}
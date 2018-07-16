

using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;
using Util;

public class TitleView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject button = (GameObject) Resources.Load ("Prefabs/Button/LargeButton");
		GameObject backGround = (GameObject) GameObject.Find ("BackGround");
		button = Prefab.instantiate(button, 0, 0) as GameObject;
		button.transform.SetParent (backGround.transform);
	}

	// Update is called once per frame
	void Update () {

	}
}
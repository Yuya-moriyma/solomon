using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Util;

public class TitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickFunc (BaseEventData data) {
		PointerEventData _data = (PointerEventData)data;
		GameObject _test = _data.pointerPress;
		_test.GetComponent<Text>().text = "test";
	}
}
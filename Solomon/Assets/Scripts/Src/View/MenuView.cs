using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class MenuView : MonoBehaviour {

	LineRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GameObject.Find ("MenuView").GetComponent<LineRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 currentPos = renderer.GetPosition (0);
		if (currentPos.y <= 5.0f) {
			renderer.SetPosition (0, new Vector3 (currentPos.x, currentPos.y + 0.05f, currentPos.z));
		}
	}
}
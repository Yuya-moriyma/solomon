using System.Collections;
using System.Collections.Generic;
using Const;
using Name;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class MenuView : MonoBehaviour {

	LineRenderer lineMenu;
	LineRenderer lineMessage;
	UnityEngine.UI.Image menuBackGround;
	UnityEngine.UI.Image messageBackGround;

	// Use this for initialization
	void Start () {
		lineMenu = GameObject.Find (Menu.LINE_MENU).GetComponent<LineRenderer> ();
		lineMessage = GameObject.Find (Menu.LINE_MESSAGE).GetComponent<LineRenderer> ();
		menuBackGround = GameObject.Find (Menu.MENU_AREA).GetComponent<Image> ();
		messageBackGround = GameObject.Find (Menu.MESSAGE_AREA).GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {
		this.animateLine ();
		this.animateBackGround ();
	}

	private void animateLine () {
		Vector3 currentPos = lineMenu.GetPosition (0);
		if (currentPos.y <= Position.WINDOW_MAX_Y) {
			lineMenu.SetPosition (
				0,
				new Vector3 (
					currentPos.x,
					currentPos.y + FlameUnit.LINE_ANIMATE_DEFAULT,
					currentPos.z
				)
			);
			if (currentPos.y + FlameUnit.LINE_ANIMATE_DEFAULT <= Position.MESSAGE_AREA_MAX_Y) {
				return;
			}
		}

		currentPos = lineMessage.GetPosition (0);
		if (currentPos.x >= Position.WINDOW_MIN_X) {
			lineMessage.SetPosition (
				0,
				new Vector3 (
					currentPos.x - FlameUnit.LINE_ANIMATE_DEFAULT,
					currentPos.y,
					currentPos.z
				)
			);
		}
	}

	private void animateBackGround () {
		if (menuBackGround.color.a <= Limit.IMAGE_ALPHA_MAX && lineMenu.GetPosition (0).y >= Position.WINDOW_MAX_Y) {
			menuBackGround.color = new Color (
				menuBackGround.color.r,
				menuBackGround.color.g,
				menuBackGround.color.b,
				menuBackGround.color.a + FlameUnit.ALPHA_CHANGE_DEFAULT
			);
		}

		if (messageBackGround.color.a <= Limit.IMAGE_ALPHA_MAX && lineMessage.GetPosition (0).x <= Position.WINDOW_MIN_X) {
			messageBackGround.color = new Color (
				messageBackGround.color.r,
				messageBackGround.color.g,
				messageBackGround.color.b,
				messageBackGround.color.a + FlameUnit.ALPHA_CHANGE_DEFAULT
			);
		}
	}
}
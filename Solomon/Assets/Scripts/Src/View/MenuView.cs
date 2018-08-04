using System.Collections;
using System.Collections.Generic;
using Const;
using Name;
using UnityEngine;
using UnityEngine.UI;
using Util;
using Model;

namespace View {

	public class MenuView : MonoBehaviour {

		LineRenderer lineMenu;
		LineRenderer lineMessage;
		Image menuBackGround;
		Image messageBackGround;
		Image map;
		List<GameObject> btnAreaPoints;
		int AreaPointMax = 1;

		// Use this for initialization
		void Start () {
			this.lineMenu = GameObject.Find (Menu.LINE_MENU).GetComponent<LineRenderer> ();
			this.lineMessage = GameObject.Find (Menu.LINE_MESSAGE).GetComponent<LineRenderer> ();
			this.menuBackGround = GameObject.Find (Menu.MENU_AREA).GetComponent<Image> ();
			this.messageBackGround = GameObject.Find (Menu.MESSAGE_AREA).GetComponent<Image> ();
			this.map = GameObject.Find (Menu.MAP).GetComponent<Image> ();
			this.btnAreaPoints = new List<GameObject>();
			this.btnAreaPoints.AddRange(GameObject.FindGameObjectsWithTag(Menu.BTN_AREA_POINT));
			foreach(GameObject btnAreaPoint in this.btnAreaPoints) {
				if (int.Parse(btnAreaPoint.name) < AreaPointMax) {
					btnAreaPoint.SetActive(false);
				}
			}
			Character model = new Character();
			model.testDelete();
		}

		// Update is called once per frame
		void Update () {
			this.animateLine ();
			this.animateBackGround ();
			this.animateMap ();
		}

		private void animateLine () {
			Vector3 _currentPos = lineMenu.GetPosition (0);
			if (_currentPos.y <= Position.WINDOW_MAX_Y) {
				lineMenu.SetPosition (
					0,
					new Vector3 (
						_currentPos.x,
						_currentPos.y + FlameUnit.LINE_ANIMATE_DEFAULT,
						_currentPos.z
					)
				);
				if (_currentPos.y + FlameUnit.LINE_ANIMATE_DEFAULT <= Position.MESSAGE_AREA_MAX_Y) {
					return;
				}
			}

			_currentPos = lineMessage.GetPosition (0);
			if (_currentPos.x >= Position.WINDOW_MIN_X) {
				lineMessage.SetPosition (
					0,
					new Vector3 (
						_currentPos.x - FlameUnit.LINE_ANIMATE_DEFAULT,
						_currentPos.y,
						_currentPos.z
					)
				);
			}
		}

		private void animateBackGround () {
			if (menuBackGround.color.a <= Limit.IMAGE_ALPHA_MAX && lineMenu.GetPosition (0).y >= Position.WINDOW_MAX_Y) {
				this.changeAlphaByFlame(ref menuBackGround);
			}

			if (messageBackGround.color.a <= Limit.IMAGE_ALPHA_MAX && lineMessage.GetPosition (0).x <= Position.WINDOW_MIN_X) {
				this.changeAlphaByFlame(ref messageBackGround);
			}
		}

		private void animateMap () {
			if (map.color.a <= Limit.IMAGE_ALPHA_MAX && messageBackGround.color.a >= Limit.IMAGE_ALPHA_MAX) {
				this.changeAlphaByFlame(ref map);
			}
			foreach (GameObject btnAreaPoint in this.btnAreaPoints) {
				Image _btnAreaPoint = btnAreaPoint.GetComponent<Image>();
				if (_btnAreaPoint.color.a <= Limit.IMAGE_ALPHA_MAX && messageBackGround.color.a >= Limit.IMAGE_ALPHA_MAX) {
					this.changeAlphaByFlame(ref _btnAreaPoint);
				}
			}
		}

		private void changeAlphaByFlame (ref Image image) {
			image.color = new Color (
						image.color.r,
						image.color.g,
						image.color.b,
						image.color.a + FlameUnit.ALPHA_CHANGE_DEFAULT
			);
		}
	}
}
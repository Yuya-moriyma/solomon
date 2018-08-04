using System.Collections;
using System.Collections.Generic;
using Const;
using Name;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Util;

namespace View {

	public class TitleView : MonoBehaviour {

		GameObject curtain;
		bool changeSceneFlag = false;
		bool readyToChangeScene = false;

		public bool getReady () {
			return this.readyToChangeScene;
		}

		public void changeSecne (BaseEventData data) {
			this.changeSceneFlag = true;
		}

		void Start () {
			this.curtain = GameObject.Find (Title.CURTAIN);
		}

		// Update is called once per frame
		void Update () {
			if (this.changeSceneFlag) {
				this.animateScene ();
			}
		}

		private void animateScene () {
			Image _curtain = this.curtain.GetComponent<Image> ();
			_curtain.enabled = true;
			if (_curtain.color.a <= Limit.IMAGE_ALPHA_MAX) {
				_curtain.color = new Color (
					_curtain.color.r,
					_curtain.color.g,
					_curtain.color.b,
					_curtain.color.a + FlameUnit.ALPHA_CHANGE_SLOW
				);
				return;
			}
			readyToChangeScene = true;
		}
	}
}
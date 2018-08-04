using System.Collections;
using System.Collections.Generic;
using Const;
using Name;
using View;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Util;


namespace Controller {

	public class TitleController : MonoBehaviour {

		TitleView view;
		int toChangeSceneIndex;

		public void onClickFunc (BaseEventData data) {
			PointerEventData _data = (PointerEventData) data;
			GameObject _object = _data.pointerPress;
			if (_object.name == Title.BTN_NEW_GAME) {
				this.toChangeSceneIndex = Const.Scene.INDEX_STORY;
			}
			if (_object.name == Title.BTN_CONTINUE) {
				this.toChangeSceneIndex = Const.Scene.INDEX_MENU;
			}
			this.view.changeSecne (data);
		}
		
		// Use this for initialization
		void Start () {
			this.view = (TitleView)(GameObject.Find(Title.VIEW).GetComponent(Title.VIEW));
		}

		// Update is called once per frame
		void Update () {
			if (this.view.getReady ()) {
				StartCoroutine("wait", Const.Scene.CHANGE_SCENE_WAIT_SECOND);
			}
		}


		private IEnumerator wait (float time) {
			Debug.Log("wait");
			yield return new WaitForSeconds (time);
			Debug.Log("release");
			SceneManager.LoadScene (this.toChangeSceneIndex);
		}
	}
}
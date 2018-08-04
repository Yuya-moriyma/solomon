using System.Collections;
using System.Collections.Generic;
using Const;
using Name;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtnAreaPoint : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    ParticleSystem effect;

    // Use this for initialization
    void Start () {
        this.effect = GameObject.Find (Menu.SELECTED_AREA_EFFECT).GetComponent<ParticleSystem> ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void OnPointerClick (PointerEventData eventData) {
        Text _nextAreaInfoText = GameObject.Find(Menu.NEXT_AREA_INFO).GetComponentInChildren<Text> ();;
        _nextAreaInfoText.text = string.Format(Message.NEXT_AREA_MESSAGE, this.name); 
        this.effect.Pause();
        this.effect.transform.position = new Vector3 (
            this.transform.position.x,
            this.transform.position.y,
            this.effect.transform.position.z
        );
        this.effect.Play();
    }

    public void OnPointerEnter (PointerEventData eventData) {
        this.transform.localScale = new Vector3 (
            this.transform.localScale.x + 1,
            this.transform.localScale.y + 1,
            this.transform.localScale.z
        );
    }

    public void OnPointerExit (PointerEventData eventData) {
        this.transform.localScale = new Vector3 (
            this.transform.localScale.x - 1,
            this.transform.localScale.y - 1,
            this.transform.localScale.z
        );
    }
}
using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Btn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    Text btnObject;
    string displayText;
    bool canChangeMessage = true;

    // Use this for initialization
    void Start () {
        this.btnObject = GetComponentInChildren<Text> ();
        this.displayText = this.btnObject.text;
    }

    // Update is called once per frame
    void Update () {

    }

    public void OnPointerEnter (PointerEventData eventData) {
        if (this.canChangeMessage) {
            this.btnObject.text = "† " + displayText + " †";
        }
    }

    public void OnPointerExit (PointerEventData eventData) {
        if (this.canChangeMessage) {
            this.btnObject.text = displayText;
        }
    }

    public void OnPointerClick (PointerEventData eventData) {
        this.canChangeMessage = false;
        this.btnObject.text = "† " + displayText + " †";
    }
}
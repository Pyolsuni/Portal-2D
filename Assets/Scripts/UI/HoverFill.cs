using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverFill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Image image;
    private bool inBounds;

    private void Update() {
        if (inBounds) { image.fillAmount += 0.04f; }
        else { image.fillAmount -= 0.04f; }
    }

    private void OnDisable() {
        inBounds = false;
        image.fillAmount = 0f;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        inBounds = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        inBounds = false;
    }
}

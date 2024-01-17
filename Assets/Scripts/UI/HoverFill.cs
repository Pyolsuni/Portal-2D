using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[HelpURL("https://forum.unity.com/threads/how-to-use-onpointerenter-event.294801/#post-1942607")]
public class HoverFill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField]
    private Image image;
    private bool inBounds;

    [Tooltip("Change button's fill speed.")]
    [ContextMenuItem(name: "Change to default value", function: "DefaultFillSpeed")]
    [Range(0, 1)]
    public float fillSpeed = 0.04f;

    public AudioSource hoverAudio;

    private void Start() {
        hoverAudio.volume = PlayerPrefs.GetFloat("SoundVolume")/11;
    }

    [ContextMenu("DefaultFillSpeed")]
    private void DefaultFillSpeed() {
        fillSpeed = 0.04f;
    }

    private void Update() {
        if (inBounds) { image.fillAmount += fillSpeed; }
        else { image.fillAmount -= fillSpeed; }
    }

    private void OnDisable() {
        inBounds = false;
        image.fillAmount = 0f;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        hoverAudio.Play();
        inBounds = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        inBounds = false;
    }

}

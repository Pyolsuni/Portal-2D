using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite Inactive;
    public Sprite Active;
    public bool Pressed = false;
    private SpriteRenderer Renderer;
    public AudioSource audioClip;

    private void Start()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Renderer.sprite = Active;
        Events.ButtonPressed(gameObject);
        Pressed = true;
        audioClip = GetComponent<AudioSource>();
        if (audioClip != null) audioClip.Play(0);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Renderer.sprite = Inactive;
        Events.ButtonReleased(gameObject);
        Pressed = false;
    }
}

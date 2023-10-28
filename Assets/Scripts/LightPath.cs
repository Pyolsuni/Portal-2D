using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPath : MonoBehaviour
{
    public Sprite CornerActive;
    public Sprite CornerInactive;
    public Sprite StraightActive;
    public Sprite StraightInactive;
    public GameObject Button;

    private SpriteRenderer Renderer;
    private void Awake()
    {
        Events.OnButtonPressed += ButtonPressed;
        Events.OnButtonReleased += ButtonReleased;
    }
    private void OnDestroy()
    {
        Events.OnButtonReleased -= ButtonReleased;
        Events.OnButtonPressed -= ButtonPressed;
    }

    private void Start()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void ButtonPressed(GameObject button)
    {
        if (button != null && button == Button) 
        {
            TurnOn();
        }
    }
    public void ButtonReleased(GameObject button)
    {
        if (button != null && button == Button)
        {
            TurnOff();
        }
    }
    private void TurnOn()
    {
        if (Renderer.sprite == CornerInactive)
        {
            Renderer.sprite = CornerActive;
        }
        if (Renderer.sprite == StraightInactive) 
        {
            Renderer.sprite = StraightActive;
        }
    }
    private void TurnOff()
    {
        if (Renderer.sprite == CornerActive)
        {
            Renderer.sprite = CornerInactive;
        }
        if (Renderer.sprite == StraightActive)
        {
            Renderer.sprite = StraightInactive;
        }
    }
}

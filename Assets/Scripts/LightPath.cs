using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPath : MonoBehaviour
{
    public Sprite CornerActive;
    public Sprite CornerInactive;
    public Sprite StraightActive;
    public Sprite StraightInactive;
    public GameObject Activator;

    private SpriteRenderer Renderer;
    private void Awake()
    {
        Events.OnButtonPressed += Activate;
        Events.OnButtonReleased += Inactivate;
        Events.OnLaserReceived += Activate;
        Events.OnLaserRemoved += Inactivate;
    }
    private void OnDestroy()
    {
        Events.OnButtonReleased -= Activate;
        Events.OnButtonPressed -= Inactivate;
        Events.OnLaserReceived -= Activate;
        Events.OnLaserRemoved -= Inactivate;
    }

    private void Start()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Activate(GameObject activator)
    {
        if (activator != null && activator == Activator) 
        {
            TurnOn();
        }
    }
    public void Inactivate(GameObject activator)
    {
        if (activator != null && activator == Activator)
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

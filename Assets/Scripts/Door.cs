using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject LeftDoor;
    public GameObject RightDoor;

    public Sprite LeftDoorOpen;
    public Sprite LeftDoorClosed;
    public Sprite RightDoorOpen;
    public Sprite RightDoorClosed;

    public int ButtonsNeeded;
    private int buttonsPressed;

    public int LasersNeeded;
    private int lasersReceived;
    private void Awake()
    {
        Events.OnButtonPressed += ButtonPressed;
        Events.OnButtonReleased += ButtonReleased;
        Events.OnLaserReceived += LaserReceived;
        Events.OnLaserRemoved += LaserRemoved;
    }
    private void OnDestroy()
    {
        Events.OnButtonReleased -= ButtonReleased;
        Events.OnButtonPressed -= ButtonPressed;
        Events.OnLaserReceived -= LaserReceived;
        Events.OnLaserRemoved -= LaserRemoved;
    }

    public void ButtonPressed(GameObject button)
    {
        buttonsPressed++;
        if (buttonsPressed >= ButtonsNeeded && lasersReceived >= LasersNeeded) 
        {
            OpenDoors();
        }
    }
    public void ButtonReleased(GameObject button)
    {
        buttonsPressed--;
        if (buttonsPressed < ButtonsNeeded) CloseDoors();
    }

    public void LaserReceived(GameObject laser)
    {
        lasersReceived++;
        if (lasersReceived >= LasersNeeded && buttonsPressed >= ButtonsNeeded)
        {
            OpenDoors();
        }
    }
    public void LaserRemoved(GameObject laser)
    {
        lasersReceived--;
        if (lasersReceived < LasersNeeded) CloseDoors();
    }
    private void OpenDoors()
    {
        LeftDoor.GetComponent<SpriteRenderer>().sprite = LeftDoorOpen;
        RightDoor.GetComponent<SpriteRenderer>().sprite = RightDoorOpen;
        LeftDoor.GetComponent<Collider2D>().enabled = false;
        RightDoor.GetComponent<Collider2D>().enabled = false;
    }
    private void CloseDoors()
    {
        LeftDoor.GetComponent<SpriteRenderer>().sprite = LeftDoorClosed;
        RightDoor.GetComponent<SpriteRenderer>().sprite = RightDoorClosed;
        LeftDoor.GetComponent<Collider2D>().enabled = true;
        RightDoor.GetComponent<Collider2D>().enabled = true;
    }
}

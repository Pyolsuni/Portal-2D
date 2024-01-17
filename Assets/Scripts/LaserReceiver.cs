using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    private bool receiving = false;
    public Sprite laseron;
    public Sprite laseroff;
    public void LaserReceived()
    {
        if (!receiving)
        {
            receiving = true;
            Events.LaserReceived(gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = laseron;
        }
    }
    public void LaserRemoved()
    {
        if (receiving)
        {
            receiving = false;
            Events.LaserRemoved(gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = laseroff;
        }
    }
}

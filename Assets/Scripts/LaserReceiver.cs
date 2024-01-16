using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    private bool receiving = false;
    public void LaserReceived()
    {
        if (!receiving)
        {
            receiving = true;
            Events.LaserReceived(gameObject);
        }
    }
    public void LaserRemoved()
    {
        if (receiving)
        {
            receiving = false;
            Events.LaserRemoved(gameObject);
        }
    }
}

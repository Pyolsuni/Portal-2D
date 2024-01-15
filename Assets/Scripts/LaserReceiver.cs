using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    private bool receiving = false;
    public void LaserReceived()
    {
        receiving = true;
        Events.LaserReceived(gameObject);
    }
    public void LaserRemoved()
    {
        receiving = false;
        Events.LaserRemoved(gameObject);
    }

    private void Update()
    {
        if (receiving)
        {
            LaserRemoved();
        }
    }
}

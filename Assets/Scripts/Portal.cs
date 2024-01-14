using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Rigidbody2D enteredRigidBody;
    private GameObject toSpawnFirst;
    private GameObject toSpawnSecond;
    private float noReEnterTime = 0f;
    private bool runTimer = false;

    private void Update()
    {
        if (runTimer)
        {
            noReEnterTime -= Time.deltaTime;
            if (noReEnterTime < 0f)
            {
                PortalControl.Instance.EnableColliders();
                runTimer = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (toSpawnFirst == null)
        {
            toSpawnFirst = collision.gameObject;
        }
        else if (toSpawnSecond == null)
        {
            toSpawnSecond = collision.gameObject;
        }
        enteredRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
        //Debug.Log(gameObject.name + " Triggerenter: " + toSpawnFirst.name + " " + toSpawnSecond.name);
        if (gameObject.name == "BluePortal")
        {
            PortalControl.Instance.DisableCollider("Orange");
            if (toSpawnSecond == null) PortalControl.Instance.CreateClone("Orange", toSpawnFirst.name, collision.gameObject.GetComponent<Rigidbody2D>());
            else PortalControl.Instance.CreateClone("Orange", toSpawnSecond.name, collision.gameObject.GetComponent<Rigidbody2D>());
        }
        else if (gameObject.name == "OrangePortal")
        {
            PortalControl.Instance.DisableCollider("Blue");
            if (toSpawnSecond == null) PortalControl.Instance.CreateClone("Blue", toSpawnFirst.name, collision.gameObject.GetComponent<Rigidbody2D>());
            else PortalControl.Instance.CreateClone("Blue", toSpawnSecond.name, collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Clone")
        {
            Debug.Log(gameObject.name + " Triggerexit: " + toSpawnFirst + " " + toSpawnSecond);
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject);
            if (toSpawnFirst.name == "Player")
            {
                GameObject.Find("Clone").name = "Player";
            }
            else if (toSpawnFirst.name == "Cube") GameObject.Find("Clone").name = "Cube";
            if (toSpawnSecond != null)
            {
                toSpawnFirst = toSpawnSecond;
                toSpawnSecond = null;
                Debug.Log("toSpawnSecond");
            }
            else
            {
                toSpawnFirst = null;
                runTimer = true;
                noReEnterTime = 0.5f;
                Debug.Log("toSpawnFirst");
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}

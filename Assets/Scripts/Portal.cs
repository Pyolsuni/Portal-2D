using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Rigidbody2D enteredRigidBody;
    private string toSpawnFirst;
    private string toSpawnSecond;
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
        if (collision.gameObject.tag == "Cube")
        {
            if (toSpawnFirst == null) toSpawnFirst = "Box";
            else toSpawnSecond = "Box";
        }
        else if (collision.gameObject.tag == "Player")
        {
            if (toSpawnFirst == null) toSpawnFirst = "Player";
            else if (toSpawnFirst != "Player") toSpawnSecond = "Player";
        }
        else
        {
            Destroy(collision.gameObject);
        }
        enteredRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(gameObject.name + " Triggerenter: " + toSpawnFirst + " " + toSpawnSecond);
        if (gameObject.name == "BluePortal")
        {
            PortalControl.Instance.DisableCollider("Orange");
            if (toSpawnSecond == null) PortalControl.Instance.CreateClone("Orange", toSpawnFirst, collision.gameObject.GetComponent<Rigidbody2D>());
            else PortalControl.Instance.CreateClone("Orange", toSpawnSecond, collision.gameObject.GetComponent<Rigidbody2D>());
        }
        else if (gameObject.name == "OrangePortal")
        {
            PortalControl.Instance.DisableCollider("Blue");
            if (toSpawnSecond == null) PortalControl.Instance.CreateClone("Blue", toSpawnFirst, collision.gameObject.GetComponent<Rigidbody2D>());
            else PortalControl.Instance.CreateClone("Orange", toSpawnSecond, collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Clone")
        {
            Debug.Log(gameObject.name + " Triggerexit: " + toSpawnFirst + " " + toSpawnSecond);
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject);
            if (toSpawnFirst == "Player")
            {
                GameObject.Find("Clone").name = "Player";
            }
            else if (toSpawnFirst == "Box") GameObject.Find("Clone").name = "Cube";
            if (toSpawnSecond != null)
            {
                toSpawnFirst = toSpawnSecond;
                toSpawnSecond = null;
            }
            else
            {
                toSpawnFirst = null;
                runTimer = true;
                noReEnterTime = 0.5f;
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}

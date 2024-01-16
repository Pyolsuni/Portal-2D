using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Rigidbody2D enteredRigidBody;
    private List<GameObject> spawned = new List<GameObject>();
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
        spawned.Add(collision.gameObject);
        enteredRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(gameObject.name + " Triggerenter: " + spawned[spawned.Count - 1].tag);
        if (gameObject.name == "BluePortal")
        {
            PortalControl.Instance.DisableCollider("Orange");
            PortalControl.Instance.CreateClone("Orange", spawned[spawned.Count - 1].tag, collision.gameObject.GetComponent<Rigidbody2D>());
        }
        else if (gameObject.name == "OrangePortal")
        {
            PortalControl.Instance.DisableCollider("Blue");
            PortalControl.Instance.CreateClone("Blue", spawned[spawned.Count - 1].tag, collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Clone")
        {
            Debug.Log(gameObject.name + " Triggerexit: " + spawned[0].name);
            Debug.Log(collision.gameObject.name);
            int index = spawned.IndexOf(collision.gameObject);
            Destroy(collision.gameObject);
            if (spawned[index].tag == "Player")
            {
                GameObject.Find("Clone").name = "Player";
            }
            else if (spawned[index].tag == "Cube") GameObject.Find("Clone").name = "Cube";
            spawned.RemoveAt(index);
            runTimer = true;
            noReEnterTime = 0.5f;
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}

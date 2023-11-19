using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Rigidbody2D enteredRigidBody;
    private string toSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            toSpawn = "Box";
        }
        else toSpawn = "Player";
        enteredRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();

        if (gameObject.name == "BluePortal")
        {
            PortalControl.Instance.DisableCollider("Orange");
            PortalControl.Instance.CreateClone("Orange", toSpawn, collision.gameObject.GetComponent<Rigidbody2D>());
        }
        else if (gameObject.name == "OrangePortal")
        {
            PortalControl.Instance.DisableCollider("Blue");
            PortalControl.Instance.CreateClone("Blue", toSpawn, collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name != "Clone")
        {
            Destroy(collision.gameObject);
            PortalControl.Instance.EnableColliders();
            if (toSpawn == "Player") GameObject.Find("Clone").name = "Player";
            else if (toSpawn == "Box") GameObject.Find("Clone").name = "Cube";
        }
    }
}

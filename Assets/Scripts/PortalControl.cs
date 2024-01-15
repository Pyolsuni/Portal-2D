using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalControl : MonoBehaviour
{
    public static PortalControl Instance;

    [SerializeField]
    private GameObject blueportal, orangeportal;

    [SerializeField]
    private GameObject blueportallaser, orangeportallaser;

    private PortalLaser bluelaser, orangelaser;

    [SerializeField]
    private Transform bluePortalSpawnPoint, orangePortalSpawnPoint;

    private Collider2D bluePortalCollider, orangePortalCollider;

    [SerializeField]
    private GameObject player, cube;

    [SerializeField]
    private VelocityEqualizer equalizer;
    void Start()
    {
        Instance = this;
        bluePortalCollider = blueportal.GetComponent<Collider2D>();
        orangePortalCollider = orangeportal.GetComponent<Collider2D>();
        bluelaser = blueportallaser.GetComponent<PortalLaser>();
        orangelaser = orangeportallaser.GetComponent<PortalLaser>();
    }

    public void CreateClone(string whereToCreate, string whatToCreate, Rigidbody2D toMimic)
    {
        if (whereToCreate == "Blue")
        {
            if (whatToCreate == "Player")
            {
                var instantiatedClone = Instantiate(player, bluePortalSpawnPoint.position, Quaternion.identity);
                instantiatedClone.gameObject.name = "Clone";
            }
            else if (whatToCreate == "Cube")
            {
                var instantiatedClone = Instantiate(cube, bluePortalSpawnPoint.position, Quaternion.identity);
                instantiatedClone.gameObject.name = "Clone";
                equalizer.targetObject = instantiatedClone.GetComponent<Rigidbody2D>();
                equalizer.sourceObject = toMimic;
            }
        }
        else if (whereToCreate == "Orange")
        {
            if (whatToCreate == "Player")
            {
                var instantiatedClone = Instantiate(player, orangePortalSpawnPoint.position, Quaternion.identity);
                instantiatedClone.gameObject.name = "Clone";
            }
            else if (whatToCreate == "Cube")
            {
                var instantiatedClone = Instantiate(cube, orangePortalSpawnPoint.position, Quaternion.identity);
                instantiatedClone.gameObject.name = "Clone";
                equalizer.targetObject = instantiatedClone.GetComponent<Rigidbody2D>();
                equalizer.sourceObject = toMimic;
            }
        }
    }

    public void DisableCollider(string colliderToDisable)
    {
        if (colliderToDisable == "Orange")
        {
            orangePortalCollider.enabled = false;
        }
        else if (colliderToDisable == "Blue")
        {
            bluePortalCollider.enabled = false;
        }
    }

    public void EnableColliders()
    {
        orangePortalCollider.enabled = true;
        bluePortalCollider.enabled = true;
    }

    public void EnableLaser(GameObject portal, Vector2 offset)
    {
        if (portal == blueportal)
        {
            orangelaser.EnableLaser(offset);
        }
        else if (portal == orangeportal)
        {
            bluelaser.EnableLaser(offset);
        }
    }

    public void DisableLasers()
    {
        orangelaser.DisableLaser();
        bluelaser.DisableLaser();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform LaserFirePoint;
    public LineRenderer LaserLine;
    Transform m_transform;

    private LaserReceiver hitReceiver;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();
    }
    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D[] _hit = Physics2D.RaycastAll(m_transform.position, transform.right);
            RaycastHit2D closestHit = Physics2D.Raycast(m_transform.position, transform.right);
            foreach (RaycastHit2D hit in _hit)
            {
                if((!hit.collider.isTrigger || hit.collider.gameObject.tag == "Portal") && hit.distance < closestHit.distance)
                {
                    closestHit = hit;
                    //Debug.Log(hit.collider.gameObject.name + ", " + hit.distance);
                }
            }
            Draw2DRay(LaserFirePoint.position, closestHit.point);
            if (closestHit.collider.gameObject.tag == "Portal" && closestHit.collider.isTrigger)
            {
                Vector2 hitportal = closestHit.collider.gameObject.transform.position;
                Vector2 offset = hitportal - closestHit.point;
                PortalControl.Instance.EnableLaser(closestHit.collider.gameObject, offset);
                if (hitReceiver != null) hitReceiver.LaserRemoved();
            }
            else if (closestHit.collider.gameObject.tag == "Receiver")
            {
                LaserReceiver receiver = closestHit.collider.gameObject.GetComponent<LaserReceiver>();
                receiver.LaserReceived();
                hitReceiver = receiver;
            }
            else
            {
                if (PortalControl.Instance != null) PortalControl.Instance.DisableLasers();
                if (hitReceiver != null) hitReceiver.LaserRemoved();
            }
        }
        else
        {
            Draw2DRay(LaserFirePoint.position, LaserFirePoint.right * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        LaserLine.SetPosition(0, new Vector3(startPos.x, startPos.y, -1));
        LaserLine.SetPosition(1, new Vector3(endPos.x, endPos.y, -1));
    }
}

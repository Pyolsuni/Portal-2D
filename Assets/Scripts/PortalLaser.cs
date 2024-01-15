using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLaser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform LaserFirePoint;
    public LineRenderer LaserLine;
    Transform m_transform;

    private bool LaserEnabled = false;
    private Vector2 offset = Vector2.zero;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (LaserEnabled) ShootLaser();
    }

    public void EnableLaser(Vector2 distance)
    {
        LaserEnabled = true;
        LaserLine.enabled = true;
        offset = distance;
    }

    public void DisableLaser() {
        LaserEnabled = false;
        LaserLine.enabled = false;
    }
    void ShootLaser()
    {
        if (Physics2D.Raycast(new Vector2(m_transform.position.x, m_transform.position.y + offset.y), -transform.right))
        {
            RaycastHit2D[] _hit = Physics2D.RaycastAll(new Vector2(m_transform.position.x, m_transform.position.y + offset.y), -transform.right);
            RaycastHit2D closestHit = Physics2D.Raycast(new Vector2(m_transform.position.x, m_transform.position.y + offset.y), -transform.right);
            foreach (RaycastHit2D hit in _hit)
            {
                if ((!hit.collider.isTrigger || hit.collider.gameObject.tag == "Portal") && hit.distance < closestHit.distance)
                {
                    closestHit = hit;
                    //Debug.Log(hit.collider.gameObject.name + ", " + hit.distance);
                }
            }
            if (closestHit.collider.gameObject.tag == "Receiver")
            {
                LaserReceiver receiver = closestHit.collider.gameObject.GetComponent<LaserReceiver>();
                receiver.LaserReceived();
            }
            Draw2DRay(new Vector2(m_transform.position.x, m_transform.position.y + offset.y), closestHit.point);
        }
        else
        {
            Draw2DRay(new Vector2(m_transform.position.x, m_transform.position.y + offset.y), LaserFirePoint.right * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        LaserLine.SetPosition(0, new Vector3(startPos.x, startPos.y, -1));
        LaserLine.SetPosition(1, new Vector3(endPos.x, endPos.y, -1));
    }
}

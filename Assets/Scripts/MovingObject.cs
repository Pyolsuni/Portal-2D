using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private Vector2 StartPoint;
    public Vector2 EndPoint;
    public float MovementTime;
    public bool Return;

    void Start()
    {
        StartPoint = gameObject.transform.position;
    }
    void Update()
    {
        if (Return) gameObject.transform.position = Vector2.Lerp(StartPoint, EndPoint, Mathf.PingPong(Time.time / MovementTime, 1));
        else gameObject.transform.position = Vector2.Lerp(StartPoint, EndPoint, Time.time / MovementTime);
    }
}

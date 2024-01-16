using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private Vector2 StartPoint;
    public Vector2 EndPoint;
    public float MovementTime;
    public bool Return;

    private float time = 0;

    void Start()
    {
        StartPoint = gameObject.transform.position;
        time = 0;
    }
    void Update()
    {
        time += Time.deltaTime;
        if (Return) gameObject.transform.position = Vector2.Lerp(StartPoint, EndPoint, Mathf.PingPong(time / MovementTime, 1));
        else gameObject.transform.position = Vector2.Lerp(StartPoint, EndPoint, time / MovementTime);
    }
}

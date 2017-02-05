﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField]
    Transform startPoint;

    [SerializeField]
    Transform endPoint;

    public Vector2 RightDirection { get { return (Vector2)(endPoint.position - startPoint.position).normalized; } }
    public Vector2 LeftDirection { get { return (Vector2)(startPoint.position - endPoint.position).normalized; } }

    public Vector2 Normal { get { return new Vector2(-RightDirection.y, RightDirection.x).normalized; } }

    public Vector2 StartPosition { get { return startPoint.position; } }

    public Vector2 EndPosition { get { return endPoint.position; } }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 0, 5 * Time.deltaTime);
    }

    public Vector2 GetPositionOnFloor(float lerpValue)
    {
        return Vector2.Lerp(StartPosition, EndPosition, lerpValue);
    }
}

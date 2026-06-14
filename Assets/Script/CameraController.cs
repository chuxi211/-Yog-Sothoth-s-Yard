using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    private float DragSpeed=1f;
    private Vector3 LastMousePos;
    public Bounds bound { get; private set; }
    //首先，把限制逻辑和移动，缩放的逻辑独立出来，写成函数
    public void SetBound(Bounds bound)
    {
        this.bound = bound;
    }
    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    private void Update()
    {
        if (_camera != null)
        {
            ClampCamera(bound);
            DragCamera();
        }
    }
    private void ClampCamera(Bounds bound)
    {
        Vector3 pos = _camera.transform.position;
        pos.x = Mathf.Clamp(pos.x,bound.min.x,bound.max.x);
        pos.y=Mathf.Clamp(pos.y,bound.min.y, bound.max.y);
        _camera.transform.position = pos;
    }
    private void DragCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LastMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - LastMousePos;
            Vector3 move = new Vector3(-delta.x, -delta.y, 0) * DragSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);
            LastMousePos = Input.mousePosition;
        }
    }
}

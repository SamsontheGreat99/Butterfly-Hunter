using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//To create a summary section like this, hit '/' 3 times
/// <summary>
/// Keeps a gameobject on screen.
/// Note that this ONLY works for an orthographic main camera at the origin.
/// </summary>
public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inpsector")]
    public float radius = 1f;
    public bool keepOnScreen = true;

    [Header("Set Dynamically")]
    public bool isOnscreen = true;
    public float camWidth;
    public float camHeight;

    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        isOnscreen = true;
        offRight = offLeft = offUp = offDown = false;

        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            offRight = true;
        }
        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            offLeft = true;
        }
        if (pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
            offUp = true;
        }
        if (pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
            offDown = true;
        }

        isOnscreen = !(offRight || offLeft || offUp || offDown);
        if (keepOnScreen && !isOnscreen)
        {
            transform.position = pos;
            isOnscreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
        
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}

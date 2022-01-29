using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBridge : MonoBehaviour
{
    private ColliderListener _listener;
    public void Initialize(ColliderListener listener)
    {
        _listener = listener;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        _listener.OnCollisionEnter2D(collision);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        _listener.OnCollisionExit2D(collision);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _listener.OnTriggerEnter2D(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _listener.OnTriggerExit2D(other);
    }
}

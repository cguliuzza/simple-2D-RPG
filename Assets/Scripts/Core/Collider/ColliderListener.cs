using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderListener : MonoBehaviour
{
    protected virtual void Awake()
    {
        // Check if Colider is in another GameObject
        Collider2D collider = GetComponentInChildren<Collider2D>();
        if (collider.gameObject != gameObject)
        {
            ColliderBridge cb = collider.gameObject.AddComponent<ColliderBridge>();
            cb.Initialize(this);
        }
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    public virtual void OnCollisionExit2D(Collision2D collision)
    {

    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {

    }
    public virtual void OnTriggerExit2D(Collider2D other)
    {
        
    }
}

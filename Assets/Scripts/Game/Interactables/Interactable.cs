using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool _canInteract = false;
    protected bool _isInteracting = false;
    // Update is called once per frame
    protected virtual void Update()
    {
        if (_canInteract && Input.GetButtonDown("Fire1") && PlayerController.Instance.canMove)
        {
            Interact();
        }
    }
    protected virtual void Interact()
    {
        _isInteracting = true;
    }

    protected virtual void OutOfRange()
    {
        _isInteracting = false;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canInteract = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canInteract = false;
            OutOfRange();
        }
    }
}

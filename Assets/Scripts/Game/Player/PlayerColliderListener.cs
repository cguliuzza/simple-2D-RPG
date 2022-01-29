using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderListener : ColliderListener
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    public override void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wildgrass")
        {
            BattleController.Instance.OnEnterWildgrass();
        }
    }
    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wildgrass")
        {
            BattleController.Instance.OnExitWildgrass();
        }
    }
}

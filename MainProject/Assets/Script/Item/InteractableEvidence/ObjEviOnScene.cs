using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ø… π”√
/// </summary>
public class ObjEviOnScene : InteractableObj
{

    protected override void InteractAction()
    {
        ToPackage();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) InteractAction();
    }

}

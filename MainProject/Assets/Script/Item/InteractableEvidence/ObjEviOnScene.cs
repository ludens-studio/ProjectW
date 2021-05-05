using UnityEngine;

/// <summary>
/// ø… π”√
/// </summary>
public class ObjEviOnScene : TalkableObject
{
    public override void EndAquire()
    {
        Destroy(gameObject);
    }

    public override void StartAquire()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) InteractAction();
    }

}

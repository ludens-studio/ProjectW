using UnityEngine;

/// <summary>
/// 碰到就加入背包的物品
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Evidence/ObjectEvidence ")]
public class ObjectEvidence : BaseEvidence
{
    [SerializeReference] private Sprite imageSprite;

    /// <summary>
    /// 用于获取物品在背包中的Sprite
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite() 
    {
        return imageSprite;
    }

}

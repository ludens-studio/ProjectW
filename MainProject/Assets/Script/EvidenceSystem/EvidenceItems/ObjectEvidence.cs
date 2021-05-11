using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Evidence/ObjectEvidence ")]
public class ObjectEvidence : BaseEvidence
{
    [SerializeReference] private Sprite imageSprite;
    /// <summary>
    /// 可交互物品名字
    /// </summary>
    [SerializeReference] private List<string> interactableObj=new List<string>();
    /// <summary>
    /// 物证在背包中的Sprite
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite() 
    {
        return imageSprite;
    }

    /// <summary>
    /// 判断是否能够与某个物品交互
    /// </summary>
    /// <param name="objname"></param>
    /// <returns></returns>
    public bool Interactable(string objname) 
    {
        if (!interactableObj.Contains(objname)) return false;
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Evidence/ObjectEvidence ")]
public class ObjectEvidence : BaseEvidence
{
    [SerializeReference] private Sprite imageSprite;
    /// <summary>
    /// 物证的可交互物品名字
    /// </summary>
    [SerializeReference] private List<string> interactableObj=new List<string>();
    /// <summary>
    /// 获取物证的图片
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite() 
    {
        return imageSprite;
    }

    /// <summary>
    /// 返回物证是否能够与当前的道具交互
    /// </summary>
    /// <param name="objname"></param>
    /// <returns></returns>
    public bool Interactable(string objname) 
    {
        if (!interactableObj.Contains(objname)) return false;
        return true;
    }
}

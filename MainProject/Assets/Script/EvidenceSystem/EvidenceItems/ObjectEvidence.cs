using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Evidence/ObjectEvidence ")]
public class ObjectEvidence : BaseEvidence
{
    [SerializeReference] private Sprite imageSprite;
    /// <summary>
    /// 可交互物品列表，用于动静态解密
    /// </summary>
    [SerializeReference] private List<string> interactableObj=new List<string>();
    /// <summary>
    /// 用于获取物品在背包中的Sprite
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite() 
    {
        return imageSprite;
    }

    /// <summary>
    /// 交互,并且返回是否能够交互
    /// </summary>
    /// <param name="objname"></param>
    /// <returns></returns>
    public bool Interact(string objname) 
    {
        if (!interactableObj.Contains(objname)) return false;
        else return true;
    }
}

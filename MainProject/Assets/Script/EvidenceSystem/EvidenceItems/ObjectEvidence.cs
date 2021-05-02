using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Evidence/ObjectEvidence ")]
public class ObjectEvidence : BaseEvidence
{
    [SerializeReference] private Sprite imageSprite;
    /// <summary>
    /// �ɽ�����Ʒ�б����ڶ���̬����
    /// </summary>
    [SerializeReference] private List<string> interactableObj=new List<string>();
    /// <summary>
    /// ���ڻ�ȡ��Ʒ�ڱ����е�Sprite
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite() 
    {
        return imageSprite;
    }

    /// <summary>
    /// ����,���ҷ����Ƿ��ܹ�����
    /// </summary>
    /// <param name="objname"></param>
    /// <returns></returns>
    public bool Interact(string objname) 
    {
        if (!interactableObj.Contains(objname)) return false;
        else return true;
    }
}

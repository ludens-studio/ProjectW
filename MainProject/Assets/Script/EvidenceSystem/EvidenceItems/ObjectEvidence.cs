using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Evidence/ObjectEvidence ")]
public class ObjectEvidence : BaseEvidence
{
    [SerializeReference] private Sprite imageSprite;

    /// <summary>
    /// ���ڻ�ȡ��Ʒ�ڱ����е�Sprite
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite() 
    {
        return imageSprite;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ɽ�����,������
/// </summary>
public abstract class InteractableObj : MonoBehaviour
{
    [SerializeReference] private string objectName;
    [SerializeReference] private bool isObject;


    protected void Awake()
    {
    }

    /// <summary>
    /// ���뱳���ӿ�
    /// </summary>
    protected void ToPackage()
    {
        EvidenceManager eviMGR = EvidenceManager.GetInstance();
        if (isObject) eviMGR.AddObjectEvidence(objectName);
        else eviMGR.AddWordEvidence(objectName);
    }

    /// <summary>
    /// ����ģʽ��������������Ʒ����
    /// </summary>
    protected abstract void InteractAction();
}

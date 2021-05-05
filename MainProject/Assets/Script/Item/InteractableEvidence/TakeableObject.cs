using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ɽ�����,������
/// </summary>
public abstract class TalkableObject : MonoBehaviour, AddToPackage
{
    [SerializeReference] private string objectName;
    [SerializeReference] private bool isObject;

    /// <summary>
    /// ���뱳���ӿ�
    /// </summary>
    protected void ToPackage()
    {
        EndAquire();
        EvidenceManager eviMGR = EvidenceManager.GetInstance();
        if (isObject) eviMGR.AddObjectEvidence(objectName);
        else eviMGR.AddWordEvidence(objectName);
    }

    /// <summary>
    /// ����ģʽ�������ô������Ʒ���뱳��
    /// </summary>
    protected void InteractAction() 
    {
        StartAquire();
        ToPackage();
        EndAquire();
    }

    public abstract void EndAquire();
    public abstract void StartAquire();
}

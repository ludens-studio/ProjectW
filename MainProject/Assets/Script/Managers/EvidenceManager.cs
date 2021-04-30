using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ϵͳ�ĵ�����ͬʱ������֤,�ڹ��Ĺ�����
/// </summary>
public class EvidenceManager : SingletonMono<EvidenceManager> 
{
    public AllEvidence allEvidences;
    public Package package;
    public SurveyLog log;

    public delegate void EvidenceHandler(string objectEvi);
    public event EvidenceHandler AddObjectEvent;
    public event EvidenceHandler RemoveObjectEvent;


    protected override void  Awake()
    {
        base.Awake();
        allEvidences.Initialize();
    }

    /// <summary>
    /// �����ã�ͬʱ�������ݿ���UI�ĸı�
    /// </summary>
    /// <param name="evidence"></param>
    public void AddObjectEvidence(string evidence) 
    {
        package.AddEvidence(evidence);
        if(AddObjectEvent!=null)AddObjectEvent(evidence);
    }

    public void RemoveObjectEvidence(string eviname) 
    {
        package.RemoveEvidence(eviname);
        RemoveObjectEvent(eviname);
    }
}

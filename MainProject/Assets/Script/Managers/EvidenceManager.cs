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
    public event EvidenceHandler AddWordEvent;


    protected override void  Awake()
    {
        base.Awake();
        allEvidences.Initialize();
    }

    /// <summary>
    /// �����ã�ͬʱ�������ݿ���UI�ĸı�,�����Ƿ�ɹ����뱳��
    /// </summary>
    /// <param name="evidence"></param>
    public bool AddObjectEvidence(string evidence) 
    {
        if (package.AddEvidence(evidence))
        {
            if (AddObjectEvent != null) AddObjectEvent(evidence);
            return true;
        }
        return false;
    }

    public void RemoveObjectEvidence(string eviname) 
    {
        package.RemoveEvidence(eviname);
        RemoveObjectEvent(eviname);
    }

    public void AddWordEvidence(string evidence)
    {
        log.AddEvidence(evidence);
        if (AddWordEvent != null) AddWordEvent(evidence);
    }

}

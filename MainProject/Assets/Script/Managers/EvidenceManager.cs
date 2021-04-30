using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背包系统的单例，同时管理物证,口供的管理器
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
    /// 外界调用，同时控制数据库与UI的改变
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

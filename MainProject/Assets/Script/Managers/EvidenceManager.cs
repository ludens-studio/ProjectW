using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 证据管理器，用于全局添加与删除证据，单例
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
    /// 将物证加入背包
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

    /// <summary>
    /// 移除物证
    /// </summary>
    /// <param name="eviname"></param>
    public void RemoveObjectEvidence(string eviname) 
    {
        package.RemoveEvidence(eviname);
        RemoveObjectEvent(eviname);
    }

    /// <summary>
    /// 添加口证
    /// </summary>
    /// <param name="evidence"></param>
    public void AddWordEvidence(string evidence)
    {
        log.AddEvidence(evidence);
        if (AddWordEvent != null) AddWordEvent(evidence);
    }

}

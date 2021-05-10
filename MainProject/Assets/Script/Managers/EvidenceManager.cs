using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例，用于全局添加删除物证，并且初始化图鉴字典
/// 用于全局加入物证口证，全局删除物证
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
    /// 将名字evidence的物证加入背包，返回是否成功加入背包
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
    /// 将物证从背包中移除
    /// </summary>
    /// <param name="eviname"></param>
    public void RemoveObjectEvidence(string eviname) 
    {
        package.RemoveEvidence(eviname);
        RemoveObjectEvent(eviname);
    }

    /// <summary>
    ///添加口证
    /// </summary>
    /// <param name="evidence"></param>
    public void AddWordEvidence(string evidence)
    {
        log.AddEvidence(evidence);
        if (AddWordEvent != null) AddWordEvent(evidence);
    }

}

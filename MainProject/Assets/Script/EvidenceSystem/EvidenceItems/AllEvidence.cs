using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有的证据都加在这里面
/// 所有的证据的主图鉴，需要GameManager管理
/// </summary>
public class AllEvidence : ScriptableObject
{
    [SerializeReference] private List<WordEvidence> words = new List<WordEvidence>();
    [SerializeReference] private List<ObjectEvidence> objects = new List<ObjectEvidence>();

    private Dictionary<string, WordEvidence> wordDic = new Dictionary<string, WordEvidence>();
    private Dictionary<string, ObjectEvidence> objectDic = new Dictionary<string, ObjectEvidence>();

    /// <summary>
    /// 用于单例模式，初始化库中的字典
    /// </summary>
    public void Initialize() 
    {
         foreach(WordEvidence evi in words) 
        {
            string eviName = evi.GetEvidenceName();
            if (!wordDic.ContainsKey(eviName)) wordDic.Add(eviName, evi);
        }

        foreach (ObjectEvidence evi in objects)
        {
            string eviName = evi.GetEvidenceName();
            if (!objectDic.ContainsKey(eviName)) objectDic.Add(eviName, evi);
        }
    }

    /// <summary>
    /// 获得口供
    /// </summary>
    /// <param name="evidenceName"></param>
    /// <returns></returns>
    public WordEvidence GetWordEvidence(string evidenceName) 
    {
        return wordDic[evidenceName];
    }

    /// <summary>
    /// 获得物证
    /// </summary>
    /// <param name="evidenceName"></param>
    /// <returns></returns>
    public ObjectEvidence GetObjectEvidence(string evidenceName)
    {
        return objectDic[evidenceName];
    }

}

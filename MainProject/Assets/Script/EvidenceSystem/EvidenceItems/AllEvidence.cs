using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 记录游戏里面所有的证据
/// </summary>
public class AllEvidence : ScriptableObject
{
    [SerializeReference] private List<WordEvidence> words = new List<WordEvidence>();
    [SerializeReference] private List<ObjectEvidence> objects = new List<ObjectEvidence>();

    private Dictionary<string, WordEvidence> wordDic = new Dictionary<string, WordEvidence>();
    private Dictionary<string, ObjectEvidence> objectDic = new Dictionary<string, ObjectEvidence>();

    /// <summary>
    /// 初始化字典
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
    /// 
    /// </summary>
    /// <param name="evidenceName"></param>
    /// <returns></returns>
    public WordEvidence GetWordEvidence(string evidenceName) 
    {
        if(wordDic.ContainsKey(evidenceName))
        return wordDic[evidenceName];
        else return null;
    }

    /// <summary>
    ///获得物证
    /// </summary>
    /// <param name="evidenceName"></param>
    /// <returns></returns>
    public ObjectEvidence GetObjectEvidence(string evidenceName)
    {
        if(objectDic.ContainsKey(evidenceName))
        return objectDic[evidenceName];
        else return null;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���е�֤�ݶ�����������
/// ���е�֤�ݵ���ͼ������ҪGameManager����
/// </summary>
public class AllEvidence : ScriptableObject
{
    [SerializeReference] private List<WordEvidence> words = new List<WordEvidence>();
    [SerializeReference] private List<ObjectEvidence> objects = new List<ObjectEvidence>();

    private Dictionary<string, WordEvidence> wordDic = new Dictionary<string, WordEvidence>();
    private Dictionary<string, ObjectEvidence> objectDic = new Dictionary<string, ObjectEvidence>();

    /// <summary>
    /// ���ڵ���ģʽ����ʼ�����е��ֵ�
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
    /// ��ÿڹ�
    /// </summary>
    /// <param name="evidenceName"></param>
    /// <returns></returns>
    public WordEvidence GetWordEvidence(string evidenceName) 
    {
        return wordDic[evidenceName];
    }

    /// <summary>
    /// �����֤
    /// </summary>
    /// <param name="evidenceName"></param>
    /// <returns></returns>
    public ObjectEvidence GetObjectEvidence(string evidenceName)
    {
        return objectDic[evidenceName];
    }

}

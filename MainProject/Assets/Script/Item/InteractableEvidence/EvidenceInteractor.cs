using UnityEngine;

/// <summary>
/// 挂载，所有证据可交互物品需要添加
/// </summary>
public class EvidenceInteractor : MonoBehaviour
{
    public delegate void InteractWithEvidence(string str);
    public InteractWithEvidence EvidenceHandler;

    /// <summary>
    /// 开启交互，证据触发
    /// </summary>
    /// <param name="str"></param>
    public void Interact(string str) 
    {
       if(EvidenceHandler!=null) EvidenceHandler(str);
    }
}

/// <summary>
/// 可被带走的我
/// </summary>
public interface AddToPackage 
{
    /// <summary>
    ///获得物品前的动作
    /// </summary>
    void StartAquire();
    /// <summary>
    ///获得物品后的动作
    /// </summary>
    void EndAquire();
}

/// <summary>
/// 与背包证据交互
/// </summary>
public interface MatchEvidence 
{
    /// <summary>
    /// 与道具交互的行为
    /// </summary>
    /// <param name="evidence"></param>
    /// <returns></returns>
    bool MatchAction(string evidence);
}


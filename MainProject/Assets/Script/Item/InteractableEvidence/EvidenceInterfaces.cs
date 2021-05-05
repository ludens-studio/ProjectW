/// <summary>
/// 将物品加入背包的实现
/// </summary>
public interface AddToPackage 
{
    /// <summary>
    ///把道具加入背包前的行为
    /// </summary>
    void StartAquire();
    /// <summary>
    ///把道具加入背包后的行为
    /// </summary>
    void EndAquire();
}

/// <summary>
/// 道具之间交互的实现
/// </summary>
public interface MatchEvidence 
{
    /// <summary>
    /// 可交互物品具体的交互逻辑
    /// </summary>
    /// <param name="evidence"></param>
    /// <returns></returns>
    bool MatchAction(string evidence);
}


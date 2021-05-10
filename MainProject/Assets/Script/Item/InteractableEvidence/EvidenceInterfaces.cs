/// <summary>
/// 可加入背包物品的接口
/// </summary>
public interface AddToPackage 
{
    /// <summary>
    ///加入背包之前的动作
    /// </summary>
    void StartAquire();
    /// <summary>
    ///加入背包之后的动作
    /// </summary>
    void EndAquire();
}

/// <summary>
/// 交互类物品接口，让场景上的物品与证据交互
/// </summary>
public interface MatchEvidence 
{
    /// <summary>
    /// 匹配的行为
    /// </summary>
    /// <param name="evidence"></param>
    /// <returns></returns>
    bool MatchAction(string evidence);
}


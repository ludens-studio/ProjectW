/// <summary>
/// ����Ʒ���뱳����ʵ��
/// </summary>
public interface AddToPackage 
{
    /// <summary>
    ///�ѵ��߼��뱳��ǰ����Ϊ
    /// </summary>
    void StartAquire();
    /// <summary>
    ///�ѵ��߼��뱳�������Ϊ
    /// </summary>
    void EndAquire();
}

/// <summary>
/// ����֮�佻����ʵ��
/// </summary>
public interface MatchEvidence 
{
    /// <summary>
    /// �ɽ�����Ʒ����Ľ����߼�
    /// </summary>
    /// <param name="evidence"></param>
    /// <returns></returns>
    bool MatchAction(string evidence);
}


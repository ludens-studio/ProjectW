public class CodeButtonMgr : BaseManager<CodeButtonMgr>
{
    ///<summary>
    ///暂存当前输入的密码，用于显示
    ///</summary>
    private string code = null;

    ///<summary>
    ///正确的密码
    ///</summary>
    private string correctCode = "1245";

    ///<summary>
    ///获取当前输入
    ///</summary>
    public string GetCode(){
        if(code!=null)
            return code;
        else
            return "Enter the code";
    }
    ///<summary>
    ///通过用户输入获取密码并存放至code
    ///</summary>
    public void GetNumberFromButton(string codeFromButton){
        code+=codeFromButton;
    }

    ///<summary>
    ///确认是否输入了正确的密码
    ///</summary>
    public bool Confirm(){
        if(code == correctCode)
            return true;
        return false;
    }

    ///<summary>
    ///回退一格密码
    ///</summary>
    public void DeleteCode(){
        if(code.Length!=0)
            code = code.Substring(0,code.Length-1);
    }

    ///<summary>
    ///清空当前输入的密码，在退出面板时使用
    ///</summary>
    public void ClearCode(){
        code = null;
    }
}

using UnityEngine;
using TMPro;

///<summary>
/// 密码锁控制器，包含：
/// 按钮输入的响应事件；
/// 确认的响应事件；
/// 删除的响应事件
///</summary>
public class CodeLockController : MonoBehaviour
{
    public TextMeshProUGUI codeText;

    public void DigitButtonPressed(string currentNum){
        CodeButtonMgr.GetInstance().GetNumberFromButton(currentNum);
    }

    public void EnterButtonPressed(){
        if(CodeButtonMgr.GetInstance().Confirm()){
            //执行对应的事件，比如获取到某个物品等等
            Debug.Log("好耶，你输入对了");
        }
    }

    public void DeleteButtonPressed(){
        CodeButtonMgr.GetInstance().DeleteCode();
    }
}

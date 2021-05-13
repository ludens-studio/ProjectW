using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;  

public class InteractiveManager : MonoBehaviour
{
    public GameObject Tips ; 
  public static InteractiveManager instance;
    private void Awake()
    {
        if(instance == null ){
            instance = this ;
            //设置instance
        }else{
            if(instance != this){
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    } 
    
    public void UsingIt (int _mode)
	{
        Debug.Log("使用交互，模式： "+ _mode);
        
        switch(_mode)
		{
            case 0 :
                Debug.Log("No Mode");
                break ;

            case 1 :
                //进入静态解密
                EnterProblem();
                break;

            
        }
    }

    //开门系列，使用playerfrebs键值对实现
    public void OpenDoor(string _doorNum){
        //输入对应门的编号(int)打开这个门，门的编号设置在门对应物体上
        PlayerPrefs.SetInt(_doorNum,1);
        Debug.Log("Door "+_doorNum+"is Open (Mgr)");
        //1代表该门的状态是开启
    }

    public void CloseDoor(string _doorNum){
        //输入对应门的编号(int)关闭这个门
        PlayerPrefs.SetInt(_doorNum,0);
        Debug.Log("Door "+_doorNum+"is Close (Mgr)");
        //0代表该门的状态应该是关闭
    }

    public void OpenTips(){
        //弹出交互提示的方法
        Tips.SetActive(true);
    }

    public void CloseTips(){
        Tips.SetActive(false);
    }

    public void EnterProblem()
	{
        //进入静态解密的部分
    }

    //通过字符串，或者场景的index来切换场景
    public void ChangeSence(string _position){
        SceneManager.LoadScene(_position);
    }
    public void ChangeSence(int _position){
        SceneManager.LoadScene(_position);
    }
}

using UnityEngine;
using TMPro;

public class TextShining : MonoBehaviour
{
    public Material m_sharedMaterial;
    public TextMeshProUGUI currentNum;
    private float dilate = 0;
    private string defaultText = "";
    private float timer = 0f;
    private bool addL = false;
    void Start(){
        defaultText = currentNum.text;
        m_sharedMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 2);
    }

    void FixedUpdate(){
        SeparatorShining();
    }
    
    void SeparatorShining(){
        timer+=0.02f;
        if(addL){
            m_sharedMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, dilate += 0.03f);//递增
        }else{
            m_sharedMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, dilate -= 0.03f);//递减
        }
        if(timer > 0.55f && !addL){
            currentNum.text = CodeButtonMgr.GetInstance().GetCode()+"|";
            addL = true;
            timer = 0f;
        }
        if(timer > 0.55f && addL){
            currentNum.text = currentNum.text.Substring(0,currentNum.text.Length-1);
            addL = false;
            timer = 0f;
        }
    }
}

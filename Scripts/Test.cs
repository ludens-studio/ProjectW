using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    Transform ttransform;
    void Start(){
        ttransform = GameObject.Find("Main Camera").transform;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)){
            RoomMgr.GetInstance().LoadRoom("Prefab/C");
        }
        if(Input.GetKeyDown(KeyCode.O)){
            RoomMgr.GetInstance().LeaveRoom();
        }
    }
}

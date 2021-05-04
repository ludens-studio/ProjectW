using UnityEngine;

// 相机管理器，管理相机的状态
public class CameraMgr : BaseManager<CameraMgr>
{
    //找到相机
    GameObject cameraInScene = GameObject.Find("Main Camera");
    //进入静态场景
    public void SetInRoom(){
        cameraInScene.GetComponent<RoomCameraController>().enabled = true;
        cameraInScene.GetComponent<MapCameraController>().enabled = false;
    }
    //进入大地图
    public void SetInMap(){
        cameraInScene.GetComponent<MapCameraController>().enabled = true;
        cameraInScene.GetComponent<RoomCameraController>().enabled = false;
    }
    //禁用相机。要启用，请在对应情况使用map或room
    public void ForbidCamera(){
        cameraInScene.GetComponent<MapCameraController>().enabled = false;
        cameraInScene.GetComponent<RoomCameraController>().enabled = true;
    }
}

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 房间管理器
/// 加载房间(其实就是墙壁)的资源，覆盖在大地图和玩家的前方
/// 离开房间，原本的墙壁被隐藏
/// 房间自带可交互的物体(本质是各种按钮)。实现一下渐变显隐显示面板的效果就ok了
/// </summary>
public class RoomMgr : BaseManager<RoomMgr>
{
    //已加载的房间的列表
    private List<GameObject> roomList = new List<GameObject>();
    //当前房间
    private static GameObject currentRoom;
    GameObject _camera = GameObject.Find("Main Camera");  

    /// <summary>
    /// 加载对应路径上的房间预制件，name写路径
    /// </summary>
    public void LoadRoom(string name){
        //检查是否已经实例化过
        foreach(GameObject room in roomList){
            if(room.name == name){
                room.transform.position = new Vector3(_camera.transform.position.x,_camera.transform.position.y,room.transform.position.z);
                room.SetActive(true);
                currentRoom = room;
                return;
            }
        }
        //注意一下，这里的name要写成路径，比如UI文件夹下的a图片，name应该是UI/a
        ResMgr.GetInstance().LoadAsync<GameObject>(name,(o) =>
        {
            o.name = name;
            o.transform.position = new Vector3(_camera.transform.position.x,_camera.transform.position.y,o.transform.position.z);
            roomList.Add(o);
            currentRoom = o;
        });
    }

    /// <summary>
    /// 离开房间
    /// </summary>
    public void LeaveRoom(){
        if(currentRoom!=null)
            currentRoom.SetActive(false);
    }
}

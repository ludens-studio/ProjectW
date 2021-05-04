using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 资源加载
/// </summary>
public class ResMgr : BaseManager<ResMgr>
{
    //异步加载资源
    public void LoadAsync<T>(string name, UnityAction<T> callback) where T:Object
    {
        //开启异步加载的协程
        MonoMgr.GetInstance().StartCoroutine(ReallyLoadAsync(name, callback));
    }

    //真正的协同程序函数  用于 开启异步加载对应的资源
    private IEnumerator ReallyLoadAsync<T>(string name, UnityAction<T> callback) where T : Object//name写的是完整路径
    {
        ResourceRequest r = Resources.LoadAsync<T>(name);//异步加载路径上对应的资源
        yield return r;

        if (r.asset is GameObject){
            callback(GameObject.Instantiate(r.asset) as T);
        }
        else{
            Debug.Log(r.asset.name+"不是物体");
            callback(r.asset as T);
        }
    }
}

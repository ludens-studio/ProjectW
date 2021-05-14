using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenItem : TalkableObject
{
    ItemHighlighter highlighter;

    void Start()
    {
        highlighter=gameObject.GetComponent<ItemHighlighter>();
    }

    void Update()
    {
        if(highlighter.enter)
        {
            if(Input.GetKeyDown(KeyCode.K)) InteractAction();
        }
    }

    protected override void ToPackage()
    {
        EvidenceManager eviMGR = EvidenceManager.GetInstance();
        eviMGR.AddObjectEvidence(objectName);     
    }

    public override void EndAquire()
    {
        Destroy(gameObject);
    }
    //动态获取，在走近时按下回车获取道具
    public override void StartAquire()
    {
    }
    
}

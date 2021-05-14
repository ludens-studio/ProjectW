using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoItem : TalkableObject
{
    private  ItemHighlighter highlighter;

    void Start()
    {
        highlighter=gameObject.GetComponent<ItemHighlighter>();
    }

    void Update()
    {
        if(highlighter!=null&&highlighter.enter)
        {
            if(Input.GetKeyDown(KeyCode.K))InteractAction();
        }
    }

    public override void StartAquire()
    {

    }

    public override void EndAquire()
    {

    }

    protected override void ToPackage()
    {
        EvidenceManager evidence= EvidenceManager.GetInstance();
        if(evidence.package.GetEvidence(objectName)==null)
        {
            evidence.AddObjectEvidence(objectName);
        }
        else 
        {
            print(false);
            DiaLogManager.GetInstance().BoringSpeak(0);
        }
    }
}

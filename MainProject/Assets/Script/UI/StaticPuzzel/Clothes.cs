using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EvidenceManager.GetInstance().AddObjectEvidence("尺寸不一的衣服");        
    }

}

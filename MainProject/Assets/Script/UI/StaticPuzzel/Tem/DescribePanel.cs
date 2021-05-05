using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescribePanel : MonoBehaviour
{
    private EvidenceInteractor interactor;
    public Text text;

    private void Start()
    {
        interactor = gameObject.GetComponent<EvidenceInteractor>();
        interactor.EvidenceHandler += ShowDescribe;
    }

    private void ShowDescribe(string str) 
    {
        ObjectEvidence evi = EvidenceManager.GetInstance().allEvidences.GetObjectEvidence(str);
        text.text = evi.GetDescribe();
    }
}

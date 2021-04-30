using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Collection/Survey")]

public class SurveyLog : BaseCollector
{
    public override void AddEvidence(string evidence)
    {
        WordEvidence target = EvidenceManager.GetInstance().allEvidences.GetWordEvidence(evidence);
        for (int i = 0; i < 12; i++)
        {
            if (evidenceList[i] == null) 
            {
                evidenceList[i] = target;
                break;
            }
        }
    }

}

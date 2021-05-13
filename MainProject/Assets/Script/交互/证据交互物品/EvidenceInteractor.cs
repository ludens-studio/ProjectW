using UnityEngine;

public class EvidenceInteractor : MonoBehaviour
{
    public delegate void InteractWithEvidence(string str);
    public InteractWithEvidence EvidenceHandler;

    public void Interact(string str) 
    {
       if(EvidenceHandler!=null) EvidenceHandler(str);
    }
}

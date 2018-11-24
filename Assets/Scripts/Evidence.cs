using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : MonoBehaviour
{
    [SerializeField]
    private CaseFile caseFileToUnlock;
    
    public void UnlockCaseFile()
    {
        if (caseFileToUnlock != null)
            caseFileToUnlock.IsLocked = false;
    }
}

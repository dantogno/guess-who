using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : MonoBehaviour
{
    [SerializeField]
    private CaseFile caseFileToUnlock;

    private Animator animator;
    private int isLockedAnimParam = Animator.StringToHash(nameof(isLockedAnimParam));
    private int isBeingLookedAtAnimParam = Animator.StringToHash(nameof(isBeingLookedAtAnimParam));
    private bool isBeingLookedAt = false;

    public bool IsBeingLookedAt
    {
        get
        {
            return isBeingLookedAt;
        }
        set
        {
            isBeingLookedAt = value;
            animator.SetBool(isBeingLookedAtAnimParam, value);
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool(isLockedAnimParam, caseFileToUnlock.IsLocked);
    }

    public void UnlockCaseFile()
    {
        if (caseFileToUnlock != null)
            caseFileToUnlock.IsLocked = false;
        animator.SetBool(isLockedAnimParam, false);
    }
}

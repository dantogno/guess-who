using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Evidence : MonoBehaviour
{
    [TextArea(3,5)]
    [SerializeField]
    private string evidenceARDisplayText;

    [SerializeField]
    private CaseFile caseFileToUnlock;

    [SerializeField]
    private Text evidenceCanvasHeading;

    [SerializeField]
    private Text evidenceARText;

    private Animator animator;
    private int isLockedAnimParam = Animator.StringToHash(nameof(isLockedAnimParam));
    private int isBeingLookedAtAnimParam = Animator.StringToHash(nameof(isBeingLookedAtAnimParam));
    private bool isBeingLookedAt = false;
    private const string headingPrefix = "Case file added: ";
    private const string multiplePrefix = "Multiple case files added";

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

    // Thinking this needs to happen in start so that CaseFile initializes first in Awake.
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool(isLockedAnimParam, caseFileToUnlock.IsLocked);
        evidenceCanvasHeading.text = caseFileToUnlock.UnlocksLinkedCaseFiles ? 
            multiplePrefix : headingPrefix + caseFileToUnlock.DisplayName;
        evidenceARText.text = evidenceARDisplayText;
    }

    public void UnlockCaseFile()
    {
        if (caseFileToUnlock != null)
            caseFileToUnlock.IsLocked = false;
        animator.SetBool(isLockedAnimParam, false);
    }
}

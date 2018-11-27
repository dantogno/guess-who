using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseFile : MonoBehaviour
{
    public static event Action CaseFileUnlocked;
    public static List<CaseFile> AllCaseFiles { get; private set; } = new List<CaseFile>();

    [SerializeField]
    private CharacterID associatedCharacter;

    [SerializeField]
    private int fileNumber;

    [SerializeField]
    private bool isLocked;

    [Tooltip("If set, casefile will unlock when the linked file unlocks.")]
    [SerializeField]
    private CaseFile linkedCaseFileToUnlockWith;

    [SerializeField]
    [TextArea(3,10)]
    private string fileText;

    
    public string DisplayName => $"{associatedCharacter.ToString()} - File #{fileNumber}";
    public string FileText => fileText;

    public bool IsNew { get; set; } = true;

    public CharacterID AssociatedCharacter => associatedCharacter;

    public bool IsLocked
    {
        get
        {
            return isLocked;
        }

        set
        {
            if (value == !isLocked && isLocked)
            {
                isLocked = value;
                CaseFileUnlocked?.Invoke();
            }
            else
                isLocked = value;
        }
    }

    public bool UnlocksLinkedCaseFiles { get; private set; } = false;

    public void SetUnlocksLinkedCaseFiles()
    {
        UnlocksLinkedCaseFiles = true;
    }

    private void Awake()
    {
        AllCaseFiles.Add(this);
        if (linkedCaseFileToUnlockWith != null)
            linkedCaseFileToUnlockWith.SetUnlocksLinkedCaseFiles();
    }
    private void OnEnable()
    {
        if (linkedCaseFileToUnlockWith != null)
            CaseFileUnlocked += OnCaseFileUnlocked;
    }
    private void OnDisable()
    {
        if (linkedCaseFileToUnlockWith != null)
            CaseFileUnlocked -= OnCaseFileUnlocked;
    }
    private void OnCaseFileUnlocked()
    {
        if (linkedCaseFileToUnlockWith != null && !linkedCaseFileToUnlockWith.isLocked)
            IsLocked = false;            
    }
}
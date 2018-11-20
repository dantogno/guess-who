using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseFile : MonoBehaviour
{
    public static List<CaseFile> AllCaseFiles { get; private set; } = new List<CaseFile>();

    [SerializeField]
    private CharacterID associatedCharacter;

    [SerializeField]
    private int fileNumber;

    [SerializeField]
    private bool isUnlocked;

    [SerializeField]
    [TextArea(3,10)]
    private string fileText;

    public string DisplayName => $"{nameof(associatedCharacter)} - File #{fileNumber}";

    public bool IsNew { get; set; } = true;

    public CharacterID AssociatedCharacter => associatedCharacter;

    public bool IsUnlocked
    {
        get
        {
            return isUnlocked;
        }

        set
        {
            isUnlocked = value;
        }
    }

    private void Awake()
    {
        AllCaseFiles.Add(this);
    }
}
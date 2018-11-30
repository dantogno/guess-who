using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SuspectInterface : MonoBehaviour
{
    [SerializeField]
    private CharacterID guiltyParty;

    [SerializeField]
    private Image selectedSuspectPortraitImage, selectedSuspectPortraitHighlightImage;

    [SerializeField]
    private Text selectedSuspectNameText, selectedSuspectAgeText, selectedSuspectOccupationText, mainText, mainTextLabel,
        caseFileSelectedHeading, extendedSolvedMessageText, resultsHeaderText;

    [SerializeField]
    private GameObject caseFileButtonPrefab;

    [SerializeField]
    private Transform caseFileButtonParent;

    private SuspectSelectedBehaviour suspectSelectedBehaviour;
    private SuspectListBehaviour suspectListBehaviour;
    private CaseFileSelectedBehaviour caseFileSelectedBehaviour;
    private CaseSolvedBehaviour caseSolvedBehaviour;
    private int goToSuspectSelectedAnimTrigger = Animator.StringToHash(nameof(goToSuspectSelectedAnimTrigger));
    private int goToCaseFileSelectedAnimTrigger = Animator.StringToHash(nameof(goToCaseFileSelectedAnimTrigger));
    private int goToChargeSuspectAnimTrigger = Animator.StringToHash(nameof(goToChargeSuspectAnimTrigger));
    private int goToSuspectListAnimTrigger = Animator.StringToHash(nameof(goToSuspectListAnimTrigger));
    private int backAnimTrigger = Animator.StringToHash(nameof(backAnimTrigger));
    private int submitAnimTrigger = Animator.StringToHash(nameof(submitAnimTrigger));
    private Animator animator;
    private List<CaseFileEntryButton> caseFileButtons = new List<CaseFileEntryButton>();

    public static SuspectInterface Instance { get; private set; }

    public bool IsCaseSolvedCorrectly => guiltyParty == suspectSelectedBehaviour.SelectedCharacter.CharacterID;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        InitializeStateMachineBehaviours();
    }

    public void GoToSuspectSelectedState(Character selectedCharacter)
    {
        GenerateCaseFileButtons(selectedCharacter);
        suspectSelectedBehaviour.SelectedCharacter = selectedCharacter;
        animator.SetTrigger(goToSuspectSelectedAnimTrigger);
    }

    public void GoToSuspectListState()
    {
        animator.SetTrigger(goToSuspectListAnimTrigger);
    }

    public void GoToChargeSuspectState()
    {
        animator.SetTrigger(goToChargeSuspectAnimTrigger);
    }

    public void HandleSubmitButtonClicked()
    {
        animator.SetTrigger(submitAnimTrigger);
    }

    private void InitializeStateMachineBehaviours()
    {
        suspectSelectedBehaviour = animator.GetBehaviour<SuspectSelectedBehaviour>();
        suspectSelectedBehaviour.Initialize(selectedSuspectPortraitImage, selectedSuspectPortraitHighlightImage,
            selectedSuspectNameText, selectedSuspectAgeText, selectedSuspectOccupationText, mainTextLabel, mainText);
        suspectListBehaviour = animator.GetBehaviour<SuspectListBehaviour>();
        caseFileSelectedBehaviour = animator.GetBehaviour<CaseFileSelectedBehaviour>();
        caseFileSelectedBehaviour.Initialize(caseFileSelectedHeading, mainText);
        caseSolvedBehaviour = animator.GetBehaviour<CaseSolvedBehaviour>();
        caseSolvedBehaviour.Initialize(extendedSolvedMessageText, resultsHeaderText);
    }

    private void GenerateCaseFileButtons(Character selectedCharacter)
    {
        // TODO: use object pool
        // Consider moving to SuspectSelectedBehaviour
        var caseFiles = 
            CaseFile.AllCaseFiles.Where(caseFile => caseFile.AssociatedCharacter == selectedCharacter.CharacterID &&
            !caseFile.IsLocked).ToList();
        for (int i = 0; i < caseFiles.Count(); i++)
        {
            var button = Instantiate(caseFileButtonPrefab, caseFileButtonParent).GetComponent<CaseFileEntryButton>();
            button.SetCaseFile(caseFiles[i]);
            caseFileButtons.Add(button);
        }
    }

    public void UpdateCaseFileIsNewIcons()
    {
        // Consider moving to SuspectSelectedBehaviour
        foreach (var item in caseFileButtons)
        {
            item.UpdateNewIconDisplay();
        }
    }

    public void DestroyAllCaseFileButtons()
    {
        // TODO: object pool
        foreach (var item in caseFileButtons)
        {
            Destroy(item.gameObject);
        }
        caseFileButtons.Clear();
    }

    public void GoToCaseFileSelectedState(CaseFile selectedCaseFile)
    {
        caseFileSelectedBehaviour.UpdateCaseFileText(selectedCaseFile);
        animator.SetTrigger(goToCaseFileSelectedAnimTrigger);
    }

    public void GoBack()
    {
        animator.SetTrigger(backAnimTrigger);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SuspectInterface : MonoBehaviour
{
    [SerializeField]
    private Image selectedSuspectPortraitImage, selectedSuspectPortraitHighlightImage;

    [SerializeField]
    private Text selectedSuspectNameText, selectedSuspectAgeText, selectedSuspectOccupationText, mainText, mainTextLabel;

    [SerializeField]
    private GameObject caseFileButtonPrefab;

    [SerializeField]
    private Transform caseFileButtonParent;

    private SuspectSelectedBehaviour suspectSelectedBehaviour;
    private SuspectListBehaviour suspectListBehaviour;
    private int goToSuspectSelectedAnimTrigger = Animator.StringToHash(nameof(goToSuspectSelectedAnimTrigger));
    private int goToCaseFileSelectedAnimTrigger = Animator.StringToHash(nameof(goToCaseFileSelectedAnimTrigger));
    private int goToChargeSuspectAnimTrigger = Animator.StringToHash(nameof(goToChargeSuspectAnimTrigger));
    private int goToSuspectListAnimTrigger = Animator.StringToHash(nameof(goToSuspectListAnimTrigger));
    private int backAnimTrigger = Animator.StringToHash(nameof(backAnimTrigger));
    private const string bioLabelText = "BIO";
    private Animator animator;
    private List<CaseFileEntryButton> caseFileButtons = new List<CaseFileEntryButton>();

    public static SuspectInterface Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        InitializeStateMachineBehaviours();
    }

    public void GoToSuspectSelectedState(Character selectedCharacter)
    {
        GenerateCaseFileButtons(selectedCharacter);
        SetSelectedCharacterInfo(selectedCharacter);
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

    private void InitializeStateMachineBehaviours()
    {
        suspectSelectedBehaviour = animator.GetBehaviour<SuspectSelectedBehaviour>();
        suspectSelectedBehaviour.SuspectInterface = this;

        suspectListBehaviour = animator.GetBehaviour<SuspectListBehaviour>();
        suspectListBehaviour.SuspectInterface = this;
    }

    private void GenerateCaseFileButtons(Character selectedCharacter)
    {
        // TODO: use object pool
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

    private void SetSelectedCharacterInfo(Character selectedCharacter)
    {
        selectedSuspectPortraitImage.sprite = selectedCharacter.PortraitSprite;
        selectedSuspectPortraitHighlightImage.sprite = selectedCharacter.PortraitHighlightSprite;
        selectedSuspectNameText.text = selectedCharacter.CharacterName;
        selectedSuspectAgeText.text = selectedCharacter.Age;
        selectedSuspectOccupationText.text = selectedCharacter.Occupation;
        mainTextLabel.text = bioLabelText;
        mainText.text = selectedCharacter.Bio;
    }

    public void GoToCaseFileSelectedState(CaseFile selectedCaseFile)
    {
        // TODO: setup heading / text for selected case file
        animator.SetTrigger(goToCaseFileSelectedAnimTrigger);
    }

    public void GoBack()
    {
        animator.SetTrigger(backAnimTrigger);
    }
}

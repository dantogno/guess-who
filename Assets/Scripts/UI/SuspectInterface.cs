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
    private int goToSuspectSelectedAnimTrigger = Animator.StringToHash(nameof(goToSuspectSelectedAnimTrigger));
    private int goToCaseFileSelectedAnimTrigger = Animator.StringToHash(nameof(goToCaseFileSelectedAnimTrigger));
    private int backAnimTrigger = Animator.StringToHash(nameof(backAnimTrigger));
    private const string bioLabelText = "BIO";
    private Animator animator;
    private List<GameObject> caseFileButtons = new List<GameObject>();

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

    private void InitializeStateMachineBehaviours()
    {
        suspectSelectedBehaviour = animator.GetBehaviour<SuspectSelectedBehaviour>();
        suspectSelectedBehaviour.SuspectInterface = this;
    }

    private void GenerateCaseFileButtons(Character selectedCharacter)
    {
        var caseFiles = CaseFile.AllCaseFiles.Where(caseFile => caseFile.AssociatedCharacter == selectedCharacter.CharacterID).ToList();
        for (int i = 0; i < caseFiles.Count(); i++)
        {
            var button = Instantiate(caseFileButtonPrefab, caseFileButtonParent).GetComponent<CaseFileEntryButton>();
            button.SetCaseFile(caseFiles[i]);
            caseFileButtons.Add(button.gameObject);
        }
    }

    public void DestroyAllCaseFileButtons()
    {
        // TODO: I need to call this whenever I go back to the suspect list. Does that mean I need a state machine behaviour for that state?
        // Because I'm just calling back in here.
        // Maybe I could check the state of the animator and destroy the buttons when they hit back if their in a certain state?
        foreach (var item in caseFileButtons)
        {
            Destroy(item);
        }
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

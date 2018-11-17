using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspectInterface : MonoBehaviour
{
    [SerializeField]
    private Image selectedSuspectPortraitImage, selectedSuspectPortraitHighlightImage;

    [SerializeField]
    private Text selectedSuspectNameText, selectedSuspectAgeText, selectedSuspectOccupationText, mainText, mainTextLabel;

    private int goToSuspectSelectedAnimTrigger = Animator.StringToHash(nameof(goToSuspectSelectedAnimTrigger));
    private int goToCaseFileSelectedAnimTrigger = Animator.StringToHash(nameof(goToCaseFileSelectedAnimTrigger));
    private int backAnimTrigger = Animator.StringToHash(nameof(backAnimTrigger));
    private const string bioLabelText = "BIO";
    private Animator animator;

    public static SuspectInterface Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    public void GoToSuspectSelectedState(Character selectedCharacter)
    {
        SetSelectedCharacterInfo(selectedCharacter);
        animator.SetTrigger(goToSuspectSelectedAnimTrigger);
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

    public void GoToCaseFileSelectedState()
    {
        animator.SetTrigger(goToCaseFileSelectedAnimTrigger);
    }

    public void GoBack()
    {
        animator.SetTrigger(backAnimTrigger);
    }
}

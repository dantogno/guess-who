using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspectSelectedBehaviour : StateMachineBehaviour
{
    private const string bioLabelText = "BIO";
    private Character selectedCharacter;
    private Image selectedSuspectPortraitImage, selectedSuspectPortraitHighlightImage;
    private Text selectedSuspectNameText, selectedSuspectAgeText, selectedSuspectOccupationText,
        mainTextLabel, mainText;

    public Character SelectedCharacter
    {
        get
        {
            return selectedCharacter;
        }

        set
        {
            selectedCharacter = value;
        }
    }

    public void Initialize(Image selectedSuspectPortraitImage, Image selectedSuspectPortraitHighlightImage,  
        Text selectedSuspectNameText, Text selectedSuspectAgeText, Text selectedSuspectOccupationText,
        Text mainTextLabel, Text mainText)
    {
        this.selectedSuspectPortraitImage = selectedSuspectPortraitImage;
        this.selectedSuspectPortraitHighlightImage = selectedSuspectPortraitHighlightImage;
        this.selectedSuspectNameText = selectedSuspectNameText;
        this.selectedSuspectAgeText = selectedSuspectAgeText;
        this.selectedSuspectOccupationText = selectedSuspectOccupationText;
        this.mainTextLabel = mainTextLabel;
        this.mainText = mainText;
    }

    private void UpdateSelectedCharacterInfo()
    {
        selectedSuspectPortraitImage.sprite = selectedCharacter.PortraitSprite;
        selectedSuspectPortraitHighlightImage.sprite = selectedCharacter.PortraitHighlightSprite;
        selectedSuspectNameText.text = selectedCharacter.CharacterName;
        selectedSuspectAgeText.text = selectedCharacter.Age;
        selectedSuspectOccupationText.text = selectedCharacter.Occupation;
        mainTextLabel.text = bioLabelText;
        mainText.text = selectedCharacter.Bio;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        SuspectInterface.Instance.UpdateCaseFileIsNewIcons();
        UpdateSelectedCharacterInfo();
    }

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMachineEnter is called when entering a statemachine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
    //
    //}

    // OnStateMachineExit is called when exiting a statemachine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
    //
    //}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseSolvedBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private Color failedTextColor, correctColor;

    [TextArea(3, 5)]
    [SerializeField]
    private string correctExtendedMessageText, failedExtendedMessageText;

    private Text extendedMessage, resultsHeader;
    private const string failedHeaderText = "FAILED";
    private const string correctHeaderText = "SOLVED";

    public void Initialize(Text extendedSolvedMessageText, Text resultsHeaderText)
    {
        this.extendedMessage = extendedSolvedMessageText;
        this.resultsHeader = resultsHeaderText;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (SuspectInterface.Instance.IsCaseSolvedCorrectly)
            InitializeForCorrectSolution();
        else
            InitializeForWrongSolution();
    }

    private void InitializeForWrongSolution()
    {
        resultsHeader.color = failedTextColor;
        resultsHeader.text = failedHeaderText;
        extendedMessage.text = failedExtendedMessageText;
    }

    private void InitializeForCorrectSolution()
    {
        resultsHeader.color = correctColor;
        resultsHeader.text = correctHeaderText;
        extendedMessage.text = correctExtendedMessageText;
    }


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}

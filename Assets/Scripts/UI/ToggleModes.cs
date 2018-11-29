using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleModes : MonoBehaviour
{
    [SerializeField]
    private GameObject arCamera;

    [SerializeField]
    private CanvasGroup suspectInterfaceCanvasGroup, toggleModesCanvasGroup, scanningCanvasGroup;

    private bool isSuspectCharged;

    private void OnEnteredChargeSuspectState()
    {
        SetToggleModesCanvasGroupVisibility(false);
    }
    private void OnExitedChargeSuspectState()
    {
        SetToggleModesCanvasGroupVisibility(true);
    }
    private void OnEnable()
    {
        ChargeSuspectPopupBehaviour.EnteredChargeSuspectState += OnEnteredChargeSuspectState;
        ChargeSuspectPopupBehaviour.ExitedChargeSuspectState += OnExitedChargeSuspectState;
        ChargeSuspectMenu.SuspectCharged += OnSuspectCharged;
    }
    private void OnDisable()
    {
        ChargeSuspectPopupBehaviour.EnteredChargeSuspectState -= OnEnteredChargeSuspectState;
        ChargeSuspectPopupBehaviour.ExitedChargeSuspectState -= OnExitedChargeSuspectState;
        ChargeSuspectMenu.SuspectCharged -= OnSuspectCharged;
    }

    /// <summary>
    /// Always hides if suspect is charged.
    /// </summary>
    /// <param name="isVisible"></param>
    private void SetToggleModesCanvasGroupVisibility(bool isVisible)
    {
        bool shouldBeVisible = isSuspectCharged ? false : isVisible;
        toggleModesCanvasGroup.alpha = shouldBeVisible ? 1 : 0;
        toggleModesCanvasGroup.blocksRaycasts = shouldBeVisible;
        toggleModesCanvasGroup.interactable = shouldBeVisible;
    }

    /// <summary>
    /// Once a suspect has been charged, we want to hide this.
    /// </summary>
    private void OnSuspectCharged()
    {
        isSuspectCharged = true;
    }

    public void SuspectListToggled(bool isOn)
    {
        suspectInterfaceCanvasGroup.alpha = isOn ? 1 : 0;
        suspectInterfaceCanvasGroup.blocksRaycasts = isOn;
        suspectInterfaceCanvasGroup.interactable = isOn;
        arCamera.SetActive(!isOn);
        scanningCanvasGroup.alpha = isOn ? 0 : 1;
        if (isOn)
         SuspectInterface.Instance.GoToSuspectListState();
    }
}

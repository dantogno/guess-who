using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleModes : MonoBehaviour
{
    [SerializeField]
    private GameObject arCamera;

    [SerializeField]
    private CanvasGroup suspectInterfaceCanvasGroup, toggleModesCanvasGroup, scanningCanvasGroup;

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
    }
    private void OnDisable()
    {
        ChargeSuspectPopupBehaviour.EnteredChargeSuspectState -= OnEnteredChargeSuspectState;
        ChargeSuspectPopupBehaviour.ExitedChargeSuspectState -= OnExitedChargeSuspectState;
    }

    private void SetToggleModesCanvasGroupVisibility(bool isVisible)
    {
        toggleModesCanvasGroup.alpha = isVisible ? 1 : 0;
        toggleModesCanvasGroup.blocksRaycasts = isVisible;
        toggleModesCanvasGroup.interactable = isVisible;
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

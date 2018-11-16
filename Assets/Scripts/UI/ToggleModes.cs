using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleModes : MonoBehaviour
{
    [SerializeField]
    private GameObject suspectInterfacePanel, arCamera;

    public void SuspectListToggled(bool isOn)
    {
        suspectInterfacePanel.SetActive(isOn);
        arCamera.SetActive(!isOn);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleModes : MonoBehaviour
{
    [SerializeField]
    private GameObject suspectInterfacePanel;

    public void SuspectListToggled(bool isOn)
    {
        suspectInterfacePanel.SetActive(isOn);
    }
}

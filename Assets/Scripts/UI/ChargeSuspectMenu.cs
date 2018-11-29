using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSuspectMenu : MonoBehaviour
{
    public static event Action SuspectCharged;

    public void ChargeButtonClicked()
    {
        SuspectInterface.Instance.GoToChargeSuspectState();
    }

    public void SubmitButtonClicked()
    {
        SuspectInterface.Instance.HandleSubmitButtonClicked();
        SuspectCharged?.Invoke();
    }

    public void CancelButtonClicked()
    {
        SuspectInterface.Instance.GoBack();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSuspectMenu : MonoBehaviour
{
    public void ChargeButtonClicked()
    {
        SuspectInterface.Instance.GoToChargeSuspectState();
    }

    public void SubmitButtonClicked()
    {

    }

    public void CancelButtonClicked()
    {
        SuspectInterface.Instance.GoBack();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HamburgerMenu : MonoBehaviour
{
    public void RestartGame()
    {
        CaseFile.AllCaseFiles.Clear();
        SceneManager.LoadScene(0);
    }
    public void CancelButtonPressed()
    {
        SuspectInterface.Instance.GoBack();
    }

    public void HamburgerMenuButtonPressed()
    {
        SuspectInterface.Instance.GoToHamburgerMenu();
    }
}

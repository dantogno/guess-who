using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseFileEntryButton : MonoBehaviour
{
    [SerializeField]
    private GameObject newIcon;

    private Button button;

    private CaseFile caseFile;

    public void SetCaseFile(CaseFile caseFile)
    {
        this.caseFile = caseFile;
        UpdateNewIconDisplay();
    }

    public void UpdateNewIconDisplay()
    {
        newIcon.SetActive(caseFile.IsNew);
    }

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => CaseFileEntryButtonPressed());
    }
    private void CaseFileEntryButtonPressed()
    {
        caseFile.IsNew = false;
        SuspectInterface.Instance.GoToCaseFileSelectedState(caseFile);
    }
}

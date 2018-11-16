using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private List<string> attributeList;

    [SerializeField]
    private GameObject highlight;

    public List<string> AttributesList => attributeList;
    public GameObject Highlight => highlight;

    public void ClickedCharacter()
    {
        SuspectInterface.Instance.GoToSuspectSelectedState();
    }
}

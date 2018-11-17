using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField]
    private List<string> attributeList;

    [SerializeField]
    private GameObject highlight;

    [SerializeField]
    private Image portraitImage, portraitHighlightImage;

    public List<string> AttributesList => attributeList;
    public GameObject Highlight => highlight;
    public Sprite PortraitSprite => portraitImage.sprite;
    public Sprite PortraitHighlightSprite => portraitHighlightImage.sprite;

    public void ClickedCharacter()
    {
        SuspectInterface.Instance.GoToSuspectSelectedState(this);
    }
}

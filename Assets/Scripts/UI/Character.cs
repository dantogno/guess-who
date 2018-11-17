using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField]
    private string characterName = "Schmoe";

    [SerializeField]
    private string age = "??";

    [SerializeField]
    private string occupation = "Jobber";

    [SerializeField]
    [Multiline(5)]
    private string bio = "My life story.";

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
    public string CharacterName => characterName;
    public string Age => age;
    public string Occupation => occupation;
    public string Bio => bio;

    public void ClickedCharacter()
    {
        SuspectInterface.Instance.GoToSuspectSelectedState(this);
    }
}

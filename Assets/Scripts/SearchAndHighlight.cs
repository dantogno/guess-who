using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SearchAndHighlight : MonoBehaviour
{
    [SerializeField]
    private List<Character> allCharacters;

    [SerializeField]
    private InputField inputField;
    
    public void SubmitButtonClicked()
    {
        HighlightMatches(
           GetMatches(inputField.text));
    }

    public void SearchInputTextValueChanged(string inputText)
    {
       
    }

    private List<Character> GetMatches(string searchInput)
    {
        var matchingCharacters = new List<Character>();

        var keywords = searchInput.ToLower()
            .Split(' ');

        foreach (var character in allCharacters)
        {
            foreach (var item in character.AttributesList)
            {
                var attributeWords = item.ToLower().Split(' ');

                var match = attributeWords.Any(word => keywords.Contains(word));

                if (match)
                {
                    matchingCharacters.Add(character);
                }
            }
        }
        
        return matchingCharacters;
    }

    private void HighlightMatches(List<Character> matchingCharacters)
    {
        foreach (var item in matchingCharacters)
        {
            item.Highlight.SetActive(true);
        }
    }

    private void RemoveAllHighlights()
    {
        foreach (var item in allCharacters)
        {
            item.Highlight.SetActive(false);    
        }
    }
}

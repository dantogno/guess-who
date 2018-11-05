﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SearchAndHighlight : MonoBehaviour
{
    [SerializeField]
    private List<Character> allCharacters;
    
    public void SubmitButtonClicked()
    {
        
    }

    public void SearchInputTextValueChanged(string inputText)
    {
       HighlightMatches(
           GetMatches(inputText));
    }

    private List<Character> GetMatches(string searchInput)
    {
        var matchingCharacters = new List<Character>();

        var keywords = searchInput.ToLower()
            .Split(' ');

        foreach (var character in allCharacters)
        {
            
        }
        
        return new List<Character>();
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

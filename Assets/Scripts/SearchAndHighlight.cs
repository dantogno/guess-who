﻿using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SearchAndHighlight : MonoBehaviour
{
    [SerializeField]
    private List<Character> allCharacters;

    [SerializeField]
    private InputField inputField;

    private void Start()
    {
        //string testString = "foxes";
        //string testsubstring = "fox";
        //Debug.Log(testString.Contains(testsubstring));
        // output: true
    }

    public void SubmitButtonClicked()
    {
        //HighlightCharacters(
        //   GetMatchingCharacters(inputField.text));

        GetMatchingCharacters( GetSearchKeywords(inputField.text));
    }

    public void EndedEditingInputText(string input)
    {
        RemoveAllHighlights();
        HighlightCharacters(GetMatchingCharacters(GetSearchKeywords(input)));
    }


    private List<Character> GetMatchingCharacters(IEnumerable<string> keywords)
    {
        var matchingCharacters = new List<Character>();

        foreach (var character in allCharacters)
        {
            foreach (var entry in character.AttributesList)
            {
                var entryWords = entry.ToLower().Split(' ');

                foreach (var word in entryWords)
                {
                    if (keywords.Contains(word))
                    {
                        Debug.Log(word);
                        matchingCharacters.Add(character);
                    }
                }
            }
        }
        
        return matchingCharacters;
    }

    /// <summary>
    /// Turns user input string into list of keywords, including plural forms.
    /// </summary>
    /// <param name="searchInput">User input from form.</param>
    /// <returns>IEnumerable of singular and plural form of all search terms.</returns>
    private IEnumerable<string> GetSearchKeywords(string searchInput)
    {
        var pluralizationService = PluralizationService.CreateService(CultureInfo.CurrentCulture);
        var keywords = searchInput.ToLower().Split(' ');
        var singularsAndPlurals = new List<string>();

        foreach (var word in keywords)
        {
            singularsAndPlurals.Add(pluralizationService.Pluralize(word));
            singularsAndPlurals.Add(pluralizationService.Singularize(word));
        }

        return keywords.Union(singularsAndPlurals);
    }

    private void HighlightCharacters(List<Character> matchingCharacters)
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

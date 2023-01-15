using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerationController : MonoBehaviour
{
    ToggleObject[] toggleObjects;
    [SerializeField] TMP_Text inputText;
    
    void Awake() 
    {
    
        toggleObjects = GetComponents<ToggleObject>();
        
    }
    public void SubmitText() 
    {
        string phrase = inputText.text;
        foreach (ToggleObject toggleObject in toggleObjects)
        {
            toggleObject.ToggleIfStringMatches(phrase);
        }
    }

    public void SubmitText(string phrase) 
    {
        foreach (ToggleObject toggleObject in toggleObjects)
        {
            toggleObject.ToggleIfStringMatches(phrase);
        }
    }
}
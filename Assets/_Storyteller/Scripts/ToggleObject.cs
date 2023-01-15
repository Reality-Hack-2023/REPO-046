using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject toggleObject;

    float moveRange = 5; //the domain within which the object will be randomly positioned 

    public List<string> words = new();
 
    void Start() 
    {
        toggleObject?.SetActive(false);
    }

    void MoveToRandomPosition() 
    {
        Vector2 rand = Random.insideUnitCircle * moveRange;
        transform.position = new Vector3 (rand.x, 0, rand.y);
    }

    public void ToggleIfStringMatches(string phrase)
    {
        string lowercasePhrase = phrase.ToLower();

        foreach (string word in words)
        {
            
            if (lowercasePhrase.Contains(word.ToLower()))
            {
               
                toggleObject.SetActive(true);

                return;
            }
          


        }

        
        toggleObject.SetActive(false);
    }

}

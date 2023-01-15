using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Controller : MonoBehaviour
{
    public string phrase;

    public List<ToggleObject> toggleObjects = new();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckPhrase(phrase);
        }
    }

    void CheckPhrase(string phrase)
    {
        foreach (ToggleObject toggleObject in toggleObjects)
        {
            toggleObject.ToggleIfStringMatches(phrase);
        }
    }
}

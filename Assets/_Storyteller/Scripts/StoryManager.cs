using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StoryManager : MonoBehaviour
{
    GenerationController generationController;
    public TextAsset storyFile;
    public TMP_Text storyLine;
    public List<TimedLines> timedLineData = new();
    void Awake() 
    {
        generationController = GetComponentInParent<GenerationController>();
    }
    // Start is called before the first frame update

    void Start()
    {
        if (timedLineData.Count == 0) 
        {
            string[] lines = storyFile.text.Split('\n');
            for (int i = 1; i < lines.Length; i++) 
            {
                timedLineData.Add(new TimedLines(lines[i]));
            }
            StartStory();
        }
        else 
        {
            StartStory();
        }
    }

    // void OnEnable() {
    //     if (timedLineData.Count > 0)
    //     {
    //         StartStory();
    //     }
    // }
    void StartStory() 
    {
        Debug.Log("StartStory");
        StartCoroutine(StartStoryCoroutine());
    }

    IEnumerator StartStoryCoroutine()
    {
        foreach (TimedLines line in timedLineData) 
        {
            yield return StartCoroutine(StartStoryObject(line));
        }
    }

    IEnumerator StartStoryObject(TimedLines timedLine)
    {
        generationController.SubmitText(timedLine.line);
        storyLine.text = timedLine.line;
        yield return new WaitForSeconds(timedLine.waitTime);
    }

}
[System.Serializable]
public class TimedLines 
{
    public float waitTime = 3;
    public string line = "";

    public TimedLines(string _line)
    {
        line = _line;
    }

    public TimedLines (float _waitTime, string _line) 
    {
        waitTime = _waitTime;
        line = _line;
    }
}


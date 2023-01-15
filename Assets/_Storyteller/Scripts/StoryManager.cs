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
            for (int i = 0; i < lines.Length; i++) 
            {
            timedLineData.Add(new TimedLines(i, lines[i]));
            }
        }
    }

    void OnEnable() {
        if (timedLineData.Count > 0)
        {
            StartStory();
        }
    }
    void StartStory() 
    {
        foreach (TimedLines line in timedLineData) 
        {
            StartCoroutine(StartStoryObject(line));
        }
    }
    IEnumerator StartStoryObject(TimedLines timedLine)
    {
        yield return new WaitForSeconds(timedLine.waitTime);
        generationController.SubmitText(timedLine.line);
        storyLine.text = timedLine.line;
    }

}
[System.Serializable]
public class TimedLines 
{
    public float waitTime = 0;
    public string line = "";

    public TimedLines (float _waitTime, string _line) 
    {
        waitTime = _waitTime;
        line = _line;
    }
}


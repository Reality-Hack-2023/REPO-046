using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using TMPro;

public class PythonCommunicator : MonoBehaviour
{

    [SerializeField] TMP_Text inputText;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("http://127.0.0.1:5000/"));
        Debug.Log("got input text" + inputText);
    }


    

    //string inputPrompt = "For this game, add 10 trees, 2 castles, a dragon. After that, the dragon attacks the player. If the dragon dies, then the princess appears and the princess will follow player. Then, the princess kisses the player";
    IEnumerator GetRequest(string url){
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url+"?q="+  inputText))
        {
            yield return webRequest.SendWebRequest();
            Debug.Log("Result: " +  webRequest.result);
            if(webRequest.result == UnityWebRequest.Result.ConnectionError){
                Debug.Log("Error: " + webRequest.error);

            } else {
                Debug.Log(webRequest.downloadHandler.text);
                JObject response = JObject.Parse(webRequest.downloadHandler.text);
                Debug.Log("Jobject");
                Debug.Log(response);
                JArray arr = (JArray)response["message"];
                //Debug.Log("Arr: "+arr);
                int count = 0;
                foreach (var item in arr) {
                    Debug.Log("count: " + count);
                    print(item);
                    if (item["add"] != null) {
                        ParseAdd((JObject)item["add"]);
                        
                    } else if (item["action"] != null) {
                        
                        ParseAction((JObject)item["action"]);
                    } else if (item["if"] != null) {
                        //ParseIf((JObject)item["if"], (JObject)item["then"]);
                        ParseIf((JObject)item["if"]);
                    }
                    //print(item);
                    count++;
                }
                // Debug.Log(response["message"]);






            }
        }
    }

    void ParseAdd(JObject obj) {
        print($"ADD:" + obj);

        foreach (var item in obj)
        {
            string assetName = item.Key;
            JToken numOfAsset = item.Value;
            Debug.Log(assetName + " -> " + numOfAsset);
        }

    }

    void ParseAction(JObject obj) {
        print("ACTION: " + obj);
        JToken noun = obj["noun"][0];
        JToken verb = obj["verb"][0];

        Debug.Log("noun: "+ noun);
        Debug.Log("verb: " + verb);
    }

    //void ParseIf(JObject objIf, JObject objThen) {
    void ParseIf(JObject obj)
    {
        
        print("IF: " + obj);

        JToken nounIf = obj["noun"][0];
        JToken verbIf = obj["verb"][0];

        Debug.Log("noun: " + nounIf);
        Debug.Log("verb: " + verbIf);

        JToken objThen = obj["then"];
        Debug.Log("then: "+ objThen);

        foreach (var item in objThen)
        {
            JToken nounThen = item["noun"][0];
            JToken verbThen = item["verb"][0];

            Debug.Log("noun: " + nounThen);
            Debug.Log("verb: " + verbThen);
        }
        //(JObject)item["then"]
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private TTSManager ttsManager;
    private string apiUrl = "https://us-central1-meta-nyc-hackathon.cloudfunctions.net/api";
    private List<string> user = new List<string>();
    private List<string> ai = new List<string>();
    private string input = "";

    //public EnemiesManager conversation;

    public TextMeshProUGUI monitorText;

    // Method to call the API
    IEnumerator CallAPI()
    {   
        //user.Add(textMeshProUGUI.text);
        input += "customer service representative: " + textMeshProUGUI.text + ", ";
        input += "you: ";

        monitorText.text += "you: " + textMeshProUGUI.text + "\n";
        //conversation.AddEnemy("you", textMeshProUGUI.text);

        string contextEnglish = "Act like a client that needs help cooking ratatouille, talking to a customer service representative. You have no knowledge of how to cook ratatouille, below is our conversation so far, only give me one sentence response, do not start with the character name in your response";
        string contextFrench = "Agissez comme un client qui a besoin d'aide pour cuisiner une ratatouille et parlez à un représentant du service client. Vous ne savez pas comment cuisiner la ratatouille, voici notre conversation jusqu'à présent, donnez-moi seulement une réponse en une phrase, ne commencez pas par le nom du personnage dans votre réponse";
        string jsonBody = "{ \"input\": \"" + input + "\", \"context\": \"" + contextFrench + "\"}";
        
        using (UnityWebRequest www = UnityWebRequest.Post(apiUrl+"/llm_api", jsonBody, "application/json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("ERROR!!!!: " + www.error);
                //user.RemoveAt(user.Count-1);
            }
            else
            {   
                user.Add(textMeshProUGUI.text);
                Debug.LogWarning("Response: " + www.downloadHandler.text);
                textMeshProUGUI.text = www.downloadHandler.text;
                ttsManager.SynthesizeAndPlay(textMeshProUGUI.text, TTSModel.TTS_1, TTSVoice.Alloy, 1f);
                ai.Add(textMeshProUGUI.text);   
                monitorText.text += "customer: " + www.downloadHandler.text + "\n";
                //conversation.AddEnemy("customer", www.downloadHandler.text);

                input = "";
                for(int i = 0; i < user.Count; i ++){

                    input += "customer service representative: " + user[i] + ", ";
                    input += "you: " + ai[i] + ", ";
                }
            }
        }
    }

    public void StartAPICall()
    {
        StartCoroutine(CallAPI());
    }


}

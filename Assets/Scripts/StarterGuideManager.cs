using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterGuideManager : MonoBehaviour
{
    [SerializeField] private TTSManager ttsManager;

    private string[] french = { "Bonjour, comment allez-vous?", "Bonjour, comment puis-je vous aider?", "Bonjour, ça va"};

     public void OnSpeakButtonPress(int id){
        ttsManager.SynthesizeAndPlay(french[id], TTSModel.TTS_1, TTSVoice.Onyx, 1f);
    }
}

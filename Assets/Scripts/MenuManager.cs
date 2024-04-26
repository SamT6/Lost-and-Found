using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject sidePanel;
    public TextMeshProUGUI frenchText;
    public TextMeshProUGUI englishText;
    [SerializeField] private TTSManager ttsManager;
    private string[] french = { "2 Aubergines", "2 Poivrons", "4 Courgettes", "2 Cuilleres a soupe d’huile d’olive", "2 Brins de thym", "2 Oignons", "6 Tomates", "3 Gousses d’ail", "Sel et poivre", "Lavez et coupez en rondelles des tomates, des courgettes, des aubergines et des poivrons.", "Epluchez l’oignon et les gousses d’ail, et coupez-les en cubes.", "Dans une poêle, faites chauffer de l'huile d'olive à feu moyen.", "Ajoutez les rondelles de légumes, les oignons, et l’ail dans la poêle, en les superposant légèrement.", "Assaisonnez avec du sel, du poivre, et le thym.", "Laissez cuire à feu moyen pendant environ 15-20 minutes, en retournant les rondelles à mi-cuisson.", "Une fois les légumes tendres, servez chaud."};
    private string [] english = {"2 Eggplants", "3 Bell peppers", "4 Zucchinis", "2 Tablespoons of olive oil", "2 Sprigs of thyme", "2 Onions", "6 Tomatoes", "3 Cloves of garlic", "Salt and pepper", "Wash and slice tomatoes, zucchinis, eggplants, and bell peppers into rounds.", "Peel the onion and cloves of garlic, and chop them into cubes.", "In a skillet, heat olive oil over medium heat.", "Add the vegetable slices, onions, and garlic to the skillet, slightly overlapping them.", "Season with salt, pepper, and thyme.", "Cook over medium heat for about 15-20 minutes, flipping the rounds halfway through.", "Once the vegetables are tender, serve hot."}; 
    private int currentid = 0;

    public void ToggleSidePanel(int id){
        if(id == currentid){
            if(sidePanel.activeSelf){
                sidePanel.SetActive(false);
            }
            else{
                sidePanel.SetActive(true);
                frenchText.text = french[id];
                englishText.text = english[id];
                currentid = id;
            }
        }
        else{
            sidePanel.SetActive(true);
            frenchText.text = french[id];
            englishText.text = english[id];
            currentid = id;
        }
    }

    public void OnSpeakButtonPress(){
        ttsManager.SynthesizeAndPlay(french[currentid], TTSModel.TTS_1, TTSVoice.Onyx, 1f);
    }
}

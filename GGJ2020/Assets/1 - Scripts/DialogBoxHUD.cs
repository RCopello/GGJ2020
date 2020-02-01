using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class DialogBoxHUD : MonoBehaviour
{ 
    public TMP_Text name;

    public TMP_Text dialogPrefab;
    public Button choicePrefab;

    private TMP_Text dialog;
    private List<Button> buttons = new List<Button>();

    public void displayName(string name)
    {
        this.name.text = name;
    }

    public void displayText(string text)
    {
        dialog = Instantiate(dialogPrefab);
        
        this.dialog.text = text;
    }

    public void displayChoices(List<Choice> choices)
    {
        for (int i = 0; i < choices.Count; i++)
        {
            buttons.Add(Instantiate(choicePrefab));
            buttons[i].GetComponentInChildren<Text>().text = choices[i].text;
        }
    }

    
}

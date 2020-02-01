using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class InkController : MonoBehaviour
{
    public TextAsset inkJSON;

    private Story story;
    private DialogBoxHUD HUD;


    // Start is called before the first frame update
    void Start()
    {
        // Pega referencia da HUD
        HUD = this.GetComponent<DialogBoxHUD>();

        // Pega os trechos de texto do Ink
        story = new Story(inkJSON.text);
        displayInDialogBox("Fulano", loadStoryChunk());

        if (story.currentChoices.Count > 0)
        {
            displayInDialogBox(story.currentChoices);
        }

        displayInDialogBox("Fulano", loadStoryChunk());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Carrega os textos do Ink
    private string loadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }

        return text;
    }

    // aplica o texto e escolhas na HUD
    private void displayInDialogBox(string name, string text)
    {
        HUD.displayName(name);
        HUD.displayText(text);
    }

    private void displayInDialogBox(List<Choice> choices)
    {
        HUD.displayChoices(choices);
    }
}

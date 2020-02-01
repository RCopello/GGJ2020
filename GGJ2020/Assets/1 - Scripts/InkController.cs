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

        loadStoryChunk();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            HUD.refreshDialogBox();
            loadStoryChunk();
        }
    }



    // Carrega os dialogos do Ink
    private void loadStoryChunk()
    {
        if (story.currentChoices.Count > 0)
        {
            displayInDialogBox(story.currentChoices);
        } else
        {
            displayInDialogBox("Fulano", loadStoryText());
        }   
    }

    // Carrega os textos da historia
    private string loadStoryText()
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

    // Funcoes atreladas ao botao de escolha

    // When we click the choice button, tell the story to choose that choice!
    public void OnClickChoiceButton(Choice choice)
    {
        HUD.refreshDialogBox();
        story.ChooseChoiceIndex(choice.index);
        loadStoryChunk();
    }
}

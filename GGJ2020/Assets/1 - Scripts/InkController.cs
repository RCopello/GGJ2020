using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class InkController : MonoBehaviour
{
    public TextAsset inkJSON;

    private Story story;
    private DialogBoxHUD HUD;

<<<<<<< HEAD
=======
    // Nao permite que o jogo troque as falas sem que a escolha seja feita
    private bool isChoosing = false;
>>>>>>> 9901068ea0da0c853571598bbfb15ae8f8892898

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
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.Return))
=======
        if (Input.GetKeyDown(KeyCode.Return) && !isChoosing)
>>>>>>> 9901068ea0da0c853571598bbfb15ae8f8892898
        {
            HUD.refreshDialogBox();
            loadStoryChunk();
        }
    }

<<<<<<< HEAD


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
=======
    // Carrega os dialogos do Ink
    private void loadStoryChunk()
    {

        if (story.currentChoices.Count > 0)
        {
            isChoosing = true;
            displayInDialogBox(story.currentChoices);
        } else
        {
            string text = loadStoryText();

            List<string> tags = story.currentTags;
            string name = checkNameTag(tags);

            if (name != null)
            {
                displayInDialogBox(name, text);
            } else
            {
                displayInDialogBox(text);
            }

        }  
>>>>>>> 9901068ea0da0c853571598bbfb15ae8f8892898
    }

    // Carrega os textos da historia
    private string loadStoryText()
    {
        string text = "";

        if (story.canContinue)
        {
<<<<<<< HEAD
            text = story.ContinueMaximally();
=======
            text = story.Continue();
>>>>>>> 9901068ea0da0c853571598bbfb15ae8f8892898
        }

        return text;
    }

    // aplica o texto e escolhas na HUD
    private void displayInDialogBox(string name, string text)
    {
        HUD.displayName(name);
        HUD.displayText(text);
    }

<<<<<<< HEAD
=======
    private void displayInDialogBox(string text)
    {
        HUD.displayText(text);
    }

>>>>>>> 9901068ea0da0c853571598bbfb15ae8f8892898
    private void displayInDialogBox(List<Choice> choices)
    {
        HUD.displayChoices(choices);
    }

    // Funcoes atreladas ao botao de escolha

    // When we click the choice button, tell the story to choose that choice!
    public void OnClickChoiceButton(Choice choice)
    {
<<<<<<< HEAD
        HUD.refreshDialogBox();
        story.ChooseChoiceIndex(choice.index);
        loadStoryChunk();
    }
=======
        story.ChooseChoiceIndex(choice.index);
        isChoosing = false;
        HUD.refreshDialogBox();
        loadStoryChunk();
    }

    // Funcao para checar as tags
    private string checkNameTag(List<string> tags)
    {
        foreach (string tag in tags)
        {
            if (tag.StartsWith("NAME"))
            {
                return tag.TrimStart("NAME_".ToCharArray());
            }
        }

        return null;
    }

>>>>>>> 9901068ea0da0c853571598bbfb15ae8f8892898
}

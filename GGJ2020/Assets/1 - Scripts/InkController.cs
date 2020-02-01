using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class InkController : MonoBehaviour
{
    #region

    private static InkController instance;

    public static InkController Instance { get { return instance; } }

    private void Awake(){
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    #endregion

    public TextAsset inkJSON;

    private Story story;
    private DialogBoxHUD HUD;

    // Nao permite que o jogo troque as falas sem que a escolha seja feita
    private bool isChoosing = false;

    // Nao permite que se começa um dialogo com o mesmo NPC quando a conversa já começou
    private bool startedDialog = false;

    // Start is called before the first frame update
    void Start()
    {
        // Pega referencia da HUD
        HUD = this.GetComponent<DialogBoxHUD>(); 
    }

    public void InitiateDialog(TextAsset textStory)
    {
        // Pega os trechos de texto do Ink
        story = new Story(textStory.text);

        loadStoryChunk();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && !isChoosing)
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
    }

    // Carrega os textos da historia
    private string loadStoryText()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.Continue();
        }

        return text;
    }

    // aplica o texto e escolhas na HUD
    private void displayInDialogBox(string name, string text)
    {
        HUD.displayName(name);
        HUD.displayText(text);
    }

    private void displayInDialogBox(string text)
    {
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
                return tag.Remove(0, 5);
            }
        }

        return null;
    }

}

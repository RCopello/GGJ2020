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

    private bool breakDialog;

    public GameObject Player;

    public TextAsset inkJSON;

    private Story story;
    private DialogBoxHUD HUD;

    // Nao permite que o jogo troque as falas sem que a escolha seja feita
    private bool isChoosing = false;

    // Nao permite que se começa um dialogo com o mesmo NPC quando a conversa já começou
    private bool startedDialog = false;

    public TextAsset inkInitializationScript;
    private string InkState;

    // Start is called before the first frame update
    void Start()
    {
        // Pega referencia da HUD
        HUD = this.GetComponent<DialogBoxHUD>();

        //InitiateDialog(inkJSON);
        breakDialog = false;

        var story2 = new Story(inkInitializationScript.text);
        InkState = story2.state.ToJson();
    }

    public void InitiateDialog(TextAsset textStory)
    {
        if (!startedDialog)
        {
            startedDialog = true;
            Player.GetComponent<PlayerMovement>().canMove = false;

            // Pega os trechos de texto do Ink
            story = new Story(textStory.text);
            story.state.LoadJson(InkState);

            loadStoryChunk();    
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isChoosing && startedDialog)
        {
            HUD.refreshDialogBox();
            loadStoryChunk();
        }
    }

    // Carrega os dialogos do Ink
    private void loadStoryChunk()
    {
        List<string> tags = story.currentTags;
        checkEventTags(tags); //trata tags do tipo CLEARED (tem efeito colateral no ProgressSystem!)

        if ((story.canContinue || story.currentChoices.Count > 0) && !breakDialog)
        {
            
            if (story.currentChoices.Count > 0)
            {
                isChoosing = true;
                displayInDialogBox(story.currentChoices);
            }
            else
            {
                string text = loadStoryText();
                string name = checkNameTag(tags);

                if (name != null)
                {
                    displayInDialogBox(name, text);
                }
                else
                {
                    displayInDialogBox(text);
                }
            }

        } else {
            EndDialog();
        }

    }

    private void EndDialog() {

        startedDialog = false;
        breakDialog = false;

        //salva estado
        InkState = story.state.ToJson();

        Player.GetComponent<PlayerMovement>().canMove = true;
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

        return "";
    }

    private void checkEventTags(List<string> tags)
    {
        foreach (string tag in tags)
        {
            if (tag.StartsWith("CLEARED"))
            {
                //Debug.Log(tag.Substring(8));
                ProgressionSystem.Instance.MarkAsCleared(tag.Substring(8));
            }
            if (tag.StartsWith("END_DIALOGUE"))
            {
                breakDialog = true;
            }
            if (tag.StartsWith("GRAB"))
            {
                ProgressionSystem.Instance.MarkObjectAsAcquired(tag.Remove(0, 5));
            }
            if (tag.StartsWith("GIVE"))
            {
                ProgressionSystem.Instance.MarkObjectAsRetrieved(tag.Remove(0, 5));
            }

        }

        return;
    }

}

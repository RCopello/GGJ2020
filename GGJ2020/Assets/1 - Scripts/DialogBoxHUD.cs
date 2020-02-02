using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class DialogBoxHUD : MonoBehaviour
{ 

    public TMP_Text namePrefab;
    public TMP_Text dialogPrefab;
    public Button choicePrefab;

    private TMP_Text name;
    private TMP_Text dialog;
    private List<Button> buttons = new List<Button>();


    // Delegate
    delegate void MyDelegate();

    UnityEngine.Events.UnityAction GetChoiceIndex(int i, List<Choice> choices)
    {
        return delegate {

            InkController inkControl = this.GetComponent<InkController>();

            Debug.Log(i);
            inkControl.OnClickChoiceButton(choices[i]);
        };
    }

    // Mostra as informações do trexo de texto na HUD
    public void displayName(string name)
    {
        this.name = Instantiate(namePrefab, InkController.Instance.ArteCaixa.transform);

        this.name.text = name;
    }

    public void displayText(string text)
    {
        dialog = Instantiate(dialogPrefab, InkController.Instance.ArteCaixa.transform);
        
        this.dialog.text = text;
    }

    public void displayChoices(List<Choice> choices)
    {
        for (int i = 0; i < choices.Count; i++)
        {
            buttons.Add(Instantiate(choicePrefab, InkController.Instance.ArteCaixa.transform));
            buttons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = choices[i].text;
            buttons[i].onClick.AddListener(GetChoiceIndex(i,choices));
        }
    }

    // Limpa as informações para um novo trecho de código
    public void refreshDialogBox()
    {
        if (name)
            Destroy(name.gameObject);

        if (dialog)
            Destroy(dialog.gameObject);

        foreach(Button button in buttons)
        {
            Destroy(button.gameObject);
        }
        buttons.Clear();
    }

    
}

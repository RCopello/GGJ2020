using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class DialogBoxHUD : MonoBehaviour
{ 
<<<<<<< HEAD
    public TMP_Text name;

    public TMP_Text dialogPrefab;
    public Button choicePrefab;

=======
    public TMP_Text namePrefab;
    public TMP_Text dialogPrefab;
    public Button choicePrefab;

    private TMP_Text name;
>>>>>>> 9901068ea0da0c853571598bbfb15ae8f8892898
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
<<<<<<< HEAD
=======
        this.name = Instantiate(namePrefab, this.transform);

>>>>>>> 9901068ea0da0c853571598bbfb15ae8f8892898
        this.name.text = name;
    }

    public void displayText(string text)
    {
        dialog = Instantiate(dialogPrefab, this.transform);
        
        this.dialog.text = text;
    }

    public void displayChoices(List<Choice> choices)
    {
        for (int i = 0; i < choices.Count; i++)
        {
            buttons.Add(Instantiate(choicePrefab, this.transform));
            buttons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = choices[i].text;

<<<<<<< HEAD


=======
>>>>>>> 9901068ea0da0c853571598bbfb15ae8f8892898
            buttons[i].onClick.AddListener(GetChoiceIndex(i,choices));
        }
    }

    // Limpa as informações para um novo trecho de código
    public void refreshDialogBox()
    {
<<<<<<< HEAD
=======
        if (name)
            Destroy(name.gameObject);

>>>>>>> 9901068ea0da0c853571598bbfb15ae8f8892898
        if (dialog)
            Destroy(dialog.gameObject);

        foreach(Button button in buttons)
        {
            Destroy(button.gameObject);
        }
    }

    
}

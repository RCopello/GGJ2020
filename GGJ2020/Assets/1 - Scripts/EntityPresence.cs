using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPresence : MonoBehaviour
{
    public TextAsset NPCDialog;

    public bool isObject = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        checkIfOnTrigger(collision);
    }

    // fazo  trigger do NPC
    private void checkIfOnTrigger(Collider2D collision)
    {
        //Debug.Log("check trigger");
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("keycode E");
            if (collision.CompareTag("Player"))
            {
                // Trigga o dialogo
                Debug.Log("call initiate dialog");
                InkController.Instance.InitiateDialog(NPCDialog);
                if(isObject)
                    Destroy(this.gameObject);

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPresence : MonoBehaviour
{
    public TextAsset NPCDialog;

    private void OnTriggerStay2D(Collider2D collision)
    {
        checkIfOnTrigger(collision);
    }

    // fazo  trigger do NPC
    private void checkIfOnTrigger(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.CompareTag("Player"))
            {
                // Trigga o dialogo
                InkController.Instance.InitiateDialog(NPCDialog);

            }
        }
    }
}

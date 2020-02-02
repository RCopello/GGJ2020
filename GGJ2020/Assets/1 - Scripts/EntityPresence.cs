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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.CompareTag("Player"))
            {
                // Trigga o dialogo
                InkController.Instance.InitiateDialog(NPCDialog);
                if(isObject)
                    Destroy(this.gameObject);

            }
        }
    }
}

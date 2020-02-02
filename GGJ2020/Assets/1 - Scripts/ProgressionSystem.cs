using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//um sisteminha pra lembrar de quais acertos o player fez durante o jogo
public class ProgressionSystem : MonoBehaviour
{
    
    public static ProgressionSystem Instance{get; private set;}

    //singleton
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            GameObject.Destroy(this);
        }
    }

    public List<string> objects_names;
    private Dictionary<string, bool> objects_acquired;
    private Dictionary<string, bool> objects_retrived;

    public List<string> char_names;
    private Dictionary<string, bool> chars_cleared;
    // Start is called before the first frame update
    void Start()
    {
        chars_cleared = new Dictionary<string, bool>();
        foreach(string name in char_names)
        {
            chars_cleared[name] = false;
        }

        objects_acquired = new Dictionary<string, bool>();
        objects_retrived = new Dictionary<string, bool>();
        foreach (string name in objects_names)
        {
            objects_acquired[name] = false;
            objects_retrived[name] = false;
        }
    }

    public void MarkAsCleared(string char_name)
    {
        if(chars_cleared.ContainsKey(char_name))
        {
            chars_cleared[char_name] = true;
        }
        else
        {
            Debug.LogWarning("INVALID CHARACTER NAME \"" + char_name + "\" passed to mark as cleared. Please check for typos.");
        }
    }

    public void MarkObjectAsAcquired(string objects_names)
    {
        Debug.Log(objects_names);
        if (objects_acquired.ContainsKey(objects_names))
        {
            objects_acquired[objects_names] = true;
            Inventory.Instance.UpdateInventory();
        }
        else
        {
            Debug.LogWarning("INVALID CHARACTER NAME \"" + objects_names + "\" passed to mark as cleared. Please check for typos.");
        }
    }

    public void MarkObjectAsRetrieved(string objects_names)
    {
        if (objects_retrived.ContainsKey(objects_names))
        {
            objects_retrived[objects_names] = true;
            Inventory.Instance.UpdateInventory();
        }
        else
        {
            Debug.LogWarning("INVALID CHARACTER NAME \"" + objects_names + "\" passed to mark as cleared. Please check for typos.");
        }
    }

    public bool IsObjectInInventory(string object_name)
    {
        return objects_acquired.ContainsKey(object_name) && objects_acquired[object_name] && (!objects_retrived.ContainsKey(object_name) || !objects_retrived[object_name]);
    }

}

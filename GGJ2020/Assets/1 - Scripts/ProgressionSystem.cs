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

    // Update is called once per frame
    void Update()
    {
        
    }
}

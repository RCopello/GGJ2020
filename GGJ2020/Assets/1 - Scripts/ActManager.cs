using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActManager : MonoBehaviour
{
    public GameObject Player;

    public static ActManager Instance { get; private set;}
    private List<GameObject> acts;

    public bool canGoToNextAct = false;

    private int currentAct;
    [Tooltip("Setar aqui o ato inicial pra poder testar! Indexado em 0! Não avacalhem!")]
    public int initialAct = 0;
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
    
    // Start is called before the first frame update
    void Start()
    {
        acts = new List<GameObject>();
        foreach (Transform t in transform)
        {
            //Debug.Log(t);
            acts.Add(t.gameObject);
        }

        //se não estou em "modo debug", somente o primeiro ato fica acionado
        if(acts.Count > 0)
        {
            foreach(GameObject go in acts)
            {
                go.SetActive(false);
            }
            acts[initialAct].SetActive(true);
        }
    }

    public void NextAct()
    {
        if (canGoToNextAct)
        {
            if (currentAct < acts.Count - 1)
            {
                acts[currentAct].SetActive(false);
                acts[currentAct + 1].SetActive(true);
                currentAct++;
                Player.GetComponent<PlayerMovement>().ReturnToOriginalPos();
                canGoToNextAct = false;
            }
        }  
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.E))
        {
            NextAct();
        }*/
    }
}

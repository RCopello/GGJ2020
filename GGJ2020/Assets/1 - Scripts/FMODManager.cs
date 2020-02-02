using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;



public class FMODManager : MonoBehaviour
{
    
    #region

    private static FMODManager instance;
    public static FMODManager Instance { get { return instance; } }

    public List<GameObject> triggers;




    void Start () {
        //soundscape = GameObject.Find("Music").GetComponent<FMOD.Studio.StudioEventEmmiter>();
    }


    private void Awake(){
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(this);
        }
    }

    #endregion

    public void SetMusicParameter(int i)
    {
        if(i >=0 && i < triggers.Count)
        {
            triggers[i].SetActive(true);
            triggers[i].SetActive(false);
        }
    }

    public void PlaySound(string soundname)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

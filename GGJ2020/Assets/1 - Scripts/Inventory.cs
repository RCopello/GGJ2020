using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region

    private static Inventory instance;
    public static Inventory Instance { get { return instance; } }

    private void Awake(){
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    #endregion

    private bool lateInitialized;
    List<GameObject> inventoryObjects;
    // Start is called before the first frame update
    void Start()
    {
        inventoryObjects = new List<GameObject>();
        foreach(Transform t in transform)
        {
            inventoryObjects.Add(t.gameObject);
        }
        lateInitialized = false;
    }

    public void UpdateInventory()
    {
        for(int i = 0; i < inventoryObjects.Count; i++)
        {
            var obj = inventoryObjects[i];
            //Debug.Log(obj);
            obj.SetActive(ProgressionSystem.Instance.IsObjectInInventory(obj.name));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!lateInitialized) 
        {
            UpdateInventory();
            lateInitialized = true;
        }
    }
}

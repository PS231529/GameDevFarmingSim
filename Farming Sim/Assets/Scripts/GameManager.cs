using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public ItemContainer inventoryContainer;
<<<<<<< HEAD
    
=======
    public DragAndDropController dragAndDropController;
    public ItemSpawnManager itemSpawnManager;

>>>>>>> 68ce711156c77c5e4079bafe7da9516b84c5282d
}

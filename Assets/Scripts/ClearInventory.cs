using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearInventory : MonoBehaviour
{

    public RoomLogic roomLogic;
    private void Start()
    {
        roomLogic = GameObject.Find("RoomLogic").GetComponent<RoomLogic>();
        roomLogic.ClearInventory();
    }
}
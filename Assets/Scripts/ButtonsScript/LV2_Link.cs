using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2_Link : MonoBehaviour {

    public void OnStartGame()
    {
        Debug.Log("You pressed start game!");
        Application.LoadLevel("LV2");
    }
}

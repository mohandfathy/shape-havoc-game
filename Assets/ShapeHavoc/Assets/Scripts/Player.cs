using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject[] playerPanels;

    Vector3 pos = new Vector3(-7f, 0, 0);

    [HideInInspector]
    public bool gameIsOver = false;
    [HideInInspector]
    public int ammoCount = 0;


    public void AddPlayerPanel(int index)       //Spawner script calls this function
    {
            if (FindObjectOfType<Spawner>().spawnedObstacles != 0)      //If this is not the first spawn
                Destroy(GameObject.FindGameObjectWithTag("PlayerPanel").gameObject, 0.45f);     //Then destroys the previously spawned playerPanel
            Instantiate(playerPanels[index], transform.position, Quaternion.identity);      //Spawns a new one       
    }
}

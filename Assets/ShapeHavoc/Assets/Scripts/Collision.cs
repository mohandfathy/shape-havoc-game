using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public GameObject[] destroyedParticle;

    /*
        int tapCount = Input.touchCount;
        for (int j = 0; j < tapCount; j++)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    
                }
            }
        }
*/

    void OnMouseDown()      //If the object has been clicked
    {
        if ((FindObjectOfType<Player>().ammoCount > 0) && (!FindObjectOfType<Player>().gameIsOver))     //If the player has ammo and the game is not over yet
        {
            for (int i = 0; i < destroyedParticle.Length; i++)
            {
                if (PlayerPrefs.GetInt("ParticleColor", 0) == i)
                {
                    FindObjectOfType<AudioManager>().HavocSound();      //Sound effect plays
                    Destroy(Instantiate(destroyedParticle[i], transform.position, Quaternion.identity), 1f);       //Instantiates a particle and destroys it after x seconds
                    Destroy(gameObject);        //Destroys the cube which has been clicked
                    FindObjectOfType<Player>().ammoCount--;     //Reduces ammo
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))       //If gameobject collides with an obstacle, then game is over
        {
            //Game over functions
            FindObjectOfType<AudioManager>().DeathSound();
            FindObjectOfType<ScoreManager>().IncrementToken();
            Destroy(Instantiate(destroyedParticle[0], transform.position, Quaternion.identity), 1f);
            Destroy(other, 1);
            GetComponent<Animation>().Play("CubeDeathAnim");
            FindObjectOfType<Player>().gameIsOver = true;
            FindObjectOfType<GameManager>().EndPanelActivation();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animation>().Play("CameraDeathAnim");
        }
    }
}

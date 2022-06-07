using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public TextMeshProUGUI scoreText, tokenText;
    private Animation scoreTextAnim, tokenTextAnim, cameraAnim;

    [HideInInspector]
    public int score = 0;

    void Start()
    {
        cameraAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animation>();     //Initializes cameraAnim
        scoreTextAnim = scoreText.gameObject.GetComponent<Animation>();     //Initializes socreTextAnim
        tokenTextAnim = tokenText.gameObject.GetComponent<Animation>();     //Initializes tokenTextAnim
        tokenText.text = PlayerPrefs.GetInt("tokenText", 0).ToString();     //Writes out the number of tokens to the screen
    }

    public void IncrementScore()
    {
        if (FindObjectOfType<Player>().gameIsOver == false)       //If the game is not over
            scoreText.text = (++score).ToString();      //Increments the 'scoretext' text as well as the score variable's value and writes it out to the screen
        scoreTextAnim.Play();        //Plays the animation attached to the scoreText
    }

    public void IncrementToken()
    {
        if (FindObjectOfType<Player>().gameIsOver == false)
            PlayerPrefs.SetInt("tokenText", PlayerPrefs.GetInt("tokenText", 0) + Random.Range(0, 2));        //Increases the number of tokens
        if (FindObjectOfType<Player>().gameIsOver == true)       //If the game is not over
        {
            tokenText.text = PlayerPrefs.GetInt("tokenText", 0).ToString();     //Writes out the number of tokens to the screen
            tokenTextAnim.Play();       //Plays tokenTextAnim
            //FindObjectOfType<AudioManager>().TokenSound();      //Plays tokenSou
        }
    }

    public void IncrementToken(int countOfToken)
    {
        if (FindObjectOfType<Player>().gameIsOver == false)       //If the game is not over
        {
            PlayerPrefs.SetInt("tokenText", PlayerPrefs.GetInt("tokenText", 0) + countOfToken);        //Increases the number of tokens
            tokenText.text = PlayerPrefs.GetInt("tokenText", 0).ToString();     //Writes out the number of tokens to the screen
            tokenTextAnim.Play();       //Plays tokenTextAnim
            //FindObjectOfType<AudioManager>().TokenSound();      //Plays tokenSound
        }
    }

    public void DecrementToken(int decreaseValue)
    {
        PlayerPrefs.SetInt("tokenText", PlayerPrefs.GetInt("tokenText", 0) - decreaseValue);        //Decreases the number of tokens by decreaseValue
        tokenText.text = PlayerPrefs.GetInt("tokenText", 0).ToString();     //Writes out the number of tokens to the screen
    }
}

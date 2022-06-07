using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkinsPlayerManager : MonoBehaviour
{
    public GameObject[] skinsPlayer1, skinsPlayer2, skinsPlayer3, skinsPlayer4, skinsPlayer5, skinsPlayer6, lockedSkinImages, Used;
    public int[] requiredTokensToUnlock;
    public TextMeshProUGUI[] requiredTokenTexts;
    public GameObject notEnoughTokensText;

    private ArrayList skinsPlayer = new ArrayList();

    void Start()
    {
        skinsPlayer.Add(skinsPlayer1);
        skinsPlayer.Add(skinsPlayer2);
        skinsPlayer.Add(skinsPlayer3);
        skinsPlayer.Add(skinsPlayer4);
        skinsPlayer.Add(skinsPlayer5);
        skinsPlayer.Add(skinsPlayer6);
        PlayerPrefs.SetInt("Skin1UnlockedP", 1);     //The first skin is unlocked
        SkinCheck();
        InitializeRequiredTokensTexts();
    }

    public void InitializeRequiredTokensTexts()
    {
        for (int i = 0; i < requiredTokenTexts.Length; i++)     //Loops through the requiedTokenTexts list and sets the texts identical to the requied count of tokens
            requiredTokenTexts[i].text = requiredTokensToUnlock[i].ToString();
    }

    public void SkinCheck()
    {
        for (int i = 0; i < lockedSkinImages.Length; i++)       //Loops through the lockedSkinImages list
        {
            if (PlayerPrefs.GetInt("Skin" + (i + 1).ToString() + "UnlockedP", 0) == 1)     //Checks if the list's element is unlocked yet
                lockedSkinImages[i].SetActive(false);       //If it is unlocked, then the lockedImage is disabled
            Used[i].SetActive(false);
            if(PlayerPrefs.GetInt("SkinUsedP", 0) == i)
                Used[i].SetActive(true);
        }

        if (PlayerPrefs.GetInt("SkinP", 0) == 0)
        {
            FindObjectOfType<Player>().playerPanels = (GameObject[])skinsPlayer[0];
            PlayerPrefs.SetInt("ParticleColor", 0);
        }
        else if (PlayerPrefs.GetInt("SkinP", 0) == 1)
        {
            FindObjectOfType<Player>().playerPanels = (GameObject[])skinsPlayer[1];
            PlayerPrefs.SetInt("ParticleColor", 1);
        }
        else if (PlayerPrefs.GetInt("SkinP", 0) == 2)
        {
            FindObjectOfType<Player>().playerPanels = (GameObject[])skinsPlayer[2];
            PlayerPrefs.SetInt("ParticleColor", 2);
        }
        else if (PlayerPrefs.GetInt("SkinP", 0) == 3)
        {
            FindObjectOfType<Player>().playerPanels = (GameObject[])skinsPlayer[3];
            PlayerPrefs.SetInt("ParticleColor", 3);
        }
        else if (PlayerPrefs.GetInt("SkinP", 0) == 4)
        {
            FindObjectOfType<Player>().playerPanels = (GameObject[])skinsPlayer[4];
            PlayerPrefs.SetInt("ParticleColor", 4);
        }
        else if (PlayerPrefs.GetInt("SkinP", 0) == 5)
        {
            FindObjectOfType<Player>().playerPanels = (GameObject[])skinsPlayer[5];
            PlayerPrefs.SetInt("ParticleColor", 5);
        }

    }

    public void Skin1()
    {
        if (PlayerPrefs.GetInt("Skin1UnlockedP", 0) == 0)        //If the skin is not unlocked yet
        {
            if (PlayerPrefs.GetInt("tokenText", 0) < requiredTokensToUnlock[0])       //If the skin cannot be unlocked
            {
                notEnoughTokensText.GetComponent<Animation>().Play();       //Plays the animation of notEnoughTokensText
                                                                            //FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
            }
            else    //If the skin can be unlocked
            {
                PlayerPrefs.SetInt("Skin1UnlockedP", 1);     //Unlocks skin
                FindObjectOfType<ScoreManager>().DecrementToken(requiredTokensToUnlock[0]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                PlayerPrefs.SetInt("SkinP", 0);
                PlayerPrefs.SetInt("SkinUsedP", 0);
                SkinCheck();        //Enables the selected skin
                                    //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
        else    //If the skin is unlocked
        {
            PlayerPrefs.SetInt("SkinP", 0);
            PlayerPrefs.SetInt("SkinUsedP", 0);
            SkinCheck();        //Enables the selected skin
                                //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
        }
    }

    public void Skin2()
    {
        if (PlayerPrefs.GetInt("Skin2UnlockedP", 0) == 0)        //If the skin is not unlocked yet
        {
            if (PlayerPrefs.GetInt("tokenText", 0) < requiredTokensToUnlock[1])       //If the skin cannot be unlocked
            {
                notEnoughTokensText.GetComponent<Animation>().Play();       //Plays the animation of notEnoughTokensText
                                                                            //FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
            }
            else    //If the skin can be unlocked
            {
                PlayerPrefs.SetInt("Skin2UnlockedP", 1);     //Unlocks skin
                FindObjectOfType<ScoreManager>().DecrementToken(requiredTokensToUnlock[1]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                PlayerPrefs.SetInt("SkinP", 1);
                PlayerPrefs.SetInt("SkinUsedP", 1);
                SkinCheck();        //Enables the selected skin
                                    //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
        else    //If the skin is unlocked
        {
            PlayerPrefs.SetInt("SkinP", 1);
            PlayerPrefs.SetInt("SkinUsedP", 1);
            SkinCheck();        //Enables the selected skin
                                //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
        }
    }

    public void Skin3()
    {
        if (PlayerPrefs.GetInt("Skin3UnlockedP", 0) == 0)        //If the skin is not unlocked yet
        {
            if (PlayerPrefs.GetInt("tokenText", 0) < requiredTokensToUnlock[2])       //If the skin cannot be unlocked
            {
                notEnoughTokensText.GetComponent<Animation>().Play();       //Plays the animation of notEnoughTokensText
                                                                            //FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
            }
            else    //If the skin can be unlocked
            {
                PlayerPrefs.SetInt("Skin3UnlockedP", 1);     //Unlocks skin
                FindObjectOfType<ScoreManager>().DecrementToken(requiredTokensToUnlock[2]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                PlayerPrefs.SetInt("SkinP", 2);
                PlayerPrefs.SetInt("SkinUsedP", 2);
                SkinCheck();        //Enables the selected skin
                                    //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
        else    //If the skin is unlocked
        {
            PlayerPrefs.SetInt("SkinP", 2);
            PlayerPrefs.SetInt("SkinUsedP", 2);
            SkinCheck();        //Enables the selected skin
                                //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
        }
    }

    public void Skin4()
    {
        if (PlayerPrefs.GetInt("Skin4UnlockedP", 0) == 0)        //If the skin is not unlocked yet
        {
            if (PlayerPrefs.GetInt("tokenText", 0) < requiredTokensToUnlock[3])       //If the skin cannot be unlocked
            {
                notEnoughTokensText.GetComponent<Animation>().Play();       //Plays the animation of notEnoughTokensText
                                                                            //FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
            }
            else    //If the skin can be unlocked
            {
                PlayerPrefs.SetInt("Skin4UnlockedP", 1);     //Unlocks skin
                FindObjectOfType<ScoreManager>().DecrementToken(requiredTokensToUnlock[3]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                PlayerPrefs.SetInt("SkinP", 3);
                PlayerPrefs.SetInt("SkinUsedP", 3);
                SkinCheck();        //Enables the selected skin
                                    //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
        else    //If the skin is unlocked
        {
            PlayerPrefs.SetInt("SkinP", 3);
            PlayerPrefs.SetInt("SkinUsedP", 3);
            SkinCheck();        //Enables the selected skin
                                //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
        }
    }

    public void Skin5()
    {
        if (PlayerPrefs.GetInt("Skin5UnlockedP", 0) == 0)        //If the skin is not unlocked yet
        {
            if (PlayerPrefs.GetInt("tokenText", 0) < requiredTokensToUnlock[4])       //If the skin cannot be unlocked
            {
                notEnoughTokensText.GetComponent<Animation>().Play();       //Plays the animation of notEnoughTokensText
                                                                            //FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
            }
            else    //If the skin can be unlocked
            {
                PlayerPrefs.SetInt("Skin5UnlockedP", 1);     //Unlocks skin
                FindObjectOfType<ScoreManager>().DecrementToken(requiredTokensToUnlock[4]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                PlayerPrefs.SetInt("SkinP", 4);
                PlayerPrefs.SetInt("SkinUsedP", 4);
                SkinCheck();        //Enables the selected skin
                                    //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
        else    //If the skin is unlocked
        {
            PlayerPrefs.SetInt("SkinP", 4);
            PlayerPrefs.SetInt("SkinUsedP", 4);
            SkinCheck();        //Enables the selected skin
                                //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
        }
    }

    public void Skin6()
    {
        if (PlayerPrefs.GetInt("Skin6UnlockedP", 0) == 0)        //If the skin is not unlocked yet
        {
            if (PlayerPrefs.GetInt("tokenText", 0) < requiredTokensToUnlock[5])       //If the skin cannot be unlocked
            {
                notEnoughTokensText.GetComponent<Animation>().Play();       //Plays the animation of notEnoughTokensText
                                                                            //FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
            }
            else    //If the skin can be unlocked
            {
                PlayerPrefs.SetInt("Skin6UnlockedP", 1);     //Unlocks skin
                FindObjectOfType<ScoreManager>().DecrementToken(requiredTokensToUnlock[5]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                PlayerPrefs.SetInt("SkinP", 5);
                PlayerPrefs.SetInt("SkinUsedP", 5);
                SkinCheck();        //Enables the selected skin
                                    //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
        else    //If the skin is unlocked
        {
            PlayerPrefs.SetInt("SkinP", 5);
            PlayerPrefs.SetInt("SkinUsedP", 5);
            SkinCheck();        //Enables the selected skin
                                //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
        }
    }
}

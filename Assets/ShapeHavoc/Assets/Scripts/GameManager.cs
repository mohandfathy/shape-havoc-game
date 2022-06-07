using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //----------------------------------------------
    //Thank you for purchasing the asset! If you have any questions/suggestions, don't hesitate to contact me!
    //E-mail: ragendom@gmail.com
    //Please let me know your impressions about the asset by leaving a review, I will appreciate it.
    //----------------------------------------------
    public Material[] materials;
    public Texture cube;
    public GameObject startPanel, endPanel, SkinPanel, muteImage, scoreText, FirstBage, SecondBage, reviveButton, ModeButton, Easy, Hard;
    public TextMeshProUGUI highScoreText, endScoreText, endHighScoreText;

	void Start () {
        //UNCOMMENT THE FOLLOWING LINES IF YOU ENABLED UNITY ADS AT UNITY SERVICES AND REOPENED THE PROJECT!
        //if (FindObjectOfType<AdManager>().unityAds)
        //    CallUnityAds();     //Calls Unity Ads
        //else
        CallAdmobAds();     //Calls Admob Ads
        
        PlayerPrefs.SetInt("MultiPlayer",0);
        StartPanelActivation();
        HighScoreCheck();
        AudioCheck();
	}

    //UNCOMMENT THE FOLLOWING LINES IF YOU ENABLED UNITY ADS AT UNITY SERVICES AND REOPENED THE PROJECT!
    //public void CallUnityAds()
    //{
    //    if (Time.time != Time.timeSinceLevelLoad)
    //        FindObjectOfType<AdManager>().ShowUnityVideoAd();      //Shows Interstitial Ad when game starts (except for the first time)
    //    FindObjectOfType<AdManager>().HideAdmobBanner();
    //}

    public void CallAdmobAds()
    {
        FindObjectOfType<AdManager>().ShowAdmobBanner();        //Shows Banner Ad when game starts
        if (Time.time != Time.timeSinceLevelLoad)
            FindObjectOfType<AdManager>().ShowAdmobInterstitial();      //Shows Interstitial Ad when game starts (except for the first time)
    }

    public void Initialize()
    {
        FindObjectOfType<Spawner>().enabled = false;
        scoreText.SetActive(false);
    }

    public void StartPanelActivation()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        SkinPanel.SetActive(false);
    }

    public void EndPanelActivation()
    {
        startPanel.SetActive(false);
        endPanel.SetActive(true);
        scoreText.SetActive(false);
        endScoreText.text = scoreText.GetComponent<TextMeshProUGUI>().text;
        HighScoreCheck();
    }

    public void SkinsPanelActivation()
    {
        startPanel.SetActive(false);
        SkinPanel.SetActive(true);
    }

    public void SkinBackButton()
    {
        if (FirstBage.active == true) 
            StartPanelActivation();
        else
        {
            FirstBage.SetActive(true);
            SecondBage.SetActive(false);
        }
    }

    public void SkinNextButton()
    {
        FirstBage.SetActive(false);
        SecondBage.SetActive(true);
    }

    public void HighScoreCheck()
    {
        if (FindObjectOfType<ScoreManager>().score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", FindObjectOfType<ScoreManager>().score);
        }
        highScoreText.text = "BEST " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        endHighScoreText.text = "BEST " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void AudioCheck()
    {
        if (PlayerPrefs.GetInt("Audio", 0) == 0)
        {
            muteImage.SetActive(false);
            FindObjectOfType<AudioManager>().soundIsOn = true;
            FindObjectOfType<AudioManager>().PlayBackgroundMusic();
        }
        else
        {
            muteImage.SetActive(true);
            FindObjectOfType<AudioManager>().soundIsOn = false;
            FindObjectOfType<AudioManager>().StopBackgroundMusic();
        }
    }

    public void StartButton()
    {
        FindObjectOfType<Spawner>().enabled = true;
        scoreText.SetActive(true);
        startPanel.SetActive(false);
    }

    public void FirstButton()
    {
        FindObjectOfType<Spawner>().enabled = true;
        scoreText.SetActive(true);
        startPanel.SetActive(false);
        startPanel.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Revive()
    {
        //UNCOMMENT THE FOLLOWING LINES IF YOU ENABLED UNITY ADS AT UNITY SERVICES AND REOPENED THE PROJECT!
        //if (FindObjectOfType<AdManager>().unityAds)
        //    FindObjectOfType<AdManager>().ShowUnityRewardVideoAd();       //Shows Unity Reward Video ad
        //else
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            FindObjectOfType<AdManager>().ShowAdmobRewardVideo();       //Shows Admob Reward Video ad

            FindObjectOfType<Player>().gameIsOver = false;

            endPanel.SetActive(false);
            reviveButton.SetActive(false);
            scoreText.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("PlayerPanel").gameObject, 0.45f);
        }
    }

    public void ModeB()
    {
        if(Easy.active == true && Hard.active == true)
        {
            Easy.SetActive(false);
            Hard.SetActive(false);
        }
        else
        {
            Easy.SetActive(true);
            Hard.SetActive(true);
        }
    }

    public void EasyButton()
    {
        for(int i = 0; i < materials.Length; i++)
        {
            materials[i].mainTexture = cube;
        }
        Easy.SetActive(false);
        Hard.SetActive(false);
    }

    public void HardButton()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].mainTexture = null;
        }
        Easy.SetActive(false);
        Hard.SetActive(false);
    }

    public void AudioButton()
    {
        if (PlayerPrefs.GetInt("Audio", 0) == 0)
            PlayerPrefs.SetInt("Audio", 1);
        else
            PlayerPrefs.SetInt("Audio", 0);
        AudioCheck();
    }
}

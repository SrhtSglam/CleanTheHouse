using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public GameObject[] panelList;
    public TextMeshProUGUI statsText;
    public AudioSource source;
    public Slider volumeSlider;

    private void panelClose(){
        for (int i = 0; i < panelList.Count(); i++){
            panelList[i].SetActive(false);
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        if(PlayerPrefs.HasKey("TimeValue") == false){
            PlayerPrefs.SetInt("TimeValue", 0);
            PlayerPrefs.Save();
        }

        panelClose();
        panelList[0].SetActive(true);
        
        int timeCount = PlayerPrefs.GetInt("TimeValue");
        statsText.text = "Best Finish Time: " + timeCount.ToString();

        source.volume = 0.25f;
    }

    public void NewGame_OnClick(){
        SceneManager.LoadScene(1);
    }

    public void Back_OnClick(){
        panelClose();
        panelList[0].SetActive(true);
    }

    public void Stats_OnClick(){
        panelClose();
        panelList[1].SetActive(true);
    }

    public void Settings_OnClick(){
        panelClose();
        panelList[2].SetActive(true);
    }

    public void Information_OnClick(){
        panelClose();
        panelList[3].SetActive(true);
    }

    public void Exit_OnClick(){
        Application.Quit();
    }

    public void Apply_OnClick(){
        volumeSlider.value = volumeSlider.value;
        volumeSlider.value = source.volume;

        panelClose();
        panelList[0].SetActive(true);
    }
}

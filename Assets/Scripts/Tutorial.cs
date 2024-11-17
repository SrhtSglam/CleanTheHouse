using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject tutorialPanel;

    void Start()
    {
        tutorialPanel.SetActive(false);
        PlayerPrefs.SetInt("IsTutorial", 1);
        PlayerPrefs.Save();
        // int IsTutorial = PlayerPrefs.GetInt("IsTutorial");
        // if(IsTutorial == 1){
        //     tutorialPanel.SetActive(false);
        // }
        // else{
        //     tutorialPanel.SetActive(true);
            
        //     Cursor.visible = true;
        //     Cursor.lockState = CursorLockMode.None;
        // }
    }

    // public void ComplateTutorial_OnClick(){
    //     tutorialPanel.SetActive(false);
    //     PlayerPrefs.SetInt("IsTutorial", 1);
    //     PlayerPrefs.Save();
    //     Cursor.lockState = CursorLockMode.Locked;
    //     Cursor.visible = false;
    // }
}

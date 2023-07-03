using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class GameplaySettings : MonoBehaviour
{

    //Gameplay Settings
    [SerializeField] private TMP_Text ControllerTextValue = null;
    [SerializeField] private Slider controllerSenSlider = null;
    public int mainControllerSen = 4;

    //toggle Settings
    [SerializeField] private Toggle invertYToggle = null;

    public void SetControllorSen(float sensitiviyy)
    {
        mainControllerSen = Mathf.RoundToInt(sensitiviyy);
        ControllerTextValue.text = sensitiviyy.ToString("0");
    }

    public void GameplayApply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
            //invert y
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
            //not invert 
        }

        PlayerPrefs.SetFloat("masterSen", mainControllerSen);
        
    }
}

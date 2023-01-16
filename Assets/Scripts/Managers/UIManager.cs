using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    [Header("Texts")]
    public TextMeshProUGUI FromLevelText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ToLevelText;
    public TextMeshProUGUI InformationText;
    public TextMeshProUGUI LevelText;

    [Header("Images")]
    public Image progressImage;

    public RectTransform fader;

    

    


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void UpgradeLevelText()
    {
        LevelText.text = "Level " + (PlayerPrefs.GetInt("RealLevel") + 1).ToString();
    }

    public void UpdateLevelToText()
    {
        FromLevelText.text = (PlayerPrefs.GetInt("RealLevel") + 1).ToString();
        ToLevelText.text = (PlayerPrefs.GetInt("RealLevel") + 2).ToString();
    }

    public void UpgradeScoreText()
    {
        DOVirtual.Float(0f, ScoreManager.Instance.score, .5f,OnValueUpdate);
        //ScoreText.text=ScoreManager.Instance.score.ToString();
    }

    private void OnValueUpdate(float v)
    {
        ScoreText.text = Mathf.Floor(v).ToString();
    }

    public void UpdateProgressBar(float value)
    {
        progressImage.DOFillAmount(value,0.5f);
    }

    public void UpdateInformation()
    {
        InformationText.text=FindObjectOfType<LevelInformation>().LevelInformationText.ToString();
    }
    
}

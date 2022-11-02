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
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ToLevelText;

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
        LevelText.text = (PlayerPrefs.GetInt("RealLevel") + 1).ToString();
        ToLevelText.text = (PlayerPrefs.GetInt("RealLevel") + 2).ToString();
    }

    public void UpgradeScoreText()
    {
        //DOTween.To(() => score, x => score = x, score+increaseScore, 5f);
        ScoreText.text=ScoreManager.Instance.score.ToString();
    }

    public void UpdateProgressBar(float value)
    {
        progressImage.DOFillAmount(value,0.5f);
    }

    public void StartFader()
    {
        fader.gameObject.SetActive(true);

        fader.DOScale(new Vector3(3,3,3),1).OnComplete(()=>{
            fader.DOScale(Vector3.zero,1f).OnComplete(()=>fader.gameObject.SetActive(false));
        });
    }
}

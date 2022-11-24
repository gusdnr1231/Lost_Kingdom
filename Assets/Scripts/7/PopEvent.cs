using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class PopEvent : MonoBehaviour
{
    public RectTransform upperBlock;
    public RectTransform underBlock;
    public RectTransform optionsPanel;
    public GameObject optionPanel;
    public GameObject optionButtonPanel;
    public RectTransform optionButtonPanelRect;

    public float duration = 0.2f;

    private Sequence seq;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DoPopUp();
        }
    }

    //15 -15 85 -85 
    public void DoPopDown()
    {
        seq = DOTween.Sequence();

        seq.Append(upperBlock.DOLocalMoveY(15f, duration).SetEase(Ease.InCubic));
        seq.Join(underBlock.DOLocalMoveY(-15f, duration).SetEase(Ease.InCubic));
        seq.Join(optionsPanel.DOScaleY(0, duration).SetEase(Ease.InCubic));
        seq.AppendCallback(() => {
            optionPanel.SetActive(false);
            seq.Kill();
        });
    }
    public void DoPopUp()
    {
        seq = DOTween.Sequence();

        optionPanel.SetActive(true);
        seq.Append(upperBlock.DOLocalMoveY(85f, duration).SetEase(Ease.InCubic));
        seq.Join(underBlock.DOLocalMoveY(-85f, duration).SetEase(Ease.InCubic));
        seq.Join(optionsPanel.DOScaleY(1, duration).SetEase(Ease.InCubic));
        seq.AppendCallback(() => {
            seq.Kill();
        });
    }

    public void DoOptionPopUp()
    {
        seq = DOTween.Sequence();

        seq.Append(upperBlock.DOLocalMoveY(15f, duration).SetEase(Ease.InCubic));
        seq.Join(underBlock.DOLocalMoveY(-15f, duration).SetEase(Ease.InCubic));
        seq.Join(optionsPanel.DOScaleY(0, duration).SetEase(Ease.InCubic));
        

        optionButtonPanel.SetActive(true);
        seq.Append(upperBlock.DOLocalMoveY(85f, duration).SetEase(Ease.InCubic));
        seq.Join(underBlock.DOLocalMoveY(-130f, duration).SetEase(Ease.InCubic));
        seq.Join(optionButtonPanelRect.DOScaleY(1, duration).SetEase(Ease.InCubic));
        seq.AppendCallback(() =>
        {
            seq.Kill();
        });
    }

    public void DoOptionPopDown()
    {
        seq = DOTween.Sequence();

        seq.Append(upperBlock.DOLocalMoveY(15f, duration).SetEase(Ease.InCubic));
        seq.Join(underBlock.DOLocalMoveY(-15f, duration).SetEase(Ease.InCubic));
        seq.Join(optionButtonPanelRect.DOScaleY(0, duration).SetEase(Ease.InCubic));

        seq.Append(upperBlock.DOLocalMoveY(85f, duration).SetEase(Ease.InCubic));
        seq.Join(underBlock.DOLocalMoveY(-85f, duration).SetEase(Ease.InCubic));
        seq.Join(optionsPanel.DOScaleY(1, duration).SetEase(Ease.InCubic));
        seq.AppendCallback(() =>
        {
            seq.Kill();
        });
    }

    public void QuitToManu()
    {
        SceneManager.LoadScene("Intro");
    }
}

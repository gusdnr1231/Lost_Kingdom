using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class PopEvent : MonoBehaviour
{
    [Header("可记")]
    public RectTransform upperBlock;
    public RectTransform underBlock;
    public RectTransform optionsPanel;
    public GameObject optionPanel;
    public GameObject optionButtonPanel;
    public RectTransform optionButtonPanelRect;
    public RectTransform textRect;
    [Header("牢亥配府")]
    public GameObject inventoryPanel;
    public bool isPopUpTheInventoryPanel = false;
    [Header("NPC UI")]
    public RectTransform npcUpperBlock;
    public RectTransform npcUnderBlock;
    public RectTransform rectNPCPanel;
    public GameObject npcPanel;
    public TextMeshProUGUI npcText;
    [Header("盔家 裙垫")]
    public RectTransform elementUI;
    public TextMeshProUGUI elementText;
    public GameObject elementPanel;

    bool lif;


    SliderController sliderController;

    public float duration = 0.2f;

    //private Sequence sequence;

    private void Awake()
    {
        sliderController = FindObjectOfType<SliderController>();
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

        if (!isPopUpTheInventoryPanel && Input.GetKeyDown(KeyCode.E))
        {
            OnInventoryPanel();
            isPopUpTheInventoryPanel = true;
        }
        else if(isPopUpTheInventoryPanel && Input.GetKeyDown(KeyCode.E))
        {
            OffInventoryPanel();
            isPopUpTheInventoryPanel = false;
        }
    }

    //15 -15 85 -85 
    public void DoPopDown()
    {
        Sequence seq = DOTween.Sequence();

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
        Sequence seq = DOTween.Sequence();

        optionPanel.SetActive(true);
        seq.Append(upperBlock.DOLocalMoveY(250f, duration).SetEase(Ease.InCubic));
        seq.Join(underBlock.DOLocalMoveY(-250f, duration).SetEase(Ease.InCubic));
        seq.Join(optionsPanel.DOScaleY(1, duration).SetEase(Ease.InCubic));
        seq.AppendCallback(() => {
            seq.Kill();
        });
    }

    public void DoOptionPopUp()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(upperBlock.DOLocalMoveY(15f, duration).SetEase(Ease.InCubic));
        seq.Join(underBlock.DOLocalMoveY(-15f, duration).SetEase(Ease.InCubic));
        seq.Join(optionsPanel.DOScaleY(0, duration).SetEase(Ease.InCubic));

        optionButtonPanel.SetActive(true);
        seq.Append(upperBlock.DOLocalMoveY(250f, duration).SetEase(Ease.InCubic));
        seq.Join(underBlock.DOLocalMoveY(-250f, duration).SetEase(Ease.InCubic));
        seq.Join(optionButtonPanelRect.DOScaleY(1, duration).SetEase(Ease.InCubic));
        seq.Join(textRect.DOLocalMoveY(310f, duration).SetEase(Ease.InCubic));
        seq.AppendCallback(() =>
        {
            seq.Kill();
        });
    }

    public void DoOptionPopDown()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(upperBlock.DOLocalMoveY(15f, duration).SetEase(Ease.InCubic));
        seq.Join(underBlock.DOLocalMoveY(-15f, duration).SetEase(Ease.InCubic));
        seq.Join(optionButtonPanelRect.DOScaleY(0, duration).SetEase(Ease.InCubic));

        seq.Append(upperBlock.DOLocalMoveY(250f, duration).SetEase(Ease.InCubic));
        seq.Join(underBlock.DOLocalMoveY(-250f, duration).SetEase(Ease.InCubic));
        seq.Join(optionsPanel.DOScaleY(1, duration).SetEase(Ease.InCubic));
        seq.AppendCallback(() =>
        {
            seq.Kill();
        });
    }

    public void OnInventoryPanel()
    {
        inventoryPanel.SetActive(true);
    }

    public void OffInventoryPanel()
    {
        inventoryPanel.SetActive(false);
    }

    public void PopUpTheNPCUI()
    {
        Sequence seq = DOTween.Sequence();

        npcPanel.SetActive(true);
        seq.Append(npcUpperBlock.DOLocalMoveY(255f, duration).SetEase(Ease.InCubic));
        seq.Join(npcUnderBlock.DOLocalMoveY(-220f, duration).SetEase(Ease.InCubic));
        seq.Join(rectNPCPanel.DOScaleY(1, duration).SetEase(Ease.InCubic));
        seq.AppendCallback(() => {
            seq.Kill();
        });
    }

    public void PopDownTheNPCUI()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(npcUpperBlock.DOLocalMoveY(50f, duration).SetEase(Ease.InCubic));
        seq.Join(npcUnderBlock.DOLocalMoveY(-50f, duration).SetEase(Ease.InCubic));
        seq.Join(rectNPCPanel.DOScaleY(0, duration).SetEase(Ease.InCubic));
        seq.AppendCallback(() => {
            npcPanel.SetActive(false);
            seq.Kill();
        });
    }

    public void PopUpTheElementUI()
    {
        Sequence seq = DOTween.Sequence();

        elementPanel.SetActive(true);
        seq.Join(elementUI.DOScaleY(1, duration).SetEase(Ease.InCubic));
        seq.AppendCallback(() => {
            seq.Kill();
        });
    }
    public void PopDownTheElementUI()
    {
        Sequence seq = DOTween.Sequence();

        elementPanel.SetActive(false);
        seq.Join(elementUI.DOScaleY(0, duration).SetEase(Ease.InCubic));
        seq.AppendCallback(() => {
            seq.Kill();
        });
    }

    public void QuitToManu()
    {
        SceneManager.LoadScene(4);
    }
}

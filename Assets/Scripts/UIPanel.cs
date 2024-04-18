using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class UIPanel : MonoBehaviour
{
    public string panelName;
    public float animationDuration;

    public UIManager.UIPanelAnimation overrideAnimation;
    public Ease overrideEase;
    
    private void OnEnable()
    {
        StartCoroutine(UpdateRect());
    }

    public virtual void Open(Action onOpenCallback, UIManager.UIPanelAnimation animation, Ease ease)
    {
        if (overrideAnimation != UIManager.UIPanelAnimation.None)
        {
            animation = overrideAnimation;
        }

        if (overrideEase != Ease.Unset)
        {
            ease = overrideEase;
        }
        
        RectTransform rect = GetComponent<RectTransform>();
        
        switch (animation)
        {
            
            case UIManager.UIPanelAnimation.None:
                onOpenCallback?.Invoke();
                break;
            case UIManager.UIPanelAnimation.Fade:
                rect.anchoredPosition = Vector2.zero;
                GetComponent<CanvasGroup>().alpha = 0;
                GetComponent<CanvasGroup>().DOFade(1f, animationDuration).OnComplete(() =>
                {
                    onOpenCallback?.Invoke();
                }).SetEase(ease);
                break;
            
            case UIManager.UIPanelAnimation.Swap:
                rect.anchoredPosition = new Vector2(-rect.rect.size.x, rect.anchoredPosition.y);
                rect.DOAnchorPosX(0, animationDuration).OnComplete(() =>
                {
                    onOpenCallback?.Invoke();
                }).SetEase(ease);
                break;
            case UIManager.UIPanelAnimation.Slide:
                rect.anchoredPosition = new Vector2(-rect.rect.size.x, rect.anchoredPosition.y);
                rect.DOAnchorPosX(0, animationDuration).OnComplete(() =>
                {
                    onOpenCallback?.Invoke();
                }).SetEase(ease);
                break;
            
            case UIManager.UIPanelAnimation.SwapAndFade:
                GetComponent<CanvasGroup>().alpha = 0;
                GetComponent<CanvasGroup>().DOFade(1f, animationDuration).OnComplete(() =>
                {
                    onOpenCallback?.Invoke();
                }).SetEase(ease);
                
                rect.anchoredPosition = new Vector2(-rect.rect.size.x, rect.anchoredPosition.y);
                rect.DOAnchorPosX(0, animationDuration).SetEase(ease);
                break;
            
            case UIManager.UIPanelAnimation.SlideAndFade:
                GetComponent<CanvasGroup>().alpha = 0;
                GetComponent<CanvasGroup>().DOFade(1f, animationDuration).OnComplete(() =>
                {
                    onOpenCallback?.Invoke();
                }).SetEase(ease);
                
                rect.anchoredPosition = new Vector2(-rect.rect.size.x, rect.anchoredPosition.y);
                rect.DOAnchorPosX(0, animationDuration).SetEase(ease);
                break;
        }
    }

    public virtual void Close(Action onCloseCallback, UIManager.UIPanelAnimation animation, Ease ease)
    {
        if (overrideAnimation != UIManager.UIPanelAnimation.None)
        {
            animation = overrideAnimation;
        }
        
        if (overrideEase != Ease.Unset)
        {
            ease = overrideEase;
        }
        
        RectTransform rect = GetComponent<RectTransform>();
        
        switch (animation)
        {
            case UIManager.UIPanelAnimation.None:
                onCloseCallback?.Invoke();
                gameObject.SetActive(false);
                break;
            case UIManager.UIPanelAnimation.Fade:
                rect.anchoredPosition = Vector2.zero;
                GetComponent<CanvasGroup>().alpha = 1f;
                GetComponent<CanvasGroup>().DOFade(0f, animationDuration).OnComplete(() =>
                {
                    onCloseCallback?.Invoke();
                    gameObject.SetActive(false);
                }).SetEase(ease);
                break;
            
            case UIManager.UIPanelAnimation.Swap:
                rect.anchoredPosition = Vector2.zero;
                rect.DOAnchorPosX(-rect.rect.size.x, animationDuration).OnComplete(() =>
                {
                    onCloseCallback?.Invoke();
                    gameObject.SetActive(false);
                }).SetEase(ease);
                break;
            
            case UIManager.UIPanelAnimation.Slide:
                rect.anchoredPosition = Vector2.zero;
                rect.DOAnchorPosX(rect.rect.size.x*2, animationDuration).OnComplete(() =>
                {
                    onCloseCallback?.Invoke();
                    gameObject.SetActive(false);
                }).SetEase(ease);
                break;
            
            case UIManager.UIPanelAnimation.SwapAndFade:
                GetComponent<CanvasGroup>().alpha = 1f;
                GetComponent<CanvasGroup>().DOFade(0f, animationDuration).OnComplete(() =>
                {
                    onCloseCallback?.Invoke();
                    gameObject.SetActive(false);
                }).SetEase(ease);
                
                rect.anchoredPosition = Vector2.zero;
                rect.DOAnchorPosX(-rect.rect.size.x, animationDuration).SetEase(ease);
                break;
            
            case UIManager.UIPanelAnimation.SlideAndFade:
                GetComponent<CanvasGroup>().alpha = 1f;
                GetComponent<CanvasGroup>().DOFade(0f, animationDuration).OnComplete(() =>
                {
                    onCloseCallback?.Invoke();
                    gameObject.SetActive(false);
                }).SetEase(ease);
                
                rect.anchoredPosition = Vector2.zero;
                rect.DOAnchorPosX(rect.rect.size.x*2, animationDuration).SetEase(ease);
                break;
        }
    }

    private IEnumerator UpdateRect()
    {
        yield return new WaitForEndOfFrame();
        foreach (HorizontalOrVerticalLayoutGroup gr in FindObjectsOfType<HorizontalOrVerticalLayoutGroup>())
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(gr.transform as RectTransform);
        }
    }
}

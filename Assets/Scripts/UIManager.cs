using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public UIPanel mainPanel;
    public UIPanel welcomePanel;

    public UIPanelAnimation defaultAnimation;
    public Ease defaultEase;
    
    private List<UIPanel> _panels = new List<UIPanel>();
    public bool _animationIsPlaying;
    
    private void Awake()
    {
        instance = this;
        
        StartWork();
    }
    private void StartWork()
    {
        _panels = FindObjectsOfType<UIPanel>(true).ToList();
        
        _panels.ForEach(panel =>
        {
            panel.gameObject.SetActive(false);
        });

        if (PlayerPrefs.GetInt("FirstEnter", 0) == 0)
        {
            welcomePanel.gameObject.SetActive(true);
            welcomePanel.Open(null, UIPanelAnimation.None, Ease.Unset);   
            PlayerPrefs.SetInt("FirstEnter", 1);
        }
        else
        {
            if(mainPanel != null)
            {
                mainPanel.gameObject.SetActive(true);
                mainPanel.Open(null, UIPanelAnimation.None, Ease.Unset);
            }
        }
        
    }

    public void URL(string url)
    {
        Application.OpenURL(url);
    }

    public void OpenPanelOverlay(string panelName)
    {
        UIPanel panel = _panels.Find(p => p.panelName == panelName);
        if (panel != null)
        {
            panel.gameObject.SetActive(true);
            panel.Open(null, defaultAnimation, defaultEase);
        }
    }

    public void OpenPanel(string panelName)
    {
        if (_animationIsPlaying)
        {
            return;
        }
        
        _panels.ForEach((uiPanel =>
        {
            if (uiPanel.name != panelName)
            {
                uiPanel.Close(() => { uiPanel.gameObject.SetActive(false); }, defaultAnimation, defaultEase);
            }
        }));
        
        UIPanel panel = _panels.Find(p => p.panelName == panelName);
        if (panel != null)
        {
            _animationIsPlaying = true;
            panel.gameObject.SetActive(true);
            panel.Open(() => { _animationIsPlaying = false;}, defaultAnimation, defaultEase);
        }
    }

    public void ClosePanel(string panelName)
    {
        if (_animationIsPlaying)
        {
            return;
        }
        
        UIPanel panel = _panels.Find(p => p.panelName == panelName);
        if (panel != null)
        {
            _animationIsPlaying = true;
            panel.Close(() => { _animationIsPlaying = false;}, defaultAnimation, defaultEase);
        }
    }
    
    public void OpenPanel(string panelName, Action callback)
    {
        if (_animationIsPlaying)
        {
            return;
        }
        
        _panels.ForEach((uiPanel =>
        {
            if (uiPanel.name != panelName)
            {
                uiPanel.Close(() => { uiPanel.gameObject.SetActive(false); }, defaultAnimation, defaultEase);
            }
        }));
        
        UIPanel panel = _panels.Find(p => p.panelName == panelName);
        if (panel != null)
        {
            _animationIsPlaying = true;
            panel.gameObject.SetActive(true);
            panel.Open(() => { _animationIsPlaying = false; callback?.Invoke();}, defaultAnimation, defaultEase);
        }
    }

    public void ClosePanel(string panelName, Action callback)
    {
        if (_animationIsPlaying)
        {
            return;
        }
        
        UIPanel panel = _panels.Find(p => p.panelName == panelName);
        if (panel != null)
        {
            _animationIsPlaying = true;
            panel.Close(() => { _animationIsPlaying = false; callback?.Invoke();}, defaultAnimation, defaultEase);
        }
    }
    
    public enum UIPanelAnimation
    {
        None,
        Fade,
        Swap,
        SwapAndFade,
        Slide,
        SlideAndFade
    }
}

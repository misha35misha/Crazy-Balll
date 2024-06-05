using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelFrame : MonoBehaviour
{
    public Text LevelTxt;

    [SerializeField] private Image _icon;
    [SerializeField] private Image[] _stars;
    [SerializeField] private Sprite _noStar;
    [SerializeField] private Sprite _star;
    [SerializeField] private Sprite _lock;
    [SerializeField] private Sprite _unLock;

    public bool IsLock;

    public void SetStars(int count)
    {
        for (int i = 0; i < _stars.Length; i++)
        {
            _stars[i].sprite = i < count ? _star : _noStar;
        }
    }

    public void SetLock(bool isLock)
    {
        IsLock = isLock;
        var button = GetComponent<Button>();
        
        if (IsLock)
        {
            _icon.sprite = _lock;
            LevelTxt.gameObject.SetActive(false);
            if (button != null)
                button.interactable = false;
        }
        else
        {
            _icon.sprite = _unLock;
            LevelTxt.gameObject.SetActive(true);
            if (button != null)
                button.interactable = true;
        }
    }
}

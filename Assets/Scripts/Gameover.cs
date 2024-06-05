using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private LevelFrame _levelFrame;
    [SerializeField] private Image[] _stars;
    [SerializeField] private Sprite _noStar;
    [SerializeField] private Sprite _star;
    [SerializeField] private TMP_Text _moneyTxt;

    public void Show(int starsCount)
    {
        Sound.Instance.PlayGameover();
        _panel.SetActive(true);
        SetStars(starsCount);
        _levelFrame.LevelTxt.text = (Game.Instance.LevelData.CurrentLevel + 1).ToString();
        int attempt = Global.Instance.SaveData.Attempts[Game.Instance.LevelData.CurrentLevel]++;
        int reward = 10 * attempt;
        if (reward < 50) reward = 50;
        _moneyTxt.text = $"+{reward}";
        
        if (Global.Instance.SaveData.UnlockLevel <= Game.Instance.LevelData.CurrentLevel)
            Global.Instance.SaveData.UnlockLevel++;
        
        Global.Instance.Money += reward;
    }
    
    public void Hide()
    {
        _panel.SetActive(false);
    }

    private void SetStars(int count)
    {
        _levelFrame.SetStars(count);
        
        for (int i = 0; i < _stars.Length; i++)
            _stars[i].sprite = i < count ? _star : _noStar;

        if (Global.Instance.SaveData.Stars[Game.Instance.LevelData.CurrentLevel] < count)
            Global.Instance.SaveData.Stars[Game.Instance.LevelData.CurrentLevel] = count;
    }
}

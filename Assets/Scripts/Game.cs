using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game Instance;
    public LevelData LevelData;

    [SerializeField] private Box _box;
    [SerializeField] private Gun _gun;
    [SerializeField] private Gameover _gameover;
    [SerializeField] private Image _bg;
    [SerializeField] private Sprite[] _backgrounds;
    private int _ballsInBox;
    private bool _isGame;

    public void InitLevel()
    {
        _ballsInBox = 0;

        int rnd = Random.Range(0, _backgrounds.Length);
        _bg.sprite = _backgrounds[rnd];
        LevelData.GetCurrentLvl().LevelObj.SetActive(true);
        _box.UpdateInfo(_ballsInBox, LevelData.GetCurrentLvl().NeedCountBalls);
        _gun.UpdateInfo(LevelData.GetCurrentLvl().NeedCountBalls * 2);
        _isGame = true;
    }

    public void SetLevel(int num)
    {
        LevelData.CurrentLevel = num;
    }

    public void SetPause(bool p)
    {
        Time.timeScale = p ? 0f : 1f;
        _isGame = !p;
    }

    public void ExitGame()
    {
        LevelData.GetCurrentLvl().LevelObj.SetActive(false);
    }
    
    public void AddBallInBox()
    {
        _ballsInBox++;
        _box.UpdateInfo(_ballsInBox, LevelData.GetCurrentLvl().NeedCountBalls);
        
        if (_ballsInBox >= LevelData.GetCurrentLvl().NeedCountBalls)
        {
            _isGame = false;
            int stars = 0;

            if (_gun.Balls >= 50 * _ballsInBox * 0.01f) stars = 1;
            if (_gun.Balls >= 75 * _ballsInBox * 0.01f) stars = 2;
            if (_gun.Balls == _ballsInBox) stars = 3;
            
            _gameover.Show(stars);
        }
    }

    public void HideGameOver() => _gameover.Hide();

    private void OnMouseDown()
    {
        if (_isGame == false) return;
        
        _gun.Fire();
    }

    private void Awake()
    {
        if (!Instance) Instance = this;
    }
}

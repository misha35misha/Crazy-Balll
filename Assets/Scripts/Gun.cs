using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private Ball _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _point;
    [SerializeField] private TMP_Text _countTxt;
    [SerializeField] private Image _image;

    private int _count;

    public int Balls => _count;

    public void UpdateInfo(int count)
    {
        _countTxt.text = count.ToString();
        _count = count;
        _image.sprite = Game.Instance.LevelData.GetCurrentSkin().Gun;
    }
    
    public void Fire()
    {
        if (_count <= 0) return;
        
        Sound.Instance.PlayFire();
        Ball ball = Instantiate(_prefab, _point.position, Quaternion.identity, _parent);
        ball.SetSkin(Game.Instance.LevelData.GetCurrentSkin().Ball);
        ball.Rigidbody2D.AddForce(Vector2.down * 300f);
        _count--;
        _countTxt.text = _count.ToString();
    }
}
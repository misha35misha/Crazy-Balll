using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    [SerializeField] private TMP_Text _needCountTxt;
    private Rigidbody2D _rigidbody2D;
    private Image _image;
    private Camera _camera;
    private float _leftBorder, _rightBorder;
    private Vector2 _dir;
    private string _boxTxt;

    public void UpdateInfo(int count, int need)
    {
        _needCountTxt.text = string.Format(_boxTxt, count.ToString(), need.ToString());
        _image.sprite = Game.Instance.LevelData.GetCurrentSkin().Box;
    }
    
    private void Awake()
    {
        _camera = Camera.main;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _dir = Vector2.right;
        _image = GetComponent<Image>();

        _leftBorder = _camera.ScreenToWorldPoint(new Vector2(0f, 0f)).x + 0.65f;
        _rightBorder = _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0f)).x - 0.65f;

        _boxTxt = "{0}/{1}";
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _dir * (Game.Instance.LevelData.GetCurrentLvl().BoxSpeed * Time.fixedDeltaTime));

        if (_rigidbody2D.position.x >= _rightBorder)
            _dir = Vector2.left;
        
        if (_rigidbody2D.position.x <= _leftBorder)
            _dir = Vector2.right;
    }
}
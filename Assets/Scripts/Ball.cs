using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private Image _image;
    public Rigidbody2D Rigidbody2D { get; private set; }

    public void SetSkin(Sprite sprite)
    {
        _image.sprite = sprite;
    }
    
    private void Awake()
    {
        _image = GetComponent<Image>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Sound.Instance.PlayInBox();
            Game.Instance.AddBallInBox();
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}

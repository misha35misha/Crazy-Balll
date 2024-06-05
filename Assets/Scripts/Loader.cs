using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private bool _isComplete = false;

    public UnityEvent OnComplete;

    private void Update()
    {
        if (_isComplete == false)
        {
            _slider.value += Time.deltaTime;

            if (_slider.value >= 1)
            {
                OnComplete?.Invoke();
                _isComplete = true;
            }
        }
    }
}

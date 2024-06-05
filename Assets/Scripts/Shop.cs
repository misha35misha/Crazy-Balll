using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;

    public void Buy(int id)
    {
        Global.Instance.Money -= GetCost(id);
        Global.Instance.SaveData.UnlockSkin = id;
        Game.Instance.LevelData.CurrentSkin = id;
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            if (Global.Instance.SaveData.UnlockSkin > i)
            {
                Destroy(_panels[i]);
            }
            else
            {
                _panels[i].GetComponentInChildren<Button>().interactable = Global.Instance.Money >= GetCost(i + 1);
            }
        }
    }

    private void OnEnable()
    {
        UpdateStatus();
    }

    private int GetCost(int id)
    {
        switch (id)
        {
            case 1:
                return 8000;
            case 2:
                return 20000;
            case 3:
                return 32000;
            case 4:
                return 44000;
            case 5:
                return 56000;
        }

        return 0;
    }
}

using System;
using TMPro;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global Instance;
    
    public SaveData SaveData;

    [SerializeField] private TMP_Text[] _moneyTxts;
    private int _money;

    public int Money
    {
        get => _money;
        set
        {
            _money = value;
            SaveData.Money = _money;
            
            foreach (TMP_Text text in _moneyTxts)
            {
                text.text = _money.ToString();
            }
            
            Save();
        }
    }

    public void Save()
    {
        PlayerPrefs.SetString("save", JsonUtility.ToJson(SaveData));
        PlayerPrefs.Save();
    }
    
    private void Awake()
    {
        if (!Instance) Instance = this;

        if (PlayerPrefs.HasKey("save"))
        {
            SaveData = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString("save"));
        }
        else
        {
            SaveData = new SaveData();
        }

        Money = SaveData.Money;
    }
}

[Serializable]
public class SaveData
{
    public int[] Stars;
    public int[] Attempts;
    public int Money;
    public int UnlockLevel;
    public int UnlockSkin;

    public SaveData()
    {
        Stars = new int[8];
        Attempts = new int[8];
    }
}

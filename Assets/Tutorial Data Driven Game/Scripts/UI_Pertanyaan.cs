using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pertanyaan : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _tempatJudulLevel = null;

    [SerializeField]
    private TextMeshProUGUI _tempatTeks = null;

    [SerializeField]
    private Image _tempatGambar = null;

    private void Start()
    {
        Debug.Log("Isi tempat teks yaitu:");
        Debug.Log(_tempatTeks.text);
    }

    public void SetPertanyaan(string teksJudulLevel, string teksPertanyaan, Sprite gambarHint)
    {
        _tempatJudulLevel.text = teksJudulLevel;
        _tempatTeks.text = teksPertanyaan;
        _tempatGambar.sprite = gambarHint;
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pertanyaan : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _tempatTeks = null;

    [SerializeField]
    private Image _tempatGambar = null;

    private void Start()
    {
        Debug.Log("Isi tempat teks yaitu:");
        Debug.Log(_tempatTeks.text);
    }

    public void SetPertanyaan(string teksPertanyaan, Sprite gambarHint)
    {
        _tempatTeks.text = teksPertanyaan;
        _tempatGambar.sprite = gambarHint;
    }
}

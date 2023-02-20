using UnityEngine;

public class UI_MenuConfirmMessage : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerData = null;

    [SerializeField]
    private GameObject _pesanCukupKoin = null;

    [SerializeField]
    private GameObject _pesanTakCukupKoin = null;

    private void Start()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);

        // Subscribe event
        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        // Unsubscribe event
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(LevelPackKuis levelPack, bool terkunci)
    {
        // Cek apakah terkunci atau tidak, jika tidak maka abaikan
        if (!terkunci) return;

        gameObject.SetActive(true);

        // Cek kecukupan koin untuk membeli Level Pack
        if (_playerData.progresData.koin < levelPack.Harga)
        {
            // Jika tidak cukup
            _pesanCukupKoin.SetActive(false);
            _pesanTakCukupKoin.SetActive(true);
            return;
        }

        // Jika cukup
        _pesanTakCukupKoin.SetActive(false);
        _pesanCukupKoin.SetActive(true);
    }
}

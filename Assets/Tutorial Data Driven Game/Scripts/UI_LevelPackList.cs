using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField]
    private InisialDataGameplay _initGameplay = null;

    [SerializeField]
    private UI_LevelKuisList _levelList = null;

    [SerializeField]
    private UI_OpsiLevelPack _tombolLevelPack = null;

    [SerializeField]
    private RectTransform _content = null;

    [Space, SerializeField]
    private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    private void Start()
    {
        LoadLevelPack();

        if (_initGameplay.SaatKalah)
        {
            UI_OpsiLevelPack_EventSaatKlik(_initGameplay.levelPack);
        }

        // Subscribe events
        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        // Unsubscribe events
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnApplicationQuit()
    {
        _initGameplay.Reset();
    }

    private void UI_OpsiLevelPack_EventSaatKlik(LevelPackKuis levelPack)
    {
        // Buka Menu Levels
        _levelList.gameObject.SetActive(true);
        _levelList.UnloadLevelPack(levelPack);

        // Tutup Menu Level Packs
        gameObject.SetActive(false);

        _initGameplay.levelPack = levelPack;
    }

    // Method untuk memuat semua level pack sebelum ditampilkan
    private void LoadLevelPack()
    {
        foreach (var lp in _levelPacks)
        {
            // Membuat salinan objek dari prefab tombol level pack
            var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(lp);

            // Masukkan objek tombol sebagai anak dari objek "content"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }
}

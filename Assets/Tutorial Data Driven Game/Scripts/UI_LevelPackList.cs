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

    //[Space, SerializeField]
    //private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    private PlayerProgress.MainData _playerData;

    private void Start()
    {
        //LoadLevelPack();

        // Cek apakah setelah Gameplay sempat kalah
        if (_initGameplay.SaatKalah)
        {
            UI_OpsiLevelPack_EventSaatKlik(null, _initGameplay.levelPack, false);
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

    private void UI_OpsiLevelPack_EventSaatKlik(UI_OpsiLevelPack referensiOpsiTombol,
        LevelPackKuis levelPack, bool terkunci)
    {
        // Cek apakah terkunci, jika terkunci abaikan
        if (terkunci) return;

        // Buka Menu Levels
        _levelList.gameObject.SetActive(true);
        _levelList.UnloadLevelPack(levelPack, _playerData);

        // Tutup Menu Level Packs
        gameObject.SetActive(false);

        _initGameplay.levelPack = levelPack;
    }

    // Method untuk memuat semua level pack sebelum ditampilkan
    public void LoadLevelPack(LevelPackKuis[] levelPacks, PlayerProgress.MainData playerData)
    {
        _playerData = playerData;

        foreach (var lp in levelPacks)
        {
            // Membuat salinan objek dari prefab tombol level pack
            var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(lp);

            // Masukkan objek tombol sebagai anak dari objek "content"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;

            // Cek apakah level pack terdaftar di Dictionary progres pemain
            if (!playerData.progresLevel.ContainsKey(lp.name))
            {
                // Jika tidak terdaftar maka Level Pack terkunci
                t.KunciLevelPack();
            }
        }
    }
}

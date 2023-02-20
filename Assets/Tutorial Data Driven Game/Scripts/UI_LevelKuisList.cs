using UnityEngine;

public class UI_LevelKuisList : MonoBehaviour
{
    [SerializeField]
    private InisialDataGameplay _initGameplay = null;

    [SerializeField]
    private UI_OpsiLevelKuis _tombolLevel = null;

    [SerializeField]
    private RectTransform _content = null;

    [SerializeField]
    private LevelPackKuis _sampelLevelPack = null;

    [Space, Header("Scene Manager")]
    [SerializeField]
    private GameSceneManager _gameSceneManager = null;

    [SerializeField]
    private string _gameplayScene = string.Empty;

    private void Start()
    {
        // Subscribe events
        UI_OpsiLevelKuis.EventSaatKlik += UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void OnDestroy()
    {
        // Unsubscribe events
        UI_OpsiLevelKuis.EventSaatKlik -= UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void OnApplicationQuit()
    {
        _initGameplay.Reset();
    }

    private void UI_OpsiLevelKuis_EventSaatKlik(int index)
    {
        _initGameplay.soalIndexKe = index;
        _gameSceneManager.BukaScene(_gameplayScene);
    }

    // Membuka, memuat, dan menampilkan level dari isi Level Pack
    public void UnloadLevelPack(LevelPackKuis levelPack, PlayerProgress.MainData playerData)
    {
        HapusIsiKonten();

        int levelTerbukaTerakhir = playerData.progresLevel[levelPack.name] - 1;

        for (int i = 0; i < levelPack.BanyakLevel; i++)
        {
            // Membuat salinan objek dari prefab tombol level
            var t = Instantiate(_tombolLevel);

            t.SetLevelKuis(levelPack.AmbilLevelKe(i), i);

            // Masukkan objek tombol sebagai anak dari objek "content"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;

            // Cek apabila melewati level terakhir yang belum diselesaikan pemain
            if (i > levelTerbukaTerakhir)
            {
                // Kunci tombol agar pemain tidak dapat menekan tombol level
                t.InteraksiTombol = false;
            }
        }
    }

    private void HapusIsiKonten()
    {
        var cc = _content.childCount;

        for (int i = 0; i < cc; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }
}

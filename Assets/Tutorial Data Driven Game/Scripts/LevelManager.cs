using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private InisialDataGameplay _initGameplay = null;

    //[SerializeField]
    //private LevelPackKuis _soalSoal = null;

    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private UI_Pertanyaan _tempatPertanyaan = null;

    [SerializeField]
    private UI_PoinJawaban[] _tempatPilihanJawaban = new UI_PoinJawaban[0];

    [Space, Header("Scene Manager")]
    [SerializeField]
    private GameSceneManager _gameSceneManager = null;

    [SerializeField]
    private string _sceneMenuLevel = string.Empty;

    [Space, Header("Suara Event")]
    [SerializeField]
    private PemanggilSuara _pemanggilSuara = null;

    [SerializeField]
    private AudioClip _suaraJawabanBenar = null;

    [SerializeField]
    private AudioClip _suaraJawabanSalah = null;

    private int _indexSoal = -1;

    private void Start()
    {
        // Atur mulai di level ke berapa
        _indexSoal = _initGameplay.soalIndexKe - 1;

        NextLevel();

        // Mainkan suara BGM untuk gameplay
        AudioManager.instance.PlayBGM(1);

        // Subscribe events
        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }

    private void OnDestroy()
    {
        // Unsubscribe events
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }

    private void OnApplicationQuit()
    {
        _initGameplay.Reset();
    }

    private void UI_PoinJawaban_EventJawabSoal(string jawaban, bool adalahBenar)
    {
        _pemanggilSuara.PanggilSuara(adalahBenar ? _suaraJawabanBenar : _suaraJawabanSalah);

        // Cek jika tidak benar, maka abaikan prosedur
        if (!adalahBenar) return;

        string namaLevelPack = _initGameplay.levelPack.name;
        int levelTerakhir = _playerProgress.progresData.progresLevel[namaLevelPack];

        // Cek apabila level terakhir kali main telah diselesaikan
        if (_indexSoal + 2 > levelTerakhir)
        {
            // Tambahkan koin sebagai hadiah dari menyelesaikan soal kuis
            _playerProgress.progresData.koin += 20;

            // Membuka level selanjutnya agar dapat diakses di menu level
            _playerProgress.progresData.progresLevel[namaLevelPack] = _indexSoal + 2;

            _playerProgress.SimpanProgres();
        }
    }

    public void NextLevel()
    {
        // Soal index selanjutnya
        _indexSoal++;

        // Jika index melampaui soal terakhir
        if (_indexSoal >= _initGameplay.levelPack.BanyakLevel)
        {
            // Level Pack dianggap selesai, kembali ke menu level
            _gameSceneManager.BukaScene(_sceneMenuLevel);
            return;

            //// Prosedur ini untuk mengulang level pack dari awal
            //_indexSoal = 0;
        }

        // Ambil data Pertanyaan
        LevelSoalKuis soal = _initGameplay.levelPack.AmbilLevelKe(_indexSoal);

        // Set informasi soal
        _tempatPertanyaan.SetPertanyaan($"Level {_indexSoal + 1}", soal.pertanyaan, soal.hint);

        for (int i = 0; i < _tempatPilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _tempatPilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawabanTeks, opsi.adalahBenar);
        }
    }
}


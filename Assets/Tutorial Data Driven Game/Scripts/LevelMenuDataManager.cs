using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private UI_LevelPackList _levelPackList = null;

    [SerializeField]
    private TextMeshProUGUI _teksKoin = null;

    [SerializeField]
    private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    private void Start()
    {
        // Chek apabila tidak berhasil memuat progres
        if (!_playerProgress.MuatProgres())
        {
            // Buat simpanan progres atau ganti dengan yang baru
            _playerProgress.SimpanProgres();
        }

        // Muat semua level pack yang ada di game
        _levelPackList.LoadLevelPack(_levelPacks, _playerProgress.progresData);

        _teksKoin.text = $"{_playerProgress.progresData.koin}";

        // Mainkan suara BGM untuk menu Level
        AudioManager.instance.PlayBGM(0);
    }
}

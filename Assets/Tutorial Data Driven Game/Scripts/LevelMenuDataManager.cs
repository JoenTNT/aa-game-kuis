using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private TextMeshProUGUI _teksKoin = null;

    private void Start()
    {
        _teksKoin.text = $"{_playerProgress.progresData.koin}";
    }
}

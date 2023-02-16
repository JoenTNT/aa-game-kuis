using TMPro;
using UnityEngine;

public class UI_OpsiLevelKuis : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _levelName = null;

    [SerializeField]
    private LevelSoalKuis _levelKuis = null;

    private void Start()
    {
        if (_levelKuis != null)
            SetLevelKuis(_levelKuis);
    }

    public void SetLevelKuis(LevelSoalKuis levelKuis)
    {
        _levelName.text = levelKuis.name;
        _levelKuis = levelKuis;
    }
}

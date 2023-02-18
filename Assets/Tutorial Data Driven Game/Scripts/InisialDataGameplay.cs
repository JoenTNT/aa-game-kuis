using UnityEngine;

[CreateAssetMenu(
    fileName = "Inisial Data Gameplay Baru",
    menuName = "Game Kuis/Inisial Data Gameplay")]
public class InisialDataGameplay : ScriptableObject
{
    public LevelPackKuis levelPack = null;
    public int soalIndexKe = 0;

    private bool _saatKalah = false;

    public bool SaatKalah
    {
        get => _saatKalah;
        set => _saatKalah = value;
    }
}

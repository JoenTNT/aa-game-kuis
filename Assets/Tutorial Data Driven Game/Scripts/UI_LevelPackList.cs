using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField]
    private UI_OpsiLevelPack _tombolLevelPack = null;

    [SerializeField]
    private RectTransform _content = null;

    [Space, SerializeField]
    private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    private void Start()
    {
        LoadLevelPack();
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

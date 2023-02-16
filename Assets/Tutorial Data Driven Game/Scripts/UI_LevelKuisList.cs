using UnityEngine;

public class UI_LevelKuisList : MonoBehaviour
{
    [SerializeField]
    private UI_OpsiLevelKuis _tombolLevel = null;

    [SerializeField]
    private RectTransform _content = null;

    [SerializeField]
    private LevelPackKuis _sampelLevelPack = null;

    private void Start()
    {
        UnloadLevelPack(_sampelLevelPack);
    }

    // Membuka, memuat, dan menampilkan level dari isi Level Pack
    public void UnloadLevelPack(LevelPackKuis levelPack)
    {
        for (int i = 0; i < levelPack.BanyakLevel; i++)
        {
            // Membuat salinan objek dari prefab tombol level
            var t = Instantiate(_tombolLevel);

            t.SetLevelKuis(levelPack.AmbilLevelKe(i));

            // Masukkan objek tombol sebagai anak dari objek "content"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }
}

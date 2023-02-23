using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton
    public static AudioManager instance = null;

    [SerializeField]
    private AudioSource _bgmPrefab = null;

    [SerializeField]
    private AudioClip[] _bgmClips = new AudioClip[0];

    private AudioSource _bgm = null;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Objek \"Audio Manager\" sudah ada.\n" +
                "Hapus Objek serupa.", instance);
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        // Buat objek BGM
        _bgm = Instantiate(_bgmPrefab);
        DontDestroyOnLoad(_bgm);
    }

    private void OnDestroy()
    {
        if (this == instance)
        {
            instance = null;

            if (_bgm != null)
                Destroy(_bgm.gameObject);
        }
    }

    public void PlayBGM(int index)
    {
        _bgm.clip = _bgmClips[index];
    }
}
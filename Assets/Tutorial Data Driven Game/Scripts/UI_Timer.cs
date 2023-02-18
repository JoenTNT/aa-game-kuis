using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    public static event System.Action EventWaktuHabis;

    //[SerializeField]
    //private UI_PesanLevel _tempatPesan = null;

    [SerializeField]
    private Slider _timeBar = null;

    [SerializeField]
    private float _waktuJawab = 30; // Dalam Detik

    private float _sisaWaktu = 0;
    private bool _waktuBerjalan = false;

    public bool WaktuBerjalan
    {
        get => _waktuBerjalan;
        set => _waktuBerjalan = value;
    }

    private void Start()
    {
        UlangiWaktu();
        _waktuBerjalan = true;
    }

    private void Update()
    {
        if (!_waktuBerjalan)
            return;

        _sisaWaktu -= Time.deltaTime;

        _timeBar.value = _sisaWaktu / _waktuJawab;

        if (_sisaWaktu <= 0f)
        {
            //_tempatPesan.Pesan = "Waktu Habis";
            //_tempatPesan.gameObject.SetActive(true);

            EventWaktuHabis?.Invoke();
            _waktuBerjalan = false;
            return;
        }
    }

    public void UlangiWaktu()
    {
        _sisaWaktu = _waktuJawab;
    }
}


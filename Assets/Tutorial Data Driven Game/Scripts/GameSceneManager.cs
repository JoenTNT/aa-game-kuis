using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // Untuk memuat target Scene dengan nama.
    // Nama Scene ini sensitif.
    public void BukaScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }
}

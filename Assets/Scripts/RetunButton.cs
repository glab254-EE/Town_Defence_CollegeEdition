using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetunButton : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Set-up")]
    [SerializeField] private SceneAsset scene;
    [SerializeField] private Button button;

    void Start()
    {
        button.onClick.AddListener(OnPress);
    }

    // Update is called once per frame
    private void OnPress()
    {
        SceneManager.LoadScene(scene.name,LoadSceneMode.Single);
    }
}

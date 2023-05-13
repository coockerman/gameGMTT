using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LoadNewArea : MonoBehaviour
{
    public int leverToload;

    public string ExitMap;

    private PlayerCtrl thePlayer;

    public GameObject loading;
    public Slider slider;
    public TextMeshProUGUI textMeshPro;
    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerCtrl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            LoadLevel(leverToload);
            thePlayer.StartPoint = ExitMap;
        }
    }
    
    public void LoadLevel(int sceneIndex)
    {
        loading.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneIndex));

    }
    
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            textMeshPro.text = ((int)(progress * 100)).ToString() + "%";
            yield return null;
        }
    }
}

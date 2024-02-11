using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalBoxes = 0;
    public int finishedBoxes;

    [SerializeField] private GameObject masks;
    [SerializeField] private Button EnterLevel1Button;
    [SerializeField] private Button EnterLevel2Button;
    [SerializeField] private Button EnterLevel3Button;
    [SerializeField] private Button QuitButton;

    private void Start()
    {
        masks.SetActive(false);

        EnterLevel1Button.onClick.AddListener(OnEnterLevel1ButtonClick);
        EnterLevel2Button.onClick.AddListener(OnEnterLevel2ButtonClick);
        EnterLevel3Button.onClick.AddListener(OnEnterLevel3ButtonClick);
        QuitButton.onClick.AddListener(OnQuitButtonClick);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetStage();
    }

    public void CheckFinish()
    {
        if (finishedBoxes == totalBoxes)
        {
            print("YOU WIN!");
            StartCoroutine(LoadNextStage());
        }
    }

    void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadNextStage()
    {
        yield return new WaitForSeconds(1);

        masks.SetActive(true);
    }

    private void OnEnterLevel1ButtonClick()
    {
        SceneManager.LoadScene("Level 01");
    }

    private void OnEnterLevel2ButtonClick()
    {
        SceneManager.LoadScene("Level 02");
    }

    private void OnEnterLevel3ButtonClick()
    {
        SceneManager.LoadScene("Level 03");
    }

    private void OnQuitButtonClick()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

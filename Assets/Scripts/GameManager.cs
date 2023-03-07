using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    HitStop hsControl;
    [SerializeField] float loseStopDuration = 5f;
    [SerializeField] GameObject losePanel;
    UISnake uisnake;

    // Start is called before the first frame update
    void Start()
    {
        hsControl = FindObjectOfType<HitStop>();
        uisnake = FindObjectOfType<UISnake>();
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MenuControls();
    }

    void MenuControls()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Lose()
    {
        StartCoroutine(LoseEvents());
    }
    IEnumerator LoseEvents()
    {
        hsControl.Stop(1f);
        Time.timeScale = 0;
        //uisnake.CreateUISnake();
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}

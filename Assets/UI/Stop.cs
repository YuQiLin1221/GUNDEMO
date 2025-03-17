using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Stop : MonoBehaviour
{
    private VisualElement homeElement;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        homeElement = root.Q<VisualElement>("GameStop");

        homeElement.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0;

            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            homeElement = root.Q<VisualElement>("GameStop");

            homeElement.style.display = DisplayStyle.Flex;
            Button RePlay = root.Q<Button>("Play");
            RePlay.RegisterCallback<ClickEvent>(Replaygame);
        }
    }

    private void Replaygame(ClickEvent cke)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        homeElement.style.display = DisplayStyle.None;
    }
}

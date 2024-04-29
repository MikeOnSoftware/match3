using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class ButtonClickHandler : MonoBehaviour
{
    Program program;

    GameObject clickedHider;
    GameObject clickedObject;

    void Awake()
    {
        program = FindObjectOfType<Program>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ClickEvent);
    }

    void ClickEvent()
    {
        GameObject.Find("SelectSound").GetComponent<AudioSource>().Play();

        clickedHider = this.gameObject;
        clickedHider.SetActive(false);
        clickedObject = clickedHider.transform.parent.gameObject;

        program.clickedObject = this.clickedObject;
        program.clickedObjects.Add(clickedObject);
    }
}

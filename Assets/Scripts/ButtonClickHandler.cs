using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    Source src;

    GameObject clickedHider;
    GameObject clickedObject;

    void Awake()
    {
        src = FindObjectOfType<Source>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ClickEvent);
    }

    void ClickEvent()
    {
        clickedHider = this.gameObject;
        clickedHider.SetActive(false);
        clickedObject = clickedHider.transform.parent.gameObject;

        src.clickedObject = this.clickedObject;
        src.clickedObjects.Add(clickedObject);
    }

}

using TMPro;
using UnityEngine;
using DG.Tweening;

public class FooteMenuController : MonoBehaviour
{
    [SerializeField] RectTransform optionsContainer;
    [SerializeField] private UnityEngine.UI.Button[] menuOptions;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color selectedColor = Color.yellow;

    [SerializeField] float spacing = 400f;
    [SerializeField] float moveSpeed = 10f;

    int currentIndex;

    Vector2 targetPos;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = optionsContainer.anchoredPosition;
        UpdatedSelectionVisual();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex++;
            MoveMenu();
            UpdatedSelectionVisual();

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex--;
            MoveMenu();
            UpdatedSelectionVisual();
        }

        currentIndex = Mathf.Clamp(currentIndex, 0, 4);

        optionsContainer.anchoredPosition =
        Vector2.Lerp(
            optionsContainer.anchoredPosition,
            targetPos,
            moveSpeed * Time.deltaTime
        );

        
    }

    void MoveMenu()
    {
        targetPos = new Vector2(
            -currentIndex * spacing,
            optionsContainer.anchoredPosition.y
        );
    }

    void UpdatedSelectionVisual()
    {
        for(int i = 0; i < menuOptions.Length; i++)
        {
            bool selected = i == currentIndex;

            menuOptions[i].image.color =
            selected ? selectedColor : normalColor;

            menuOptions[i].transform.DOScale(
                selected ? 1.15f : 1f,
                0.2f
            );
        }
    }
}

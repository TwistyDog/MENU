using TMPro;
using UnityEngine;
using DG.Tweening;

public class FooteMenuController : MonoBehaviour
{
    [SerializeField] RectTransform optionsContainer;

    [SerializeField] float spacing = 400f;
    [SerializeField] float moveSpeed = 10f;

    int currentIndex;

    Vector2 targetPos;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = optionsContainer.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex++;
            MoveMenu();

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex--;
            MoveMenu();
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
}

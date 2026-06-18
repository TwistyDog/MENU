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
            UpdateVisual();

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex--;
            UpdateVisual();
        }
    }

    void UpdateVisual()
    {
        currentIndex = Mathf.Clamp(currentIndex, 0, 4);

        float targetX = -currentIndex * spacing;

        optionsContainer.DOAnchorPosX(targetX, 0.35f)
            .SetEase(Ease.OutCubic);
    }
}

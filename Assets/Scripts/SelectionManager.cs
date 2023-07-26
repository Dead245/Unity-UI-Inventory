using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float scaleMultiplier = 1.1f;
    [SerializeField] private float moveTime = 0.1f;

    private Vector3 startScale;
    // Start is called before the first frame update
    void Start() {
        startScale = transform.localScale;
    }

    private IEnumerator MoveCard(bool selected)
    {
        Vector3 endScale;

        float timeElapsed = 0f;
        while (timeElapsed < moveTime) {
            timeElapsed += Time.deltaTime;

            if (selected)
            {
                endScale = startScale * scaleMultiplier;
            }
            else {
                endScale = startScale;
            }

            //Lerp to scale
            Vector3 lerpedScale = Vector3.Lerp(transform.localScale, endScale, timeElapsed / moveTime);

            transform.localScale = lerpedScale;

            yield return null;
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(MoveCard(true));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(MoveCard(false));
    }
}
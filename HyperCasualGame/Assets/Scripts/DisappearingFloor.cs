using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DisappearingFloor : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(DisappearReady());
    }

    private IEnumerator DisappearReady()
    {
        for (int i = 0; i < 5; i++)
        {
            SpriteRenderer.DOColor(new Color(1, 1, 1, 1), 0.5f);
            yield return new WaitForSeconds(0.5f);
            SpriteRenderer.DOColor(new Color(1, 1, 1, 50 / 255f), 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
        gameObject.SetActive(false);
    }
}

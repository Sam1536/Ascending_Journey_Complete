using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;

    public Color color = Color.yellow;
    public float duration = .2f;

    private Tween _currentTween;

    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }
    }

    private void Update()
    {
        if(_currentTween != null)
        {
            _currentTween.Kill();

            spriteRenderers.ForEach(i => i.color = Color.white);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Flash();
        }
    }

    public void Flash()
    {
        foreach(var s in spriteRenderers)
        {
            s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}

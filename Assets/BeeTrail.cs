using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Helpers.Routine;

public class BeeTrail : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ActionHelper.Delay(1.0f, () => sprite.DOFade(0f, 1f));
        ActionHelper.Delay(2.5f, () => Destroy(gameObject));
    }
}

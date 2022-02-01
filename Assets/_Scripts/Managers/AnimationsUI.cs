using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class AnimationsUI : MonoBehaviour
{
    protected virtual void Start()
    {
        DOTween.Init();
    }

    public void DoMoveX(Transform target, float position, float duration)
    {
        target.DOLocalMoveX(position, duration);
    }

    public void DoMove(Transform target, Vector2 position, float duration)
    {
        target.DOLocalMove(position, duration);
    }

    public void DoScale(Transform target, Vector3 scala, float duration)
    {
        target.DOScale(scala, duration);
    }

    public void DoFade(Image target, float fadeValue, float duration)
    {
        target.DOFade(fadeValue, duration);
    }
}

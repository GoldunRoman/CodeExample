using DG.Tweening;
using UnityEngine;

public class ScaleEffect : MonoBehaviour
{
    private float duration = 0.15f;  
    private Vector3 _startScale = new Vector3(0, 0, 0);  
    private Vector3 _endScale = new Vector3(1, 1, 1);    

    void OnEnable()
    {
        transform.localScale = _startScale;

        transform.DOScale(_endScale, duration);
    }
}

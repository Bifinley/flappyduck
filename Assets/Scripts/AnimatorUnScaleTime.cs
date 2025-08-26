using UnityEngine;

public class AnimatorUnScaleTime : MonoBehaviour
{
    [SerializeField] private Animator getAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        getAnimator.updateMode = AnimatorUpdateMode.UnscaledTime; // keeps the title animation moving even when game is paused
    }
}

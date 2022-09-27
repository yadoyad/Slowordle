using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
    [SerializeField] private GameObject curtain;
    private Animator animator;

    void Awake()
    {
        animator = curtain.GetComponent<Animator>();
    }

    public void ShowCurtain()
    {
        animator.SetTrigger("RollIn");
    }

    public void HideCurtain()
    {
        animator.SetTrigger("RollOut");
    }
}

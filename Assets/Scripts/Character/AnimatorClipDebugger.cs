using UnityEngine;

public class AnimatorClipDebugger : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void Reset() => anim = GetComponent<Animator>();

    void Update()
    {
        if (!anim) return;

        var clips = anim.GetCurrentAnimatorClipInfo(0); // Base layer
        if (clips.Length > 0)
        {
            Debug.Log($"State: {anim.GetCurrentAnimatorStateInfo(0).shortNameHash} | Clip: {clips[0].clip.name} | Controller: {anim.runtimeAnimatorController.name} | Type: {anim.runtimeAnimatorController.GetType().Name}");
        }
    }
}
using UnityEngine;

public class AnimatorLayerSpy : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sr;

    void Reset()
    {
        anim = GetComponent<Animator>();
        if (!sr) sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (!anim || !sr) return;

        string s = $"SPRITE: {(sr.sprite ? sr.sprite.name : "NULL")} | Layers={anim.layerCount} | ";

        for (int i = 0; i < anim.layerCount; i++)
        {
            var clips = anim.GetCurrentAnimatorClipInfo(i);
            var clipName = clips.Length > 0 ? clips[0].clip.name : "None";
            s += $"L{i}(w={anim.GetLayerWeight(i):0.00}):{clipName} ";
        }

        Debug.Log(s);
    }
}
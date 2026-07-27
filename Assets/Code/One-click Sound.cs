using UnityEngine;

public class One_clickSound : MonoBehaviour
{
    public AudioClip soundEffect;//効果音再生
    private AudioSource audioSource;
    void Start()
    {
        //AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
    }
}

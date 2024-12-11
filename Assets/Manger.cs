using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manger : MonoBehaviour
{
    public static Manger Instance;
    public GameObject Player;
    public GameObject Enimy;
    public AudioClip[] LevelAudio;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

 /*   public void PlaySound(AudioClip sound, Vector3 pos)
    {
        GameObject obg = Pooling.pooling.GetPool();
        AudioSource aoudio = obg.GetComponent<AudioSource>();
        obg.transform.position = pos;
        obg.SetActive(true);
        aoudio.PlayOneShot(sound);
        StartCoroutine(DisaapleAoudio(aoudio));

    }
    IEnumerator DisaapleAoudio(AudioSource audio)

    {

        while (audio.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);

        }
        audio.gameObject.SetActive(false);
    }
 */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDiedScript : MonoBehaviour
{
    public resetLevel script;
    [SerializeField]
    private AudioSource source;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "kill")
        {
            StartCoroutine(DelayedAction());
        }
    }

    IEnumerator DelayedAction()
    {
        source.Play();
        yield return new WaitForSeconds(1.0f);
        script.ActivateScreenProcess();
    }


}

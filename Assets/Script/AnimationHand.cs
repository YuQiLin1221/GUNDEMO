using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHand : MonoBehaviour
{
    Animation anim;

    bool _reload = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        anim.CrossFade("Take_In");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            anim.CrossFade("Fire");
            Debug.Log("nhan chuot");
        }
        else if (_reload)
        {
            StartCoroutine("funReload", 2.1f);
            Debug.Log("trang thai reload");
        }
        //else
        //{
        //    anim.CrossFade("Idle");
        //    Debug.Log("trang thai idle");
        //}

        if (Input.GetKey(KeyCode.M))
        {
            _reload = true;
            Debug.Log("nhan phim M");
        }
    }

    IEnumerator funReload (float t)
    {
        anim.CrossFade("Reload");
        yield return new WaitForSeconds(t);
        _reload = false;
    }
}

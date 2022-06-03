using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ParticleScript : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Waiting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayParticle()
    {
        var particleEfect = Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);

        Destroy(particleEfect, 1f);
        //Waiting();
    }

    //private IEnumerator Waiting()
    //{
        
    //    yield return new WaitForSeconds(5);
    //}
}

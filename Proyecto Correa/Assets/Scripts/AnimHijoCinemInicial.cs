using System.Collections;
using UnityEngine;

public class AnimHijoCinemInicial : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float waiting1;
    [SerializeField] float waiting2;
    [SerializeField] float waiting3;
    [SerializeField] float waiting4;
    private int n = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Moving());   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * n * Time.deltaTime);
    }

    IEnumerator Moving() {
        yield return new WaitForSeconds(waiting1);
        n = 1;
        yield return new WaitForSeconds(waiting2);
        transform.Rotate(new Vector3(0, 180, 0));
        n = 0;
        yield return new WaitForSeconds(waiting3);
        n = 1;
        yield return new WaitForSeconds(waiting4);
        n = 0;
        GetComponent<Animator>().SetTrigger("Change");
    }

   
}

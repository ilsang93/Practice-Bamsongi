using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
        StartCoroutine(DestroyBamsongi(5));
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("target"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<ParticleSystem>().Play();
            StartCoroutine(DestroyBamsongi(1));
            if (col.collider.name.Equals("target_1"))
            {
                GameManager.Instance.Score = 10;
            }
            else if (col.collider.name.Equals("target_2"))
            {
                GameManager.Instance.Score = 20;
            }
            else if (col.collider.name.Equals("target_3"))
            {
                GameManager.Instance.Score = 30;
            }
        }
    }

    private IEnumerator DestroyBamsongi(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        yield break;
    }
}

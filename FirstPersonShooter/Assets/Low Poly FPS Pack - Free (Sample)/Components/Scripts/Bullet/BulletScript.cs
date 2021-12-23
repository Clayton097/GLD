using UnityEngine;
using System.Collections;

// ----- Low Poly FPS Pack Free Version -----
public class BulletScript : MonoBehaviour
{

    [SerializeField]
    float bulletDamage = 20f;

    [Range(5, 100)]
    [Tooltip("After how long time should the bullet prefab be destroyed?")]
    public float destroyAfter;
    [Tooltip("If enabled the bullet destroys on impact")]
    public bool destroyOnImpact = false;
    [Tooltip("Minimum time after impact that the bullet is destroyed")]
    public float minDestroyTime;
    [Tooltip("Maximum time after impact that the bullet is destroyed")]
    public float maxDestroyTime;

    [Header("Impact Effect Prefabs")]
    public Transform[] metalImpactPrefabs;

    private void Start()
    {
        //Start destroy timer
        StartCoroutine(DestroyAfter());
    }

    //If the bullet collides with anything
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy bullet on collision.
        if (collision.transform.tag == "DestroyBulletEnvoirement")
        {
            Destroy(this.gameObject);
        }

        //Bugs health bar decrease on each bullet hit and destroy bullet.
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= bulletDamage;
            Destroy(gameObject);
            //If health  lower than 0 destroy enemy.
            if (collision.gameObject.GetComponent<EnemyHealth>().health <= 0) {
                //Destroy bullet object
                collision.gameObject.GetComponent<EnemyHealth>().DropCoin(Random.Range(1,3));
                Destroy(collision.gameObject);
                Debug.Log("Bug Destroyed");
                Destroy(gameObject);
            }
        }

        //Skeleton health bar decrease on each bullet hit and destroy bullet.
        if (collision.transform.tag == "Skeleton")
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= bulletDamage;
            Destroy(gameObject);
            //If health  lower than 0 destroy enemy.
            if (collision.gameObject.GetComponent<EnemyHealth>().health <= 0)
            {
                //Destroy bullet object
                Destroy(collision.gameObject);
                Debug.Log("Skeleton Destroyed");
                Destroy(gameObject);
            }
        }

        /*
        //Destroy bug and bullet on collision.
        if (collision.transform.tag == "Bug")
        {
            //Destroy bullet object
            Destroy(collision.gameObject);
            Debug.Log("Bug");
            Destroy(gameObject);
        }
        */

    }

    private IEnumerator DestroyTimer()
    {
        //Wait random time based on min and max values
        yield return new WaitForSeconds
            (Random.Range(minDestroyTime, maxDestroyTime));
        //Destroy bullet object
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfter()
    {
        //Wait for set amount of time
        yield return new WaitForSeconds(destroyAfter);
        //Destroy bullet object
        Destroy(gameObject);
    }
}
// ----- Low Poly FPS Pack Free Version -----
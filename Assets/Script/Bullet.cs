using System.Collections;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 4f;
    public int damage = 20;
    //public ParticleSystem explosion;
   
    //public GameObject effect;
    public GameObject explosionEffect; // Prefab cho hiệu ứng nổ
    public GameObject sparkEffect; // Prefab cho hiệu ứng tóe lửa

    private float timeAlive;
    private void OnEnable()
    {
       
        timeAlive = 0f; // Đặt lại thời gian sống khi kích hoạt
    }

    private void Update()
    {

        // Di chuyển viên đạn

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Tăng thời gian sống
        timeAlive += Time.deltaTime;

        // Nếu vượt quá thời gian sống, trả lại pool
        if (timeAlive >= lifeTime)
        {
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        // Trả đối tượng về pool
        FindObjectOfType<ObjectPool>().ReturnObject(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAI monster = collision.gameObject.GetComponent<EnemyAI>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
                Debug.Log("va cham voi quai");
                StartCoroutine(NoEx()); // Tạo hiệu ứng nổ
                //explosion.Play();
                //// Hủy đạn
                //Destroy(gameObject);
            }
            //else
            //{
            //    // va chạm với bề mặt khác
            //    StartCoroutine(ToeLua());
            //}
            //ReturnToPool();
        }
        if (collision.gameObject.CompareTag("Untagged"))
        {
            StartCoroutine(ToeLua());
        }
    }

    IEnumerator NoEx()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Destroy(explosion); // Hủy đối tượng nổ sau 0.1 giây
    }
    IEnumerator ToeLua()
    {
        GameObject spark = Instantiate(sparkEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Destroy(spark); // Hủy đối tượng tóe lửa sau 0.1 giây
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        EnemyAI monster = other.gameObject.GetComponent<EnemyAI>();
    //        if (monster != null)
    //        {
    //            monster.TakeDamage(damage);
    //            Debug.Log("va cham voi quai");

    //            //// Hủy đạn
    //            //Destroy(gameObject);
    //        }
    //    }
    //}

}
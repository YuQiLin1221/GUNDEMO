using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyP : MonoBehaviour
{
    public ObjectPoolEnemy objectPool; // Tham chiếu đến Object Pool
    public int enemyCount = 5; // Số lượng Enemy muốn sinh ra mỗi lần

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Sinh Enemy từ Object Pool
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = objectPool.GetObject();
                if (enemy != null) // Kiểm tra null trước khi sử dụng
                {
                    enemy.transform.position = GetRandomSpawnPosition(); // Đặt vị trí ngẫu nhiên
                    enemy.SetActive(true); // Kích hoạt Enemy
                }
            }

            // Đợi 3 giây trước khi biến mất
            yield return new WaitForSeconds(3f);

            // Trả lại tất cả Enemy vào pool
            objectPool.ReturnAllObjects();

            // Đợi 2 giây trước khi làm mới
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Tạo một vị trí ngẫu nhiên để sinh Enemy
        return new Vector3(
            Random.Range(-16, -42), // X
            Random.Range(6, 8),     // Y
            Random.Range(7, 20)     // Z
        );
    }
}

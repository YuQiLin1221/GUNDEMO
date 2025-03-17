using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    //public ScreenShake ScreenShake;

    public float maxHealth = 100f;   // Máu tối đa
    public float currentHealth;      // Máu hiện tại
    public HealthBar healthBar;      // Reference tới HealthBar để cập nhật
    public GameObject gameOverUI;    // UI Game Over (UI Toolkit hoặc bất kỳ UI nào bạn sử dụng)
    //public ParticleSystem explosion;

    public GameObject cameraM;
    public GameObject cameraP;

    private void Start()
    {
        currentHealth = maxHealth;  // Thiết lập máu ban đầu bằng máu tối đa
        healthBar.SetMaxHealth(maxHealth);  // Cập nhật thanh máu ban đầu
        gameOverUI.SetActive(false);  // Đảm bảo UI Game Over ẩn khi bắt đầu trò chơi
        cameraM.SetActive(true);
        cameraP.SetActive(false);
    }

    private void Update()
    {
    }

    // Hàm giảm máu khi bị tấn công
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Giảm máu
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        healthBar.SetHealth(currentHealth); // Cập nhật thanh máu

        // Kiểm tra nếu máu về 0
        if (currentHealth <= 0)
        {
            TriggerGameOver();
        }

        
    }

    // Hàm kích hoạt màn hình Game Over
    private void TriggerGameOver()
    {
        gameOverUI.SetActive(true);  // Kích hoạt UI Game Over khi máu = 0
        Time.timeScale = 0;
        Debug.Log("Ket Thuc");
    }

    // Hàm phục hồi máu
    public void Heal(float amount)
    {
        currentHealth += amount; // Tăng máu
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Đảm bảo không vượt quá máu tối đa
        }

        healthBar.SetHealth(currentHealth); // Cập nhật thanh máu
    }

    // Hàm kiểm tra xem người chơi còn sống hay không
    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    // Khi va chạm với đối tượng có tag "Enemy", giảm máu
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Giảm máu khi va chạm với Enemy
            TakeDamage(10f); // Giảm 10 máu khi va chạm
            //explosion.Play();
            //StartCoroutine(ScreenShake.Shake());
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Switch"))
        {
            cameraM.SetActive(false);
            cameraP.SetActive(true);
            StartCoroutine(ResetCameraAfterDelay(3f)); // Đặt thời gian quay lại camera
        }
    }

    private IEnumerator ResetCameraAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Chờ trong khoảng thời gian delay
        cameraP.SetActive(false); // Tắt camera phụ
        cameraM.SetActive(true); // Bật lại camera chính
    }
}
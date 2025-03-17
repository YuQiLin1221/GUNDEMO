using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Reference tới UI Slider (Thanh máu)

    // Cập nhật thanh máu theo giá trị hiện tại
    public void SetHealth(float health)
    {
        healthSlider.value = health;  // Cập nhật giá trị thanh máu
    }

    // Cập nhật thanh máu tối đa khi bắt đầu trò chơi
    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health; // Thiết lập giá trị tối đa
        healthSlider.value = health;    // Đặt giá trị thanh máu bằng giá trị tối đa
    }
}

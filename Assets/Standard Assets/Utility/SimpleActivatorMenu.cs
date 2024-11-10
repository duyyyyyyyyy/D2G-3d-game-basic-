using System;
using UnityEngine;
using UnityEngine.UI; // Thêm dòng này

namespace UnityStandardAssets.Utility
{
    public class SimpleActivatorMenu : MonoBehaviour
    {
        // Một menu rất đơn giản khi nhận tham chiếu đến các GameObject trong scene
        public Text camSwitchButton; // Thay GUIText bằng Text
        public GameObject[] objects;

        private int m_CurrentActiveObject;

        private void OnEnable()
        {
            // active object bắt đầu từ đối tượng đầu tiên trong mảng
            m_CurrentActiveObject = 0;
            camSwitchButton.text = objects[m_CurrentActiveObject].name;
        }

        public void NextCamera()
        {
            int nextActiveObject = m_CurrentActiveObject + 1 >= objects.Length ? 0 : m_CurrentActiveObject + 1;

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == nextActiveObject);
            }

            m_CurrentActiveObject = nextActiveObject;
            camSwitchButton.text = objects[m_CurrentActiveObject].name;
        }
    }
}

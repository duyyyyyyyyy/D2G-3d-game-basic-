using System;
using UnityEngine;
using UnityEngine.UI; // Thêm dòng này

namespace UnityStandardAssets.Utility
{
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        const string display = "{0} FPS";
        [SerializeField] private Text m_Text; // Thay GUIText bằng Text và thêm SerializeField để gắn trong Inspector

        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
        }

        private void Update()
        {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int)(m_FpsAccumulator / fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                if (m_Text != null) // Kiểm tra nếu m_Text đã được gán
                {
                    m_Text.text = string.Format(display, m_CurrentFps);
                }
            }
        }
    }
}

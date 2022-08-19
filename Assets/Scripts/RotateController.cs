using UnityEngine;
using UnityEngine.UI;

public class RotateController : MonoBehaviour
{
    private float m_Velocity;
    private float m_Max;

    public Text m_UI;

    public float Velocity {
        get { return m_Velocity; }
        set {
            m_Velocity = value;
            m_Max = value;
        }
    }

    private void Update() {
        if(!Mathf.Approximately(m_Velocity, 0f)) {
            Rotate();
            float inchValue = InchingFun(1 - m_Velocity / m_Max);
            bool plus = m_Velocity > 0;
            if(plus)
                m_Velocity -= inchValue;
            else
                m_Velocity += inchValue;

            if(m_Velocity > 0 != plus)
                m_Velocity = 0;
        } else {
            m_Velocity = 0;
        }
    }

    private void FixedUpdate() {
        float speed = 60 / 0.02f * m_Velocity / 360;
        m_UI.text = Mathf.Abs((int)speed) + "/min";
    }

    private void Rotate() {
        transform.Rotate(Vector3.forward, m_Velocity, Space.Self);
    }

    private float InchingFun(float pro) {
        //return (4 - time * time) * 0.04f;
        return Mathf.Pow(0.003f, pro);
    }
}

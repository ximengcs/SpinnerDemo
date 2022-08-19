using UnityEngine;

public class InputChecker : MonoBehaviour {
    public RotateController m_Target;

    private const float GAP = 0.1f;
    private const float MAXFORCE = 30;
    private float m_Time = 0.1f;
    private Vector2 m_Point;

    private void Update() {
        if(Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)) {
            if(m_Time <= 0) {
                float force = Input.mousePosition.x - m_Point.x;
                To(force * 0.1f);
                m_Time = GAP;
                m_Point = Input.mousePosition;
            }
            else
                m_Time -= Time.deltaTime;
        } else if(Input.GetMouseButtonUp(0)) {
            To(Input.mousePosition.x - m_Point.x + m_Target.Velocity);
            m_Time = GAP;
        }
    }

    private void To(float force) {
        if(force > 0)
            force = Mathf.Min(force, MAXFORCE);
        else
            force = Mathf.Max(force, -MAXFORCE);
        m_Target.Velocity = force;
    }
}

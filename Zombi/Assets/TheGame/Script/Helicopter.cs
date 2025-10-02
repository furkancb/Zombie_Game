using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField]
    float _secondsToLand = 180.0f;

    private Animation _animation;

    void Start()
    {
        _animation = GetComponent<Animation>();

        _animation["Flying"].wrapMode = WrapMode.Loop;
        _animation["Landed"].wrapMode = WrapMode.ClampForever;
        _animation["Landing"].wrapMode = WrapMode.ClampForever;

        _animation.Blend("Landing", 1.0f, 0.01f);
        _animation.Blend("Flying", 1.0f, 0.01f);

        _animation["Landing"].speed = 0;

        Invoke("Land", _secondsToLand);
    }

    public void Land()
    {
        _animation["Landing"].speed = 1;
    }

    void Update()
    {
        if (_animation["Landing"].normalizedTime >= 1.0f)
        {
            _animation.Blend("Landed", 1.0f, 0.01f);
        }
    }
}

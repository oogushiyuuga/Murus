using UnityEngine;

public class SpotLight : MonoBehaviour
{
    [Header("動きの強さ")]
    [SerializeField] private float rangeX = 20f; // 左右の振れ幅
    [SerializeField] private float rangeY = 20f; // 上下の振れ幅

    [Header("動きの速さ")]
    [SerializeField] private float speed = 0.5f;

    private Vector3 initialRotation;
    private float seedX;
    private float seedY;

    void Start()
    {
        // 最初の向きを保存
        initialRotation = transform.localEulerAngles;
        
        // 毎回違う動きにするためのランダムな初期値
        seedX = Random.Range(0f, 100f);
        seedY = Random.Range(0f, 100f);
    }

    void Update()
    {
        // パーリンノイズで -1.0 ～ 1.0 の値を作る
        // (PerlinNoiseは0~1を返すので、0.5引いて2倍することで-1~1にする)
        float noiseX = Mathf.PerlinNoise(Time.time * speed, seedX) * 2f - 1f;
        float noiseY = Mathf.PerlinNoise(Time.time * speed, seedY) * 2f - 1f;

        // 回転を計算
        float rotX = initialRotation.x + (noiseX * rangeX);
        float rotY = initialRotation.y + (noiseY * rangeY);

        transform.localRotation = Quaternion.Euler(rotX, rotY, initialRotation.z);
    }
}
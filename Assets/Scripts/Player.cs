using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float padding = 0.6f;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    void Start()
    {
        this.InitializeCoordinates();
    }

    private void InitializeCoordinates()
    {
        Camera camera = Camera.main;
        Vector3 leftBottom = camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightTop = camera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        this.xMin = leftBottom.x + this.padding;
        this.xMax = rightTop.x - this.padding;

        this.yMin = leftBottom.y + this.padding;
        this.yMax = rightTop.y - this.padding;
    }

    void Update()
    {
        this.MovePlayer();
    }

    private void MovePlayer()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * this.moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * this.moveSpeed;

        base.transform.position = new Vector2(
            Mathf.Clamp(base.transform.position.x + deltaX, this.xMin, this.xMax),
            Mathf.Clamp(base.transform.position.y + deltaY, this.yMin, this.yMax));
    }
}

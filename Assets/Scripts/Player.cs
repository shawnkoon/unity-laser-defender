using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float padding = 0.6f;
    [SerializeField]
    private GameObject lazerPrefab;
    [SerializeField]
    private float lazerSpeed = 10f;
    [SerializeField]
    private float lazerFiringPeriod = 0.1f;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private Coroutine firingCoroutine;

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
        this.FireLazer();
    }

    private void FireLazer()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.firingCoroutine = base.StartCoroutine(this.FireContinuously());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            base.StopCoroutine(this.firingCoroutine);
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject lazer = Object.Instantiate(this.lazerPrefab, this.transform.position, Quaternion.identity);
            lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.lazerSpeed);
            yield return new WaitForSeconds(this.lazerFiringPeriod);
        }
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

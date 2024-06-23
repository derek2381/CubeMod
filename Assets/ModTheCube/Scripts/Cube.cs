using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float min = 50f;
    public float max = 300f;

    private float speed;

    void Start()
    {
        // transform.position = new Vector3(3, 4, 1);
        // transform.localScale = Vector3.one * 1.3f;
        // RandomScale();
        InvokeRepeating("RandomPosition", 0f, 5f);
        InvokeRepeating("RandomScale", 0f, 5f);

        // Material material = Renderer.material;

        // material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
        InvokeRepeating("RandomColor", 0f, 5f);
        InvokeRepeating("RandomRotation", 0f, 5f);

        StartCoroutine(ChangeSpeeRandomly());
    }

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime*100, 0.0f, 0.0f);
    }

    // random Scale of the cube
    void RandomScale(){
      float min = 1f;
      float max = 5f;
      float val = UnityEngine.Random.Range(min, max);

      transform.localScale = Vector3.one * val;
    }

    // random position of the cube
    void RandomPosition(){
      float min = 1f;
      float max = 5f;

      float x  = UnityEngine.Random.Range(min, max);
      float y  = UnityEngine.Random.Range(min, max);
      float z  = UnityEngine.Random.Range(min, max);

      transform.position = new Vector3(x, y, z);
    }

    // random color of the cubde
    void RandomColor(){
      float min = 0f;
      float max = 1f;

      float r = UnityEngine.Random.Range(min, max);
      float b = UnityEngine.Random.Range(min, max);
      float g = UnityEngine.Random.Range(min, max);
      float t = UnityEngine.Random.Range(min, max);

      Material material = Renderer.material;
      material.color = new Color(r, g, b, t);
    }

    // random rotation of the Cube
    void RandomRotation(){
      int min = 0;
      int max = 180;

      int x = UnityEngine.Random.Range(min, max);
      int y = UnityEngine.Random.Range(min, max);
      int z = UnityEngine.Random.Range(min, max);

      transform.rotation = Quaternion.Euler(x, y, z);
    }

    IEnumerator ChangeSpeeRandomly(){
      while(true){
        speed = UnityEngine.Random.Range(min, max);

        yield return new WaitForSeconds(5f);
      }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject jogador;
    public GameObject Camera1;
    public float DistanciaDaCamera;

    // Update is called once per frame
    void Update()
    {
        Camera1.transform.position = new Vector3(jogador.transform.position.x, jogador.transform.position.y, jogador.transform.position.z - DistanciaDaCamera);
    }
}

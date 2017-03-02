﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosmaMove : MonoBehaviour {

    public float velocidadeHorizontal;
    public float velocidadeVertical;
    public float min;
    public float max;
    public float espera;

    void Start() {
        StartCoroutine(Move(max));
    }

    void Update() {
        Vector3 velocidadeVetorial = Vector3.left * velocidadeHorizontal;

        transform.position = transform.position + velocidadeVetorial * Time.deltaTime;
    }

    IEnumerator Move(float destino){

        while (Mathf.Abs(destino - transform.localPosition.y) > 0.2f) {
            Vector3 direcao = (destino == max) ? Vector3.up : Vector3.down;
            Vector3 velocidadeVetorial = direcao * velocidadeVertical;
            transform.localPosition = transform.localPosition + velocidadeVetorial * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(espera);

        destino = (destino == max) ? min : max;

        StartCoroutine(Move(destino));
    }
}

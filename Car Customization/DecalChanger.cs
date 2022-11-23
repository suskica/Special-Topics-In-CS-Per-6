using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalChanger : MonoBehaviour
{
    public Material carMaterial;
    
    void Start(){
        
    }

    public void changeTexture(Texture texture) {
        carMaterial.SetTexture("_MainTex", texture);
    }
}

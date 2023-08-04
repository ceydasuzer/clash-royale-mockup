using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manaManager : MonoBehaviour
{
    public int currentMana = 0;
    public int maxMana = 10;
    public SliderJoint2D manaSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
        UpdateManaSlider();
    }

    private void UpdateManaSlider()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

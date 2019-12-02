using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Day1 : MonoBehaviour
{
    public TextMeshProUGUI consoleText;
    public Slider fuelSlider;
    public Slider massSlider;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI massText;

    private List<int> _modules = new List<int>
    {
        98541,
        129056,
        134974,
        66390,
        121382,
        94570,
        107586,
        98767,
        65101,
        56320,
        63431,
        112200,
        119262,
        142745,
        143941,
        148764,
        70301,
        149623,
        125170,
        114562,
        136701,
        76971,
        52292,
        127671,
        107547,
        77460,
        55268,
        119986,
        104257,
        82814,
        64527,
        74279,
        98542,
        54710,
        96317,
        105670,
        146248,
        134587,
        104028,
        65286,
        91788,
        106723,
        137825,
        139949,
        74403,
        106574,
        133990,
        96165,
        121316,
        94072,
        76612,
        109470,
        147556,
        113157,
        67117,
        85237,
        134232,
        94622,
        76160,
        107532,
        120637,
        51505,
        82847,
        105600,
        97719,
        113114,
        68177,
        149213,
        116125,
        145577,
        83921,
        134810,
        138804,
        90125,
        70621,
        103245,
        51584,
        93437,
        125352,
        100578,
        53497,
        112023,
        92999,
        107998,
        148030,
        101185,
        65777,
        92272,
        145846,
        81488,
        61957,
        69551,
        125625,
        146328,
        123666,
        102629,
        121996,
        94172,
        128023,
        123472,
    };

    // 80 is when the top of the text area is underground.
    private float _textOffset = 80;
    private float _speedScale = 1.0f;

    void Start()
    {
        consoleText.text = "...";
        SetVertical(_textOffset);

        StartCoroutine(RunScroll());
        StartCoroutine(RunPuzzle());
    }

    private IEnumerator RunScroll()
    {
        while (true) {
            yield return new WaitForFixedUpdate();
            _textOffset -= 0.25f * _speedScale;
            SetVertical(_textOffset);
        }
    }
    
    private IEnumerator RunPuzzle()
    {
        var totalFuel = 0;
        var totalMass = 0;
        
        yield return new WaitForSeconds(3.0f / _speedScale);
        foreach (var module in _modules)
        {
            yield return new WaitForSeconds(0.2f / _speedScale);
            consoleText.text += $"\n{module} -> ";
            totalMass += module;
            massSlider.value = totalMass;
            massText.text = $"{totalMass:n0}";
            
            yield return new WaitForSeconds(0.55f / _speedScale);
            var answer = (int) (Mathf.Floor(module / 3.0f)) - 2;
            totalFuel += answer;
            consoleText.text += answer;
            fuelSlider.value = totalFuel;
            fuelText.text = $"{totalFuel:n0}";
            
            _speedScale += 0.2f;
        }
        
        yield return new WaitForSeconds(1);
        
        Debug.Log(totalFuel);
    }

    void SetVertical(float v)
    {
        var r = consoleText.rectTransform.anchoredPosition;
        r.y = -v;
        consoleText.rectTransform.anchoredPosition = r;
    }
}
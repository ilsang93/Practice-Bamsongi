using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    [SerializeField] private GameObject bamsongiPrefab;
    [SerializeField] private GameObject generatePosObj;
    private Vector3 GeneratePos
    {
        get
        {
            return generatePosObj.transform.position;
        }
    }

    private Vector2 throwDirection;
    private Vector2 beforeMousePos, afterMousPos;
    private BamsongiController nowBamController;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 클릭 지점 방식
        // if (Input.GetMouseButtonDown(0)) {
        //     nowBamController = Instantiate(bamsongiPrefab, GeneratePos, Quaternion.identity).GetComponent<BamsongiController>();

        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     Vector3 worldDir = ray.direction;

        //     nowBamController.Shoot(worldDir.normalized * 2000);
        // }

        // 드래그 방식
        if (Input.GetMouseButtonDown(0))
        {
            nowBamController = Instantiate(bamsongiPrefab, GeneratePos, Quaternion.identity).GetComponent<BamsongiController>();
            nowBamController.GetComponent<Rigidbody>().isKinematic = true;
            beforeMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            afterMousPos = Input.mousePosition;
            Vector2 dir = (afterMousPos - beforeMousePos).normalized;
            float distance = Vector2.Distance(afterMousPos, beforeMousePos);
            nowBamController.GetComponent<Rigidbody>().isKinematic = false;
            print(distance);
            nowBamController.Shoot(new Vector3(dir.x, dir.y, 1) * distance);
            nowBamController = null;
        }
    }
}

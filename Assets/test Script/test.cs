using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通过点选多材质物体 查找点击位置对应材质
/// 物体需具备Mesh Collider
/// 
/// Get hitpoint material for multi-material obj
/// Need Mesh Collider!
/// </summary>
public class test : MonoBehaviour
{
    private Renderer m_Renderer;
    private RaycastHit hit;
    private Mesh mesh;
    private int index;
    private int submesh_num;
    private int i;

    void Awake()
    {

    }
    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            //find submesh number

            m_Renderer = hit.transform.gameObject.GetComponent<Renderer>();
            index = hit.triangleIndex;
            Debug.Log("index:" + hit.triangleIndex);

            mesh = hit.transform.GetComponent<MeshFilter>().mesh;
            
            for (i = 0; i < mesh.subMeshCount; i++)
            {
                if (index * 3 >= mesh.GetIndexStart(i))
                {
                    submesh_num = i;
                }
                else
                {
                    submesh_num = i - 1;
                    break;
                }
            }

            //chang color
            m_Renderer.materials[submesh_num].color = Color.black;
        }
    }
}

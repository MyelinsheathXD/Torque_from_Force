using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localpTor : MonoBehaviour
{
    public GameObject trans, trans2;
    public ArticulationBody mart;
    public float WWtorque=10f;

    public float ZZ,XX,YY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(trans.transform.position, trans2.transform.position, Color.cyan);
        DrawPoint(Vector3.zero, 10f);
        DrawPoint(trans.transform.position,0.2f);
        DrawPoint(trans2.transform.position, 0.2f);


        projectTZ(trans, trans2);
        projectTX(trans, trans2);
        projectTY(trans, trans2);
          





        FangleZ(trans, trans2);
        FangleX(trans, trans2);
        FangleY(trans, trans2);



        Vector3 tdir = (trans2.transform.position - trans.transform.position).normalized;

        Debug.DrawLine(trans.transform.position, trans.transform.position + tdir, Color.black);

        
        

        Vector3 kk= new Vector3(Mathf.Sin(XX * Mathf.Deg2Rad) , Mathf.Sin(YY * Mathf.Deg2Rad), Mathf.Sin(ZZ * Mathf.Deg2Rad) );

        /////Main Torque force aplied here///////////////
        mart.AddTorque(kk * WWtorque);


        //mart.AddForceAtPosition(tdir * WWtorque, trans.transform.position);

        

    }


    

    void DrawPoint(Vector3 wpos)
    {
        float ww = 0.3f;
        Debug.DrawLine(wpos - Vector3.forward*ww, wpos - Vector3.back*ww);

        Debug.DrawLine(wpos - Vector3.left * ww, wpos - Vector3.right * ww);
        Debug.DrawLine(wpos - Vector3.up * ww, wpos - Vector3.down * ww);
    }

    void DrawPoint(Vector3 wpos,float ww)
    {
        
        Debug.DrawLine(wpos - Vector3.forward * ww, wpos - Vector3.back * ww);

        Debug.DrawLine(wpos - Vector3.left * ww, wpos - Vector3.right * ww);
        Debug.DrawLine(wpos - Vector3.up * ww, wpos - Vector3.down * ww);
    }

    void DrawPoint(Vector3 wpos,Color cc)
    {

        
        float ww = 0.3f;
        Debug.DrawLine(wpos - Vector3.forward * ww, wpos - Vector3.back * ww,cc);

        Debug.DrawLine(wpos - Vector3.left * ww, wpos - Vector3.right * ww,cc);
        Debug.DrawLine(wpos - Vector3.up * ww, wpos - Vector3.down * ww,cc);
    }




    void projectTZ(GameObject TTT, GameObject TTT2)
    {
        Vector3 zzz = new Vector3(TTT.transform.position.x, TTT.transform.position.y, 0);
        DrawPoint(zzz,Color.blue);


        Vector3 zzz2 = new Vector3(TTT2.transform.position.x, TTT2.transform.position.y, 0);
        DrawPoint(zzz2, Color.blue);


        Debug.DrawLine(zzz, zzz2, Color.black);
    }


    void projectTX(GameObject TTT, GameObject TTT2)
    {
        Vector3 xxx = new Vector3(0, TTT.transform.position.y, TTT.transform.position.z);
        DrawPoint(xxx,Color.red);


        Vector3 xxx2 = new Vector3(0,TTT2.transform.position.y, TTT2.transform.position.z);
        DrawPoint(xxx2, Color.red);

        Debug.DrawLine(xxx, xxx2, Color.black);
    }



    void projectTY(GameObject TTT, GameObject TTT2)
    {
        Vector3 yyy = new Vector3( TTT.transform.position.x,0, TTT.transform.position.z);
        DrawPoint(yyy, Color.green);


        Vector3 yyy2 = new Vector3( TTT2.transform.position.x,0, TTT2.transform.position.z);
        DrawPoint(yyy2, Color.green);

        Debug.DrawLine(yyy, yyy2, Color.black);

    }

    void FangleZ(GameObject trans,GameObject trans2)
    {
        Vector2 a = new Vector2(trans2.transform.position.x - trans.transform.position.x, trans2.transform.position.y - trans.transform.position.y);

        ZZ = Vector2.SignedAngle(new Vector2(trans.transform.position.x, trans.transform.position.y), a);
    }

    void FangleX(GameObject trans, GameObject trans2)
    {
        Vector2 b = new Vector2(trans2.transform.position.y - trans.transform.position.y, trans2.transform.position.z - trans.transform.position.z);

        XX = Vector2.SignedAngle(new Vector2(trans.transform.position.y, trans.transform.position.z), b);
    }

    void FangleY(GameObject trans, GameObject trans2)
    {
        Vector2 b = new Vector2(trans2.transform.position.z - trans.transform.position.z, trans2.transform.position.x - trans.transform.position.x);

        YY = Vector2.SignedAngle(new Vector2(trans.transform.position.z, trans.transform.position.x), b);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localpTor : MonoBehaviour
{
    public GameObject trans, trans2;
    public ArticulationBody mart;

    GameObject Part;
    public float WWtorque=10f;

    public float ZZ,XX,YY;
    void Start()
    {
        Part = mart.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(trans.transform.position, trans2.transform.position, Color.cyan);
        DrawPoint(Part.transform.position, 10f);
        DrawPoint(trans.transform.position,0.2f);
        DrawPoint(trans2.transform.position, 0.2f);


        projectTZ(trans, trans2);
        projectTX(trans, trans2);
        projectTY(trans, trans2);
          





        FangleZ(trans, trans2);
        FangleX(trans, trans2);
        FangleY(trans, trans2);



        //CNVFtoTorque(trans, trans2, WWtorque);




    }

    void FixedUpdate()
    {
        CNVFtoTorque(trans, trans2, WWtorque);
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
        Vector3 Ploc1 = Part.transform.InverseTransformPoint(TTT.transform.position);
        Vector3 Ploc2 = Part.transform.InverseTransformPoint(TTT2.transform.position);


        Vector3 zzz = new Vector3(TTT.transform.position.x, TTT.transform.position.y, Part.transform.position.z);
        
        DrawPoint(zzz,Color.blue);


        Vector3 zzz2 = new Vector3(TTT2.transform.position.x, TTT2.transform.position.y, Part.transform.position.z);

       
        DrawPoint(zzz2, Color.blue);


        Debug.DrawLine(zzz, zzz2, Color.black);
    }


    void projectTX(GameObject TTT, GameObject TTT2)
    {
        Vector3 xxx = new Vector3(Part.transform.position.x, TTT.transform.position.y, TTT.transform.position.z);
        DrawPoint(xxx,Color.red);


        Vector3 xxx2 = new Vector3(Part.transform.position.x,TTT2.transform.position.y, TTT2.transform.position.z);
        DrawPoint(xxx2, Color.red);

        Debug.DrawLine(xxx, xxx2, Color.black);
    }



    void projectTY(GameObject TTT, GameObject TTT2)
    {
        Vector3 yyy = new Vector3( TTT.transform.position.x,Part.transform.position.y, TTT.transform.position.z);
        DrawPoint(yyy, Color.green);


        Vector3 yyy2 = new Vector3( TTT2.transform.position.x, Part.transform.position.y, TTT2.transform.position.z);
        DrawPoint(yyy2, Color.green);

        Debug.DrawLine(yyy, yyy2, Color.black);

    }

    void FangleZ(GameObject trans,GameObject trans2)
    {
        Vector2 a = new Vector2(trans2.transform.position.x - trans.transform.position.x, trans2.transform.position.y - trans.transform.position.y);


        Vector2 Orig = new Vector2(Part.transform.position.x, Part.transform.position.y);
        ZZ = Vector2.SignedAngle(new Vector2(trans.transform.position.x, trans.transform.position.y) - Orig, a);
    }

    void FangleX(GameObject trans, GameObject trans2)
    {
        Vector2 b = new Vector2(trans2.transform.position.y - trans.transform.position.y, trans2.transform.position.z - trans.transform.position.z);
        Vector2 Orig = new Vector2(Part.transform.position.y, Part.transform.position.z);
        XX = Vector2.SignedAngle(new Vector2(trans.transform.position.y, trans.transform.position.z) - Orig,  b );
    }

    void FangleY(GameObject trans, GameObject trans2)
    {
        Vector2 b = new Vector2(trans2.transform.position.z - trans.transform.position.z, trans2.transform.position.x - trans.transform.position.x);
        Vector2 Orig = new Vector2(Part.transform.position.z, Part.transform.position.x);
        YY = Vector2.SignedAngle(new Vector2(trans.transform.position.z, trans.transform.position.x) - Orig, b );
    }




    public void CNVFtoTorque(GameObject ttrans, GameObject ttrans2, float WWTTorque)
    {

        Vector3 Orig = new Vector3(Part.transform.position.x, Part.transform.position.y,Part.transform.position.z);

        Vector3 tdir =(ttrans2.transform.position - ttrans.transform.position).normalized;
        Vector3 tdir2 = ttrans.transform.position + tdir;



        Vector2 px, py, pz;
        pz = new Vector2(tdir2.x - tdir.x, tdir2.y - tdir.y);
        px = new Vector2(tdir2.y - tdir.y, tdir2.x - tdir.x);
        py = new Vector2(tdir2.z - tdir.z, tdir2.x - tdir.x);


        Vector3 pp = new Vector3(Mathf.Sin(XX * Mathf.Deg2Rad) * px.magnitude, Mathf.Sin(YY * Mathf.Deg2Rad) * py.magnitude, Mathf.Sin(ZZ * Mathf.Deg2Rad) * pz.magnitude);

        mart.AddTorque(pp * WWTTorque);
        
        //mart.AddForceAtPosition(tdir * WWtorque, trans.transform.position);
    }
}

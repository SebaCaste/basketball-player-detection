using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class multiplepeople : MonoBehaviour
{
    public GameObject dot;
    public class myComparer : IComparer
    {
        int IComparer.Compare(object xx, object yy)
        {
            Persona x =(Persona)xx;
            Persona y = (Persona)yy;
            return x.dis.CompareTo(y.dis);
        }
    }
    string path;
    string savePath;
    int i = 0;
    private int Numdots = 14;
    //
    public int numPeople = 1;////SEBA2 
    private GameObject[,] selectorPeople;
    public List<Persona> riferimento = new List<Persona>();
    public List<Persona> test = new List<Persona>();


    // public GameObject[][] dots;//persone //punti
    //public GameObject[][] bones = new GameObject[13][];//persone //cilindri

    public List<Frame> frames = new List<Frame>();
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/" + "21-35-23_tentetivo3r.json";
        //path = Application.persistentDataPath + "/" + "ominoBiancoSbagliato.json";
        //savePath = Application.persistentDataPath + "/" + "utilizza.json";
        string contents = System.IO.File.ReadAllText(path);
        acquisisci_frame(contents);
        Debug.Log("finqui ci arrivoo1oo");
        //Acquisizione frame per frame dal json
        calcoladis();/////////////////////
        riferimento = IsolaMovimentoDaRilevare(frames, 70);//riferimento per i test
        //test= IsolaMovimentoDaRilevare(frames, 180);//test/////////////////
        //Debug.Log(riferimento[0].joint_1+" rife "+riferimento[1].joint_1);
        //ordinaFrames();
        // IdPersona();
        // difId();
        // IdPersona();
        // IdPersona();
        //Debug.Log(IsolaMovimentoDaRilevare(frames, 50).Count+"");

        //contents = System.IO.File.ReadAllText(savePath);
        //acquisisci_frame(contents);
        dot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        dot.transform.localScale = new Vector3(0.1f ,0.1f ,0.1f);
        GameObject go = Instantiate(dot) as GameObject;
        selectorPeople = new GameObject[numPeople,Numdots];
        for (int i_ = 0; i_ < numPeople; i_++)
        {
           // Debug.Log("finqui ci arrivo");
            for (int j=0; j < Numdots;j++)
            {
                    go =  Instantiate(dot) as GameObject;
                if (i_ == 0) { go.GetComponent<Renderer>().material.color = new Color(1, 0, 1, 1); }
                if (i_ == 1) { go.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1); }
                if (i_ == 2) { go.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1); }
                if (i_ == 3) { go.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 1); }
                if (i_ == 4) { go.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1); }
                if (i_ == 5) { go.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1); }
                if (i_ == 6) { go.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 1); } 
                if (i_ == 7) { go.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1); }
                if (i_ == 8) { go.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1); }
                if (i_ == 9) { go.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1); }
                if (i_ == 10) { go.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1); }
                if (i_ == 11) { go.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1); }
                selectorPeople[i_,j] = go;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        int frame = frames.Count;//stampa frame corrente
        frame = riferimento.Count;
        //if (test.Count < frame) { frame = test.Count; }
        //Debug.Log(frame + "conto frame");
        if (i < frame)
        {
            //Debug.Log("finqui ci arrivo"+riferimento[i].joint_1.x+" rif" );
            /*
            selectorPeople[0, 0].transform.position = new Vector3(riferimento[i].joint_1.x, riferimento[i].joint_1.y, riferimento[i].joint_1.z);
            selectorPeople[0, 1].transform.position = new Vector3(riferimento[i].joint_2.x, riferimento[i].joint_2.y, riferimento[i].joint_2.z);
            selectorPeople[0, 2].transform.position = new Vector3(riferimento[i].joint_3.x, riferimento[i].joint_3.y, riferimento[i].joint_3.z);
            selectorPeople[0, 3].transform.position = new Vector3(riferimento[i].joint_4.x, riferimento[i].joint_4.y, riferimento[i].joint_4.z);
            selectorPeople[0, 4].transform.position = new Vector3(riferimento[i].joint_5.x, riferimento[i].joint_5.y, riferimento[i].joint_5.z);
            selectorPeople[0, 5].transform.position = new Vector3(riferimento[i].joint_6.x, riferimento[i].joint_6.y, riferimento[i].joint_6.z);
            selectorPeople[0, 6].transform.position = new Vector3(riferimento[i].joint_7.x, riferimento[i].joint_7.y, riferimento[i].joint_7.z);
            selectorPeople[0, 7].transform.position = new Vector3(riferimento[i].joint_8.x, riferimento[i].joint_8.y, riferimento[i].joint_8.z);
            selectorPeople[0, 8].transform.position = new Vector3(riferimento[i].joint_9.x, riferimento[i].joint_9.y, riferimento[i].joint_9.z);
            selectorPeople[0, 9].transform.position = new Vector3(riferimento[i].joint_10.x, riferimento[i].joint_10.y, riferimento[i].joint_10.z);
            selectorPeople[0, 10].transform.position = new Vector3(riferimento[i].joint_11.x, riferimento[i].joint_11.y, riferimento[i].joint_11.z);
            selectorPeople[0, 11].transform.position = new Vector3(riferimento[i].joint_12.x, riferimento[i].joint_12.y, riferimento[i].joint_12.z);
            selectorPeople[0, 12].transform.position = new Vector3(riferimento[i].joint_13.x, riferimento[i].joint_13.y, riferimento[i].joint_13.z);
            selectorPeople[0, 13].transform.position = new Vector3((riferimento[i].joint_16.x + riferimento[i].joint_17.x) / 2, (riferimento[i].joint_16.y + riferimento[i].joint_17.y) / 2, (riferimento[i].joint_16.z + riferimento[i].joint_17.z) / 2);
            */
            /*
            selectorPeople[1, 0].transform.position = new Vector3(test[i].joint_1.x, test[i].joint_1.y, test[i].joint_1.z);
            selectorPeople[1, 1].transform.position = new Vector3(test[i].joint_2.x, test[i].joint_2.y, test[i].joint_2.z);
            selectorPeople[1, 2].transform.position = new Vector3(test[i].joint_3.x, test[i].joint_3.y, test[i].joint_3.z);
            selectorPeople[1, 3].transform.position = new Vector3(test[i].joint_4.x, test[i].joint_4.y, test[i].joint_4.z);
            selectorPeople[1, 4].transform.position = new Vector3(test[i].joint_5.x, test[i].joint_5.y, test[i].joint_5.z);
            selectorPeople[1, 5].transform.position = new Vector3(test[i].joint_6.x, test[i].joint_6.y, test[i].joint_6.z);
            selectorPeople[1, 6].transform.position = new Vector3(test[i].joint_7.x, test[i].joint_7.y, test[i].joint_7.z);
            selectorPeople[1, 7].transform.position = new Vector3(test[i].joint_8.x, test[i].joint_8.y, test[i].joint_8.z);
            selectorPeople[1, 8].transform.position = new Vector3(test[i].joint_9.x, test[i].joint_9.y, test[i].joint_9.z);
            selectorPeople[1, 9].transform.position = new Vector3(test[i].joint_10.x, test[i].joint_10.y, test[i].joint_10.z);
            selectorPeople[1, 10].transform.position = new Vector3(test[i].joint_11.x, test[i].joint_11.y, test[i].joint_11.z);
            selectorPeople[1, 11].transform.position = new Vector3(test[i].joint_12.x, test[i].joint_12.y, test[i].joint_12.z);
            selectorPeople[1, 12].transform.position = new Vector3(test[i].joint_13.x, test[i].joint_13.y, test[i].joint_13.z);
            selectorPeople[1, 13].transform.position = new Vector3((test[i].joint_16.x + test[i].joint_17.x) / 2, (test[i].joint_16.y + test[i].joint_17.y) / 2, (test[i].joint_16.z + test[i].joint_17.z) / 2);

            */
                        if (numPeople>9 && frames[i].person_9 != null)
                                { 
                                //person9
                                selectorPeople[9, 0].transform.position = new Vector3(frames[i].person_9.joint_1.x, frames[i].person_9.joint_1.y, frames[i].person_9.joint_1.z);
                                selectorPeople[9, 1].transform.position = new Vector3(frames[i].person_9.joint_2.x, frames[i].person_9.joint_2.y, frames[i].person_9.joint_2.z);
                                selectorPeople[9, 2].transform.position = new Vector3(frames[i].person_9.joint_3.x, frames[i].person_9.joint_3.y, frames[i].person_9.joint_3.z);
                                selectorPeople[9, 3].transform.position = new Vector3(frames[i].person_9.joint_4.x, frames[i].person_9.joint_4.y, frames[i].person_9.joint_4.z);
                                selectorPeople[9, 4].transform.position = new Vector3(frames[i].person_9.joint_5.x, frames[i].person_9.joint_5.y, frames[i].person_9.joint_5.z);
                                selectorPeople[9, 5].transform.position = new Vector3(frames[i].person_9.joint_6.x, frames[i].person_9.joint_6.y, frames[i].person_9.joint_6.z);
                                selectorPeople[9, 6].transform.position = new Vector3(frames[i].person_9.joint_7.x, frames[i].person_9.joint_7.y, frames[i].person_9.joint_7.z);
                                selectorPeople[9, 7].transform.position = new Vector3(frames[i].person_9.joint_8.x, frames[i].person_9.joint_8.y, frames[i].person_9.joint_8.z);
                                selectorPeople[9, 8].transform.position = new Vector3(frames[i].person_9.joint_9.x, frames[i].person_9.joint_9.y, frames[i].person_9.joint_9.z);
                                selectorPeople[9, 9].transform.position = new Vector3(frames[i].person_9.joint_10.x, frames[i].person_9.joint_10.y, frames[i].person_9.joint_10.z);
                                selectorPeople[9, 10].transform.position = new Vector3(frames[i].person_9.joint_11.x, frames[i].person_9.joint_11.y, frames[i].person_9.joint_11.z);
                                selectorPeople[9, 11].transform.position = new Vector3(frames[i].person_9.joint_12.x, frames[i].person_9.joint_12.y, frames[i].person_9.joint_12.z);
                                selectorPeople[9, 12].transform.position = new Vector3(frames[i].person_9.joint_13.x, frames[i].person_9.joint_13.y, frames[i].person_9.joint_13.z);
                                selectorPeople[9, 13].transform.position = new Vector3((frames[i].person_9.joint_16.x + frames[i].person_9.joint_17.x) / 2, (frames[i].person_9.joint_16.y + frames[i].person_9.joint_17.y) / 2, (frames[i].person_9.joint_16.z + frames[i].person_9.joint_17.z) / 2);
                                }
                            if(numPeople>8 && frames[i].person_8 != null)
                                {
                                    //person8
                                    selectorPeople[8, 0].transform.position = new Vector3(frames[i].person_8.joint_1.x, frames[i].person_8.joint_1.y, frames[i].person_8.joint_1.z);
                                    selectorPeople[8, 1].transform.position = new Vector3(frames[i].person_8.joint_2.x, frames[i].person_8.joint_2.y, frames[i].person_8.joint_2.z);
                                    selectorPeople[8, 2].transform.position = new Vector3(frames[i].person_8.joint_3.x, frames[i].person_8.joint_3.y, frames[i].person_8.joint_3.z);
                                    selectorPeople[8, 3].transform.position = new Vector3(frames[i].person_8.joint_4.x, frames[i].person_8.joint_4.y, frames[i].person_8.joint_4.z);
                                    selectorPeople[8, 4].transform.position = new Vector3(frames[i].person_8.joint_5.x, frames[i].person_8.joint_5.y, frames[i].person_8.joint_5.z);
                                    selectorPeople[8, 5].transform.position = new Vector3(frames[i].person_8.joint_6.x, frames[i].person_8.joint_6.y, frames[i].person_8.joint_6.z);
                                    selectorPeople[8, 6].transform.position = new Vector3(frames[i].person_8.joint_7.x, frames[i].person_8.joint_7.y, frames[i].person_8.joint_7.z);
                                    selectorPeople[8, 7].transform.position = new Vector3(frames[i].person_8.joint_8.x, frames[i].person_8.joint_8.y, frames[i].person_8.joint_8.z);
                                    selectorPeople[8, 8].transform.position = new Vector3(frames[i].person_8.joint_9.x, frames[i].person_8.joint_9.y, frames[i].person_8.joint_9.z);
                                    selectorPeople[8, 9].transform.position = new Vector3(frames[i].person_8.joint_10.x, frames[i].person_8.joint_10.y, frames[i].person_8.joint_10.z);
                                    selectorPeople[8, 10].transform.position = new Vector3(frames[i].person_8.joint_11.x, frames[i].person_8.joint_11.y, frames[i].person_8.joint_11.z);
                                    selectorPeople[8, 11].transform.position = new Vector3(frames[i].person_8.joint_12.x, frames[i].person_8.joint_12.y, frames[i].person_8.joint_12.z);
                                    selectorPeople[8, 12].transform.position = new Vector3(frames[i].person_8.joint_13.x, frames[i].person_8.joint_13.y, frames[i].person_8.joint_13.z);
                                    selectorPeople[8, 13].transform.position = new Vector3((frames[i].person_8.joint_16.x + frames[i].person_8.joint_17.x) / 2, (frames[i].person_8.joint_16.y + frames[i].person_8.joint_17.y) / 2, (frames[i].person_8.joint_16.z + frames[i].person_8.joint_17.z) / 2);
                                }
                            if(numPeople>7 && frames[i].person_7 != null)
                                { 
                                //person7
                                selectorPeople[7, 0].transform.position = new Vector3(frames[i].person_7.joint_1.x, frames[i].person_7.joint_1.y, frames[i].person_7.joint_1.z);
                                selectorPeople[7, 1].transform.position = new Vector3(frames[i].person_7.joint_2.x, frames[i].person_7.joint_2.y, frames[i].person_7.joint_2.z);
                                selectorPeople[7, 2].transform.position = new Vector3(frames[i].person_7.joint_3.x, frames[i].person_7.joint_3.y, frames[i].person_7.joint_3.z);
                                selectorPeople[7, 3].transform.position = new Vector3(frames[i].person_7.joint_4.x, frames[i].person_7.joint_4.y, frames[i].person_7.joint_4.z);
                                selectorPeople[7, 4].transform.position = new Vector3(frames[i].person_7.joint_5.x, frames[i].person_7.joint_5.y, frames[i].person_7.joint_5.z);
                                selectorPeople[7, 5].transform.position = new Vector3(frames[i].person_7.joint_6.x, frames[i].person_7.joint_6.y, frames[i].person_7.joint_6.z);
                                selectorPeople[7, 6].transform.position = new Vector3(frames[i].person_7.joint_7.x, frames[i].person_7.joint_7.y, frames[i].person_7.joint_7.z);
                                selectorPeople[7, 7].transform.position = new Vector3(frames[i].person_7.joint_8.x, frames[i].person_7.joint_8.y, frames[i].person_7.joint_8.z);
                                selectorPeople[7, 8].transform.position = new Vector3(frames[i].person_7.joint_9.x, frames[i].person_7.joint_9.y, frames[i].person_7.joint_9.z);
                                selectorPeople[7, 9].transform.position = new Vector3(frames[i].person_7.joint_10.x, frames[i].person_7.joint_10.y, frames[i].person_7.joint_10.z);
                                selectorPeople[7, 10].transform.position = new Vector3(frames[i].person_7.joint_11.x, frames[i].person_7.joint_11.y, frames[i].person_7.joint_11.z);
                                selectorPeople[7, 11].transform.position = new Vector3(frames[i].person_7.joint_12.x, frames[i].person_7.joint_12.y, frames[i].person_7.joint_12.z);
                                selectorPeople[7, 12].transform.position = new Vector3(frames[i].person_7.joint_13.x, frames[i].person_7.joint_13.y, frames[i].person_7.joint_13.z);
                                selectorPeople[7, 13].transform.position = new Vector3((frames[i].person_7.joint_16.x + frames[i].person_7.joint_17.x) / 2, (frames[i].person_7.joint_16.y + frames[i].person_7.joint_17.y) / 2, (frames[i].person_7.joint_16.z + frames[i].person_7.joint_17.z) / 2);
                                 }
                            if(numPeople>6 && frames[i].person_6 != null)
                                { 
                                //person6
                                selectorPeople[6, 0].transform.position = new Vector3(frames[i].person_6.joint_1.x, frames[i].person_6.joint_1.y, frames[i].person_6.joint_1.z);
                                selectorPeople[6, 1].transform.position = new Vector3(frames[i].person_6.joint_2.x, frames[i].person_6.joint_2.y, frames[i].person_6.joint_2.z);
                                selectorPeople[6, 2].transform.position = new Vector3(frames[i].person_6.joint_3.x, frames[i].person_6.joint_3.y, frames[i].person_6.joint_3.z);
                                selectorPeople[6, 3].transform.position = new Vector3(frames[i].person_6.joint_4.x, frames[i].person_6.joint_4.y, frames[i].person_6.joint_4.z);
                                selectorPeople[6, 4].transform.position = new Vector3(frames[i].person_6.joint_5.x, frames[i].person_6.joint_5.y, frames[i].person_6.joint_5.z);
                                selectorPeople[6, 5].transform.position = new Vector3(frames[i].person_6.joint_6.x, frames[i].person_6.joint_6.y, frames[i].person_6.joint_6.z);
                                selectorPeople[6, 6].transform.position = new Vector3(frames[i].person_6.joint_7.x, frames[i].person_6.joint_7.y, frames[i].person_6.joint_7.z);
                                selectorPeople[6, 7].transform.position = new Vector3(frames[i].person_6.joint_8.x, frames[i].person_6.joint_8.y, frames[i].person_6.joint_8.z);
                                selectorPeople[6, 8].transform.position = new Vector3(frames[i].person_6.joint_9.x, frames[i].person_6.joint_9.y, frames[i].person_6.joint_9.z);
                                selectorPeople[6, 9].transform.position = new Vector3(frames[i].person_6.joint_10.x, frames[i].person_6.joint_10.y, frames[i].person_6.joint_10.z);
                                selectorPeople[6, 10].transform.position = new Vector3(frames[i].person_6.joint_11.x, frames[i].person_6.joint_11.y, frames[i].person_6.joint_11.z);
                                selectorPeople[6, 11].transform.position = new Vector3(frames[i].person_6.joint_12.x, frames[i].person_6.joint_12.y, frames[i].person_6.joint_12.z);
                                selectorPeople[6, 12].transform.position = new Vector3(frames[i].person_6.joint_13.x, frames[i].person_6.joint_13.y, frames[i].person_6.joint_13.z);
                                selectorPeople[6, 13].transform.position = new Vector3((frames[i].person_6.joint_16.x + frames[i].person_6.joint_17.x) / 2, (frames[i].person_6.joint_16.y + frames[i].person_6.joint_17.y) / 2, (frames[i].person_6.joint_16.z + frames[i].person_6.joint_17.z) / 2);
                                 }
                            if(numPeople>5 && frames[i].person_5 != null)
                                {        
                                //person5
                                selectorPeople[5, 0].transform.position = new Vector3(frames[i].person_5.joint_1.x, frames[i].person_5.joint_1.y, frames[i].person_5.joint_1.z);
                                selectorPeople[5, 1].transform.position = new Vector3(frames[i].person_5.joint_2.x, frames[i].person_5.joint_2.y, frames[i].person_5.joint_2.z);
                                selectorPeople[5, 2].transform.position = new Vector3(frames[i].person_5.joint_3.x, frames[i].person_5.joint_3.y, frames[i].person_5.joint_3.z);
                                selectorPeople[5, 3].transform.position = new Vector3(frames[i].person_5.joint_4.x, frames[i].person_5.joint_4.y, frames[i].person_5.joint_4.z);
                                selectorPeople[5, 4].transform.position = new Vector3(frames[i].person_5.joint_5.x, frames[i].person_5.joint_5.y, frames[i].person_5.joint_5.z);
                                selectorPeople[5, 5].transform.position = new Vector3(frames[i].person_5.joint_6.x, frames[i].person_5.joint_6.y, frames[i].person_5.joint_6.z);
                                selectorPeople[5, 6].transform.position = new Vector3(frames[i].person_5.joint_7.x, frames[i].person_5.joint_7.y, frames[i].person_5.joint_7.z);
                                selectorPeople[5, 7].transform.position = new Vector3(frames[i].person_5.joint_8.x, frames[i].person_5.joint_8.y, frames[i].person_5.joint_8.z);
                                selectorPeople[5, 8].transform.position = new Vector3(frames[i].person_5.joint_9.x, frames[i].person_5.joint_9.y, frames[i].person_5.joint_9.z);
                                selectorPeople[5, 9].transform.position = new Vector3(frames[i].person_5.joint_10.x, frames[i].person_5.joint_10.y, frames[i].person_5.joint_10.z);
                                selectorPeople[5, 10].transform.position = new Vector3(frames[i].person_5.joint_11.x, frames[i].person_5.joint_11.y, frames[i].person_5.joint_11.z);
                                selectorPeople[5, 11].transform.position = new Vector3(frames[i].person_5.joint_12.x, frames[i].person_5.joint_12.y, frames[i].person_5.joint_12.z);
                                selectorPeople[5, 12].transform.position = new Vector3(frames[i].person_5.joint_13.x, frames[i].person_5.joint_13.y, frames[i].person_5.joint_13.z);
                                selectorPeople[5, 13].transform.position = new Vector3((frames[i].person_5.joint_16.x + frames[i].person_5.joint_17.x) / 2, (frames[i].person_5.joint_16.y + frames[i].person_5.joint_17.y) / 2, (frames[i].person_5.joint_16.z + frames[i].person_5.joint_17.z) / 2);
                                }
                            if(numPeople>4 && frames[i].person_4 != null)
                                { 
                                //person4
                                selectorPeople[4, 0].transform.position = new Vector3(frames[i].person_4.joint_1.x, frames[i].person_4.joint_1.y, frames[i].person_4.joint_1.z);
                                selectorPeople[4, 1].transform.position = new Vector3(frames[i].person_4.joint_2.x, frames[i].person_4.joint_2.y, frames[i].person_4.joint_2.z);
                                selectorPeople[4, 2].transform.position = new Vector3(frames[i].person_4.joint_3.x, frames[i].person_4.joint_3.y, frames[i].person_4.joint_3.z);
                                selectorPeople[4, 3].transform.position = new Vector3(frames[i].person_4.joint_4.x, frames[i].person_4.joint_4.y, frames[i].person_4.joint_4.z);
                                selectorPeople[4, 4].transform.position = new Vector3(frames[i].person_4.joint_5.x, frames[i].person_4.joint_5.y, frames[i].person_4.joint_5.z);
                                selectorPeople[4, 5].transform.position = new Vector3(frames[i].person_4.joint_6.x, frames[i].person_4.joint_6.y, frames[i].person_4.joint_6.z);
                                selectorPeople[4, 6].transform.position = new Vector3(frames[i].person_4.joint_7.x, frames[i].person_4.joint_7.y, frames[i].person_4.joint_7.z);
                                selectorPeople[4, 7].transform.position = new Vector3(frames[i].person_4.joint_8.x, frames[i].person_4.joint_8.y, frames[i].person_4.joint_8.z);
                                selectorPeople[4, 8].transform.position = new Vector3(frames[i].person_4.joint_9.x, frames[i].person_4.joint_9.y, frames[i].person_4.joint_9.z);
                                selectorPeople[4, 9].transform.position = new Vector3(frames[i].person_4.joint_10.x, frames[i].person_4.joint_10.y, frames[i].person_4.joint_10.z);
                                selectorPeople[4, 10].transform.position = new Vector3(frames[i].person_4.joint_11.x, frames[i].person_4.joint_11.y, frames[i].person_4.joint_11.z);
                                selectorPeople[4, 11].transform.position = new Vector3(frames[i].person_4.joint_12.x, frames[i].person_4.joint_12.y, frames[i].person_4.joint_12.z);
                                selectorPeople[4, 12].transform.position = new Vector3(frames[i].person_4.joint_13.x, frames[i].person_4.joint_13.y, frames[i].person_4.joint_13.z);
                                selectorPeople[4, 13].transform.position = new Vector3((frames[i].person_4.joint_16.x + frames[i].person_4.joint_17.x) / 2, (frames[i].person_4.joint_16.y + frames[i].person_4.joint_17.y) / 2, (frames[i].person_4.joint_16.z + frames[i].person_4.joint_17.z) / 2);
                                }
                            if(numPeople>3 && frames[i].person_3 != null)
                                {
                                    //person3
                                    selectorPeople[3, 0].transform.position = new Vector3(frames[i].person_3.joint_1.x, frames[i].person_3.joint_1.y, frames[i].person_3.joint_1.z);
                                    selectorPeople[3, 1].transform.position = new Vector3(frames[i].person_3.joint_2.x, frames[i].person_3.joint_2.y, frames[i].person_3.joint_2.z);
                                    selectorPeople[3, 2].transform.position = new Vector3(frames[i].person_3.joint_3.x, frames[i].person_3.joint_3.y, frames[i].person_3.joint_3.z);
                                    selectorPeople[3, 3].transform.position = new Vector3(frames[i].person_3.joint_4.x, frames[i].person_3.joint_4.y, frames[i].person_3.joint_4.z);
                                    selectorPeople[3, 4].transform.position = new Vector3(frames[i].person_3.joint_5.x, frames[i].person_3.joint_5.y, frames[i].person_3.joint_5.z);
                                    selectorPeople[3, 5].transform.position = new Vector3(frames[i].person_3.joint_6.x, frames[i].person_3.joint_6.y, frames[i].person_3.joint_6.z);
                                    selectorPeople[3, 6].transform.position = new Vector3(frames[i].person_3.joint_7.x, frames[i].person_3.joint_7.y, frames[i].person_3.joint_7.z);
                                    selectorPeople[3, 7].transform.position = new Vector3(frames[i].person_3.joint_8.x, frames[i].person_3.joint_8.y, frames[i].person_3.joint_8.z);
                                    selectorPeople[3, 8].transform.position = new Vector3(frames[i].person_3.joint_9.x, frames[i].person_3.joint_9.y, frames[i].person_3.joint_9.z);
                                    selectorPeople[3, 9].transform.position = new Vector3(frames[i].person_3.joint_10.x, frames[i].person_3.joint_10.y, frames[i].person_3.joint_10.z);
                                    selectorPeople[3, 10].transform.position = new Vector3(frames[i].person_3.joint_11.x, frames[i].person_3.joint_11.y, frames[i].person_3.joint_11.z);
                                    selectorPeople[3, 11].transform.position = new Vector3(frames[i].person_3.joint_12.x, frames[i].person_3.joint_12.y, frames[i].person_3.joint_12.z);
                                    selectorPeople[3, 12].transform.position = new Vector3(frames[i].person_3.joint_13.x, frames[i].person_3.joint_13.y, frames[i].person_3.joint_13.z);
                                    selectorPeople[3, 13].transform.position = new Vector3((frames[i].person_3.joint_16.x + frames[i].person_3.joint_17.x) / 2, (frames[i].person_3.joint_16.y + frames[i].person_3.joint_17.y) / 2, (frames[i].person_3.joint_16.z + frames[i].person_3.joint_17.z) / 2);
                                }
                            if(numPeople>2 && frames[i].person_2 != null)
                                {
                                    //person2
                                    selectorPeople[2, 0].transform.position = new Vector3(frames[i].person_2.joint_1.x, frames[i].person_2.joint_1.y, frames[i].person_2.joint_1.z);
                                    selectorPeople[2, 1].transform.position = new Vector3(frames[i].person_2.joint_2.x, frames[i].person_2.joint_2.y, frames[i].person_2.joint_2.z);
                                    selectorPeople[2, 2].transform.position = new Vector3(frames[i].person_2.joint_3.x, frames[i].person_2.joint_3.y, frames[i].person_2.joint_3.z);
                                    selectorPeople[2, 3].transform.position = new Vector3(frames[i].person_2.joint_4.x, frames[i].person_2.joint_4.y, frames[i].person_2.joint_4.z);
                                    selectorPeople[2, 4].transform.position = new Vector3(frames[i].person_2.joint_5.x, frames[i].person_2.joint_5.y, frames[i].person_2.joint_5.z);
                                    selectorPeople[2, 5].transform.position = new Vector3(frames[i].person_2.joint_6.x, frames[i].person_2.joint_6.y, frames[i].person_2.joint_6.z);
                                    selectorPeople[2, 6].transform.position = new Vector3(frames[i].person_2.joint_7.x, frames[i].person_2.joint_7.y, frames[i].person_2.joint_7.z);
                                    selectorPeople[2, 7].transform.position = new Vector3(frames[i].person_2.joint_8.x, frames[i].person_2.joint_8.y, frames[i].person_2.joint_8.z);
                                    selectorPeople[2, 8].transform.position = new Vector3(frames[i].person_2.joint_9.x, frames[i].person_2.joint_9.y, frames[i].person_2.joint_9.z);
                                    selectorPeople[2, 9].transform.position = new Vector3(frames[i].person_2.joint_10.x, frames[i].person_2.joint_10.y, frames[i].person_2.joint_10.z);
                                    selectorPeople[2, 10].transform.position = new Vector3(frames[i].person_2.joint_11.x, frames[i].person_2.joint_11.y, frames[i].person_2.joint_11.z);
                                    selectorPeople[2, 11].transform.position = new Vector3(frames[i].person_2.joint_12.x, frames[i].person_2.joint_12.y, frames[i].person_2.joint_12.z);
                                    selectorPeople[2, 12].transform.position = new Vector3(frames[i].person_2.joint_13.x, frames[i].person_2.joint_13.y, frames[i].person_2.joint_13.z);
                                    selectorPeople[2, 13].transform.position = new Vector3((frames[i].person_2.joint_16.x + frames[i].person_2.joint_17.x) / 2, (frames[i].person_2.joint_16.y + frames[i].person_2.joint_17.y) / 2, (frames[i].person_2.joint_16.z + frames[i].person_2.joint_17.z) / 2);
                                }
                            if(numPeople>1 && frames[i].person_1 != null)
                                {
                                    //person1
                                    selectorPeople[1, 0].transform.position = new Vector3(frames[i].person_1.joint_1.x, frames[i].person_1.joint_1.y, frames[i].person_1.joint_1.z);
                                    selectorPeople[1, 1].transform.position = new Vector3(frames[i].person_1.joint_2.x, frames[i].person_1.joint_2.y, frames[i].person_1.joint_2.z);
                                    selectorPeople[1, 2].transform.position = new Vector3(frames[i].person_1.joint_3.x, frames[i].person_1.joint_3.y, frames[i].person_1.joint_3.z);
                                    selectorPeople[1, 3].transform.position = new Vector3(frames[i].person_1.joint_4.x, frames[i].person_1.joint_4.y, frames[i].person_1.joint_4.z);
                                    selectorPeople[1, 4].transform.position = new Vector3(frames[i].person_1.joint_5.x, frames[i].person_1.joint_5.y, frames[i].person_1.joint_5.z);
                                    selectorPeople[1, 5].transform.position = new Vector3(frames[i].person_1.joint_6.x, frames[i].person_1.joint_6.y, frames[i].person_1.joint_6.z);
                                    selectorPeople[1, 6].transform.position = new Vector3(frames[i].person_1.joint_7.x, frames[i].person_1.joint_7.y, frames[i].person_1.joint_7.z);
                                    selectorPeople[1, 7].transform.position = new Vector3(frames[i].person_1.joint_8.x, frames[i].person_1.joint_8.y, frames[i].person_1.joint_8.z);
                                    selectorPeople[1, 8].transform.position = new Vector3(frames[i].person_1.joint_9.x, frames[i].person_1.joint_9.y, frames[i].person_1.joint_9.z);
                                    selectorPeople[1, 9].transform.position = new Vector3(frames[i].person_1.joint_10.x, frames[i].person_1.joint_10.y, frames[i].person_1.joint_10.z);
                                    selectorPeople[1, 10].transform.position = new Vector3(frames[i].person_1.joint_11.x, frames[i].person_1.joint_11.y, frames[i].person_1.joint_11.z);
                                    selectorPeople[1, 11].transform.position = new Vector3(frames[i].person_1.joint_12.x, frames[i].person_1.joint_12.y, frames[i].person_1.joint_12.z);
                                    selectorPeople[1, 12].transform.position = new Vector3(frames[i].person_1.joint_13.x, frames[i].person_1.joint_13.y, frames[i].person_1.joint_13.z);
                                    selectorPeople[1, 13].transform.position = new Vector3((frames[i].person_1.joint_16.x + frames[i].person_1.joint_17.x) / 2, (frames[i].person_1.joint_16.y + frames[i].person_1.joint_17.y) / 2, (frames[i].person_1.joint_16.z + frames[i].person_1.joint_17.z) / 2);
                                }
                            if(numPeople>0 && frames[i].person_0 != null)
                                {   //person0
                            selectorPeople[0, 0].transform.position = new Vector3(frames[i].person_0.joint_1.x, frames[i].person_0.joint_1.y, frames[i].person_0.joint_1.z);
                            selectorPeople[0, 1].transform.position = new Vector3(frames[i].person_0.joint_2.x, frames[i].person_0.joint_2.y, frames[i].person_0.joint_2.z);
                            selectorPeople[0, 2].transform.position = new Vector3(frames[i].person_0.joint_3.x, frames[i].person_0.joint_3.y, frames[i].person_0.joint_3.z);
                            selectorPeople[0, 3].transform.position = new Vector3(frames[i].person_0.joint_4.x, frames[i].person_0.joint_4.y, frames[i].person_0.joint_4.z);
                            selectorPeople[0, 4].transform.position = new Vector3(frames[i].person_0.joint_5.x, frames[i].person_0.joint_5.y, frames[i].person_0.joint_5.z);
                            selectorPeople[0, 5].transform.position = new Vector3(frames[i].person_0.joint_6.x, frames[i].person_0.joint_6.y, frames[i].person_0.joint_6.z);
                            selectorPeople[0, 6].transform.position = new Vector3(frames[i].person_0.joint_7.x, frames[i].person_0.joint_7.y, frames[i].person_0.joint_7.z);
                            selectorPeople[0, 7].transform.position = new Vector3(frames[i].person_0.joint_8.x, frames[i].person_0.joint_8.y, frames[i].person_0.joint_8.z);
                            selectorPeople[0, 8].transform.position = new Vector3(frames[i].person_0.joint_9.x, frames[i].person_0.joint_9.y, frames[i].person_0.joint_9.z);
                            selectorPeople[0, 9].transform.position = new Vector3(frames[i].person_0.joint_10.x, frames[i].person_0.joint_10.y, frames[i].person_0.joint_10.z);
                            selectorPeople[0, 10].transform.position = new Vector3(frames[i].person_0.joint_11.x, frames[i].person_0.joint_11.y, frames[i].person_0.joint_11.z);
                            selectorPeople[0, 11].transform.position = new Vector3(frames[i].person_0.joint_12.x, frames[i].person_0.joint_12.y, frames[i].person_0.joint_12.z);
                            selectorPeople[0, 12].transform.position = new Vector3(frames[i].person_0.joint_13.x, frames[i].person_0.joint_13.y, frames[i].person_0.joint_13.z);
                            selectorPeople[0, 13].transform.position = new Vector3((frames[i].person_0.joint_16.x + frames[i].person_0.joint_17.x) / 2, (frames[i].person_0.joint_16.y + frames[i].person_0.joint_17.y) / 2, (frames[i].person_0.joint_16.z + frames[i].person_0.joint_17.z) / 2);
                                }/**/
        }
        else { i = 0; }
        i++;
    }
    List<Persona> IsolaMovimentoDaRilevare(List<Frame> frames,double position)
    {
        //Debug.Log("finqui ci arrivoooo" );
        List<double> tmp;
        double mindis = 0;
        double soglia = 25;//25
        List<Persona> rilevatoPerson = new List<Persona>();
        foreach(Frame frame in frames)
        {
            int num = 10;
            tmp = new List<double> { frame.person_0.dis, frame.person_1.dis , frame.person_2.dis, frame.person_3.dis, frame.person_4.dis, frame.person_5.dis , frame.person_6.dis  , frame.person_7.dis , frame.person_8.dis  , frame.person_9.dis , frame.person_10.dis };
            /*foreach (double t in tmp)
           {
               Debug.Log(t + "tmp popolato");
           }*/
            for (int i=0;i<num;i++){ tmp[i] = Math.Pow(tmp[i] - position, 2); }
            /*foreach (double t in tmp)
            {
                Debug.Log(t + "tmp");
            }*/
            //Debug.Log(tmp[0] + " //" + tmp[1]);
            tmp.Sort();
            //Debug.Log(tmp[0] + " //" + tmp[1]);
            mindis = tmp[0]; Debug.Log("scelto" + tmp[0]);
            if (tmp[0]==1000){ if (mindis - tmp[1]/*1*/ <= soglia) { Debug.Log("soglia superata"+ mindis +"  // "+ tmp[0]); mindis = tmp[1]/*[1]*/; Debug.Log("scelto" + tmp[1]); } }
            else { if (mindis - tmp[0]/*0*/ <= soglia) { Debug.Log("soglia superata" + mindis + "  // " + tmp[1]); mindis = tmp[0]/*[0]*/; Debug.Log("scelto" + tmp[0]); } }
            Debug.Log(mindis+ "min diss");
            
                if (Math.Pow((frame.person_0.dis - position), 2) == mindis)
                {
                    rilevatoPerson.Add(frame.person_0);
                    position = frame.person_0.dis;
                }
                if (Math.Pow((frame.person_1.dis - position), 2) == mindis)
                {
                    rilevatoPerson.Add(frame.person_1); position = Math.Sqrt(Math.Pow(frame.person_1.joint_1.x + 100, 2) + Math.Pow(frame.person_1.joint_1.z + 100, 2) + Math.Pow(frame.person_1.joint_1.y + 100, 2)); ;
                }
                if (Math.Pow((frame.person_2.dis - position), 2) == mindis)
                {
                    rilevatoPerson.Add(frame.person_2); position = Math.Sqrt(Math.Pow(frame.person_2.joint_1.x + 100, 2) + Math.Pow(frame.person_2.joint_1.z + 100, 2) + Math.Pow(frame.person_2.joint_1.y + 100, 2)); ;
                }
                if (Math.Pow((frame.person_3.dis - position), 2) == mindis)
                {
                    rilevatoPerson.Add(frame.person_3); position = Math.Sqrt(Math.Pow(frame.person_3.joint_1.x + 100, 2) + Math.Pow(frame.person_3.joint_1.z + 100, 2) + Math.Pow(frame.person_3.joint_1.y + 100, 2)); ;
                }
                if (Math.Pow((frame.person_4.dis - position), 2) == mindis)
                {
                    rilevatoPerson.Add(frame.person_4); position = Math.Sqrt(Math.Pow(frame.person_4.joint_1.x + 100, 2) + Math.Pow(frame.person_4.joint_1.z + 100, 2) + Math.Pow(frame.person_4.joint_1.y + 100, 2)); ;
                }
                if (Math.Pow((frame.person_5.dis - position), 2) == mindis)
                {
                    rilevatoPerson.Add(frame.person_5); position = Math.Sqrt(Math.Pow(frame.person_5.joint_1.x + 100, 2) + Math.Pow(frame.person_5.joint_1.z + 100, 2) + Math.Pow(frame.person_5.joint_1.y + 100, 2)); ;
                }
                if (Math.Pow((frame.person_6.dis - position), 2) == mindis)
                {
                    rilevatoPerson.Add(frame.person_6); position = Math.Sqrt(Math.Pow(frame.person_6.joint_1.x + 100, 2) + Math.Pow(frame.person_6.joint_1.z + 100, 2) + Math.Pow(frame.person_6.joint_1.y + 100, 2)); ;
                }
                /*if (Math.Pow((frame.person_7.dis - position), 2) == mindis)
                { rilevatoPerson.Add(frame.person_7); position =Math.Sqrt(Math.Pow(frame.person_7.joint_1.x + 100, 2) + Math.Pow(frame.person_7.joint_1.z + 100, 2) + Math.Pow(frame.person_7.joint_1.y + 100, 2)); ;
                }
                if (Math.Pow((frame.person_8.dis - position), 2) == mindis)
                { rilevatoPerson.Add(frame.person_8); position =Math.Sqrt(Math.Pow(frame.person_8.joint_1.x + 100, 2) + Math.Pow(frame.person_8.joint_1.z + 100, 2) + Math.Pow(frame.person_8.joint_1.y + 100, 2)); ;
                }
                if (Math.Pow((frame.person_9.dis - position), 2) == mindis)
                { rilevatoPerson.Add(frame.person_9); position =Math.Sqrt(Math.Pow(frame.person_9.joint_1.x + 100, 2) + Math.Pow(frame.person_9.joint_1.z + 100, 2) + Math.Pow(frame.person_9.joint_1.y + 100, 2)); ;
                }
                if (Math.Pow((frame.person_10.dis - position), 2) == mindis)
                { rilevatoPerson.Add(frame.person_10); position =Math.Sqrt(Math.Pow(frame.person_10.joint_1.x + 100, 2) + Math.Pow(frame.person_10.joint_1.z + 100, 2) + Math.Pow(frame.person_10.joint_1.y + 100, 2)); ;
                }
                if (Math.Pow((frame.person_11.dis - position), 2) == mindis)
                { rilevatoPerson.Add(frame.person_11); position =Math.Sqrt(Math.Pow(frame.person_11.joint_1.x + 100, 2) + Math.Pow(frame.person_11.joint_1.z + 100, 2) + Math.Pow(frame.person_11.joint_1.y + 100, 2)); ;
                }*/
            
           
        }
        return rilevatoPerson;

    }
    void IdPersona()
    {
        List<Persona> tmp=new List<Persona>();
       // List<Vector2> di = new List<Vector2>();
            int frame = frames.Count;
            int nper = 0;
            for (int i = 0; i < frame; i++)
            {
                tmp = new List<Persona>();

          if (frames[i].person_0 != null) { tmp.Add(frames[i].person_0); nper++;}
          if (frames[i].person_1 != null) { tmp.Add(frames[i].person_1); nper++;}
          if (frames[i].person_2 != null) { tmp.Add(frames[i].person_2); nper++;}
          if (frames[i].person_3 != null) { tmp.Add(frames[i].person_3); nper++;}
          if (frames[i].person_4 != null) { tmp.Add(frames[i].person_4); nper++;}
          if (frames[i].person_5 != null) { tmp.Add(frames[i].person_5); nper++;}
          if (frames[i].person_6 != null) { tmp.Add(frames[i].person_6); nper++; }
          if (frames[i].person_7 != null) { tmp.Add(frames[i].person_7); nper++; }
          if (frames[i].person_8 != null) { tmp.Add(frames[i].person_8); nper++; }
          if (frames[i].person_9 != null) { tmp.Add(frames[i].person_9); nper++; }
          if (frames[i].person_10 != null) { tmp.Add(frames[i].person_10); nper++; }
          if (frames[i].person_11 != null) { tmp.Add(frames[i].person_11); nper++; }
          if (frames[i].person_12 != null) { tmp.Add(frames[i].person_12); nper++; }
          if (frames[i].person_13 != null) { tmp.Add(frames[i].person_13); nper++; }
          if (frames[i].person_14 != null) { tmp.Add(frames[i].person_14); nper++; }
          if (frames[i].person_15 != null) { tmp.Add(frames[i].person_15); nper++; }
          if (frames[i].person_16 != null) { tmp.Add(frames[i].person_16); nper++; }
          if (frames[i].person_17 != null) { tmp.Add(frames[i].person_17); nper++; }
          if (frames[i].person_18 != null) { tmp.Add(frames[i].person_18); nper++; }
          if (frames[i].person_19 != null) { tmp.Add(frames[i].person_19); nper++; }
        //   Debug.Log( frames[i].person_0.dis);
        //  Debug.Log( frames[i].person_1.dis);
        //  Debug.Log( frames[i].person_2.dis);
        //  Debug.Log( frames[i].person_3.dis);
        //  Debug.Log( frames[i].person_4.dis);
        //  Debug.Log( frames[i].person_5.dis);
        // Debug.Log(tmp[8].joint_1.x + " " + frames[i].person_8.joint_1.x);
        // Debug.Log(tmp[7].joint_1.x + " " + frames[i].person_7.joint_1.x);
        // Debug.Log(tmp[6].joint_1.x + " " + frames[i].person_6.joint_1.x);
        // Debug.Log(tmp[5].joint_1.x + " " + frames[i].person_5.joint_1.x);
           /* tmp.Sort(delegate (Persona a, Persona b)
            {
                if (a.dis == null && b.dis== null) return 0;
                else if (a.dis == null) return -1;
                else if (b.dis == null) return 1;
                return a.dis.CompareTo(b.dis);
            });*/
     //       Debug.Log(frames[i].person_0.dis);
     //       Debug.Log(frames[i].person_1.dis);
     //       Debug.Log(frames[i].person_2.dis);
     //       Debug.Log(frames[i].person_3.dis);
     //       Debug.Log(frames[i].person_4.dis);
     //       Debug.Log(frames[i].person_5.dis);
            // Debug.Log(tmp[4].joint_1.x + " " + frames[i].person_4.joint_1.x);
            // Debug.Log(tmp[3].joint_1.x + " " + frames[i].person_3.joint_1.x);
            // Debug.Log(tmp[2].joint_1.x + " " + frames[i].person_2.joint_1.x);
            // Debug.Log(tmp[1].joint_1.x + " " + frames[i].person_1.joint_1.x);
            // Debug.Log(tmp[0].joint_1.x + " " + frames[i].person_0.joint_1.x);
            /* tmp[10]=(frames[i].person_10);
                 tmp[11]=(frames[i].person_11);
                 tmp[12]=(frames[i].person_12);
                 tmp[13]=(frames[i].person_13);
                 tmp[14]=(frames[i].person_14);
                 tmp[15]=(frames[i].person_15);
                 tmp[16]=(frames[i].person_16);
                 tmp[17]=(frames[i].person_17);
                 tmp[18]=(frames[i].person_18);
                 tmp[19]=(frames[i].person_19);*/
            // Debug.Log(frames[i].person_0.joint_1.x + " "+ frames[i].person_1.joint_1.x + " "+ frames[i].person_2.joint_1.x + " "+ frames[i].person_3.joint_1.x + " ");
            // tmp.Sort();

            // Debug.Log(tmp[0].joint_1.x + " " + tmp[1].joint_1.x + " " + tmp[2].joint_1.x + " " + tmp[3].joint_1.x + " ");
            int j = tmp.Count;
                //Debug.Log(nper);
                


                if (tmp[8].joint_1 != null && frames[i].person_8.joint_1 != null && j > 8 && nper > 8) { frames[i].person_8 = tmp[8];} 
                if (tmp[7].joint_1 != null && frames[i].person_7.joint_1 != null && j > 7 && nper > 7) { frames[i].person_7 = tmp[7];} 
                if (tmp[6].joint_1 != null && frames[i].person_6.joint_1 != null && j > 6 && nper > 6) { frames[i].person_6 = tmp[6];} 
                if (tmp[5].joint_1 != null && frames[i].person_5.joint_1 != null && j > 5 && nper > 5) { frames[i].person_5 = tmp[5];}
                if (tmp[4].joint_1 != null && frames[i].person_4.joint_1 != null && j > 4 && nper > 4) { frames[i].person_4 = tmp[4];}
                if (tmp[3].joint_1 != null && frames[i].person_3.joint_1 != null && j > 3 && nper > 3) { frames[i].person_3 = tmp[3];}
                if (tmp[2].joint_1 != null && frames[i].person_2.joint_1 != null && j > 2 && nper > 2) { frames[i].person_2 = tmp[2];}
                if (tmp[1].joint_1 != null && frames[i].person_1.joint_1 != null && j > 1 && nper > 1) { frames[i].person_1 = tmp[1];}
                if (tmp[0].joint_1 != null && frames[i].person_0.joint_1 != null && j > 0 && nper > 0) { frames[i].person_0 = tmp[0];}
                if (tmp[9].joint_1 != null && frames[i].person_9.joint_1 != null && j > 9 && nper > 9) { frames[i].person_9 = tmp[9];}
                if (tmp[18].joint_1 != null && frames[i].person_18.joint_1 != null && j > 18 && nper > 18) { frames[i].person_18 = tmp[18]; }
                if (tmp[17].joint_1 != null && frames[i].person_17.joint_1 != null && j > 17 && nper > 17) { frames[i].person_17 = tmp[17]; }
                if (tmp[16].joint_1 != null && frames[i].person_16.joint_1 != null && j > 16 && nper > 16) { frames[i].person_16 = tmp[16]; }
                if (tmp[15].joint_1 != null && frames[i].person_15.joint_1 != null && j > 15 && nper > 15) { frames[i].person_15 = tmp[15]; }
                if (tmp[14].joint_1 != null && frames[i].person_14.joint_1 != null && j > 14 && nper > 14) { frames[i].person_14 = tmp[14]; }
                if (tmp[13].joint_1 != null && frames[i].person_13.joint_1 != null && j > 13 && nper > 13) { frames[i].person_13 = tmp[13]; }
                if (tmp[12].joint_1 != null && frames[i].person_12.joint_1 != null && j > 12 && nper > 12) { frames[i].person_12 = tmp[12]; }
                if (tmp[11].joint_1 != null && frames[i].person_11.joint_1 != null && j > 11 && nper > 11) { frames[i].person_11 = tmp[11]; }
                if (tmp[10].joint_1 != null && frames[i].person_10.joint_1 != null && j > 10 && nper > 10) { frames[i].person_10 = tmp[10]; }
                if (tmp[19].joint_1 != null && frames[i].person_19.joint_1 != null && j > 19 && nper > 19) { frames[i].person_19 = tmp[19]; }
            /* Debug.Log("2");
             Debug.Log("3");
             Debug.Log("4");
             Debug.Log("5");
             Debug.Log("6");
             Debug.Log("7");
             Debug.Log("8");
             Debug.Log("9");
             Debug.Log("10");*/
            // Debug.Log(frames[i].person_0.joint_1.x + " " + frames[i].person_1.joint_1.x + " " + frames[i].person_2.joint_1.x + " " + frames[i].person_3.joint_1.x + " ");
            nper = 0;
          //  for(int f = nper; f > 0; f--)
          //  {
          //      tmp.Remove(tmp[f-1]);
          //
          //  }
          
           // Debug.Log("11");
            /* frames[i].person_10 = tmp[10];
             frames[i].person_11 = tmp[11];
             frames[i].person_12 = tmp[12];
             frames[i].person_13 = tmp[13];
             frames[i].person_14 = tmp[14];
             frames[i].person_15 = tmp[15];
             frames[i].person_16 = tmp[16];
             frames[i].person_17 = tmp[17];
             frames[i].person_18 = tmp[18];
             frames[i].person_19 = tmp[19];*/
            //Frame t = new Frame(tmp[0],tmp[1],tmp[2], tmp[3], tmp[4], tmp[5], tmp[6], tmp[7], tmp[8],tmp[9], tmp[10], tmp[11], tmp[12], tmp[13], tmp[14], tmp[15], tmp[16], tmp[17], tmp[18], tmp[19]);
            //save.Add(t);
        }

            Debug.Log("SaveData:");
            //string output = JsonUtility.ToJson(save, true);
            //System.IO.File.WriteAllText(savePath, output);
       
    }
    void calcoladis()
    {
        int frame = frames.Count;
        for (int i = 0; i < frame; i++)
        {
            frames[i].person_0.cdis();
            frames[i].person_1.cdis();
            frames[i].person_2.cdis();
            frames[i].person_3.cdis();
            frames[i].person_4.cdis();
            frames[i].person_5.cdis();
            frames[i].person_6.cdis();
            frames[i].person_7.cdis();
            frames[i].person_8.cdis();
            frames[i].person_9.cdis();
            frames[i].person_10.cdis();
            frames[i].person_11.cdis();
            frames[i].person_12.cdis();
            frames[i].person_13.cdis();
            frames[i].person_14.cdis();
            frames[i].person_15.cdis();
            frames[i].person_16.cdis();
            frames[i].person_17.cdis();
            frames[i].person_18.cdis();
            frames[i].person_19.cdis();
        }
    }
    void acquisisci_frame(string contents)
    {
        int i = 0;
        int pos = 0;
        int el = 0;
        do
        {
            int ini = contents.IndexOf("frame", pos);
            int dif = contents.IndexOf('"', ini) - ini;
            contents = contents.Remove(ini, dif);
            contents = contents.Insert(ini, "frame_primo");

            FrameWrap wrapper = JsonUtility.FromJson<FrameWrap>(contents);

            frames.Add(wrapper.frame_primo);
            i++;
            el = contents.IndexOf("frame", ini + 100);
            contents = contents.Remove(contents.IndexOf('{', 0) + 1, el - (contents.IndexOf('{', 0) + 2));
        } while (contents.IndexOf("frame", 100) > 0);
    }
    void difId()//non va non so perchè
    {
        float threshold= 1;
        List<double> distance=new List<double>();
        List<Persona> p = new List<Persona>();
        int frame = frames.Count;
        int framelost = 5;
        int[] time=new int[20];
        for (int r = 0; r < 20; r++)
        {
           // time[r] = -1;
        }
        if (frames[0].person_0 != null) { distance.Add(frames[0].person_0.dis);  time[0]=framelost; }
        if (frames[0].person_1 != null) { distance.Add(frames[0].person_0.dis);  time[1]=framelost;}
        if (frames[0].person_2 != null) { distance.Add(frames[0].person_0.dis);  time[2]=framelost;}
        if (frames[0].person_3 != null) { distance.Add(frames[0].person_0.dis);  time[3]=framelost;}
        if (frames[0].person_4 != null) { distance.Add(frames[0].person_0.dis);  time[4]=framelost;}
        if (frames[0].person_5 != null) { distance.Add(frames[0].person_0.dis);  time[5]=framelost;}
        if (frames[0].person_6 != null) { distance.Add(frames[0].person_0.dis);  time[6]=framelost;}
        if (frames[0].person_7 != null) { distance.Add(frames[0].person_0.dis);  time[7]=framelost;}
        if (frames[0].person_8 != null) { distance.Add(frames[0].person_0.dis);  time[8]=framelost;}
        if (frames[0].person_9 != null) { distance.Add(frames[0].person_0.dis);  time[9]=framelost; }
        if (frames[0].person_10 != null) { distance.Add(frames[0].person_0.dis); time[10]=framelost;}
        if (frames[0].person_11 != null) { distance.Add(frames[0].person_0.dis); time[11]=framelost;}
        if (frames[0].person_12 != null) { distance.Add(frames[0].person_0.dis); time[12]=framelost;}
        if (frames[0].person_13 != null) { distance.Add(frames[0].person_0.dis); time[13]=framelost;}
        if (frames[0].person_14 != null) { distance.Add(frames[0].person_0.dis); time[14]=framelost;}
        if (frames[0].person_15 != null) { distance.Add(frames[0].person_0.dis); time[15]=framelost;}
        if (frames[0].person_16 != null) { distance.Add(frames[0].person_0.dis); time[16]=framelost;}
        if (frames[0].person_17 != null) { distance.Add(frames[0].person_0.dis); time[17]=framelost;}
        if (frames[0].person_18 != null) { distance.Add(frames[0].person_0.dis); time[18]=framelost;}
        if (frames[0].person_19 != null) { distance.Add(frames[0].person_0.dis); time[19] = framelost; }
        
        for (int h = 1; h< frame; h++)//ciclo frames
        {
            p.Clear();
            if (frames[h].person_0 != null) { p.Add(frames[h].person_0); }
            if (frames[h].person_1 != null) { p.Add(frames[h].person_1); }
            if (frames[h].person_2 != null) { p.Add(frames[h].person_2); }
            if (frames[h].person_3 != null) { p.Add(frames[h].person_3); }
            if (frames[h].person_4 != null) { p.Add(frames[h].person_4); }
            if (frames[h].person_5 != null) { p.Add(frames[h].person_5); }
            if (frames[h].person_6 != null) { p.Add(frames[h].person_6); }
            if (frames[h].person_7 != null) { p.Add(frames[h].person_7); }
            if (frames[h].person_8 != null) { p.Add(frames[h].person_8); }
            if (frames[h].person_9 != null) { p.Add(frames[h].person_9); }
            if (frames[h].person_10 != null) { p.Add(frames[h].person_10); }
            if (frames[h].person_11 != null) { p.Add(frames[h].person_11); }
            if (frames[h].person_12 != null) { p.Add(frames[h].person_12); }
            if (frames[h].person_13 != null) { p.Add(frames[h].person_13); }
            if (frames[h].person_14 != null) { p.Add(frames[h].person_14); }
            if (frames[h].person_15 != null) { p.Add(frames[h].person_15); }
            if (frames[h].person_16 != null) { p.Add(frames[h].person_16); }
            if (frames[h].person_17 != null) { p.Add(frames[h].person_17); }
            if (frames[h].person_18 != null) { p.Add(frames[h].person_18); }
            if (frames[h].person_19 != null) { p.Add(frames[h].person_19); }
            Debug.Log(p.Count);
            for(int y = 0; y < p.Count; y++)//ciclo persone nel frame presente
            {

               if (frames[h].person_0 != null)
                {
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                           // time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }//distance[t]=-1
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                            distance[t] = -1;
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        //time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_1 != null) {
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_2 != null) {
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_3 != null) {
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_4 != null) {
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_5 != null) {
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_6 != null) {
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_7 != null) {
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_8 != null) {
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_9 != null) {
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_10 != null){
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_11 != null){
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_12 != null){
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_13 != null){
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_14 != null){
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_15 != null){
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_16 != null){
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_17 != null){
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_18 != null){
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count){
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               if (frames[h].person_19 != null)
                {
                    bool ver = true;
                    for (int t = 0; t < distance.Count; t++)//ciclo verifica distanze già presenti
                    {
                        if (p[y].dis - distance[t] < threshold && ver == true)//verifica sotto soglia
                        {
                            ver = false;
                            time[t] = framelost;
                            distance[t] = p[y].dis;
                            switch (t)
                            {
                                case 0: { frames[h].person_0 = p[y]; break; }
                                case 1: { frames[h].person_1 = p[y]; break; }
                                case 2: { frames[h].person_2 = p[y]; break; }
                                case 3: { frames[h].person_3 = p[y]; break; }
                                case 4: { frames[h].person_4 = p[y]; break; }
                                case 5: { frames[h].person_5 = p[y]; break; }
                                case 6: { frames[h].person_6 = p[y]; break; }
                                case 7: { frames[h].person_7 = p[y]; break; }
                                case 8: { frames[h].person_8 = p[y]; break; }
                                case 9: { frames[h].person_9 = p[y]; break; }
                                case 10: { frames[h].person_10 = p[y]; break; }
                                case 11: { frames[h].person_11 = p[y]; break; }
                                case 12: { frames[h].person_12 = p[y]; break; }
                                case 13: { frames[h].person_13 = p[y]; break; }
                                case 14: { frames[h].person_14 = p[y]; break; }
                                case 15: { frames[h].person_15 = p[y]; break; }
                                case 16: { frames[h].person_16 = p[y]; break; }
                                case 17: { frames[h].person_17 = p[y]; break; }
                                case 18: { frames[h].person_18 = p[y]; break; }
                                case 19: { frames[h].person_19 = p[y]; break; }
                            }
                        }

                    }//trovo una pos simile
                    if (ver)
                    {
                        distance.Add(p[y].dis);
                        time[distance.Count] = framelost;
                        switch (distance.Count)
                        {
                            case 0: { frames[h].person_0 = p[y]; break; }
                            case 1: { frames[h].person_1 = p[y]; break; }
                            case 2: { frames[h].person_2 = p[y]; break; }
                            case 3: { frames[h].person_3 = p[y]; break; }
                            case 4: { frames[h].person_4 = p[y]; break; }
                            case 5: { frames[h].person_5 = p[y]; break; }
                            case 6: { frames[h].person_6 = p[y]; break; }
                            case 7: { frames[h].person_7 = p[y]; break; }
                            case 8: { frames[h].person_8 = p[y]; break; }
                            case 9: { frames[h].person_9 = p[y]; break; }
                            case 10: { frames[h].person_10 = p[y]; break; }
                            case 11: { frames[h].person_11 = p[y]; break; }
                            case 12: { frames[h].person_12 = p[y]; break; }
                            case 13: { frames[h].person_13 = p[y]; break; }
                            case 14: { frames[h].person_14 = p[y]; break; }
                            case 15: { frames[h].person_15 = p[y]; break; }
                            case 16: { frames[h].person_16 = p[y]; break; }
                            case 17: { frames[h].person_17 = p[y]; break; }
                            case 18: { frames[h].person_18 = p[y]; break; }
                            case 19: { frames[h].person_19 = p[y]; break; }

                        }

                    }//nuova pos
                }
               /* for (int g = 0; g < 20; g++)//controllo overtime
                {
                    time[g]--;
                    if (time[g] == 0)
                    {
                        distance.RemoveAt(g);
                        for (int o = 0; o < 20; o++)
                        {
                            if (o < 19)
                            {
                                if (time[o] == 0 && time[o + 1] != -1)
                                {
                                    time[o] = time[o + 1];
                                    time[o + 1] = 0;
                                }
                            }
                        }
                    }
                }//controllo overtime*/
            }
            }
        }
    void PatternRecognition()
    {
        List<Persona>[] tmp = new List<Persona>[4];
        int frame = frames.Count;
        int nper = 0;
        int nper1 = 0;
        int nper2 = 0;
        int nper3 = 0;
        for (int i = 0; i < frame; i++)
        {
            tmp[0] = new List<Persona>();
            tmp[1] = new List<Persona>();
            tmp[2] = new List<Persona>();
            tmp[3] = new List<Persona>();
            // popolamento dei tmp
            if (frames[i].person_0 != null) { tmp[0].Add(frames[i].person_0); nper++; }
            if (frames[i].person_1 != null) { tmp[0].Add(frames[i].person_1); nper++; }
            if (frames[i].person_2 != null) { tmp[0].Add(frames[i].person_2); nper++; }
            if (frames[i].person_3 != null) { tmp[0].Add(frames[i].person_3); nper++; }
            if (frames[i].person_4 != null) { tmp[0].Add(frames[i].person_4); nper++; }
            if (frames[i].person_5 != null) { tmp[0].Add(frames[i].person_5); nper++; }
            if (frames[i].person_6 != null) { tmp[0].Add(frames[i].person_6); nper++; }
            if (frames[i].person_7 != null) { tmp[0].Add(frames[i].person_7); nper++; }
            if (frames[i].person_8 != null) { tmp[0].Add(frames[i].person_8); nper++; }
            if (frames[i].person_9 != null) { tmp[0].Add(frames[i].person_9); nper++; }
            if (frames[i].person_10 != null) { tmp[0].Add(frames[i].person_10); nper++; }
            if (frames[i].person_11 != null) { tmp[0].Add(frames[i].person_11); nper++; }
            if (frames[i].person_12 != null) { tmp[0].Add(frames[i].person_12); nper++; }
            if (frames[i].person_13 != null) { tmp[0].Add(frames[i].person_13); nper++; }
            if (frames[i].person_14 != null) { tmp[0].Add(frames[i].person_14); nper++; }
            if (frames[i].person_15 != null) { tmp[0].Add(frames[i].person_15); nper++; }
            if (frames[i].person_16 != null) { tmp[0].Add(frames[i].person_16); nper++; }
            if (frames[i].person_17 != null) { tmp[0].Add(frames[i].person_17); nper++; }
            if (frames[i].person_18 != null) { tmp[0].Add(frames[i].person_18); nper++; }
            if (frames[i].person_19 != null) { tmp[0].Add(frames[i].person_19); nper++; }

             if (frames[i+1].person_0 != null) { tmp[1].Add(frames[i+1].person_0); nper1++; }
             if (frames[i+1].person_1 != null) { tmp[1].Add(frames[i+1].person_1); nper1++; }
             if (frames[i+1].person_2 != null) { tmp[1].Add(frames[i+1].person_2); nper1++; }
             if (frames[i+1].person_3 != null) { tmp[1].Add(frames[i+1].person_3); nper1++; }
             if (frames[i+1].person_4 != null) { tmp[1].Add(frames[i+1].person_4); nper1++; }
             if (frames[i+1].person_5 != null) { tmp[1].Add(frames[i+1].person_5); nper1++; }
             if (frames[i+1].person_6 != null) { tmp[1].Add(frames[i+1].person_6); nper1++; }
             if (frames[i+1].person_7 != null) { tmp[1].Add(frames[i+1].person_7); nper1++; }
             if (frames[i+1].person_8 != null) { tmp[1].Add(frames[i+1].person_8); nper1++; }
             if (frames[i+1].person_9 != null) { tmp[1].Add(frames[i+1].person_9); nper1++; }
            if (frames[i+1].person_10 != null) { tmp[1].Add(frames[i+1].person_10); nper1++; }
            if (frames[i+1].person_11 != null) { tmp[1].Add(frames[i+1].person_11); nper1++; }
            if (frames[i+1].person_12 != null) { tmp[1].Add(frames[i+1].person_12); nper1++; }
            if (frames[i+1].person_13 != null) { tmp[1].Add(frames[i+1].person_13); nper1++; }
            if (frames[i+1].person_14 != null) { tmp[1].Add(frames[i+1].person_14); nper1++; }
            if (frames[i+1].person_15 != null) { tmp[1].Add(frames[i+1].person_15); nper1++; }
            if (frames[i+1].person_16 != null) { tmp[1].Add(frames[i+1].person_16); nper1++; }
            if (frames[i+1].person_17 != null) { tmp[1].Add(frames[i+1].person_17); nper1++; }
            if (frames[i+1].person_18 != null) { tmp[1].Add(frames[i+1].person_18); nper1++; }
            if (frames[i+1].person_19 != null) { tmp[1].Add(frames[i+1].person_19); nper1++; }

            if (frames[i+2].person_0 != null) { tmp[2].Add(frames[i+2].person_0); nper2++; }
            if (frames[i+2].person_1 != null) { tmp[2].Add(frames[i+2].person_1); nper2++; }
            if (frames[i+2].person_2 != null) { tmp[2].Add(frames[i+2].person_2); nper2++; }
            if (frames[i+2].person_3 != null) { tmp[2].Add(frames[i+2].person_3); nper2++; }
            if (frames[i+2].person_4 != null) { tmp[2].Add(frames[i+2].person_4); nper2++; }
            if (frames[i+2].person_5 != null) { tmp[2].Add(frames[i+2].person_5); nper2++; }
            if (frames[i+2].person_6 != null) { tmp[2].Add(frames[i+2].person_6); nper2++; }
            if (frames[i+2].person_7 != null) { tmp[2].Add(frames[i+2].person_7); nper2++; }
            if (frames[i+2].person_8 != null) { tmp[2].Add(frames[i+2].person_8); nper2++; }
            if (frames[i+2].person_9 != null) { tmp[2].Add(frames[i+2].person_9); nper2++; }
            if (frames[i+2].person_10 != null) { tmp[2].Add(frames[i+2].person_10); nper2++; }
            if (frames[i+2].person_11 != null) { tmp[2].Add(frames[i+2].person_11); nper2++; }
            if (frames[i+2].person_12 != null) { tmp[2].Add(frames[i+2].person_12); nper2++; }
            if (frames[i+2].person_13 != null) { tmp[2].Add(frames[i+2].person_13); nper2++; }
            if (frames[i+2].person_14 != null) { tmp[2].Add(frames[i+2].person_14); nper2++; }
            if (frames[i+2].person_15 != null) { tmp[2].Add(frames[i+2].person_15); nper2++; }
            if (frames[i+2].person_16 != null) { tmp[2].Add(frames[i+2].person_16); nper2++; }
            if (frames[i+2].person_17 != null) { tmp[2].Add(frames[i+2].person_17); nper2++; }
            if (frames[i+2].person_18 != null) { tmp[2].Add(frames[i+2].person_18); nper2++; }
            if (frames[i+2].person_19 != null) { tmp[2].Add(frames[i+2].person_19); nper2++; }

            if (frames[i+3].person_0 != null) { tmp[3].Add(frames[i+3].person_0); nper3++; }
            if (frames[i+3].person_1 != null) { tmp[3].Add(frames[i+3].person_1); nper3++; }
            if (frames[i+3].person_2 != null) { tmp[3].Add(frames[i+3].person_2); nper3++; }
            if (frames[i+3].person_3 != null) { tmp[3].Add(frames[i+3].person_3); nper3++; }
            if (frames[i+3].person_4 != null) { tmp[3].Add(frames[i+3].person_4); nper3++; }
            if (frames[i+3].person_5 != null) { tmp[3].Add(frames[i+3].person_5); nper3++; }
            if (frames[i+3].person_6 != null) { tmp[3].Add(frames[i+3].person_6); nper3++; }
            if (frames[i+3].person_7 != null) { tmp[3].Add(frames[i+3].person_7); nper3++; }
            if (frames[i+3].person_8 != null) { tmp[3].Add(frames[i+3].person_8); nper3++; }
            if (frames[i+3].person_9 != null) { tmp[3].Add(frames[i+3].person_9); nper3++; }
            if (frames[i+3].person_10 != null) { tmp[3].Add(frames[i+3].person_10); nper3++; }
            if (frames[i+3].person_11 != null) { tmp[3].Add(frames[i+3].person_11); nper3++; }
            if (frames[i+3].person_12 != null) { tmp[3].Add(frames[i+3].person_12); nper3++; }
            if (frames[i+3].person_13 != null) { tmp[3].Add(frames[i+3].person_13); nper3++; }
            if (frames[i+3].person_14 != null) { tmp[3].Add(frames[i+3].person_14); nper3++; }
            if (frames[i+3].person_15 != null) { tmp[3].Add(frames[i+3].person_15); nper3++; }
            if (frames[i+3].person_16 != null) { tmp[3].Add(frames[i+3].person_16); nper3++; }
            if (frames[i+3].person_17 != null) { tmp[3].Add(frames[i+3].person_17); nper3++; }
            if (frames[i+3].person_18 != null) { tmp[3].Add(frames[i+3].person_18); nper3++; }
            if (frames[i+3].person_19 != null) { tmp[3].Add(frames[i+3].person_19); nper3++; }
            
            //sort dei temp
            
            tmp[0].Sort(delegate (Persona a, Persona b)
            {
                if (a.dis == null && b.dis == null) return 0;
                else if (a.dis == null) return -1;
                else if (b.dis == null) return 1;
                return a.dis.CompareTo(b.dis);
            });
            int j = tmp[0].Count;
            tmp[1].Sort(delegate (Persona a, Persona b)
            {
                if (a.dis == null && b.dis == null) return 0;
                else if (a.dis == null) return -1;
                else if (b.dis == null) return 1;
                return a.dis.CompareTo(b.dis);
            });
            int j1 = tmp[1].Count;
            tmp[2].Sort(delegate (Persona a, Persona b)
            {
                if (a.dis == null && b.dis == null) return 0;
                else if (a.dis == null) return -1;
                else if (b.dis == null) return 1;
                return a.dis.CompareTo(b.dis);
            });
            int j2 = tmp[2].Count;
            tmp[3].Sort(delegate (Persona a, Persona b)
            {
                if (a.dis == null && b.dis == null) return 0;
                else if (a.dis == null) return -1;
                else if (b.dis == null) return 1;
                return a.dis.CompareTo(b.dis);
            });
            int j3 = tmp[3].Count;
            


            for (int c = 0; c < 4; c++)//salvataggio in frames
            {
                if (tmp[c][9].joint_1 != null && frames[i].person_9.joint_1 != null && j > 9 && nper > 9) { frames[i].person_9 = tmp[c][9]; }
                if (tmp[c][8].joint_1 != null && frames[i].person_8.joint_1 != null && j > 8 && nper > 8) { frames[i].person_8 = tmp[c][8]; }
                if (tmp[c][7].joint_1 != null && frames[i].person_7.joint_1 != null && j > 7 && nper > 7) { frames[i].person_7 = tmp[c][7]; }
                if (tmp[c][6].joint_1 != null && frames[i].person_6.joint_1 != null && j > 6 && nper > 6) { frames[i].person_6 = tmp[c][6]; }
                if (tmp[c][5].joint_1 != null && frames[i].person_5.joint_1 != null && j > 5 && nper > 5) { frames[i].person_5 = tmp[c][5]; }
                if (tmp[c][4].joint_1 != null && frames[i].person_4.joint_1 != null && j > 4 && nper > 4) { frames[i].person_4 = tmp[c][4]; }
                if (tmp[c][3].joint_1 != null && frames[i].person_3.joint_1 != null && j > 3 && nper > 3) { frames[i].person_3 = tmp[c][3]; }
                if (tmp[c][2].joint_1 != null && frames[i].person_2.joint_1 != null && j > 2 && nper > 2) { frames[i].person_2 = tmp[c][2]; }
                if (tmp[c][1].joint_1 != null && frames[i].person_1.joint_1 != null && j > 1 && nper > 1) { frames[i].person_1 = tmp[c][1]; }
                if (tmp[c][0].joint_1 != null && frames[i].person_0.joint_1 != null && j > 0 && nper > 0) { frames[i].person_0 = tmp[c][0]; }
                if (tmp[c][19].joint_1 != null && frames[i].person_19.joint_1 != null && j > 19 && nper > 19) { frames[i].person_19 = tmp[c][19]; }
                if (tmp[c][18].joint_1 != null && frames[i].person_18.joint_1 != null && j > 18 && nper > 18) { frames[i].person_18 = tmp[c][18]; }
                if (tmp[c][17].joint_1 != null && frames[i].person_17.joint_1 != null && j > 17 && nper > 17) { frames[i].person_17 = tmp[c][17]; }
                if (tmp[c][16].joint_1 != null && frames[i].person_16.joint_1 != null && j > 16 && nper > 16) { frames[i].person_16 = tmp[c][16]; }
                if (tmp[c][15].joint_1 != null && frames[i].person_15.joint_1 != null && j > 15 && nper > 15) { frames[i].person_15 = tmp[c][15]; }
                if (tmp[c][14].joint_1 != null && frames[i].person_14.joint_1 != null && j > 14 && nper > 14) { frames[i].person_14 = tmp[c][14]; }
                if (tmp[c][13].joint_1 != null && frames[i].person_13.joint_1 != null && j > 13 && nper > 13) { frames[i].person_13 = tmp[c][13]; }
                if (tmp[c][12].joint_1 != null && frames[i].person_12.joint_1 != null && j > 12 && nper > 12) { frames[i].person_12 = tmp[c][12]; }
                if (tmp[c][11].joint_1 != null && frames[i].person_11.joint_1 != null && j > 11 && nper > 11) { frames[i].person_11 = tmp[c][11]; }
                if (tmp[c][10].joint_1 != null && frames[i].person_10.joint_1 != null && j > 10 && nper > 10) { frames[i].person_10 = tmp[c][10]; }
            }
            nper = 0;
            nper1 = 0;
            nper2 = 0;
            nper3 = 0;

        }

    }
    void ordinaFrames()
    {
        var output = JsonUtility.ToJson(frames[0].person_0, true);
        Debug.Log(output);


        var prova = new List<Persona>();
        var gro = new List<Frame>();
        gro.Add(frames[0]);
        gro.Add(frames[1]);
        gro.Add(frames[2]);
        prova.Add(frames[0].person_0);
        prova.Add(frames[0].person_1);
        prova.Add(frames[0].person_2);
        prova.Add(frames[0].person_3);
        prova.Add(frames[0].person_4);
        prova.Add(frames[0].person_5);
        prova.Add(frames[0].person_6);
        Debug.Log("-------------");
        Debug.Log(prova[0].dis);
        Debug.Log(prova[1].dis);
        Debug.Log(prova[2].dis);
        Debug.Log(prova[3].dis);
        Debug.Log(prova[4].dis);
        Debug.Log(prova[5].dis);
        foreach(Frame fra in frames)
        {
            fra.Sort(delegate (Persona a, Persona b)
            {
                return a.dis.CompareTo(b.dis);
            });
        }
        prova.Sort(delegate (Persona a, Persona b)
        {
            return a.dis.CompareTo(b.dis);
        });
        //Frame vediamo = frames[0];
        //vediamo.Sort(new myComparer());
        // var output2 = JsonUtility.ToJson(prova, true);
        //Debug.Log(output2);
        Debug.Log("-------------");
        Debug.Log(prova[0].dis);
        Debug.Log(prova[1].dis);
        Debug.Log(prova[2].dis);
        Debug.Log(prova[3].dis);
        Debug.Log(prova[4].dis);
        Debug.Log(prova[5].dis);

    }
}

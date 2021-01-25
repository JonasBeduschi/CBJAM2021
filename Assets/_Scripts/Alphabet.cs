using UnityEngine;

public class Alphabet : MonoBehaviour
{
    [SerializeField] private GameObject[] Letters;

    public GameObject GetObjectFor(char c)
    {
        switch (c) {
            case 'A': return Letters[0];
            case 'B': return Letters[1];
            case 'C': return Letters[2];
            case 'D': return Letters[3];
            case 'E': return Letters[4];
            case 'F': return Letters[5];
            case 'G': return Letters[6];
            case 'H': return Letters[7];
            case 'I': return Letters[8];
            case 'J': return Letters[9];
            case 'K': return Letters[10];
            case 'L': return Letters[11];
            case 'M': return Letters[12];
            case 'N': return Letters[13];
            case 'O': return Letters[14];
            case 'P': return Letters[15];
            case 'Q': return Letters[16];
            case 'R': return Letters[17];
            case 'S': return Letters[18];
            case 'T': return Letters[19];
            case 'U': return Letters[20];
            case 'V': return Letters[21];
            case 'W': return Letters[22];
            case 'X': return Letters[23];
            case 'Y': return Letters[24];
            case 'Z': return Letters[25];
            case '?': return Letters[26];
            case '!': return Letters[27];
            case '*': return Letters[28];
            case ',': return Letters[29];
            case ' ': return Letters[30];
            default: return Letters[0];
        }
    }
}
using UnityEngine;

public class CameraVolger : MonoBehaviour
{
    [Header("Basis Instellingen")]
    public Transform doelwit;         // Het busje
    public float afstand = 8f;        // Hoe ver de camera achter het busje hangt
    public float hoogteOffset = 1.5f; // Hoe hoog boven het midden van het busje hij kijkt
    public float muisGevoeligheid = 3f;

    [Header("Automatisch Terugdraaien")]
    public float wachtTijdVoorReset = 2f; // Aantal seconden wachten na loslaten muis
    public float resetSnelheid = 3f;      // Hoe snel hij terugdraait naar achteren

    private float huidigeYaw = 0f;
    private float huidigePitch = 15f;
    private float standaardPitch = 15f;
    private float tijdSindsLaatsteMuisBeweging = 0f;

    void Start()
    {
        if (doelwit != null)
        {
            huidigeYaw = doelwit.eulerAngles.y;
        }
    }

    void LateUpdate()
    {
        if (doelwit == null) return;

        // 1. Als de RECHTERmuisknop wordt ingedrukt
        if (Input.GetMouseButton(1))
        {
            // Reset de timer naar 0 zolang we de knop vasthouden
            tijdSindsLaatsteMuisBeweging = 0f;

            huidigeYaw += Input.GetAxis("Mouse X") * muisGevoeligheid;
            huidigePitch -= Input.GetAxis("Mouse Y") * muisGevoeligheid;
            huidigePitch = Mathf.Clamp(huidigePitch, 5f, 80f);
        }
        else
        {
            // 2. Knop is losgelaten: tel de seconden op
            tijdSindsLaatsteMuisBeweging += Time.deltaTime;

            // Is de wachttijd voorbij? Draai dan vloeiend terug achter het busje!
            if (tijdSindsLaatsteMuisBeweging >= wachtTijdVoorReset)
            {
                // doelwit.eulerAngles.y is de richting waar de voorkant van het busje heen wijst
                float doelYaw = doelwit.eulerAngles.y;

                // LerpAngle is speciaal voor hoeken (zodat hij bij 360 graden niet de verkeerde kant op tolt)
                huidigeYaw = Mathf.LerpAngle(huidigeYaw, doelYaw, resetSnelheid * Time.deltaTime);
                huidigePitch = Mathf.Lerp(huidigePitch, standaardPitch, resetSnelheid * Time.deltaTime);
            }
        }

        // 3. Bereken de positie en rotatie van de camera
        Quaternion rotatie = Quaternion.Euler(huidigePitch, huidigeYaw, 0f);
        Vector3 kijkPunt = doelwit.position + Vector3.up * hoogteOffset;
        Vector3 gewenstePositie = kijkPunt - (rotatie * Vector3.forward * afstand);

        transform.position = gewenstePositie;
        transform.LookAt(kijkPunt);
    }
}

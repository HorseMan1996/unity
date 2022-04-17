using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropen : MonoBehaviour
{
    public Animator outdooranimation;
    public AudioSource kapiacsesi;
    public AudioSource kapikapamasesi;
    public AudioClip kapiacsesis;
    public AudioClip kapikapamasesis;

    public Animator indoorleftanimation;
    public AudioSource indoorleftkapiacsesi;
    public AudioSource indoorleftkapikapamasesi;
    public AudioClip indoorleftkapiacsesis;
    public AudioClip indoorleftkapikapamasesis;

    public Animator indoorrightanimation;
    public AudioSource indoorrightkapiacsesi;
    public AudioSource indoorrightkapikapamasesi;
    public AudioClip indoorrightkapiacsesis;
    public AudioClip indoorrightkapikapamasesis;

    public Animator indoorcenteranimation;
    public AudioSource indoorcenterkapiacsesi;
    public AudioSource indoorcenterkapikapamasesi;
    public AudioClip indoorcenterkapiacsesis;
    public AudioClip indoorcenterkapikapamasesis;

    public Animator indoorcenterrightanimation;
    public AudioSource indoorcenterrightkapiacsesi;
    public AudioSource indoorcenterrightkapikapamasesi;
    public AudioClip indoorcenterrightkapiacsesis;
    public AudioClip indoorcenterrightkapikapamasesis;

    public Animator energyroomdooranimation;
    public AudioSource energyroomdooropensound;
    public AudioSource energyroomdoorclosesound;
    public AudioClip energyroomdooropensounds;
    public AudioClip energyroomdoorclosesounds;

    public Animator indoorcenterleftanimation;
    public AudioSource indoorcenterleftopensound;
    public AudioSource indoorcenterleftclosesound;
    public AudioClip indoorcenterleftopensounds;
    public AudioClip indoorcenterleftclosesounds;

    public Animator toilet1doortanimation;
    public AudioSource toilet1dooropensound;
    public AudioSource toilet1doorclosesound;
    public AudioClip toilet1dooropensounds;
    public AudioClip toilet1doorclosesounds;

    public Animator toilet2doortanimation;
    public AudioSource toilet2dooropensound;
    public AudioSource toilet2doorclosesound;
    public AudioClip toilet2dooropensounds;
    public AudioClip toilet2doorclosesounds;

    public Animator warehousedoortanimation;
    public AudioSource warehousedooropensound;
    public AudioSource warehousedoorclosesound;
    public AudioClip warehousedooropensounds;
    public AudioClip warehousedoorclosesounds;

    public Animator coopdooranimation;
    public AudioSource coopdooropensound;
    public AudioSource coopdoorclosesound;
    public AudioClip coopdooropensounds;
    public AudioClip coopdoorclosesounds;

    public Animator entrydooranimation;
    public AudioSource entrydooropensound;
    public AudioSource entrydoorclosesound;
    public AudioClip entrydooropensounds;
    public AudioClip entrydoorclosesounds;

    public Animator folukkapak;
    public AudioSource follukac;
    public AudioClip follukacs;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    void OnTriggerStay(Collider collision)
    {

        //cisim duvarlara çarptığında 
        if ((collision.name == "outdoor"))
        {
            if (Input.GetKeyDown("e"))
            {
                kapiacsesi.PlayOneShot(kapiacsesis, 1F);
                outdooranimation.SetBool("outdoorac", true);
            }
            if (Input.GetKeyDown("r"))
            {
                kapikapamasesi.PlayOneShot(kapikapamasesis, 1F);
                outdooranimation.SetBool("outdoorac", false);
            }
        }
        if ((collision.name == "indoorleft"))
        {
            if (Input.GetKeyDown("e"))
            {
                indoorleftkapiacsesi.PlayOneShot(kapiacsesis, 1F);
                indoorleftanimation.SetBool("indoorleft", true);
            }
            if (Input.GetKeyDown("r"))
            {
                indoorleftkapikapamasesi.PlayOneShot(kapikapamasesis, 1F);
                indoorleftanimation.SetBool("indoorleft", false);
            }
        }
        if ((collision.name == "indoorright"))
        {
            if (Input.GetKeyDown("e"))
            {
                indoorrightkapiacsesi.PlayOneShot(indoorrightkapiacsesis, 1F);
                indoorrightanimation.SetBool("indoorright", true);
            }
            if (Input.GetKeyDown("r"))
            {
                indoorrightkapikapamasesi.PlayOneShot(indoorrightkapikapamasesis, 1F);
                indoorrightanimation.SetBool("indoorright", false);
            }
        }
        if ((collision.name == "indoorcenter"))
        {
            if (Input.GetKeyDown("e"))
            {
                indoorcenterkapiacsesi.PlayOneShot(indoorcenterkapiacsesis, 1F);
                indoorcenteranimation.SetBool("indoorcenter", true);
            }
            if (Input.GetKeyDown("r"))
            {
                indoorcenterkapikapamasesi.PlayOneShot(indoorcenterkapikapamasesis, 1F);
                indoorcenteranimation.SetBool("indoorcenter", false);
            }
        }
        if ((collision.name == "indoorcenterright"))
        {
            if (Input.GetKeyDown("e"))
            {
                indoorcenterrightkapiacsesi.PlayOneShot(indoorcenterrightkapiacsesis, 1F);
                indoorcenterrightanimation.SetBool("indoorcenterright", true);
            }
            if (Input.GetKeyDown("r"))
            {
                indoorcenterrightkapikapamasesi.PlayOneShot(indoorcenterrightkapikapamasesis, 1F);
                indoorcenterrightanimation.SetBool("indoorcenterright", false);
            }
        }
        if ((collision.name == "indoorcenterleft"))
        {
            if (Input.GetKeyDown("e"))
            {
                indoorcenterleftopensound.PlayOneShot(indoorcenterleftopensounds, 1F);
                indoorcenterleftanimation.SetBool("indoorcenterleft", true);
            }
            if (Input.GetKeyDown("r"))
            {
                indoorcenterleftclosesound.PlayOneShot(indoorcenterleftclosesounds, 1F);
                indoorcenterleftanimation.SetBool("indoorcenterleft", false);
            }
        }
        if ((collision.name == "energyroomdoor"))
        {
            if (Input.GetKeyDown("e"))
            {
                indoorcenterrightkapiacsesi.PlayOneShot(energyroomdooropensounds, 1F);
                energyroomdooranimation.SetBool("energyroomdoor", true);
            }
            if (Input.GetKeyDown("r"))
            {
                energyroomdoorclosesound.PlayOneShot(energyroomdoorclosesounds, 1F);
                energyroomdooranimation.SetBool("energyroomdoor", false);
            }
        }
        if ((collision.name == "toilet1door"))
        {
            if (Input.GetKeyDown("e"))
            {
                toilet1dooropensound.PlayOneShot(toilet1dooropensounds, 1F);
                toilet1doortanimation.SetBool("toilet1door", true);
            }
            if (Input.GetKeyDown("r"))
            {
                toilet1doorclosesound.PlayOneShot(toilet1doorclosesounds, 1F);
                toilet1doortanimation.SetBool("toilet1door", false);
            }
        }
        if ((collision.name == "toilet2door"))
        {
            if (Input.GetKeyDown("e"))
            {
                toilet2dooropensound.PlayOneShot(toilet2dooropensounds, 1F);
                toilet2doortanimation.SetBool("toilet2door", true);
            }
            if (Input.GetKeyDown("r"))
            {
                toilet2doorclosesound.PlayOneShot(toilet2doorclosesounds, 1F);
                toilet2doortanimation.SetBool("toilet2door", false);
            }
        }
        if ((collision.name == "warehousedoor"))
        {
            if (Input.GetKeyDown("e"))
            {
                warehousedooropensound.PlayOneShot(warehousedooropensounds, 1F);
                warehousedoortanimation.SetBool("warehousedoor", true);
            }
            if (Input.GetKeyDown("r"))
            {
                warehousedoorclosesound.PlayOneShot(warehousedoorclosesounds, 1F);
                warehousedoortanimation.SetBool("warehousedoor", false);
            }
        }
        if ((collision.name == "coopdoor"))
        {
            if (Input.GetKeyDown("e"))
            {
                coopdooropensound.PlayOneShot(coopdooropensounds, 1F);
                coopdooranimation.SetBool("coopdoor", true);
            }
            if (Input.GetKeyDown("r"))
            {
                coopdoorclosesound.PlayOneShot(coopdoorclosesounds, 1F);
                coopdooranimation.SetBool("coopdoor", false);
            }
        }
        if ((collision.name == "entrydoor1"))
        {
            if (Input.GetKeyDown("e"))
            {
                entrydooropensound.PlayOneShot(entrydooropensounds, 1F);
                entrydooranimation.SetBool("entrydooropen", true);
            }
            if (Input.GetKeyDown("r"))
            {
                entrydoorclosesound.PlayOneShot(entrydoorclosesounds, 1F);
                entrydooranimation.SetBool("entrydooropen", false);
            }
        }
        if ((collision.name == "mentese"))
        {
            if (Input.GetKeyDown("e"))
            {
                follukac.PlayOneShot(follukacs, 1F);
                folukkapak.SetBool("follukac", true);
            }
            if (Input.GetKeyDown("r"))
            {
                follukac.PlayOneShot(follukacs, 1F);
                folukkapak.SetBool("follukac", false);
            }
        }
    }
}

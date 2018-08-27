using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MuseRecieve : MonoBehaviour {

    public OscIn oscIn;

    public bool notch_filtered_eeg_check, eeg_check, alpha_absolute_check, beta_absolute_check, delta_absolute_check, theta_absolute_check, gamma_absolute_check,
        alpha_relative_check, beta_relative_check, delta_relative_check, theta_relative_check, gamma_relative_check, alpha_session_score_check, beta_session_score_check,
        delta_session_score_check, theta_session_score_check, gamma_session_score_check, is_good_check, horseshoe_check, gyro_check, acc_check, drlref_check, batt_check, 
        blink_check, jaw_clench_check, CONCENTRATION_check, MELLOW_check;

    [HideInInspector]
    public float[] notch_filtered_eeg, eeg, alpha_absolute, beta_absolute, delta_absolute, theta_absolute, gamma_absolute,
        alpha_relative, beta_relative, delta_relative, theta_relative, gamma_relative, alpha_session_score, beta_session_score,
        delta_session_score, theta_session_score, gamma_session_score, is_good, horseshoe, gyro, acc, drlref, batt;
    [HideInInspector]
    public Int16 blink, jaw_clench;
    [HideInInspector]
    public float concentration, mellow;

    void Start()
    {
        // Ensure that we have a OscIn component.
        if (!oscIn) oscIn = gameObject.AddComponent<OscIn>();

        // Start receiving from unicast and broadcast sources on port 7000.
        oscIn.Open(7000);

    }

    void OnEnable()
    {
        if (notch_filtered_eeg_check) oscIn.Map("/notch_filtered_eeg", raw_notch_filtered_eeg);
        if (eeg_check) oscIn.Map("/eeg", raw_eeg);
        if (alpha_absolute_check) oscIn.Map("/elements/alpha_absolute", raw_alpha_absolute);
        if (beta_absolute_check) oscIn.Map("/elements/beta_absolute", raw_beta_absolute);
        if (delta_absolute_check) oscIn.Map("/elements/delta_absolute", raw_delta_absolute);
        if (theta_absolute_check) oscIn.Map("/elements/theta_absolute", raw_theta_absolute);
        if (gamma_absolute_check) oscIn.Map("/elements/gamma_absolute", raw_gamma_absolute);
        if (alpha_relative_check) oscIn.Map("/elements/alpha_relative", raw_alpha_relative);
        if (beta_relative_check) oscIn.Map("/elements/beta_relative", raw_beta_relative);
        if (delta_relative_check) oscIn.Map("/elements/delta_relative", raw_delta_relative);
        if (theta_relative_check) oscIn.Map("/elements/theta_relative", raw_theta_relative);
        if (gamma_relative_check) oscIn.Map("/elements/gamma_relative", raw_gamma_relative);
        if (alpha_session_score_check) oscIn.Map("/elements/alpha_session_score", raw_alpha_session_score);
        if (beta_session_score_check) oscIn.Map("/elements/beta_session_score", raw_beta_session_score);
        if (delta_session_score_check) oscIn.Map("/elements/delta_session_score", raw_delta_session_score);
        if (theta_session_score_check) oscIn.Map("/elements/theta_session_score", raw_theta_session_score);
        if (gamma_session_score_check) oscIn.Map("/elements/gamma_session_score", raw_gamma_session_score);
        if (is_good_check) oscIn.Map("/elements/is_good", raw_is_good);
        if (horseshoe_check) oscIn.Map("/horseshoe", raw_horseshoe);
        if (gyro_check) oscIn.Map("/gyro", raw_gyro);
        if (acc_check) oscIn.Map("/acc", raw_acc);
        if (drlref_check) oscIn.Map("/drlref", raw_drlref);
        if (batt_check) oscIn.Map("/batt", raw_batt);
        if (blink_check) oscIn.Map("/elements/blink", raw_blink);
        if (jaw_clench_check) oscIn.Map("/elements/jaw_clench", raw_jaw_clench);
        if (CONCENTRATION_check) oscIn.Map("/elements/experimental/concentration", raw_concentration);
        if (MELLOW_check) oscIn.Map("/elements/experimental/mellow", raw_mellow);


    }

    void OnDisable()
    {
        oscIn.UnmapAll("/");
        //oscIn.Unmap(raw_eeg);
        //oscIn.Unmap(raw_alpha_relative);
    }

    void raw_notch_filtered_eeg(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        notch_filtered_eeg = float_value;            // To public array
    }

    void raw_eeg(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        eeg = float_value;              // To public array
    }

    void raw_alpha_absolute(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        alpha_absolute = float_value;              // To public array
    }

    void raw_beta_absolute(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        beta_absolute = float_value;              // To public array
    }

    void raw_delta_absolute(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        delta_absolute = float_value;              // To public array
    }

    void raw_theta_absolute(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        theta_absolute = float_value;              // To public array
    }

    void raw_gamma_absolute(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        gamma_absolute = float_value;              // To public array
    }

    void raw_alpha_relative(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        alpha_relative = float_value;              // To public array
    }

    void raw_beta_relative(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        beta_relative = float_value;              // To public array
    }

    void raw_delta_relative(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        delta_relative = float_value;              // To public array
    }

    void raw_theta_relative(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        theta_relative = float_value;              // To public array
    }

    void raw_gamma_relative(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        gamma_relative = float_value;              // To public array
    }

    void raw_alpha_session_score(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        alpha_session_score = float_value;              // To public array
    }

    void raw_beta_session_score(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        beta_session_score = float_value;              // To public array
    }

    void raw_delta_session_score(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        delta_session_score = float_value;              // To public array
    }

    void raw_theta_session_score(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        theta_session_score = float_value;              // To public array
    }

    void raw_gamma_session_score(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        gamma_session_score = float_value;              // To public array
    }

    void raw_is_good(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        is_good = float_value;              // To public array
    }

    void raw_horseshoe(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[4];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        float_value[3] = float.Parse(array_value[4]);
        horseshoe = float_value;              // To public array
    }

    void raw_gyro(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[3];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        gyro = float_value;              // To public array
    }

    void raw_acc(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[3];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        acc = float_value;              // To public array
    }

    void raw_drlref(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[2];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        drlref = float_value;              // To public array
    }

    void raw_batt(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        float[] float_value = new float[3];
        float_value[0] = float.Parse(array_value[1]);
        float_value[1] = float.Parse(array_value[2]);
        float_value[2] = float.Parse(array_value[3]);
        batt = float_value;              // To public array
    }

    void raw_blink(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        blink = Convert.ToInt16(array_value[1]);         // To public array
    }

    void raw_jaw_clench(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        jaw_clench = Convert.ToInt16(array_value[1]);         // To public array
    }

    void raw_concentration(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        concentration = float.Parse(array_value[1]);         // To public array
        Debug.Log(concentration);
    }

    void raw_mellow(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        mellow = float.Parse(array_value[1]);         // To public array
    }


}

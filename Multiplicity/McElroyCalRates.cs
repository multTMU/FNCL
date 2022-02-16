using System;
using System.Collections.Generic;
using MathNet.Numerics;

namespace Multiplicity
{
    public struct DetectorCalibrationParameters
    {
        public struct DetectionParameters
        {
            public ValueWithUncertainty Efficiency;
            public ValueWithUncertainty DieAway_uS;
            public ValueWithUncertainty GateWidth_uS;
            public ValueWithUncertainty f_d; //think this is gate fraction doubles?
            public ValueWithUncertainty f_t; // think this is gate fraction triples
        }

        public struct DeadTimeParameters
        {
            public ValueWithUncertainty a_uS;
            public ValueWithUncertainty b_uSsquared;
            public ValueWithUncertainty c_ns;
            public ValueWithUncertainty d_ns;
            public ValueWithUncertainty tau;
        }

        public DetectionParameters Detector;
        public DeadTimeParameters DeadTime;
    }


    public struct ValueWithUncertainty
    {
        public double Value;
        public double Uncertainty;

        public ValueWithUncertainty(double value, double uncertainty = 0)
        {
            Value = value;
            Uncertainty = uncertainty;
        }
    }

    public struct McElroyRates
    {
        public ValueWithUncertainty Singles;
        public ValueWithUncertainty Doubles;
        public ValueWithUncertainty Triples;
        public ValueWithUncertainty Quads;
        public double SumAR;
        public double SumACC;
    }


    public static class McElroyCalcRates
    {
        public static McElroyRates calc_rates(List<double> A_R, List<double> ACCID,
            DetectorCalibrationParameters detector,
            double assay_time, int iOut, bool use_LANL_DT_flag = false)
        {
            detector = ScaleDeadTimes(detector);


            double sum_ar = 0;
            double sum_acc = 0;


            int numBins = (A_R.Count > ACCID.Count) ? A_R.Count : ACCID.Count;

            double C_S = 0; // Incc style reals rates
            double C_RA = 0;
            double C_A = 0;

            for (int i = 0; i < numBins; i++)
            {
                sum_ar += A_R[i];
                sum_acc += ACCID[i];
                C_S += ACCID[i];
                C_RA += i * A_R[i]; //Bob has (i-1) but we have zero indexed, he had one indexed
                C_A += i * ACCID[i];
            }

            double Phi = detector.DeadTime.tau.Value / detector.Detector.GateWidth_uS.Value / 1000.0;


            // make everything a list 

            List<double> alph = new List<double>();
            List<double> bet = new List<double>();
            List<double> mr = new List<double>();
            List<double> p_i = new List<double>();
            List<double> q_i = new List<double>();
            List<double> r_1 = new List<double>();
            List<double> r_2 = new List<double>();
            List<double> r_3 = new List<double>();
            List<double> gam = new List<double>();
            List<double> g_2 = new List<double>();

            for (int i = 0; i < numBins; i++)
            {
                p_i[i] = A_R[i] / sum_ar;
                q_i[i] = ACCID[i] / sum_acc;
                alph[i + 1] = (1.0 + (i + 1) * Phi + 3.0 / 2.0 * Math.Pow((i + 2) * Phi, 2) +
                               5.0 / 2.0 * Math.Pow((i + 1) * Phi, 3) +
                               7.0 / 2.0 * Math.Pow((i + 1) * Phi, 4) * (i + 2));
                bet[i + 1] = Math.Pow(alph[i + 1] / (i + 1), 2) * ((i + 1) * (i) / 2.0);
            }

            gam[0] = 0.0;
            gam[1] = 0.0;
            gam[2] = bet[2] - (alph[2] - 1.0);

            double comb_q = 0.0;
            double g_temp = 0.0;

            for (int i = 3; i < numBins; i++)
            {
                gam[i] = bet[i] - (alph[i] - 1.0);

                for (int k = 0; k < i - 4; k++)
                {
                    comb_q = Combinatorics.Combinations(i, k + 3);
                    g_temp = Math.Pow((k + 1.0) * (k + 2.0) * (k + 3.0) * Phi, k) /
                             Math.Pow((1.0 - (k + 3.0 * Phi)), k + 4);
                    gam[i] += comb_q / (2.0 * g_temp);
                }
            }

            //
            double sum_r_1 = 0;
            double sum_r_2 = 0;
            double sum_r_3 = 0;
            double sum_r_4 = 0;

            for (int i = 0; i < numBins; i++)
            {
                r_1[i] = alph[i] * (p_i[i] - q_i[i]);
                sum_r_1 += r_1[i + 1];
            }

            for (int i = 0; i < numBins; i++)
            {
                r_2[i + 1] = ((bet[i] * (p_i[i] - q_i[i])) - sum_r_1 * alph[i] * q_i[i]);
                sum_r_2 += r_2[i];
            }

            Moment n = new Moment();
            Moment b = new Moment();
            Moment r = new Moment();

            for (int i = 0; i < numBins; i++)
            {
                mr[i] = p_i[i] - q_i[i];
                n.Update(p_i[i], alph[i], bet[i], gam[i]);
                b.Update(q_i[i], alph[i], bet[i], gam[i]);
                r.Update(mr[i], alph[i], bet[i], gam[i]);
            }

            double g_w = detector.Detector.GateWidth_uS.Value * 0.000001;

            double mlt_totals = sum_acc / assay_time;
            double count_time = sum_acc / mlt_totals;
            double dead_time_factor = Math.Exp(detector.DeadTime.tau.Value * 1e-9 * mlt_totals);
            double doubles_dt_factor = Math.Exp(mlt_totals * detector.DeadTime.c_ns.Value);
            double triples_dt_factor = Math.Exp(mlt_totals * detector.DeadTime.d_ns.Value);
            double quads_dt_factor = Math.Exp(mlt_totals * detector.DeadTime.d_ns.Value);


            //
            //gate_width


            double proper_S_DT = dead_time_factor; //calc singles deadtime 
            double proper_D_DT = dead_time_factor * doubles_dt_factor; // calc doubles deadtime
            double proper_T_DT = dead_time_factor * triples_dt_factor; //calc triples deadtime


            double LANL_S_DT = Math.Exp(mlt_totals *
                                        (detector.DeadTime.a_uS.Value +
                                         detector.DeadTime.b_uSsquared.Value * mlt_totals) /
                                        4); //calc totals rate deadtime 
            double LANL_D_DT = Math.Exp(mlt_totals *
                                        (detector.DeadTime.a_uS.Value +
                                         detector.DeadTime.b_uSsquared.Value *
                                         mlt_totals)); // calc reals rate deadtime 
            double LANL_T_DT =
                dead_time_factor *
                (1 + mlt_totals * detector.DeadTime.c_ns.Value); // calc additinal deadtime for triples

            double singles;
            double doubles;
            double triples;

            if (use_LANL_DT_flag)
            {
                singles = C_S / assay_time * LANL_S_DT;
                doubles = (C_RA - C_A) / assay_time * LANL_D_DT;
                triples = sum_r_2 * mlt_totals * LANL_T_DT;
            }
            else
            {
                singles = mlt_totals * proper_S_DT;
                doubles = (C_RA - C_A) / assay_time * LANL_D_DT;
                triples = sum_r_2 * mlt_totals * proper_T_DT;
            }

            //
            g_w = detector.Detector.GateWidth_uS.Value * 0.000001;

            double quads = b.One / g_w * (r.Three - b.Two * r.One - b.One * (r.Two - b.One * r.One)) * quads_dt_factor *
                           dead_time_factor;

            double Gamma = 1.0 - (1.0 - Math.Exp(-detector.Detector.GateWidth_uS.Value / detector.DeadTime.tau.Value)) /
                (detector.Detector.GateWidth_uS.Value / detector.DeadTime.tau.Value);
            double s_d_mult = Math.Pow((1.0 + 8.0 * Gamma * doubles / detector.Detector.f_d.Value / singles), 0.5);
            double A_T = (1.0 + detector.Detector.f_t.Value / detector.Detector.f_d.Value) * singles * doubles *
                         detector.Detector.GateWidth_uS.Value * 0.000001 +
                         0.5 * singles * Math.Pow((singles * detector.Detector.GateWidth_uS.Value * 0.000001), 2);


            double s_err = Math.Pow((1.0 + 2.0 * doubles / detector.Detector.f_d.Value / singles) * sum_acc, 0.5) /
                           count_time;
            double d_err = s_d_mult *
                           Math.Pow(
                               (Math.Pow(singles, 2) * detector.Detector.GateWidth_uS.Value * 0.000001 * 2.0 +
                                doubles) / count_time, 0.5);
            double t_err =
                Math.Pow(
                    (2.0 * (Math.Pow(singles, 3) * Math.Pow(detector.Detector.GateWidth_uS.Value * 0.000001, 2) +
                            triples) / assay_time), 0.5);


            return new McElroyRates
            {
                Singles = new ValueWithUncertainty(singles, s_err),
                Doubles = new ValueWithUncertainty(doubles, d_err),
                Triples = new ValueWithUncertainty(triples, t_err),
                Quads = new ValueWithUncertainty(quads),
                SumAR = sum_ar,
                SumACC = sum_acc
            };
        }

        private struct Moment
        {
            public double Zero;
            public double One;
            public double Two;
            public double Three;
            public double Four;
            public double Five;

            public void Update(double scalar, double alph, double bet, double gam)
            {
                Zero += scalar;
                One += scalar * alph;
                Two += scalar * bet;
                Three += scalar * gam;
                // just to be explicit like Bob
                Four += scalar * 0.0;
                Five += scalar * 0.0;
            }
        }


        private static DetectorCalibrationParameters ScaleDeadTimes(DetectorCalibrationParameters detector)
        {
            detector.DeadTime.a_uS.Value /= 1000000.0;
            detector.DeadTime.b_uSsquared.Value /= 1000000000000.0;
            detector.DeadTime.c_ns.Value /= 1000000000.0;
            detector.DeadTime.d_ns.Value /= 1000000000.0;
            return detector;
        }

        public static void calc_rates_LANL()
        {
        }

        public static void calc_M_rates()
        {
        }


        public static void calc_rates_jitter()
        {
        }
    }
}

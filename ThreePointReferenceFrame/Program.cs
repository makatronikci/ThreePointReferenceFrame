using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreePointReferenceFrame
{
    internal class Program
    {
        public class PT
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
        }

        public static double[] REF_FRAME = new double[6];

        static void Main(string[] args)
        {
            List<PT> PT_LIST = new List<PT>();
            PT point1 = new PT();
            PT point2 = new PT();
            PT point3 = new PT();

            point1.X = 506.653;     //orjin point x
            point1.Y = -11.331;     //orjin point y
            point1.Z = 718.057;     //orjin point z
            point2.X = 653.403;     //x point x
            point2.Y = -11.323;     //x point y
            point2.Z = 686.758;     //x point z
            point3.X = 506.642;     //xy point x
            point3.Y = 121.719;     //xy point y
            point3.Z = 749.983;     //xy point z

            PT_LIST.Add(point1);
            PT_LIST.Add(point2);
            PT_LIST.Add(point3);
            double[] P_X = new double[3];
            double[] P_XY = new double[3];
            double[] P_Y = new double[3];
            double[] P_Z = new double[3];
            double[,] T = new double[3, 3];
            P_X[0] = PT_LIST[1].X - PT_LIST[0].X;
            P_X[1] = PT_LIST[1].Y - PT_LIST[0].Y;
            P_X[2] = PT_LIST[1].Z - PT_LIST[0].Z;
            P_X = DIV_VECTOR(P_X, 3);
            P_XY[0] = PT_LIST[2].X - PT_LIST[0].X;
            P_XY[1] = PT_LIST[2].Y - PT_LIST[0].Y;
            P_XY[2] = PT_LIST[2].Z - PT_LIST[0].Z;
            P_XY = DIV_VECTOR(P_XY, 3);

            P_Z = CROSS_PROD(P_X, P_XY);
            DIV_VECTOR(P_Z, 3);
            P_Y = CROSS_PROD(P_Z, P_X);

            for (int i = 0; i < 3; i++)
            {
                T[i, 0] = P_X[i];
                T[i, 1] = P_Y[i];
                T[i, 2] = P_Z[i];
            }

            CALC_ROT(T);

            REF_FRAME[0] = PT_LIST[0].X;
            REF_FRAME[1] = PT_LIST[0].Y;
            REF_FRAME[2] = PT_LIST[0].Z;

            Console.WriteLine("X: " + REF_FRAME[0]);
            Console.WriteLine("Y: " + REF_FRAME[1]);
            Console.WriteLine("Z: " + REF_FRAME[2]);
            Console.WriteLine("RX: " + REF_FRAME[3]);
            Console.WriteLine("RY: " + REF_FRAME[4]);
            Console.WriteLine("RZ: " + REF_FRAME[5]);
            Console.ReadKey();
        }

        public static void CALC_ROT(double[,] T)
        {
            double RZ, RY, RX, SIN_RZ, COS_RZ, SIN_RY, ABS_COS_RY, SIN_RX, COS_RX;
            RZ = Math.Atan2(T[1, 0], T[0, 0]);
            SIN_RZ = Math.Sin(RZ);
            COS_RZ = Math.Cos(RZ);
            SIN_RY = -T[2, 0];
            ABS_COS_RY = COS_RZ * T[0, 0] + SIN_RZ * T[1, 0];
            RY = Math.Atan2(SIN_RY, ABS_COS_RY);
            SIN_RX = SIN_RZ * T[0, 2] - COS_RZ * T[1, 2];
            COS_RX = -SIN_RZ * T[0, 1] + COS_RZ * T[1, 1];
            RX = Math.Atan2(SIN_RX, COS_RX);

            REF_FRAME[3] = RX * (180 / Math.PI);
            REF_FRAME[4] = RY * (180 / Math.PI);
            REF_FRAME[5] = RZ * (180 / Math.PI);
        }

        public static double[] CROSS_PROD(double[] U, double[] V)
        {
            double[] W = new double[3];
            W[0] = (U[1] * V[2]) - (U[2] * V[1]);
            W[1] = (U[2] * V[0]) - (U[0] * V[2]);
            W[2] = (U[0] * V[1]) - (U[1] * V[0]);
            return W;
        }

        public static double[] DIV_VECTOR(double[] V, int N)
        {
            double Length = VECTOR_LENGTH(V, N);

            for (int i = 0; i < N; i++)
            {
                V[i] = V[i] / Length;
            }
            return V;
        }

        public static double SCALAR_PROD(double[] V, double[] W, int N)
        {
            double SC_PROD = 0;
            for (int i = 0; i < N; i++)
            {
                SC_PROD = SC_PROD + V[i] * W[i];
            }
            return SC_PROD;
        }

        public static double VECTOR_LENGTH(double[] V, int N)
        {
            return Math.Sqrt(SCALAR_PROD(V, V, N));
        }
    }
}

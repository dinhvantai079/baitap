using System;
using System.Numerics;

namespace buoi02
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] numbers = { 13, 3, 7, 5, 9, 15, 1, 11 };
            int length = numbers.Length; //8


            PrintArray(numbers);


            //Run Bai01
            int index = BinarySearch(numbers, length, 9);
            if (index == -1)
            {
                Console.WriteLine("The value 9 was not found in the array");
            }
            else
            {
                Console.WriteLine("The value 9 was found at index {0}", index);
            }


            ////Run Bai02
            MergeSort(numbers, 0, length - 1);
            PrintArray(numbers);



            //Run Bai03
            BigInteger X = BigInteger.Parse("2357");
            BigInteger Y = BigInteger.Parse("4891");
            int n = Math.Max(X.ToString().Length, Y.ToString().Length);

            BigInteger result = BigNumberMulti(X, Y, n);
            Console.WriteLine("Result is : {0}", result);




            Console.ReadLine();
        }

        private static int BinarySearch(int[] A, int n, int key)
        {
            int left = 0; // vị trí phần tử đầu tiên trong mảng
            int right = n - 1; // vị trí phần tử cuối cùng trong mảng
            while (left <= right)
            {
                int mid = (left + right) / 2; //vị trí giữa mảng
                if (A[mid] == key)
                    return mid; // tìm thấy key, trả về vị trí
                if (key < A[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1; // không tìm thấy key trong mảng nên trả về vị trí -1.

        }
        public static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public static void MergeSort(int[] A, int left, int right)
        {
             if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(A, left, mid); // Gọi hàm MergeSort cho nửa dãy con đầu


                MergeSort(A, mid + 1, right); // Gọi hàm MergeSort cho nửa dãy con cuối


                Merge(A, left, mid, right); // Hàm trộn 2 dãy con có thứ tự thành dãy ban đầu có thứ tự

            }
        }

        private static void Merge(int[] A, int left, int mid, int right)
        {
            int n1 = mid - left + 1; // Độ dài nửa dãy đầu của A
            int n2 = right - mid; // Độ dài nửa dãy sau của A

            int[] L = new int[n1];
            int[] R = new int[n2];

            // Chép nửa dãy đầu của A vào L
            for (int i = 0; i < n1; i++)
                L[i] = A[left + i];

            // Chép nửa dãy sau của A vào R
            for (int j = 0; j < n2; j++)
                R[j] = A[mid + j + 1];

            int u = 0, o = 0;
            int k = left;

            // L và R lại vào A sao cho A có thứ tự tăng dần
            while (u < n1 && o < n2)
            {
                if (L[u] <= R[o])
                {
                    A[k++] = L[u++];
                }
                else
                {
                    A[k++] = R[o++];
                }
            }

            // Chép các phần tử còn lại của L vào A
            while (u < n1)
            {
                A[k++] = L[u++];
            }

            // Chép các phần tử còn lại của R vào A
            while (o < n2)
            {
                A[k++] = R[o++];
            }
        }


        static BigInteger BigNumberMulti(BigInteger X, BigInteger Y, int n)
        {
            BigInteger m1, m2, m3, A, B, C, D;
            int s = Sign(X) * Sign(Y); // sign(X) trả về 1 nếu X dương; -1 là âm; 0 là X = 0
            X = BigInteger.Abs(X);
            Y = BigInteger.Abs(Y);

            if (n == 1) // X, Y có 1 chữ số
                return X * Y * s;
            else
            {
                A = Left(X, n / 2); // số có n/2 chữ số đầu của X.
                B = Right(X, n / 2); // số có n/2 chữ số cuối của X.
                C = Left(Y, n / 2); // số có n/2 chữ số đầu của Y
                D = Right(Y, n / 2); // số có n/2 chữ số cuối của Y

                m1 = BigNumberMulti(A, C, n / 2);
                m2 = BigNumberMulti(A - B, C - D, n / 2);
                m3 = BigNumberMulti(B, D, n / 2);

                return s * (m1 * BigInteger.Pow(10, n) + (m1 + m2 + m3) * BigInteger.Pow(10, n / 2) + m3);
            }
        }

        static int Sign(BigInteger value)
        {
            if (value > 0)
                return 1;
            if (value < 0)
                return -1;
            return 0;
        }

        static BigInteger Left(BigInteger value, int digits)
        {
            string s = value.ToString();
            if (s.Length <= digits)
                return value;
            return BigInteger.Parse(s.Substring(0, s.Length - digits));
        }

        static BigInteger Right(BigInteger value, int digits)
        {
            string s = value.ToString();
            if (s.Length <= digits)
                return value;
            return BigInteger.Parse(s.Substring(s.Length - digits));
        }



    }
}
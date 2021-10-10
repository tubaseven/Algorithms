using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //int sonuc = FirstFactorial(4);
            //Console.WriteLine(sonuc);

            //int[] A = new int[] { 3, 8, 9, 7, 6 };
            //Console.WriteLine(ArraysTurn(A, 3));

            //int[] B = new int[] { 3, 3, 8, 7, 7, 6, 8, 9, 7, 6 };
            //Console.WriteLine(OddNumbers(B));


            //int resulSolution = CarpanlarıBulma(24);
            //Console.WriteLine(resulSolution);


            //int super = sum_of_digit(123);  // 6 döner 1+2+3


            //int n = 2880;   //toplam basamak değeri 18 bulur bulduğu değerinde basamak toplamını bulur 1+8 =9
            //Console.Write(digSum(n));

            //List<int> arr = new List<int>() { -4, 3, -9, 0, 4, 1 };
            //plusMinus(arr);


            //Console.Write(miniMaxSum(arr));


            //List<int> arr2 = new List<int>() { 3, 3, 1, 2 };
            //Console.Write(birthdayCakeCandles(arr2));


            //string deger = RandomString(4);
            //Console.Write(deger);


            /////girilen long sayının içerisinde tek sayı varmı kontrolü örnek 222558748745 : false döner  2222222222= true döner

            //long str = Convert.ToInt64(Console.ReadLine());
            //bool result = divideLongNumber(str);
            //Console.WriteLine(result);


            //// parantez kombinasyonler
            //Console.WriteLine(BracketCombinations(Convert.ToInt32(Console.ReadLine())));
            //char karakter = '\t';
            //int[10] dizi = new int[]


            //string str = Console.ReadLine();


            //string str = "I get intern at geeksforgeeks";
            //CamelCase(str);

            Console.WriteLine(CountingMinutesI("1:23am-1:08am"));

            int[] Ab = new int[] { -1, -3 };
            MinPositiveNumber(Ab);
        }
        public static int solutionTrendyolCAse(int[] A, int K) // en büyük çift toplam bulma
        {
            int N = A.Length;

            if (K > N)
            {
                return -1;
            }
            int maxSum = 0;

            List<int> Even = new List<int>();
            List<int> Odd = new List<int>();

            for (int l = 0; l < N; l++)
            {
                if (A[l] % 2 == 1)
                {
                    Odd.Add(A[l]);
                }
                else
                {
                    Even.Add(A[l]);
                }
            }
            if (Even.Count()==0 && K%2 !=0)
            {
                return -1;
            }
            
            Odd.Sort();
            Even.Sort();

            int i = Even.Count - 1;

            int j = Odd.Count - 1;

            while (K > 0)
            {
                if (K % 2 == 1)
                {
                    if (i >= 0)
                    {
                        maxSum += Even[i];

                        i--;
                    }

                    else
                    {
                        return -1;
                    }

                    K--;
                }

                else if (i >= 1 && j >= 1)
                {
                    if (Even[i] + Even[i - 1]
                        <= Odd[j] + Odd[j - 1])
                    {
                        maxSum += Odd[j] + Odd[j - 1];

                        j -= 2;
                    }
                    else
                    {
                        maxSum += Even[i] + Even[i - 1];

                        i -= 2;
                    }

                    K -= 2;
                }

                else if (i >= 1)
                {
                    maxSum += Even[i] + Even[i - 1];

                    i -= 2;

                    K -= 2;
                }

                else if (j >= 1)
                {
                    maxSum += Odd[j] + Odd[j - 1];

                    j -= 2;

                    K -= 2;
                }
            }
            return maxSum;
        }

        // random string 
        public static string solutionTrendyolCase2(int[] A, int K)
        {
            string ans = "";
            int N = A.Length;
            if (N % 2 == 0)
            {
                // Add all characters from
                // b-y
                for (int i = 0; i < Math.Min(N, 24); i++)
                {
                    ans += (char)('b' + i);
                }

                // Append a to fill the
                // remaining length
                if (N > 24)
                {
                    for (int i = 0; i < (N - 24); i++)
                        ans += 'a';
                }
            }

            // If n is even
            else
            {
                // Add all characters from
                // b-z
                for (int i = 0; i < Math.Min(N, 25); i++)
                {
                    ans += (char)('b' + i);
                }

                // Append a to fill the
                // remaining length
                if (N > 25)
                {
                    for (int i = 0; i < (N - 25); i++)
                        ans += 'a';
                }
            }
            return ans;

        }

        //public static string OccuresRandomString(int N)
        //{
        //    var rnd = new Random();
        //    string word = null;
        //    char addedWordChar;
        //    for (int i = 0; i < N; i++)
        //    {
        //        addedWordChar = (char)rnd.Next('a', 'z');
        //        if (!word.Contains(addedWordChar))
        //        {
        //            word += addedWordChar;
        //        }

        //        else
        //        {
        //          char[] arr=  word.ToCharArray();

                   

        //        }

        //    }


        //    return word;

        //}



        //saati dk cinsinden yazma
        public static string CountingMinutesI(string str)
        {
            string[] times = str.Split("-");

            int minutes = 0;

            string dayNight1 = times[0].Substring(times[0].Length - 2);

            string dayNight2 = times[1].Substring(times[1].Length - 2);

            if (!dayNight1.Equals(dayNight2))
                minutes = 720;

            int len = times[0].Length;
            if (len == 6)
            {
                len++;
            }

            int len1 = times[1].Length;
            if (len1 == 6)
            {
                len1++;
            }

            string hour1 = times[0].Substring(0, times[0].IndexOf(":"));

            string hour2 = times[1].Substring(0, times[1].IndexOf(":"));

            string minute1 = times[0].Substring(times[0].IndexOf(":") + 1, len - 5);

            string minute2 = times[1].Substring(times[1].IndexOf(":") + 1, len1 - 5);

            int time1 = Convert.ToInt32(hour1) * 60 + Convert.ToInt32(minute1);

            int time2 = Convert.ToInt32(hour2) * 60 + Convert.ToInt32(minute2);

            minutes += time2 - time1;


            if (Convert.ToInt32(minutes) < 0)
            {
                return (1440 + minutes).ToString();
            }

            return minutes.ToString();
        }

        public static int MinPositiveNumber(int[] A)
        {
            // int[] sortedList = A.Distinct().OrderBy(i => i).ToArray();
            // int resultt = 0;

            //bool eq= sortedList.SequenceEqual(A);  int iki dizinin eşitliğini karşılaştırma

            var i = 0;
            return A.Where(a => a > 0).Distinct().OrderBy(a => a).Any(a => a != (i = i + 1)) ? i : i + 1;
        }


        public static string CamelCase(string s)
        {

            // to count spaces
            int cnt = 0;
            int n = s.Length;
            char[] ch = s.ToCharArray();
            int res_ind = 0;
            List<string> result = new List<string>();
            string res = null;


            char[] reservedCharacters =
               new char[] { '.', ':', ';', '$', ',', '?', '/', '\'', '*', '!', '|', '{', '}', '[', ']', '(', ')', '\\', '@', '<', '>', '~', '¨', '^', '%', '_', '-', '=' };

            char emp = ' ';

            for (int i = 0; i < n - cnt; i++)
            {
                if (reservedCharacters.Contains(ch[i]))
                {
                    result.Add(ch[i].ToString().Replace(ch[i], emp));
                }
                else
                {
                    result.Add(ch[i].ToString());
                }
            }


            for (int i = 0; i < n; i++)
            {

                if (ch[i] == ' ')
                {
                    cnt++;

                    ch[i + 1] = char.ToUpper(ch[i + 1]);
                    continue;
                }

                else
                    ch[res_ind++] = ch[i];
            }

            for (int i = 0; i < n - cnt; i++)
            {

                result.Add(ch[i].ToString());
            }

            return result.ToString();

        }


        //FAKTORİYEL HESAPLAMA
        public static int FirstFactorial(int num)
        {
            string abc = null;
            int a = abc.Length;
            // code goes here  
            int fact = 1;

            fact = num;
            for (int i = num - 1; i >= 1; i--)
            {
                fact = fact * i;
            }


            return fact;

        }

        //tersten yazmA

        public static string FirstReverse(string str)
        {
            string firstReverse = "";

            for (int i = str.Length - 1; i >= 0; i--)
            {
                firstReverse += str[i];
            }
            return firstReverse;

        }

        //sayının binarysini bulup 100001 1 ler arasındaki maksimum 0 sayısını bulma.
        public static int MaxZeroConut(int N)
        {
            string bits = Convert.ToString(N, 2); // binary e çevirme
            int size = 0;
            int sizeReal = 0;
            int cont = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '0')
                {
                    if (cont > 0) cont++;
                    else cont = 1;
                }
                else cont = 0;
                if (cont > size) size = cont;
                if (bits[i] == '1' && size > sizeReal) sizeReal = size;
            }
            return sizeReal;
        }


        //sayının basamak sayısını bulma.
        public static int Length(long binary)
        {
            int length = 1; //basamak sayısı

            while (binary > 9)
            {

                binary = binary / 10;
                length++;
            }
            return length;
        }

        // bir arrayin K kere yer değitirmesi.sondan başa 
        //        A = [3, 8, 9, 7, 6]
        //        K = 3
        //the function should return [9, 7, 6, 3, 8]. Three rotations were made:

        //    [3, 8, 9, 7, 6] -> [6, 3, 8, 9, 7]
        //        [6, 3, 8, 9, 7] -> [7, 6, 3, 8, 9]
        //        [7, 6, 3, 8, 9] -> [9, 7, 6, 3, 8]
        public static int[] ArraysTurn(int[] A, int K)
        {
            if (A.Length == 1 || A.Length < 0 || A.Length == K)
            {
                return A;
            }

            for (var i = 0; i < K; i++)
            {
                for (var j = A.Length - 1; j > 0; j--)
                {
                    var temp = A[j];
                    A[j] = A[j - 1];
                    A[j - 1] = temp;
                }
            }
            return A;
        }

        //using collenctions.generic eklenir
        // bir dizide eşleşmeyen değeri döndürür
        //BOŞ BİR HASHSET TANIMLADI İÇİNE TEK TEK ATARAK VARSA KALDIR YOKSA EKLE YAPTI. GERİYE BİR TEK OLAN KALDI ÇÜNKÜ CONTAİNS E O DEĞERİ REMOVE ETTİ
        public static int OddNumbers(int[] A)
        {
            var has = new HashSet<int>();
            foreach (var i in A)
                if (has.Contains(i))
                    has.Remove(i);
                else
                    has.Add(i);
            foreach (var i in has)
                return i;
            return 0;
        }
        // oDDnUMBERS IN DAHA PERFORMANSLISI
        public int solution(int[] A)
        {
            int[] newA = A.Distinct().ToArray();
            if (A.Length <= 0) return 0;
            else return newA.Length;
        }


        //Kurbağa X pozisyonunda D mesafesinde atlayabiliyor ve Y ye ulaşmaya çalışıyor.Bunun için minumum atlama saysısını bulma. Y den büyük veya eşit olana kadar
        //atlama yapıcak
        //return (int)Math.Ceiling(((double)Y - X) / D);
        public static int FrogJump(int X, int Y, int D)
        {
            int jump = 1;
            if (X == Y)
            {
                return 0;
            }
            else
            {
                int sum = X + D;
                do
                {
                    sum = sum + D;
                    jump++;
                }
                while (sum < Y);

            }
            return jump;
        }

        //Bir sayının kaç tane çarpanı olduğunu bulma
        public static int CarpanlarıBulma(int N)
        {
            int count = 0;
            var bolen = 0;

            for (int i = 2; i < N + 1; i++)
            {
                bolen = N % i;  // bölümünden kalanı bulur eğer 0 sa tam bölünür

                if (bolen == 0)
                {
                    count++;
                }

                continue;
            }

            return count;
        }

        // Recursive C# program to : sayının tüm basak değerlerini recursive kullanarak toplama 
        // find sum of digits of a number

        public static int sum_of_digit(int n)
        {
            if (n == 0)
                return 0;

            return (n % 10 + sum_of_digit(n / 10));
        }


        /// <summary>
        /// / n sayısının basamak değerini toplar bulduğu sonucun tekrar basamak değerini döndürür.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int digSum(int n)
        {
            int sum = 0;

            // Loop to do sum while
            // sum is not less than
            // or equal to 9
            while (n > 0 || sum > 9)
            {
                if (n == 0)
                {
                    n = sum;
                    sum = 0;
                }
                sum += n % 10; //10 ile bölümünden kalan 288%10 == 8  
                n /= 10;   // 288/10 = 28
            }
            return sum;
        }


        //Aritmetik dizide olmayan sayıyı bulam program.
        public static int solution5(int[] A)
        {
            //missing integer.
            int len = A.Length;
            HashSet<int> realSet = new HashSet<int>();
            HashSet<int> perfectSet = new HashSet<int>();

            int i = 0;
            while (i < len)
            {
                realSet.Add(A[i]);   //convert array to set to get rid of duplicates, order int's
                perfectSet.Add(i + 1);  //create perfect set so can find missing int
                i++;
            }
            perfectSet.Add(i + 1);

            if (realSet.All(item => item < 0))
                return 1;

            int notContains =
             perfectSet.Except(realSet).Where(item => item != 0).FirstOrDefault();
            return notContains;


        }
        public static int solution6(int[] A)
        {
            // birinci bölümün toplamı ile ikinci bölümün toplamı arasındaki mutlak farktır.

            //Örneğin, A dizisini şöyle düşünün:

            //  A[0] = 3
            //  A[1] = 1
            //  A[2] = 2
            //  A[3] = 4
            //  A[4] = 3
            //Bu kaseti dört yere ayırabiliriz:

            // P = 1, fark = | 3 - 10 | = 7
            //P = 2, fark = | 4 - 9 | = 5
            //P = 3, fark = | 6 - 7 | = 1
            //P = 4, fark = | 10 - 3 | = 7
            //Bir fonksiyon yazın:

            //class Solution { public int solution(int[] A); }

            //        Bu, boş olmayan bir A tamsayı dizisi verildiğinde, elde edilebilecek minimum farkı döndürür.
            int sum1 = 0;
            int sum2 = 0;
            int result = 0;
            List<int> values = new List<int>();

            for (int i = 0; i < A.Length - 1; i++)
            {
                sum1 = sum1 + A[i];
                sum2 = Sum2(i, A);
                result = Math.Abs(sum1 - sum2);
                values.Add(result);

            }

            return values.Min();
        }

        public static int Sum2(int i, int[] A)
        {
            int sum2 = 0;
            do
            {
                sum2 += A[i + 1];
                i++;

            } while (i < A.Length - 1);
            return sum2;
        }

        ////        17 28 30
        ////        99 16 8
        ////Sample Output 1

        //// Skor hesaplama : 2 1

        public static List<int> compareTriplets(List<int> a, List<int> b)
        {
            int skorA = 0;
            int skorB = 0;
            List<int> result = new List<int>();

            for (int i = 0; i < a.Count; i++)
            {

                if (a[i] > b[i])
                {
                    skorA++;
                }
                else if (b[i] > a[i])
                {
                    skorB++;
                }


            }
            result.Add(skorA);
            result.Add(skorB);

            return result;
        }


        public static long aVeryBigSum(List<long> ar)
        {
            long result = 0;
            foreach (var item in ar)
            {
                result += item;
            }
            return result;

        }

        //matris köşegenlerinin farkının mutlağo
        public static int diagonalDifference(List<List<int>> arr)
        {
            int result = 0;

            for (int i = 0; i < arr.Count; ++i)
                result += arr[i][i] - arr[i][arr.Count - 1 - i];

            return Math.Abs(result);
        }

        //list içerisindeki pozitif negatif ve 0 sayılarının oranını bulur
        public static List<float> plusMinus(List<int> arr)
        {
            List<int> positive = new List<int>();
            List<int> negative = new List<int>();
            List<int> zero = new List<int>();

            List<float> result = new List<float>();
            int len = arr.Count();

            foreach (var item in arr)
            {
                if (item > 0)
                {
                    positive.Add(item);
                }
                if (item < 0)
                {
                    negative.Add(item);
                }

                if (item == 0)
                {
                    zero.Add(item);
                }

            }

            result.Add((float)positive.Count / len);
            result.Add((float)negative.Count / len);
            result.Add((float)zero.Count / len);

            return result;

        }

        //n=4
        /// <summary>
        ///   #
        //    ##
        //   ###
        //  ####

        public static void staircase(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = n; j > 0; j--)
                {
                    Console.WriteLine("#");
                }
                Console.Write("\n");

            }
            Console.ReadLine();
        }



        public static List<int> miniMaxSum(List<int> arr)
        {
            arr.Sort();
            int sumMin = 0;
            int sumMax = 0;

            List<int> result = new List<int>();

            for (int i = 0; i < arr.Count - 1; i++)
            {
                sumMin += arr[i];
            }

            for (int j = arr.Count - 1; j > 0; j--)
            {
                sumMax += arr[j];
            }

            result.Add(sumMin);
            result.Add(sumMax);

            return result;

        }


        //en büyük sayıyı byl kaç tane var onu döndür.
        public static int birthdayCakeCandles(List<int> candles)
        {
            int max = candles.Max();
            int count = 1;

            var has = new List<int>();

            foreach (var i in candles)
            {
                if (i == max)
                    has.Add(i);

            }
            return has.Count;
        }


        // Input : str = “abc” 
        //Output : 6 
        //Every substring of the given string : “a”, “b”, “c”, “ab”, “bc”, “abc”
        //Input : str = “abcd” 
        //Output : 10 
        //Every substring of the given string : “a”, “b”, “c”, “d”, “ab”, “bc”, “cd”, “abc”, “bcd” and “abcd”

        public static int countNonEmptySubstr(string str)
        {
            int n = str.Length;
            return n * (n + 1) / 2;
        }


        //random string üretme
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        ///Bayragin boyuna yetismek icin gereken minimum ziplama sayisini bulmani istiyo 2 atlama türü var birincisi bigjump 2.si 1 lik atlama
        ///
        public static int jumps(int flagHeight, int bigJump)
        {
            int minJump = flagHeight / bigJump;
            int distance = minJump * bigJump;
            int step = flagHeight - distance;

            return step + minJump;

        }

        //N karakterden oluşan bir S dizesi verildiğinde, S düzgün bir şekilde yuvalanmışsa 1, aksi takdirde 0 döndürür.
        //Örneğin, S = " {[()()]} " verildiğinde, fonksiyon 1 döndürmeli ve S = " ([)()] " verildiğinde, fonksiyon yukarıda açıklandığı gibi 0 döndürmelidir.
        public int solution(string S)
        {
            if (S.Length % 2 != 0)
            {
                return 0;
            }

            var openingBrace = '{';
            var openingBracket = '[';
            var openingParen = '(';

            Stack<Char> openingStack = new Stack<Char>();

            for (int i = 0; i < S.Length; i++)
            {
                char c = S[i];
                if (c == openingBrace || c == openingBracket || c == openingParen)
                {
                    openingStack.Push(c);
                }
                else
                {
                    if (i == S.Length - 1 && openingStack.Count() != 1)
                    {
                        return 0;
                    }
                    if (openingStack.Count() == 0)
                    {
                        return 0;
                    }
                    Char openingCharacter = openingStack.Pop();
                    switch (c)
                    {
                        case '}':
                            if (!openingCharacter.Equals(openingBrace))
                            {
                                return 0;
                            }
                            break;
                        case ']':
                            if (!openingCharacter.Equals(openingBracket))
                            {
                                return 0;
                            }
                            break;
                        case ')':
                            if (!openingCharacter.Equals(openingParen))
                            {
                                return 0;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            return 1;
        }


        public static int CheckNums(int num1, int num2)
        {
            if (num2 > num1)
            {
                return 1;
            }
            else if (num2 == num1)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }

        public static string WordCount(string str)
        {
            int count = 0;
            string[] words = str.Split(' ');
            foreach (string kelime in words)
            {
                count++;
            }

            return count.ToString();

        }



        public static bool divideLongNumber(long num)
        {
            int n = 0;
            List<int> arra = new List<int>();
            bool result = false;
            long temp = num; ;
            int i = 0;

            List<int> divideList = new List<int>();
            while (temp != 0)
            {
                temp /= 10;
                n++;
            }

            long[] arr = new long[n]; // tüm basamakları tek tek  attığımız dizi.

            if (n > 10)
            {
                do
                {
                    arr[i] = num % 10;
                    num /= 10;
                    i++;
                } while (num > 0);

                foreach (var item in arr)
                {
                    if (SimpleEvens(Convert.ToInt32(item)) == 0)
                    {
                        result = false;
                        return result;
                    }

                    else if (SimpleEvens(Convert.ToInt32(item)) == 1)
                    {
                        //res = Convert.ToInt32(arr.TakeLast(n - 10));

                        if (SimpleEvens(Convert.ToInt32(item)) == 0)
                        {
                            result = false;
                            return result;
                        }

                        else
                            result = true;
                    }
                }

                //res = Convert.ToInt32(arr.Take(10));

            }
            else
            {
                int a = SimpleEvens(Convert.ToInt32(num));
                if (a == 0)
                {
                    result = false;
                    return result;

                }
                else
                {
                    result = true;
                }
            }

            return result;
        }

        // gelen int sayısını içerisindeki bir basamağında tek sayı varsa false döndürür.Bunun için DivideLongNumber method yazıldı.Çünkü girilen sayı long olabilir.
        public static int SimpleEvens(int num)
        {
            List<int> arr = new List<int>();
            int result = 0;

            if (num < 10)
            {
                if (num % 2 != 0) return 0;
                return 1;
            }

            else
            {
                while (num > 0)
                {
                    arr.Add(num % 10);
                    num = num / 10;
                }

                foreach (var item in arr)
                {
                    if (item % 2 != 0)
                    {
                        result = 0;
                        return result;
                    }
                    else
                    {
                        result = 1;
                    }
                }
            }

            return result;
        }


        ///input is 3, then the possible combinations of 3 pairs of parenthesis, namely: () () (), are()() (), () (()), (()) (), ((())), and(()()). There are 5 total combinations
        ////// BracketCombinations methodu
        public static IEnumerable<string> BracketCombinationList(int num)
        {
            if (num == 0)
                return new[] { "" };
            if (num == 1)
                return new[] { "()" };
            var r1 = BracketCombinationList(num - 1);
            var r2 = new HashSet<string>();
            foreach (var r in r1)
            {
                for (var i = 0; i < r.Length; i++)
                {
                    for (var j = i + 1; j < r.Length + 1; j++)
                    {
                        var t = r.ToList();
                        t.Insert(i, '(');
                        t.Insert(j, ')');
                        r2.Add(new string(t.ToArray()));
                    }
                }
            }
            return r2;
        }

        public static int BracketCombinations(int num)
        {
            return BracketCombinationList(num).Count();
        }
    }
}


using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Threading.Channels;

namespace C_Sharp_Introduction
{
    internal class Program
    {
        public static void DateAndTime()
        {
            DateTime meating = new DateTime(2026, 9, 17, 02, 56, 20);
            Console.WriteLine($"meating is :{meating}");
            Console.WriteLine($"meating_year is :{meating.Year}");
            Console.WriteLine($"meating_Month is :{meating.Month}");
            Console.WriteLine($"meating_Day is :{meating.Day}");
            Console.WriteLine($"meating_Hour is :{meating.Hour}");
            Console.WriteLine($"meating_minute is :{meating.Minute}");
            Console.WriteLine($"meating_minute is :{meating.Second}");
            meating = meating.AddDays(20);
            Console.WriteLine($"meating_minute is :{meating}");

            //Time now
            Console.WriteLine($"Date time now is {DateTime.Now}");
            Console.WriteLine($"Date time now in Utc  {DateTime.UtcNow}");

            //convert to string
            Console.WriteLine("");
            var dateToString = meating.ToString("yyyy-MM-dd HH:MM");
            Console.WriteLine($"string date is {dateToString}");
            bool isDateTime = DateTime.TryParse(dateToString, out DateTime res);
            Console.WriteLine($"is date time {isDateTime} and res is {res}");
            /////////////////////////////////////////DateTimeOffset///////////////////////////////////////

            DateTimeOffset cairo = new DateTimeOffset(2026, 9, 17, 3, 25, 2, TimeSpan.FromHours(3));
            Console.WriteLine(cairo);
            /////////////////////////////////////////DateOnly////////////////////////////////////////
            DateOnly birthday = new DateOnly(2002, 9, 21);
            Console.WriteLine(birthday);
            DateOnly date = DateOnly.FromDateTime(meating);
            Console.WriteLine($"date only is :{date}");

            /////////////////////////////////////////TimeOnly////////////////////////////////////////

            TimeOnly birdayTime = new(9, 30, 0);
            Console.WriteLine(birdayTime);


        }

        public static void FormatString()
        {
            string name = "mostafa";
            string address = "Talkha";
            string replace = "my name is {0}, address is {1}";
            string output = String.Format(replace, name, address);
            Console.WriteLine(output);


        }
        public static void ControlFlow()
        {
            object box = 42;
            if (box is int n && n > 20)
            {
                Console.WriteLine($"boxed is {n}");
            }
            int score = 1;
            string grade = score switch
            {
                >= 90 => "success",
                >= 50 => "good",
                _ => "fail"
            };
            Console.WriteLine(grade);


        }

        public static void StringAndMethod()
        {
            var x = 10;
            var y = 20;
            var sum = x + y;

            string d = "desha";

            Console.WriteLine($"The sum of {x} and {y} is {sum}");
            int a = Convert.ToInt32('a');
            Console.WriteLine($"The ASCII value of 'a' is {a}");

            int xp = int.Parse("10");
            Console.WriteLine($"The parsed value of '10' is {xp}");
            decimal de = decimal.Parse("10.5");
            Console.WriteLine($"The parsed value of '10.5' is {de}");
            bool z = int.TryParse("20io", out int result);
            Console.WriteLine($"The try-parse value of '20' is {z}");
            string s1 = "Hello";
            string s2 = "Hello";
            s1 += " World";
            bool br = ReferenceEquals(s1, s2);
            Console.WriteLine(br);
            Console.WriteLine("========================");
            string mostafa = "";
            bool isNull = String.IsNullOrEmpty(mostafa);
            bool isNull2 = String.IsNullOrWhiteSpace(mostafa);
            Console.WriteLine(isNull);
            Console.WriteLine(isNull2);

            int[] arr = { 10, 20, 30, 40 };
            TestArr(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static void TestArr(int[] arr)
        {
            arr[0] = 100;
            arr = [-1, -2, -3];
        }

        public static void Nullable()
        {
            /*اهم حاجات لازم تكون عارفها 
             * 1) ?
             * 2) ??
             * 3) !
             * 4)
             */

            //value-type 
            /*
             * value-type having 2-improtant function x.value, x.HasValue
             */
            int? x = null;
            Nullable<int> id1 = null;
            Console.WriteLine(id1!);
            Console.WriteLine($"x is hasing value:: {x.HasValue}  ");


            //Console.WriteLine(id1.Value); ==>throw nullReference exception
            if (x.HasValue)
            {
                Console.WriteLine($"x.value is {x.Value}");
            }
            else
            {
                Console.WriteLine($"x not having value ");
            }

            //reference-type
            /*
             * null.(اي حاجه )==> null Reference Exception
             */
            string s = null;
            //Console.WriteLine($"s :: {s!.ToUpper()}");    
            //Console.WriteLine(s.Contains("sh"));//null.contains()==> null reference exception

            Customer c1 = new Customer();

            Console.WriteLine(c1.name ?? "name is null");
            Console.WriteLine(c1.id ?? 4);
            Console.WriteLine(c1.name?.ToUpper());
            var isNull = string.IsNullOrEmpty(c1.name);
            Console.WriteLine($"is null or Empty name ::{isNull}");



            if (c1.name == null)
            {
                Console.WriteLine($"null name {c1.name!}");
            }





        }

        public static void fun1()
        {
            int x = 5, y = 0;
            try
            {
                int res = x / y;
                throw new Exception("div 0 exception happened inside fun1");


            }
            catch
            {
                //throw; //re-throw : catch بقولك خلي داله المين هي اللي تحل 
                Console.WriteLine("div 0");
            }
        }

        public static void ExceptionHandling()
        {
            int x = 4;
            int y = 0;
            try
            {
                fun1();
                Console.WriteLine("line after exception not executed");
            }

            catch (DivideByZeroException)
            {
                Console.WriteLine("divide by zero happed");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception happend");
            }

            finally
            {
                Console.WriteLine("Endding try catch");
            }


        }

        public static void EnumAndMethod()
        {
            Day d = Day.SUNDAY;
            
            Console.WriteLine((int)d); //print int value of enum

            //parse enum value to string
            var isParse=Enum.TryParse<Day>("SATURDAY", true, out var res);
            Console.WriteLine($"isParse :: {isParse} , res {res}");

            //prining values of enum day
            foreach(var item in Enum.GetValues<Day>())
            {
                Console.WriteLine(item);
            }

            
        }

        public static (int Max, int SecondMax) MaxValues()
        {
            int[] arr = { 0, 30, 50, 5, 44 };
            int max = arr[0];
            int secondMax = arr[0];


            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    secondMax = max;
                    max = arr[i];
                }else if (arr[i] > secondMax)
                {
                    secondMax = arr[i];
                }
            }
            return (max, secondMax);
        }

        public static void SingleLineFun() =>
            Console.WriteLine("hello in singleLIne function");

        public static void passingArrayToFunction(int first,params int[] nums)
        {
            Console.WriteLine($"first is :: {first}");
            int sum = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                Console.WriteLine(nums[i]);
            }
            Console.WriteLine(sum);

        }

        public static void AddRef(ref int a)
        {
            a += 100;
        }

        public static void AddOut(out int a)
        {
            a = 200;//must assign value 
        }
        public static void  refVsOut()
        {
            int x = 5, y = 10;
            AddRef( ref x);
            Console.WriteLine(x);

            AddOut(out y);
            Console.WriteLine(y);
            Console.WriteLine($"{x}  {y}");
            

        }

        public static void Array()
        {
            int[] num1 = { 10, 20, 30 };
            for(int i = 0; i < num1.Length; i++)
            {
                Console.WriteLine(num1[i]);
            }

            int[] arr = [1, 2, 3]; // is equal (int [] arr = new array(1,2,3)
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            //read 5 element from user and return max,second max
            int number;
            Console.WriteLine("Enter size array::");
            number = int.Parse(Console.ReadLine()!);
            int sum = 0;
            int[] array = new int[number];
            for(int i = 0; i < number; i++)
            {
                Console.WriteLine("Enter array Element");
                array[i] = int.Parse(Console.ReadLine()!);
                sum += array[i];

            }
            Console.WriteLine($"sum is {sum}");
        }
        static void Main(string[] args)
        {
            //DateAndTime();
            //ControlFlow();
            //FormatString();
            //StringAndMethod();
            //Nullable();
            //ExceptionHandling();
            //EnumAndMethod();
            Array();
            //passingArrayToFunction(5, 10, 20, 30, 40, 50);
            //SingleLineFun();
            //var (max,secondMax)=MaxValues();
            //Console.WriteLine($"{max} {secondMax}");
            //refVsOut(); 







        }

    }
}

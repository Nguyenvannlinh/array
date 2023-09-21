using System;
using System.Text;

namespace array
{
    class lmaoArray
    {
        static int[,] a;
        static void Input()
        {
            int n;
            Console.Write("Độ dài mảng tối đa là 100 : ");
            n = int.Parse(Console.ReadLine());
            a = new int[n, n];
            while(true)
            {
                if(n < 0 || n> 100)
                {
                    Console.Write("Độ dài mảng tối đa là 100\nĐộ dài mảng : ");
                    n = int.Parse(Console.ReadLine());
                }
                else { break; }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"nhập dãy số trong ma trận {i + 1},{j + 1} :");
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        static void showarray(int[,] a)
        {
            int n = a.GetLength(0);
            Console.WriteLine("Ma trận vuông sau khi nhập:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void PrintMatrix(int[,] matrix, int row, int col, int n)
        {
            if (row >= n)
                return;

            if (col < n)
            {
                Console.Write(matrix[row, col] + " ");
                PrintMatrix(matrix, row, col + 1, n);
            }
            else
            {
                Console.WriteLine();
                PrintMatrix(matrix, row + 1, 0, n);
            }
        }


        static int n_largest(int[,] a)
        {
            int n = a.GetLength(0);
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] < min && a[i, j] > 0)
                    {
                        min = a[i, j];
                    }
                }
            }
            return min;
        }
        static int nx_largest(int[,] a, int x, int y, int n, int min)
        {
            if (x == n) return min;
            if (a[x, y] > 0 && a[x, y] < min) min = a[x, y];
            if (y + 1 < n)
            {
                return nx_largest(a, x, y + 1, n, min);
            }
            else
            {
                return nx_largest(a, x + 1, 0, n, min);
            }
        }
        static int Sum(int[,] a)
        {
            int n = a.GetLength(0);
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += a[i, n - 1 - i];
            }

            return sum;
        }

        static bool Ascending(int[,] a)
        {
            int n = a.GetLength(0);
            for (int i = 1; i < n; i++)
            {
                if (a[i, i] <= a[i - 1, i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        static void part1()
        {
            Input();
            showarray(a);
            int n = a.GetLength(0);
            Console.WriteLine("\n\nduyệt ma trận bằng đệ quy");
            PrintMatrix(a, 0, 0, a.GetLength(0));
            
            Console.WriteLine($"số bé nhất đệ quy: {nx_largest(a, 0, 0, n, int.MaxValue)}");
            Console.WriteLine($"số bé nhất: {n_largest(a)}");
            Console.WriteLine($"tổng chéo phụ: {Sum(a)}");
            if (Ascending(a) == true)
            {
                Console.WriteLine($"chéo chính có theo tứ tự");
            }
            else { Console.WriteLine($"chéo chính không theo thứ tự"); }
        }


        struct Person //: IComparable<Person>
        {
            public int ID { get; set; }
            public string name { get; set; }
            public int birth { get; set; }
            public string ID_room { get; set; }
            public int Salary { get; set; }
            public int Bonus { get; set; }

            public int Practice { get; set; }

            public static void Compareto(Person[] p)
            {
                //int result = ID_room.CompareTo(other.ID_room);

                //if (result == 0)
                //{
                //    result = other.ID.CompareTo(ID);
                //}

                //return result;
                int n = p.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1; j++)
                    {
                        int room = String.Compare(p[j].ID_room, p[j + 1].ID_room);
                        if (room > 0)
                        {
                            Person temp = p[j];
                            p[j] = p[j + 1];
                            p[j + 1] = temp;
                        }
                        else if (room == 0)
                        {
                            if (p[j].ID < p[j + 1].ID)
                            {
                                Person temp = p[j];
                                p[j] = p[j + 1];
                                p[j + 1] = temp;
                            }
                        }
                    }
                }

            }
            static Person[] list;

            static void Program()
            {
                double up = 0;
                string t = "";
                int count = 0, sum = 0;
                int minsalaty = int.MaxValue;
                Console.Write("Có bao nhiêu nhân viên : ");
                int n = int.Parse(Console.ReadLine());
                list = new Person[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Nhập thông tin cho nhân viên thứ {i + 1}:");
                    Console.Write("Mã nhân viên: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Họ tên nhân viên: ");
                    string name = Console.ReadLine();
                    Console.Write("Năm sinh nhân viên: ");
                    int birth = int.Parse(Console.ReadLine());
                    Console.Write("Phòng ban: ");
                    string id_room = Console.ReadLine();
                    Console.Write("Lương: ");
                    int salary = int.Parse(Console.ReadLine());
                    Console.Write("Tiền thưởng: ");
                    int bonus = int.Parse(Console.ReadLine());
                    int parctice = 0;


                    list[i] = new Person
                    {
                        ID = id,
                        name = name,
                        birth = birth,
                        ID_room = id_room,
                        Salary = salary,
                        Bonus = bonus,
                        Practice = Prac(salary, bonus)
                    };
                    sum += list[i].Practice;
                    minsalaty = Min(minsalaty, list[i]);
                }

                var sorted = list.OrderBy(e => e.ID_room).ThenByDescending(e => e.ID);

                Compareto(list);
                Console.WriteLine("Danh sách nhân viên đã sắp xếp:");
                foreach (var person in list)
                {
                    up += (int)(person.Salary * 0.05);
                    Console.WriteLine($"Mã nhân viên: {person.ID}, Họ tên: {person.name}, Phòng ban: {person.ID_room}, thực lĩnh: {person.Practice} lương tăng thêm 5%: {up}\n");

                    if (minsalaty == person.Salary)
                    {
                        t = person.name;
                    }
                    if (person.Bonus >= 1200000)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Tổng số thử lĩnh của các nhân viên là: {sum}");
                Console.WriteLine($"Người có mức lương cơ bản thấp nhất: {t} với lương {minsalaty}");
                Console.WriteLine($"Tổng những người có lương thưởng trên 1200000 :{count}");
            }
            static int Prac(int salary, int bonus)
            {
                return salary + bonus;
            }

            static int Min(int min, Person person)
            {
                if (min > person.Salary)
                {
                    return person.Salary;
                }
                else { return min; }
            }

            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;
                while (true)
                {
                    Console.Clear();
                    Console.Write("bài 1 hoặc 2  0 để kết thúc bài: ");
                    int n = int.Parse(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            part1();
                            Console.ReadKey();
                            break;
                        case 2:
                            Program(); Console.ReadKey();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}

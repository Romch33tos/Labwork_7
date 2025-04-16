using System;
using System.Linq;

namespace BinaryTree
{
  class Program
  {
    static void Main(string[] args)
    {
      var tree = new BinaryTree<int>();
      tree.Add(5);
      tree.Add(3);
      tree.Add(7);
      tree.Add(2);
      tree.Add(4);
      tree.Add(6);
      tree.Add(8);

      while (true)
      {
        Console.WriteLine("Список опций:");
        Console.WriteLine("1. Прямой обход;");
        Console.WriteLine("2. Обратный обход;");
        Console.WriteLine("3. Центральный обход;");
        Console.WriteLine("0. Выход.");
        Console.Write("Ваш выбор: ");

        string option = Console.ReadLine();

        switch (option)
        {
          case "1":
            Console.WriteLine("Прямой обход:");
            foreach (var item in tree)
            {
              Console.WriteLine(item);
            }
            break;

          case "2":
            Console.WriteLine("Обратный обход:");
            foreach (var item in tree.GetReverseEnumerator())
            {
              Console.WriteLine(item);
            }
            break;

          case "3":
            Console.WriteLine("Центральный обход:");
            var inOrder = tree.GetInOrderEnumerator();
            inOrder.ToList().ForEach(item => Console.WriteLine(item));
            break;

          case "0":
            return;

          default:
            Console.WriteLine("Некорректный выбор опции!");
            break;
        }
      }
    }
  }
}
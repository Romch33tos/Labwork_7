using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
  public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
  {
    private BinaryTreeNode<T> _root;

    public void Add(T value)
    {
      _root = AddRecursive(_root, null, value);
    }

    private BinaryTreeNode<T> AddRecursive(BinaryTreeNode<T> node, BinaryTreeNode<T> parent, T value)
    {
      if (node == null)
      {
        return new BinaryTreeNode<T>(value) { Parent = parent };
      }

      if (value.CompareTo(node.Value) < 0)
      {
        node.Left = AddRecursive(node.Left, node, value);
      }
      else if (value.CompareTo(node.Value) > 0)
      {
        node.Right = AddRecursive(node.Right, node, value);
      }

      return node;
    }

    public IEnumerator<T> GetEnumerator()
    {
      return new ForwardIterator<T>(_root);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerable<T> GetReverseEnumerator()
    {
      BinaryTreeNode<T> current = _root;
      var stack = new Stack<BinaryTreeNode<T>>();
      bool done = false;

      while (!done)
      {
        if (current != null)
        {
          stack.Push(current);
          current = current.Right;
        }
        else
        {
          if (stack.Count > 0)
          {
            current = stack.Pop();
            yield return current.Value;
            current = current.Left;
          }
          else
          {
            done = true;
          }
        }
      }
    }

    public IEnumerable<T> GetInOrderEnumerator()
    {
      return InOrderTraversal(_root);
    }

    private IEnumerable<T> InOrderTraversal(BinaryTreeNode<T> node)
    {
      if (node != null)
      {
        foreach (var left in InOrderTraversal(node.Left))
        {
          yield return left;
        }

        yield return node.Value;

        foreach (var right in InOrderTraversal(node.Right))
        {
          yield return right;
        }
      }
    }
  }
}
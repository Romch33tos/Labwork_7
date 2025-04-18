namespace BinaryTree
{
  public class BinaryTreeNode<T> where T : IComparable<T>
  {
    public T Value { get; set; }
    public BinaryTreeNode<T> Left { get; set; }
    public BinaryTreeNode<T> Right { get; set; }
    public BinaryTreeNode<T> Parent { get; set; }

    public BinaryTreeNode(T value)
    {
      Value = value;
      Left = null;
      Right = null;
      Parent = null;
    }
  }
}
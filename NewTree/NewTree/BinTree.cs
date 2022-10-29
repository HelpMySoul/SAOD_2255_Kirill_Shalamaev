using System;
using System.Collections.Generic;

namespace NewTree
{
    class BinTree<T> where T : IComparable<T>
    {
        TreeNode<T> root = null;
        public int Count { get; set; }
        public string Show()
        {
            List<List<T>> resultlist = new List<List<T>> { };
            NodesToList(root,ref resultlist);
            string result = "";
            foreach ( List<T> lt in resultlist)
            {
                string line = "";
                foreach (T t in lt)
                {
                    line += t+" ";
                }
                result += line+"\n";
            }
            return result;
        }
        private void NodesToList(TreeNode<T> startNode, ref List<List<T>> Mainlist, int level = 0)
        {
            if (Mainlist.Count == level)
            {
                Mainlist.Add(new List<T> { startNode.value });
            }
            else
            {
                Mainlist[level].Add(startNode.value);
            }
            if(startNode.left != null)
            {
                NodesToList(startNode.left, ref Mainlist, level + 1);
            }
            if (startNode.right != null)
            {
                NodesToList(startNode.right, ref Mainlist, level + 1);
            }
        }
        public void Insert(T value)
        {
            if (root == null)
            {
                root = CreateNode(value, null);
                Count++;
            }
            else
            {
                TreeNode<T> now = root;
                while (true)
                {
                    if (now.value.CompareTo(value) == 0)
                    {
                        return;
                    }
                    
                    if (now.left == null && now.right == null)
                    {
                        if (now.value.CompareTo(value) < 0)
                        {
                            CreateNode(value, now, false);        
                        }
                        else
                        {
                            CreateNode(value, now, true);
                        }
                        Count++;
                        break;
                    }
                    else 
                    {
                        if (now.value.CompareTo(value) < 0)
                        {
                            if (now.right != null)
                            {
                                now = now.right;
                            }
                            else
                            {
                                CreateNode(value, now, false);
                                Count++;
                                break;
                            }
                        }
                        else
                        {
                            if(now.left != null)
                            {
                                now = now.left;
                            }
                            else
                            {
                                CreateNode(value, now, true);
                                Count++;
                                break;
                            }
                        }
                    }
                }
            }
        }
        public ref T Find(T value)
        {
            List<TreeNode<T>> resultlist = new List<TreeNode<T>> { };
            NodesToTreeNodeList(root, ref resultlist);
            TreeNode<T> result = null;
            foreach (TreeNode<T> tn in resultlist)
            {                
                if(tn.value.CompareTo(value) == 0)
                {
                    result =tn;
                }
            }
            if(result != null)
            {
                return ref result.value;
            }
            throw new Exception("Нет значения");
        }
        void NodesToTreeNodeList(TreeNode<T> startNode, ref List<TreeNode<T>> Mainlist)
        {
            Mainlist.Add(startNode);
            if (startNode.left != null)
            {
                NodesToTreeNodeList(startNode.left, ref Mainlist);
            }
            if (startNode.right != null)
            {
                NodesToTreeNodeList(startNode.right, ref Mainlist);
            }
        }
        public void Delete(T value)
        {
            if (root == null)
            {
                return;
            }
            FindToDelete(value, root);
        }
        void FindToDelete(T value, TreeNode<T> now)
        {
            if (now.value.CompareTo(value) == 0)
            {
                DeleteNode(now);
                return;
            }
            if(now.value.CompareTo(value) < 0)
            {
                now = now.right;
            }
            else
            {
                now = now.left;
            }
            if(now != null)
            {
                FindToDelete(value, now);
            }
            
        }
        void DeleteNode(TreeNode<T> node)
        {
            if (node.right == null && node.left == null)
            {
                if (node.parent != null)
                {
                    if (node.parent.right == node) { node.parent.right = null; }
                    else { node.parent.left = null; }
                }
                else { root = null; }
                node.parent = null;
                return;
            }
            if (node.right == null || node.left == null)
            {
                TreeNode<T> child = (node.left == null) ? node.right : node.left;
                if (node.parent.right == node) { node.parent.right = child; }
                else { node.parent.left = child; }
                child.parent = node.parent;
                ClearRef(node);
                return;
            }
            if (node.right.left == null)
            {
                TreeNode<T> child = node.right;
                node.value = child.value;
                if (child.right != null)
                {
                    node.right = child.right;
                    child.right.parent = node;
                    ClearRef(node.right);
                }
                else
                {
                    node.right = null;
                }
            }
            else
            {
                TreeNode<T> rlNode = node.right;
                while (rlNode.left != null)
                {
                    rlNode = rlNode.left;
                }
                node.value = rlNode.value;
                DeleteNode(rlNode);
            }
        }
        void ClearRef(TreeNode<T> node)
        {
            node.parent = null;
            node.left = null;
            node.right = null;
        }
        void CreateNode(T value, TreeNode<T> parent, bool left7)
        {
            TreeNode<T> NewNode = new TreeNode<T>(value);
            NewNode.parent = parent;
            Console.WriteLine(parent.value);
            if (left7)
            {
                parent.left = NewNode;
            }
            else
            {
                parent.right = NewNode;
            }
            
        }
        TreeNode<T> CreateNode(T value, TreeNode<T> parent)
        {
            TreeNode<T> NewNode = new TreeNode<T>(value);
            NewNode.parent = null;
            return NewNode;
        }
    }
}

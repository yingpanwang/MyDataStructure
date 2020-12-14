using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue
{
    class Program
    {
        public static void Main(string[] args) 
        {
           // BuildAndRunQueue();
           // BuildAndRunCircularQueue();

            BuildAndRunBFS();
        }

        /// <summary>
        /// 初始化并运行简单自定义队列
        /// </summary>
        public static void BuildAndRunQueue() 
        {
            MyQueue queue = new MyQueue();
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.EnQueue(3);
            queue.EnQueue(4);
            queue.EnQueue(5);
            queue.EnQueue(6);

            for (int i = 0; i < 8; i++)
            {
                queue.DeQueue();
                if (!queue.IsEmpty())
                {
                    Console.WriteLine(queue.Front());
                }
                else
                {
                    Console.WriteLine("队列为空!");
                }
            }
        }
        
        /// <summary>
        /// 初始化并运行自定义循环队列
        /// </summary>
        public static void BuildAndRunCircularQueue() 
        {

            MyCircularQueue myCircularQueue = new MyCircularQueue(5);

            Console.WriteLine(myCircularQueue.DeQueue());
            Console.WriteLine(myCircularQueue.EnQueue(1));
            Console.WriteLine(myCircularQueue.EnQueue(2));
            Console.WriteLine(myCircularQueue.EnQueue(3));
            Console.WriteLine(myCircularQueue.EnQueue(4));
            Console.WriteLine(myCircularQueue.EnQueue(5));
            Console.WriteLine(myCircularQueue.EnQueue(6));
            Console.WriteLine(myCircularQueue.EnQueue(7));
            Console.WriteLine(myCircularQueue.DeQueue());
            Console.WriteLine(myCircularQueue.EnQueue(10));

        }

        /// <summary>
        /// 初始化并运行广度优先搜索
        /// </summary>
        public static void BuildAndRunBFS() 
        {
            // 定义节点关系

            BFSNode root = new BFSNode(1, null, new BFSNode[] { });

            BFSNode n2 = new BFSNode(2, root, new BFSNode[] { });
            BFSNode n3 = new BFSNode(3, root, new BFSNode[] { });

            BFSNode n4 = new BFSNode(4, n3, new BFSNode[] { });
            BFSNode n5 = new BFSNode(5, n4, new BFSNode[] { });
            BFSNode nk = new BFSNode(10, root, new BFSNode[] { n5 });
            BFSNode n6 = new BFSNode(6, n5, new BFSNode[] { });
            root.Nodes = new BFSNode[] { n2, n3, nk };

            n3.Nodes = new BFSNode[] { n4 };
            n4.Nodes = new BFSNode[] { n5 };
            n5.Nodes = new BFSNode[] { n6 };

            Console.WriteLine(BFS(root, n6));
        }

        /// <summary>
        /// 广度优先搜索
        /// </summary>
        /// <param name="root">起始根节点</param>
        /// <param name="target">目标节点</param>
        /// <returns></returns>
        private static int BFS(BFSNode root, BFSNode target) 
        {
            Queue<BFSNode> queue = new Queue<BFSNode>();
            
            queue.Enqueue(root);
            
            int step = 0;

            // 处理队列节点
            while (queue.Count > 0)
            {
                // 处理路径步骤+1
                step += 1;
                int dealCount = queue.Count;
                // 处理每个节点
                for (int i = 0; i < dealCount; i++)
                {
                    // 获取当前 队列 开始元素
                    var currentNode = queue.Peek();

                    // 如果为目标元素
                    if (currentNode.Equals(target))
                    {
                        // 返回步骤数
                        return step;
                    }

                    // 否则 将 当前节点 下级节点 添加至队列中
                    for (int j = 0; j < currentNode.Nodes.Length; j++)
                    {
                        queue.Enqueue(currentNode.Nodes[j]);
                    }

                    // 当前元素 出列
                    queue.Dequeue(); 
                }
            }
            return -1;
        }

        
    }

    public class BFSNode 
    {
        public BFSNode(int number,BFSNode parent,IEnumerable<BFSNode> nodes) 
        {
            this.Number = number;
            this.Parent = parent;
            this.Nodes = nodes.ToArray();
        }

        public int Number { get; set; }
        public BFSNode Parent { get; set; }
        public BFSNode[] Nodes { get; set; }
    }
}

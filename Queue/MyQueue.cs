using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue
{

    /// <summary>
    /// 队列
    /// </summary>
    public class MyQueue
    {

        /// <summary>
        /// 头部索引
        /// </summary>
        private int Start { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        private List<int> Data { get; set; }


        public MyQueue() 
        {
            Data = new List<int>();
            Start = 0;
        }

        /// <summary>
        /// 入列
        /// </summary>
        /// <param name="item">数据</param>
        /// <returns></returns>
        public bool EnQueue(int item)
        {
            Data.Add(item);
            return true;
        }

        /// <summary>
        /// 出列
        /// </summary>
        /// <returns></returns>
        public bool DeQueue() 
        {
            if (IsEmpty()) 
            {
                return false;
            }

            // 头部后移一位
            Start++;
            return true;
        }

        /// <summary>
        /// 获取头部数据
        /// </summary>
        /// <returns></returns>
        public int Front() 
        {
            return Data[Start];
        }

        public bool IsEmpty() 
        {
            return Data.Count <= Start;
        }
    }
}

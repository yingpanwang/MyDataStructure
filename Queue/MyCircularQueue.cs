using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    /// <summary>
    /// 循环队列
    /// </summary>
    public class MyCircularQueue
    {
        /// <summary>
        /// 队列大小
        /// </summary>
        private int _size;

        /// <summary>
        /// 头部索引
        /// </summary>
        private int _head;

        /// <summary>
        /// 尾部索引
        /// </summary>
        private int _tail;

        /// <summary>
        /// 存储数据
        /// </summary>
        private int[] _data;


        /// <summary>
        /// 构造指定队列长度
        /// </summary>
        /// <param name="size"></param>
        public MyCircularQueue(int size) 
        {
            _size = size;
            _data = new int[size];
            _head = -1;
            _tail = -1;
        }

        /// <summary>
        /// 入列
        /// </summary>
        /// <param name="item">数据</param>
        /// <returns></returns>
        public int EnQueue(int item)
        {
            if (IsFull()) 
            {
                Console.WriteLine("队列已满");
                return -1;
            }
            if (IsEmpty()) 
            {
                // 初始化头部
                _head = 0;
            }

            // 尾部
            _tail = (_tail + 1 ) % _size;
            _data[_tail] = item;

            return item;
        }

        /// <summary>
        /// 出列
        /// </summary>
        /// <returns></returns>
        public int DeQueue()
        {

            // 如果为空
            if (IsEmpty()) 
            {
                return -1;
            }

            int value;

            // 如果 头尾相同 表示 没有数据
            if (_head == _tail)
            {
                value = _head;
                _head = -1;
                _tail = -1;
            }
            else 
            {
                value = _head;

                // 头部 移动 1
                _head = (_head + 1)%_size;
            }

            return _data[value];
        }

        public bool IsEmpty() 
        {
            return _head == -1;
        }
        public bool IsFull() 
        {
            return (_tail+1)%_size == _head;
        }
    }
}

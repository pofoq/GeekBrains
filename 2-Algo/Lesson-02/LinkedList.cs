using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_02
{
    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public class LinkedList : ILinkedList
    {
        public Node FirstNode { get; private set; }
        public Node LastNode { get; private set; }

        public LinkedList()
        { }

        public LinkedList(int value)
        {
            FirstNode = new Node(value);
        }

        // добавляет новый элемент списка
        public void AddNode(int value)
        {
            Node newNode = new Node(value);
            if (FirstNode is null)
                FirstNode = newNode;
            else
            {
                Node node = FirstNode;
                while (node.NextNode != null)
                {
                    node = node.NextNode;
                }
                node.NextNode = newNode;
                newNode.PrevNode = node;
                LastNode = newNode;
            }
        }

        // добавляет новый элемент списка после определённого элемента
        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node(value);
            newNode.NextNode = node.NextNode;
            newNode.PrevNode = node;
            node.NextNode = newNode;

            if (newNode.NextNode is null)
                LastNode = newNode;
            else
                newNode.NextNode.PrevNode = newNode;
        }

        // ищет элемент по его значению
        public Node FindNode(int searchValue)
        {
            if (FirstNode.Value == searchValue)
                return FirstNode;
            var node = FirstNode.NextNode;
            while (node != null)
            {
                if (node.Value == searchValue)
                    break;
                node = node.NextNode;
            }
            return node;
        }

        // возвращает количество элементов в списке
        public int GetCount()
        {
            int count = 0;
            var node = FirstNode;
            while (node != null)
            {
                node = node.NextNode;
                count++;
            }
            return count;
        }

        // удаляет элемент по порядковому номеру
        public void RemoveNode(int index)
        {
            int count = GetCount();
            if (index < 0 || index > count - 1)
                return;

            Node node = FirstNode;
            for (int i = 1; i <= index; i++)
            {
                node = node.NextNode;
            }
            var prev = node.PrevNode;
            var next = node.NextNode;

            if (prev is null)
                FirstNode = next;
            else
                prev.NextNode = next;

            if (next is null)
                LastNode = prev;
            else
                next.PrevNode = prev;
        }

        // удаляет указанный элемент
        public void RemoveNode(Node node)
        {
            var prev = node.PrevNode;
            var next = node.NextNode;
            if (prev is null)
                FirstNode = next;
            else
                prev.NextNode = next;

            if (next is null)
                LastNode = prev;
            else
                next.PrevNode = prev;
        }
    }
}

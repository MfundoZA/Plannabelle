using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.Models
{
    public class DoublyLinkedList<T>
    {
        public Node<T>? Head { get; set; }
        public Node<T>? Tail { get; set; }
        public int Length { get; set; }

        public void addNode(T? data)
        {
            Node<T> newNode = new Node<T>(data);

            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }

            Length++;
        }

        public void deleteFirst()
        {
            if (Length == 0) throw new NullReferenceException("No elment in the list exists to delete!");

            Head = Head.Next;
            Head.Previous = null;
            Length--;
        }

        public void deleteLast()
        {
            if (Length == 0) throw new NullReferenceException("No elment in the list exists to delete!");

            Tail = Tail.Previous;
            Tail.Next = null;
            Length--;
        }

        public bool isEmpty()
        {
            return Length == 0;
        }
    }
}

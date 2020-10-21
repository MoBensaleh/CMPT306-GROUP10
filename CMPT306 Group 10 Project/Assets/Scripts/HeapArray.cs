using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeapArray<T> where T: IState<T>
{
    int cursor;
    T[] states;

    public int Count {
        get {
            return cursor;
        } set {
            Count = value;
        }
    }

    public HeapArray(int len) {
        states = new T[len];
    }

    public bool Contains(T i) {
        return Equals(i, states[i.StateIndex]);
    }

    public void Enqueue(T s) {
        states[cursor] = s;
        s.StateIndex = cursor;

        int higherIndex = (s.StateIndex - 1) / 2;

        while (true) {
            T parent = states[higherIndex];
            if (0 < s.CompareTo(parent)) {
                int temp = s.StateIndex;
                states[s.StateIndex] = parent;
                states[parent.StateIndex] = s;
                s.StateIndex = parent.StateIndex;
                parent.StateIndex = temp;
            } else {
                break;
            }
            higherIndex = (s.StateIndex - 1) / 2;
        }

        cursor += 1;
    }

    public T Dequeue() {
        T state = states[0];
        cursor -= 1;
        states[cursor].StateIndex = 0;
        states[0] = states[cursor];
        T i = states[0];
        while (true) {
            int temp = 0;
            int leftKid = 1 + 2 * i.StateIndex;
            int rightKid = 2 + 2 * i.StateIndex;

            if (cursor > leftKid) {
                temp = leftKid;
                if (cursor > rightKid) {
                    if (0 > states[leftKid].CompareTo(states[rightKid])) temp = rightKid;
                }

                if (0 > i.CompareTo(states[temp])) {
                    T A = states[temp];
                    T B = i;
                    int indexTemp = A.StateIndex;
                    states[A.StateIndex] = B;
                    states[B.StateIndex] = A;
                    A.StateIndex = B.StateIndex;
                    B.StateIndex = indexTemp;
                    }
                 else break;
            } else break;
        }

        return state;
    }

    public void UpdateState(T i) {
        int higherIndex = (i.StateIndex - 1) / 2;

        while (true) {
            T parentItem = states[higherIndex];
            if (0 < i.CompareTo(parentItem)) {
                T A = parentItem;
                T B = i;
                int temp = A.StateIndex;
                states[A.StateIndex] = B;
                states[B.StateIndex] = A;
                A.StateIndex = B.StateIndex;
                B.StateIndex = temp;
            } else break;
            

            higherIndex = (i.StateIndex - 1) / 2;
        }
    }
}
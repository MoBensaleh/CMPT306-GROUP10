using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<T>: IComparable<T> {
    int StateIndex{
        get;
        set;
    }
}
public class State : IState<State>
{
    public bool unblocked;
    public Vector3 location;
    public int xCoordinate, yCoordinate;
    public int gOfN, hOfN;
    public State parent;
    int stateIndex;
    
    public int fOfN {
        get {
            return gOfN + hOfN;
        } set {
            fOfN = value;
        }
    }

    public int StateIndex{
        get {
            return stateIndex;
        } set {
            stateIndex = value;
        }
    }

    public State(bool myUnblocked, Vector3 myLocation, int X, int Y) {
        unblocked = myUnblocked;
        location = myLocation;
        xCoordinate = X;
        yCoordinate = Y;
    }

    public int CompareTo(State otherState) {
        int checkValue = fOfN.CompareTo(otherState.fOfN);
        if (0 == checkValue) {
            checkValue = hOfN.CompareTo(otherState.hOfN);
        }
        checkValue = -checkValue;
        return checkValue;
    }

    public void changeBlocked(bool myUnblocked) {
        unblocked = myUnblocked;
    }
}

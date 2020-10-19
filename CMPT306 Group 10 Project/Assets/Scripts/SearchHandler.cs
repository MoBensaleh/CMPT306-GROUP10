using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchHandler : MonoBehaviour
{
    struct Search {
        public Action< Vector3[], bool > callbackFunction;
        public Vector3 beginning;
        public Vector3 end;

        public Search(Vector3 searchBeginning, Vector3 searchEnding, Action< Vector3[], bool > searchCallbackFunction) {
            callbackFunction = searchCallbackFunction;
            beginning = searchBeginning;
            end = searchEnding;
        }
    }
    bool preoccupied;
    Queue<Search> queue = new Queue<Search>();
    Search immediateSearch;
    AStarSearch aStarSearch;
    static SearchHandler instance;

    void Awake() {
        instance = this;
        aStarSearch = GetComponent<AStarSearch>();
    }
    public static void RequestSearch(Vector3 beginning, Vector3 end, Action< Vector3[], bool > callbackFunction) {
        Search newSearch = new Search(beginning, end, callbackFunction);
        instance.queue.Enqueue(newSearch);
        instance.onToNextSearch();
    }

    void onToNextSearch() {
        if (0 < queue.Count && !preoccupied) {
            preoccupied = true;
            immediateSearch = queue.Dequeue();
            aStarSearch.StartSearch(immediateSearch.beginning, immediateSearch.end);
        }
    }

    public void FinishedPresentSearch(Vector3[] path, bool success) {
        immediateSearch.callbackFunction(path, success);
        preoccupied = false;
        this.onToNextSearch();
    }
}



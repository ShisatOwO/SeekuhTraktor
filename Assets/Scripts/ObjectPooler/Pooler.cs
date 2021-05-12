using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler
{
    private Dictionary<string, DummyPool> _siblingPools;
    private Stack _stack;

    public Pooler()
    {
        _siblingPools = new Dictionary<string, DummyPool>();
        _stack = new Stack();
    }
    
    private class Stack
    {
        private Entry _top;
        private int _size;

        public Stack()
        {
            _top = null;
            _size = 0;
        }
        
        private class Entry
        {
            public GameObject item;
            public Entry next;
        }

        public void Push(GameObject gameObject)
        {
            Entry e = new Entry();
            e.item = gameObject;
            e.next = _top;
            _top = e;
            _size++;
        }

        public GameObject Pop()
        {
            if (_top != null)
            {
                Entry ret = _top;
                _top = ret.next;
                return ret.item;
            }

            return null;
        }

        public GameObject Peek()
        {
            return _top.item;
        }

        public int GetSize()
        {
            return _size;
        }
    }

    public void Add(GameObject gameObject)
    {
        _stack.Push(gameObject);
    }

    public GameObject RequestObj()
    {
        if (_stack.GetSize() != 0) return _stack.Pop();
        else
        {
            foreach (var pair in _siblingPools)
            {
                Pooler pool = pair.Value;
                GameObject gobj = pool.ForceObj();
                if (gobj != null) return gobj;
            }
            return null;
        }
    }

    public GameObject ForceObj()
    {
        if (_stack.GetSize() != 0) return _stack.Pop();
        else return null;
    }
    
    public Pooler GetSiblingPool(string name)
    {
        try {return _siblingPools[name];}
        catch (KeyNotFoundException) {return null;}
    }
    
    // Wenn das klappt hab ich alles ausgetrickst...
    private class DummyPool : Pooler
    {
        public DummyPool(ref Dictionary<string, DummyPool> siblings)
        {
            _siblingPools = siblings;
        }
    }
    public Pooler CreateSiblingPool(string name)
    {
        DummyPool siblingPool = new DummyPool(ref _siblingPools);
        try
        {
            _siblingPools.Add(name, siblingPool);
            return siblingPool;
        }
        catch (ArgumentException)
        {
            Debug.Log("Es Existiert bereits ein Pool mit diesem Namen.");
            return null;
        }
    }
}

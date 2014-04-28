﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace HangFire.Server
{
    internal class ServerComponentRunnerCollection : IServerComponentRunner, ICollection<IServerComponentRunner>
    {
        private readonly List<IServerComponentRunner> _runners;

        public ServerComponentRunnerCollection(IEnumerable<IServerComponentRunner> runners)
        {
            if (runners == null) throw new ArgumentNullException("runners");

            _runners = new List<IServerComponentRunner>(runners);
        }

        public int Count { get { return _runners.Count; } }
        public bool IsReadOnly { get { return false; } }

        public void Start()
        {
            foreach (var runner in _runners)
            {
                runner.Start();
            }
        }

        public void Stop()
        {
            foreach (var runner in _runners)
            {
                runner.Stop();
            }
        }

        public void Dispose()
        {
            Stop();

            foreach (var runner in _runners)
            {
                runner.Dispose();
            }
        }

        public IEnumerator<IServerComponentRunner> GetEnumerator()
        {
            return _runners.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _runners).GetEnumerator();
        }

        public void Add(IServerComponentRunner item)
        {
            _runners.Add(item);
        }

        public void Clear()
        {
            _runners.Clear();
        }

        public bool Contains(IServerComponentRunner item)
        {
            return _runners.Contains(item);
        }

        public void CopyTo(IServerComponentRunner[] array, int arrayIndex)
        {
            _runners.CopyTo(array, arrayIndex);
        }

        public bool Remove(IServerComponentRunner item)
        {
            return _runners.Remove(item);
        }
    }
}
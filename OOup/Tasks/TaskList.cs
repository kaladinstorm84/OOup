using OOup.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    public class TaskList : IDictionary<int, ITask>
    {
        public TaskList(params string [] args)
        {
            Args = args;
        }
        public ITask this[int key] { get => ((IDictionary<int, ITask>)tasks)[key]; set => ((IDictionary<int, ITask>)tasks)[key] = value; }

        public Dictionary<int, ITask> tasks { get; set; } = new Dictionary<int, ITask>();

        public ICollection<int> Keys => ((IDictionary<int, ITask>)tasks).Keys;

        public ICollection<ITask> Values => ((IDictionary<int, ITask>)tasks).Values;

        public int Count => ((ICollection<KeyValuePair<int, ITask>>)tasks).Count;

        public bool IsReadOnly => ((ICollection<KeyValuePair<int, ITask>>)tasks).IsReadOnly;

        public string[] Args { get; }

        public void Add(int key, ITask value)
        {
            ((IDictionary<int, ITask>)tasks).Add(key, value);
        }
        public void Add(ITask value)
        {
            ((IDictionary<int, ITask>)tasks).Add(tasks.Count+1, value);
        }

        public void Add(KeyValuePair<int, ITask> item)
        {
            ((ICollection<KeyValuePair<int, ITask>>)tasks).Add(item);
        }

        public void Clear()
        {
            ((ICollection<KeyValuePair<int, ITask>>)tasks).Clear();
        }

        public bool Contains(KeyValuePair<int, ITask> item)
        {
            return ((ICollection<KeyValuePair<int, ITask>>)tasks).Contains(item);
        }

        public bool ContainsKey(int key)
        {
            return ((IDictionary<int, ITask>)tasks).ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<int, ITask>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<int, ITask>>)tasks).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<int, ITask>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<int, ITask>>)tasks).GetEnumerator();
        }

        public bool Remove(int key)
        {
            return ((IDictionary<int, ITask>)tasks).Remove(key);
        }

        public bool Remove(KeyValuePair<int, ITask> item)
        {
            return ((ICollection<KeyValuePair<int, ITask>>)tasks).Remove(item);
        }

        public bool TryGetValue(int key, [MaybeNullWhen(false)] out ITask value)
        {
            return ((IDictionary<int, ITask>)tasks).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)tasks).GetEnumerator();
        }
    }
}

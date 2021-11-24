using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace OOup.Library
{
    public class Variables : IDictionary<string, string>
    {
        public string this[string key] { get => ((IDictionary<string, string>)VariableList)[key]; set => ((IDictionary<string, string>)VariableList)[key] = value; }

        public Dictionary<string, string> VariableList { get; set; }  = new Dictionary<string, string>();

        public ICollection<string> Keys => ((IDictionary<string, string>)VariableList).Keys;

        public ICollection<string> Values => ((IDictionary<string, string>)VariableList).Values;

        public int Count => ((ICollection<KeyValuePair<string, string>>)VariableList).Count;

        public bool IsReadOnly => ((ICollection<KeyValuePair<string, string>>)VariableList).IsReadOnly;

        public void Add(string key, string value)
        {
            if (ContainsKey(key))
            {
                this[key] = value;
            }
            else
            {
                ((IDictionary<string, string>)VariableList).Add(key, value);
            }
        }

        public void Add(KeyValuePair<string, string> item)
        {
            ((ICollection<KeyValuePair<string, string>>)VariableList).Add(item);
        }

        public void Clear()
        {
            ((ICollection<KeyValuePair<string, string>>)VariableList).Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return ((ICollection<KeyValuePair<string, string>>)VariableList).Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return ((IDictionary<string, string>)VariableList).ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, string>>)VariableList).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, string>>)VariableList).GetEnumerator();
        }

        public bool Remove(string key)
        {
            return ((IDictionary<string, string>)VariableList).Remove(key);
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return ((ICollection<KeyValuePair<string, string>>)VariableList).Remove(item);
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
        {
            return ((IDictionary<string, string>)VariableList).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)VariableList).GetEnumerator();
        }
    }
}

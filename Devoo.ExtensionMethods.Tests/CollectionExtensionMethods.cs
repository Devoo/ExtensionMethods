using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Collections;
using NFluent;

namespace DevooTesting
{
    public class CollectionExtensionMethods
    {
        public IEnumerable<string> IEnumerableFactory
        {
            get
            {
                yield return "Hola";
                yield return "Chau";
            }
        }


        //[Factory(typeof(Dictionary<int, string>), "DictionaryFactory")]
        public Dictionary<int, string> DictionaryFactory
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    {1, "Hola"}, 
                    {2, "Chau"}
                };
            }
        }

        //[Factory(typeof(Hashtable), "HashTableFactory")]
        public Hashtable HashTableFactory
        {
            get
            {
                return new Hashtable()
                {
                    {1, "Hola"},
                    {2, "Chau"}
                };
            }
        }

        [Test]
        public void ToDictionary()
        {
            var diccionario = this.HashTableFactory.ToDictionary<int, string>();
            foreach (var valor in diccionario)
            {
                Assert.IsTrue(DictionaryFactory.ContainsKey(valor.Key));
                Assert.AreSame(valor.Value, DictionaryFactory[valor.Key]);
            }
        }

        [Test]
        public void Set()
        {
            var diccionario = DictionaryFactory;
            diccionario.Set(1, "Chau");
            diccionario.Set(2, "Hola");
            diccionario.Set(3, "Hola mundo");

            Assert.IsTrue(diccionario.ContainsKey(1));
            Assert.AreSame("Chau", diccionario[1]);

            Assert.IsTrue(diccionario.ContainsKey(2));
            Assert.AreSame("Hola", diccionario[2]);

            Assert.IsTrue(diccionario.ContainsKey(3));
            Assert.AreSame("Hola mundo", diccionario[3]);

        }

        [Test]
        public void JoinToString()
        {
            Assert.AreEqual("Hola,Chau", IEnumerableFactory.JoinToString());
            Assert.AreEqual("Hola|Chau", IEnumerableFactory.JoinToString("|"));
        }

    }
}

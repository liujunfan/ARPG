using System;
using System.Linq;
using UnityEngine;
using Nino.Serialization;
using System.Collections.Generic;


namespace Nino
{
    [NinoSerialize()]
    public partial struct MyStruct
    {
        [NinoMember(0)] public int a;
        [NinoMember(1)] public List<int> b;
    }
    [NinoSerialize()]
    public partial class CollectionTest
    {
        [NinoMember(0)] public List<int> a = new List<int>();
        [NinoMember(1)] public List<string> b = new List<string>();
        [NinoMember(2)] public Dictionary<int, bool> c = new Dictionary<int, bool>();
        [NinoMember(3)] public Dictionary<string, bool> d = new Dictionary<string, bool>();
        [NinoMember(4)] public Dictionary<byte, string> e = new Dictionary<byte, string>();
    }
    
    [NinoSerialize]
    public partial class ComplexData
    {
        [NinoMember(0)]
        public int[][] a;
        [NinoMember(1)]
        public List<int[]> b;
        [NinoMember(2)]
        public List<int>[] c;
        [NinoMember(3)]
        public Dictionary<string,Dictionary<string, int>> d;
        [NinoMember(4)]
        public Dictionary<string,Dictionary<string, int[][]>>[] e;
        [NinoMember(5)] 
        public Data[][] f;
        [NinoMember(6)]
        public List<Data[]> g;
        [NinoMember(7)]
        public Data[][][] h;
        [NinoMember(8)]
        public List<Data>[] i;
        [NinoMember(9)]
        public List<Data[]>[] j;
        public override string ToString()
        {
            return $"{string.Join(",", a.SelectMany(x => x).ToArray())},\n" +
                   $"{string.Join(",", b.SelectMany(x => x).ToArray())},\n" +
                   $"{string.Join(",", c.SelectMany(x => x).ToArray())},\n" +
                   $"{GetDictString(d)},\n" +
                   $"{string.Join(",\n", e.Select(GetDictString).ToArray())}\n" +
                   $"{string.Join(",\n", f.SelectMany(x => x).Select(x => x))}\n" +
                   $"{string.Join(",\n", g.SelectMany(x => x).Select(x => x))}\n" +
                   $"{string.Join(",\n", h.SelectMany(x => x).SelectMany(x => x).Select(x => x))}\n" +
                   $"{string.Join(",\n", i.SelectMany(x => x).Select(x => x))}\n" +
                   $"{string.Join(",\n", j.SelectMany(x => x).Select(x => x).SelectMany(x => x).Select(x => x))}\n";
        }

        private string GetDictString<K,V>(Dictionary<K,Dictionary<K,V>> ddd)
        {
            return $"{string.Join(",", ddd.Keys.ToList())},\n" +
                $"   {string.Join(",", ddd.Values.ToList().SelectMany(k=>k.Keys))},\n" +
                $"   {string.Join(",", ddd.Values.ToList().SelectMany(k=>k.Values))}";
        }
    }
    
    [NinoSerialize]
    public partial class CustomTypeTest
    {
        [NinoMember(1)] public Vector3 v3;

        [NinoMember(2)] private DateTime dt = DateTime.Now;

        [NinoMember(3)] public int? ni { get; set; }

        [NinoMember(4)] public List<Quaternion> qs;

        [NinoMember(5)] public Matrix4x4 m;

        [NinoMember(6)] public Dictionary<string, int> dict;

        [NinoMember(7)] public Dictionary<string, Data> dict2;

        public override string ToString()
        {
            return
                $"{v3}, {dt}, {ni}, {String.Join(",", qs)}, {m.ToString()}\n" +
                $"dict.keys: {string.Join(",", dict.Keys)},\ndict.values:{string.Join(",", dict.Values)}\n" +
                $"dict2.keys: {string.Join(",", dict2.Keys)},\ndict2.values:{string.Join(",", dict2.Values)}\n";
        }
    }
    [NinoSerialize(true)]
    [CodeGenIgnore]
    public partial class IncludeAllClass
    {
        public int a;
        public long b;
        public float c;
        public double d;

        public override string ToString()
        {
            return $"{a}, {b}, {c}, {d}";
        }
    }
    [Serializable]
    [NinoSerialize]
    public partial class NotIncludeAllClass
    {
        [NinoMember(0)]
        public int a;

        [NinoMember(1)]
        public long b;

        [NinoMember(2)]
        public float c;

        [NinoMember(3)]
        public double d;

        public override string ToString()
        {
            return $"{a}, {b}, {c}, {d}";
        }
    }
    [NinoSerialize(true)]
    public partial class IncludeAllClassCodeGen
    {
        public int a;
        public long b;
        public float c;
        public double d;

        public override string ToString()
        {
            return $"{a}, {b}, {c}, {d}";
        }
    }
    [Serializable]
    [NinoSerialize]
    public partial class Data
    {
        [NinoMember(1)]
        public int x;

        [NinoMember(2)]
        public short y;

        [NinoMember(3)]
        public long z;

        [NinoMember(4)]
        public float f;

        [NinoMember(5)]
        public decimal d;

        [NinoMember(6)]
        public double db;

        [NinoMember(7)]
        public bool bo;

        [NinoMember(8)]
        public TestEnum en;

        [NinoMember(9)]
        public string name = "";

        public override string ToString()
        {
            return $"{x},{y},{z},{f},{d},{db},{bo},{en},{name}";
        }
    }

    [Serializable]
    public enum TestEnum : byte
    {
        A = 1,
        B = 2
    }
}
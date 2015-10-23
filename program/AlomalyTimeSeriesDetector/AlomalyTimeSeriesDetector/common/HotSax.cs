using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlomalyTimeSeriesDetector.common
{
    class HotSax
    {
        private HotSaxStructure dataStruc = new HotSaxStructure();
        private double b1 = 0, b2 = 0, b3 = 0, b4 = 0, b5 = 0, b6 = 0, b7 = 0, b8 = 0, b9 = 0;

        public int run(double[] data, int paaLength, int subsequeceLength, int breakpoint) 
        {
            initBreakpoint(breakpoint);
            List<double[]> candiates = slidingWindow(data, subsequeceLength);
            for (int index = 0; index < candiates.Count; index++ )
            {
                double[] candiate = candiates.ElementAt(index);
                string[] sax = getSAXString(candiate, paaLength, breakpoint);
                this.dataStruc.insert(sax);
            }
            int anomalIndex = 0;
            return anomalIndex;
        }
        private List<double[]> slidingWindow(double[] data, int subsequenceLength) {
            List<double[]> ret = new List<double[]>();
            int length = data.Length;
            for (int i = 0; (i + subsequenceLength) <= length; i++) {
                double[] temp = new double[subsequenceLength];
                int k = 0;
                for (int j = i; j < i + subsequenceLength; j++) {
                    temp[k] = data[j];
                    k++;
                }
                ret.Add(temp);
            }
            return ret;
        }

        private string[] getSAXString(double[] data, int paaLength, int breakpoint) {
            String[] ret = null;
            double[] arr_paa = PAA.run(data, paaLength);
            ret = SAX(breakpoint, arr_paa);
            return ret;
        }

        private string[] SAX(int x, double[] D)
        {
            string[] E = new string[D.Length];
            if (x == 3)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                    {
                        E[i] = "a";
                    }
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E[i] = "b";
                    }
                    else
                    {
                        E[i] = "c";
                    }
                }
            }
            else if (x == 4)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                    {
                        E[i] = "a";
                    }
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E[i] = "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E[i] = "c";
                    }
                    else
                    {
                        E[i] = "d";
                    }
                }
            }
            else if (x == 5)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                    {
                        E[i] = "a";
                    }
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E[i] = "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E[i] = "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E[i] = "d";
                    }
                    else
                    {
                        E[i] = "e";
                    }
                }
            }
            else if (x == 6)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                    {
                        E[i] = "a";
                    }
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E[i] = "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E[i] = "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E[i] = "d";
                    }
                    else if ((b4 < D[i]) && (D[i] <= b5))
                    {
                        E[i] = "e";
                    }
                    else
                    {
                        E[i] = "f";
                    }
                }
            }
            else if (x == 7)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                    {
                        E[i] = "a";
                    }
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E[i] = "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E[i] = "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E[i] = "d";
                    }
                    else if ((b4 < D[i]) && (D[i] <= b5))
                    {
                        E[i] = "e";
                    }
                    else if ((b5 < D[i]) && (D[i] <= b6))
                    {
                        E[i] = "f";
                    }
                    else
                    {
                        E[i] = "g";
                    }
                }
            }
            else if (x == 8)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                    {
                        E[i] = "a";
                    }
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E[i] = "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E[i] = "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E[i] = "d";
                    }
                    else if ((b4 < D[i]) && (D[i] <= b5))
                    {
                        E[i] = "e";
                    }
                    else if ((b5 < D[i]) && (D[i] <= b6))
                    {
                        E[i] = "f";
                    }
                    else if ((b6 < D[i]) && (D[i] <= b7))
                    {
                        E[i] = "g";
                    }
                    else
                    {
                        E[i] = "h";
                    }
                }
            }
            else if (x == 9)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                    {
                        E[i] = "a";
                    }
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E[i] = "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E[i] = "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E[i] = "d";
                    }
                    else if ((b4 < D[i]) && (D[i] <= b5))
                    {
                        E[i] = "e";
                    }
                    else if ((b5 < D[i]) && (D[i] <= b6))
                    {
                        E[i] = "f";
                    }
                    else if ((b6 < D[i]) && (D[i] <= b7))
                    {
                        E[i] = "g";
                    }
                    else if ((b7 < D[i]) && (D[i] <= b8))
                    {
                        E[i] = "h";
                    }
                    else
                    {
                        E[i] = "i";
                    }
                }
            }
            else
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                    {
                        E[i] = "a";
                    }
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E[i] = "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E[i] = "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E[i] = "d";
                    }
                    else if ((b4 < D[i]) && (D[i] <= b5))
                    {
                        E[i] = "e";
                    }
                    else if ((b5 < D[i]) && (D[i] <= b6))
                    {
                        E[i] = "f";
                    }
                    else if ((b6 < D[i]) && (D[i] <= b7))
                    {
                        E[i] = "g";
                    }
                    else if ((b7 < D[i]) && (D[i] <= b8))
                    {
                        E[i] = "h";
                    }
                    else if ((b8 < D[i]) && (D[i] <= b9))
                    {
                        E[i] = "i";
                    }
                    else
                    {
                        E[i] = "j";
                    }
                }
            }
            return E;
        }

        private void initBreakpoint(int x)
        {
            if (x == 3)
            {
                b1 = -0.43;
                b2 = 0.43;
            }
            else if (x == 4)
            {
                b1 = -0.67;
                b2 = 0;
                b3 = 0.67;
            }
            else if (x == 5)
            {
                b1 = -0.84;
                b2 = -0.25;
                b3 = 0.25;
                b4 = 0.84;
            }
            else if (x == 6)
            {
                b1 = -0.97;
                b2 = -0.43;
                b3 = 0;
                b4 = 0.43;
                b5 = 0.97;
            }
            else if (x == 7)
            {
                b1 = -1.07;
                b2 = -0.57;
                b3 = -0.18;
                b4 = 0.18;
                b5 = 0.57;
                b6 = 1.07;
            }
            else if (x == 8)
            {
                b1 = -1.15;
                b2 = -0.67;
                b3 = -0.32;
                b4 = 0;
                b5 = 0.32;
                b6 = 0.67;
                b7 = 1.15;
            }
            else if (x == 9)
            {
                b1 = -1.22;
                b2 = -0.76;
                b3 = -0.43;
                b4 = -0.14;
                b5 = 0.14;
                b6 = 0.43;
                b7 = 0.76;
                b8 = 1.22;
            }
            else
            {
                b1 = -1.28;
                b2 = -0.84;
                b3 = -0.52;
                b4 = -0.25;
                b5 = 0;
                b6 = 0.25;
                b7 = 0.52;
                b8 = 0.84;
                b9 = 1.28;
            }
        }

        private class HotSaxStructure
        {
            private List<SaxArrayEntry> array = new List<SaxArrayEntry>();
            private List<SaxTrieNode> trie = new List<SaxTrieNode>();

            public void insert(string[] sax)
            {
                int index = insertToArray(sax);
                List<int> indexs = insertToTrie(sax, index);
                if (indexs == null)
                {
                    Console.WriteLine("Error in insert HotSaxStructure: " + sax);
                }
                updateArray(indexs);
            }
            private void updateArray(List<int> indexs)
            {
                int size = indexs.Count;
                foreach (int i in indexs)
                {
                    SaxArrayEntry entry = this.array.ElementAt(i);
                    entry.num = size;
                    this.array[i] = entry;
                }
            }
            private List<int> insertToTrie(string[] sax, int index)
            {
                bool havedata = false;
                string orig = "";
                foreach (string c in sax)
                {
                    orig += c;
                }
                foreach (SaxTrieNode node in trie)
                {
                    if (node != null && node.value != null)
                    {
                        string tmp1 = "";
                        foreach (string s in node.value)
                        {
                            tmp1 += s;
                        }
                        if (orig.Equals(tmp1))
                        {
                            havedata = true;
                            node.indexs.Add(index);
                            return node.indexs;
                        }
                    }
                }
                if (!havedata)
                {
                    SaxTrieNode c = new SaxTrieNode();
                    c.value = new string[sax.Length];
                    for (int i = 0; i < sax.Length; i++)
                    {
                        c.value[i] = sax[i];
                    }
                    c.indexs = new List<int>();
                    c.indexs.Add(index);
                    this.trie.Add(c);
                    return c.indexs;
                }
                return null;
            }
            public List<int> getIndexs(string[] sax)
            {
                string orig = "";
                foreach (string c in sax)
                {
                    orig += c;
                }
                foreach (SaxTrieNode node in trie)
                {
                    if (node != null && node.value != null)
                    {
                        string tmp1 = "";
                        foreach (string s in node.value)
                        {
                            tmp1 += s;
                        }
                        if (orig.Equals(tmp1))
                        {
                            return node.indexs;
                        }
                    }
                }
                return null;
            }
            public List<int> getMaxMatch(string[] sax)
            {
                int numMach = int.MinValue;
                SaxTrieNode c = null;
                foreach (SaxTrieNode node in trie)
                {
                    if (node != null && node.value != null)
                    {
                        int num = 0;
                        for (int i = 0; i < node.value.Length; i++)
                        {
                            if (sax[i].Equals(node.value[i]))
                            {
                                num++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (num > numMach)
                        {
                            numMach = num;
                            c = node;
                        }
                    }
                }
                if (c != null)
                {
                    return c.indexs;
                }
                return null;
            }
            public int getMaxCount()
            {
                int max = int.MinValue;
                int index = 0;
                for (int i = 0; i < array.Count; i++)
                {
                    SaxArrayEntry entry = array.ElementAt(i);
                    if (entry != null && entry.num > max)
                    {
                        max = entry.num;
                        index = i;
                    }
                }
                return index;
            }

            private int insertToArray(string[] sax)
            {
                SaxArrayEntry entry = new SaxArrayEntry();
                entry.saxString = new string[sax.Length];
                for (int i = 0; i < sax.Length; i++)
                {
                    entry.saxString[i] = sax[i];
                }
                entry.num = 1;
                this.array.Add(entry);
                return this.array.Count - 1;
            }
        }

        private class SaxArrayEntry
        {
            public string[] saxString;
            public int num;
        }

        private class SaxTrieNode
        {
            public string[] value;
            public List<int> indexs;
        }
    }
}
